using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Claytondus.PrintNode.Models;

namespace Claytondus.PrintNode
{

	public class PrintNodeClient : RestClient
	{
		public PrintNodeClient(string authToken) : base(authToken)
		{
		}

	    public async Task<WhoAmI> GetWhoAmIAsync()
	    {
	        const string resource = "/whoami";
	        return await GetAsync<WhoAmI>(resource);
	    }

	    public async Task<IEnumerable<PrintJob>> GetPrintJobsAsync()
	    {
	        const string resource = "/printjobs";
	        return await GetAsync<List<PrintJob>>(resource);
	    }

	    public async Task<int> CreatePrintJobAsync(PrintJob job)
	    {
	        const string resource = "/printjobs";
	        return await PostAsync<int>(resource, job);
	    }

	    public async Task<IEnumerable<Printer>> GetPrintersAsync()
	    {
	        const string resource = "/printers";
	        return await GetAsync<List<Printer>>(resource);
	    }

	    public async Task<IEnumerable<Computer>> GetComputersAsync()
	    {
	        const string resource = "/computers";
	        return await GetAsync<List<Computer>>(resource);
	    }

	    public async Task<IEnumerable<Scale>> GetScalesAsync(int id)
	    {
	        var resource = $"/computers/{id}/scales";
	        return await GetAsync<List<Scale>>(resource);
	    }

    }
}