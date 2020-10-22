using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.Service.Contracts.Base
{
    public interface IHttpService
    {
        public Task<TValue> SendAsync<TValue>(HttpMethod method, string url, object postData, string contentType = "application/json", Dictionary<string, string> headers = null);
    }
}
