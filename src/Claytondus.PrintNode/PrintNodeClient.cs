using System.Collections.Generic;
using System.Threading.Tasks;
using Claytondus.PrintNode.Models;
using Microsoft.Extensions.Logging;

namespace Claytondus.PrintNode
{
	/// <summary>
	/// PrintNode client. See docs at https://www.printnode.com/en/docs/api/curl
	/// </summary>
	public class PrintNodeClient : RestClient
	{
		/// <summary>
		/// Instantiates the PrintNode API client.
		/// </summary>
		/// <param name="authToken">API Key from printnode.com</param>
		/// <param name="logger">Optional ILogger instance.  Logs requests/responses at Trace level.</param>
		public PrintNodeClient(string authToken, ILogger? logger = null) : base(authToken, logger)
		{
		}

		/// <summary>
		/// Retrieves API status.
		/// </summary>
		/// <returns></returns>
	    public async Task<WhoAmI> GetWhoAmIAsync()
	    {
	        const string resource = "/whoami";
	        return await GetAsync<WhoAmI>(resource);
	    }

		/// <summary>
		/// Retrieves submitted print jobs.
		/// </summary>
		/// <returns></returns>
	    public async Task<IEnumerable<PrintJob>> GetPrintJobsAsync()
	    {
	        const string resource = "/printjobs";
	        return await GetAsync<List<PrintJob>>(resource);
	    }

		/// <summary>
		/// Creates a new print job.
		/// </summary>
		/// <param name="job"></param>
		/// <returns></returns>
	    public async Task<ulong> CreatePrintJobAsync(PrintJob job)
	    {
	        const string resource = "/printjobs";
	        return await PostAsync<ulong>(resource, job);
	    }

		/// <summary>
		/// Retrieves associated printers and capabilities.
		/// </summary>
		/// <returns></returns>
	    public async Task<IEnumerable<Printer>> GetPrintersAsync()
	    {
	        const string resource = "/printers";
	        return await GetAsync<List<Printer>>(resource);
	    }

		/// <summary>
		/// Retrieves computers associated with this account.
		/// </summary>
		/// <returns></returns>
	    public async Task<IEnumerable<Computer>> GetComputersAsync()
	    {
	        const string resource = "/computers";
	        return await GetAsync<List<Computer>>(resource);
	    }

		/// <summary>
		/// Retrieves scales associated with this account.
		/// </summary>
		/// <param name="id">Scale ID</param>
		/// <returns></returns>
	    public async Task<IEnumerable<Scale>> GetScalesAsync(int id)
	    {
	        var resource = $"/computers/{id}/scales";
	        return await GetAsync<List<Scale>>(resource);
	    }

    }
}
