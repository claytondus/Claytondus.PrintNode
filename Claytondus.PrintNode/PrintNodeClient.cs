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

	    public async Task<Address> CreateAddressAsync(Address address)
	    {
	        const string resource = "/addresses";
	        return await PostAsync<Address>(resource, address);
	    }



    }
}