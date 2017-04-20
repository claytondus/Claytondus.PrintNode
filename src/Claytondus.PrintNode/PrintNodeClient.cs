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



    }
}