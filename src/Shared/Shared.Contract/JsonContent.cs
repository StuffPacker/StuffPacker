using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Shared.Contract
{
    public class JsonContent : StringContent
    {
        public JsonContent(string content) : base(content, Encoding.UTF8, "application/json")
        {
        }

        public JsonContent(object obj) :
            base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
        {
        }
    }
}
