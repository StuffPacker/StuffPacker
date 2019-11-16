using System;

namespace StuffPacker.ViewModel.Members
{
    public class MemberListItemViewModel
    {
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        public Guid UserId { get; set; }
        public string UserImgPath { get; set; }
        public int Packlists { get;  set; }

        public int Products { get; set; }
        public bool ItsMe { get;  set; }

        public bool Following { get; set; }
    }
}
