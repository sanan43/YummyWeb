using Microsoft.AspNetCore.Identity;

namespace yummysayt.Models.Auth
{
    public class MyAppUser : IdentityUser
    {
        public string Name { get; set; }
        public bool IsActived { get; set; }


    }
}
