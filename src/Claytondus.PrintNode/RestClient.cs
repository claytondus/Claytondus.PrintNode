using System;
using System.Threading;
using System.Threading.Tasks;
using Claytondus.PrintNode.Models;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Claytondus.PrintNode
{
    public class RestClient
    {
	    protected readonly string PrintNodeUrl = "https://api.printnode.com/";
	    private readonly string _authToken;
	    private readonly ILogger? _logger;

		public RestClient(string authToken, ILogger? logger = null)
		{
			_authToken = authToken;
			_logger = logger;
		}

	    protected async Task<T> GetAsync<T>(string resource,
		    object? queryParams = null,
		    CancellationToken cancellationToken = new()) where T : class
	    {
		    try
		    {
			    var request = PrintNodeUrl
				    .AppendPathSegment(resource)
				    .SetQueryParams(queryParams)
				    .WithDefaults()
				    .WithBasicAuth(_authToken, String.Empty);

			    var response = await request.GetAsync(cancellationToken);
			    _logger?.LogTrace(response.ResponseMessage.RequestMessage.ToString());

			    var responseBody = await response.GetStringAsync();
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
			    throw new PrintNodeException("error", ex.Message)
			    {
			        Method = "GET",
			        Resource = resource,
			        HttpStatus = ex.Call.HttpResponseMessage.StatusCode,
			        ResponseBody = ex.Call.HttpResponseMessage.Content.ToString()
			    };
			}
		}

		protected async Task<T> PostAsync<T>(string resource, object body, CancellationToken cancellationToken = new())
	    {
            try
			{
				var response = await PrintNodeUrl
                    .AppendPathSegment(resource)
					.WithDefaults()
			        .WithBasicAuth(_authToken, string.Empty)
			        .PostJsonAsync(body, cancellationToken);
                _logger?.LogTrace(response.ResponseMessage.RequestMessage.ToString());
                var responseBody = await response.GetStringAsync();
                _logger?.LogTrace("Response: {responseBody}", responseBody);
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
			    throw new PrintNodeException("error", ex.Message)
			    {
			        Method = "POST",
			        Resource = resource,
			        HttpStatus = ex.Call.HttpResponseMessage.StatusCode,
			        HttpMessage = ex.Message,
			        RequestBody = ex.Call.RequestBody,
			        ResponseBody = ex.Call.HttpResponseMessage.Content.ToString()
			    };
			}

	    }

		protected async Task<T> PutAsync<T>(string resource, object? body = null, CancellationToken cancellationToken = new())
		{
            _logger?.LogTrace("PUT {0}", resource);
		    try
		    {
		        var response = await PrintNodeUrl
		            .AppendPathSegment(resource)
		            .WithDefaults()
		            .WithOAuthBearerToken(_authToken)
		            .PutJsonAsync(body, cancellationToken)
		            .ReceiveJson<T>();
		        return response;
		    }
		    catch (FlurlHttpTimeoutException)
		    {
		        throw new PrintNodeException("timeout", "Request timed out.");
		    }
		    catch (FlurlHttpException ex)
		    {
		        throw new PrintNodeException("error", ex.Message)
		        {
		            Method = "PUT",
		            Resource = resource,
		            HttpStatus = ex.Call.HttpResponseMessage.StatusCode,
		            HttpMessage = ex.Message,
		            RequestBody = ex.Call.RequestBody
		        };
		    }
		}

        protected async Task DeleteAsync(string resource, object? queryParams = null, CancellationToken cancellationToken = new())
        {
            _logger?.LogTrace("DELETE {0}", resource);
            try
            {
                await PrintNodeUrl
                    .AppendPathSegment(resource)
                    .SetQueryParams(queryParams)
                    .WithDefaults()
                    .WithOAuthBearerToken(_authToken)
                    .DeleteAsync(cancellationToken);
            }
            catch (FlurlHttpTimeoutException)
            {
                throw new PrintNodeException("timeout", "Request timed out.");
            }
            catch (FlurlHttpException ex)
            {
                throw new PrintNodeException("error", ex.Message)
                {
                    Method = "DELETE",
                    Resource = resource,
                    HttpStatus = ex.Call.HttpResponseMessage.StatusCode,
                    HttpMessage = ex.Message
                };
            }
        }

        protected async Task<T> DeleteAsync<T>(string resource, object? queryParams = null, CancellationToken cancellationToken = new())
		{
            _logger?.LogTrace("DELETE {0}", resource);
            try
            {
                var response = await PrintNodeUrl
                    .AppendPathSegment(resource)
                    .SetQueryParams(queryParams)
                    .WithDefaults()
                    .WithOAuthBearerToken(_authToken)
                    .DeleteAsync(cancellationToken)
                    .ReceiveJson<T>();
                return response;
            }
			catch (FlurlHttpTimeoutException)
			{
				throw new PrintNodeException("timeout", "Request timed out.");
			}
			catch (FlurlHttpException ex)
			{
                var response = await ex.GetResponseStringAsync();
			    throw new PrintNodeException("error", ex.Message)
			    {
			        Method = "DELETE",
			        Resource = resource,
			        HttpStatus = ex.Call.HttpResponseMessage.StatusCode,
			        HttpMessage = ex.Message
			    };
			}
        }
	}

	public static class UrlExtension
	{
		public static IFlurlRequest WithDefaults(this Url url)
		{
			return url
				.WithTimeout(10)
				.WithHeader("Accept", "application/json");
		}
	}
}
