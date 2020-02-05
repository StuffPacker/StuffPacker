using System;

namespace Shared.Contract.Dtos
{
    public class ProfileDto
    {
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid Id { get; set; }
    }
}
