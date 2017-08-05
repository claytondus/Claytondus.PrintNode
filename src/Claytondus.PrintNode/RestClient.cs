using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Claytondus.PrintNode.Logging;
using Claytondus.PrintNode.Models;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace Claytondus.PrintNode
{
    public class RestClient
    {
	    protected readonly string PrintNodeUrl = "https://api.printnode.com/";
	    private readonly string _authToken;
        private static readonly ILog Log = LogProvider.For<RestClient>();

        public RestClient()
		{
		}

		public RestClient(string authToken)
		{
			_authToken = authToken;
		}

	    protected async Task<T> GetAsync<T>(string resource, object queryParams = null) where T : class
	    {
		    try
		    {
			    var response = await new Url(PrintNodeUrl)
				    .AppendPathSegment(resource)
				    .SetQueryParams(queryParams)
				    .WithDefaults()
				    .WithBasicAuth(_authToken, String.Empty)
					.GetAsync();
                Log.Trace(response.RequestMessage.ToString);
			    var responseBody = await response.Content.ReadAsStringAsync();
				var settings = new JsonSerializerSettings
				{
					Error = (sender, args) =>
					{
						if (System.Diagnostics.Debugger.IsAttached)
						{
							System.Diagnostics.Debugger.Break();
						}
					}
				};
			    var responseDeserialized = JsonConvert.DeserializeObject<T>(responseBody, settings);
			    return responseDeserialized;
		    }
			catch (FlurlHttpTimeoutException)
			{
				throw new PrintNodeException("timeout", "Request timed out.");
			}
			catch (FlurlHttpException ex)
			{
			    var response = ex.Call.ErrorResponseBody;
			    throw new PrintNodeException("error", response)
			    {
			        Method = "GET",
			        Resource = resource,
			        HttpStatus = ex.Call.HttpStatus
			    };
			}
		}

		protected async Task<T> PostAsync<T>(string resource, object body)
	    {
            try
			{
				var response = await new Url(PrintNodeUrl)
                    .AppendPathSegment(resource)
					.WithDefaults()
			        .WithBasicAuth(_authToken, string.Empty)
			        .PostJsonAsync(body);
                Log.Trace(response.RequestMessage.ToString());
                var responseBody = await response.Content.ReadAsStringAsync();
                Log.Trace("Response: " + responseBody);
                var settings = new JsonSerializerSettings
                {
                    Error = (sender, args) =>
                    {
                        if (System.Diagnostics.Debugger.IsAttached)
                        {
                            System.Diagnostics.Debugger.Break();
                        }
                    }
                };
                var responseDeserialized = JsonConvert.DeserializeObject<T>(responseBody, settings);
                return responseDeserialized;
            }
			catch (FlurlHttpTimeoutException)
			{
				throw new PrintNodeException("timeout", "Request timed out.");
			}
			catch (FlurlHttpException ex)
			{
                var response = ex.Call.ErrorResponseBody;
			    throw new PrintNodeException("error", response)
			    {
			        Method = "POST",
			        Resource = resource,
			        HttpStatus = ex.Call.HttpStatus,
			        HttpMessage = ex.Message,
			        RequestBody = ex.Call.RequestBody
			    };
			}
			
	    }

		protected async Task<T> PutAsync<T>(string resource, object body = null)
		{
            Log.Trace("PUT " + resource);
		    try
		    {
		        var response = await new Url(PrintNodeUrl)
		            .AppendPathSegment(resource)
		            .WithDefaults()
		            .WithOAuthBearerToken(_authToken)
		            .PutJsonAsync(body)
		            .ReceiveJson<T>();
		        return response;
		    }
		    catch (FlurlHttpTimeoutException)
		    {
		        throw new PrintNodeException("timeout", "Request timed out.");
		    }
		    catch (FlurlHttpException ex)
		    {
		        var response = ex.Call.ErrorResponseBody;
		        throw new PrintNodeException("error", response)
		        {
		            Method = "PUT",
		            Resource = resource,
		            HttpStatus = ex.Call.HttpStatus,
		            HttpMessage = ex.Message,
		            RequestBody = ex.Call.RequestBody
		        };
		    }
		}

        protected async Task DeleteAsync(string resource, object queryParams = null)
        {
            Log.Trace("DELETE " + resource);
            try
            {
                await new Url(PrintNodeUrl)
                    .AppendPathSegment(resource)
                    .SetQueryParams(queryParams)
                    .WithDefaults()
                    .WithOAuthBearerToken(_authToken)
                    .DeleteAsync();
            }
            catch (FlurlHttpTimeoutException)
            {
                throw new PrintNodeException("timeout", "Request timed out.");
            }
            catch (FlurlHttpException ex)
            {
                var response = ex.Call.ErrorResponseBody;
                throw new PrintNodeException("error", response)
                {
                    Method = "DELETE",
                    Resource = resource,
                    HttpStatus = ex.Call.HttpStatus,
                    HttpMessage = ex.Message
                };
            }
        }

        protected async Task<T> DeleteAsync<T>(string resource, object queryParams = null)
		{
            Log.Trace("DELETE " + resource);
            try
            {
                var response = await new Url(PrintNodeUrl)
                    .AppendPathSegment(resource)
                    .SetQueryParams(queryParams)
                    .WithDefaults()
                    .WithOAuthBearerToken(_authToken)
                    .DeleteAsync()
                    .ReceiveJson<T>();
                return response;
            }
			catch (FlurlHttpTimeoutException)
			{
				throw new PrintNodeException("timeout", "Request timed out.");
			}
			catch (FlurlHttpException ex)
			{
                var response = ex.Call.ErrorResponseBody;
			    throw new PrintNodeException("error", response)
			    {
			        Method = "DELETE",
			        Resource = resource,
			        HttpStatus = ex.Call.HttpStatus,
			        HttpMessage = ex.Message
			    };
			}
        }
	}

	public static class UrlExtension
	{
		public static IFlurlClient WithDefaults(this Url url)
		{
			return url
				.WithTimeout(10)
				.WithHeader("Accept", "application/json");
		}
	}
}
