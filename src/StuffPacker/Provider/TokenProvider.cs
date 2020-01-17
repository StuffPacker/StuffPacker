using Shared.Contract.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.Provider
{
    public class TokenProvider : ITokenProvider
    {
        private Dictionary<Guid, string> tokens = new Dictionary<Guid, string>();

        public void AddToken(Guid id, string token)
        {
            if (tokens.TryGetValue(id, out string v))
            {
                tokens[id] = token;
            }
            else
            {
                tokens.Add(id,token);
            }
        }

        public string GetToken(Guid id)
        {
            if(tokens.TryGetValue(id,out string v))
            {
                return v;
            }

            throw new KeyNotFoundException();
        }
    }
}
