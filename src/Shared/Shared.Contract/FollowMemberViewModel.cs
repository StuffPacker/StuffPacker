using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffPacker.ViewModel
{
    public class FollowMemberViewModel
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Following { get; set; }
    }
}
