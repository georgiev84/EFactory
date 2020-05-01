using Microsoft.AspNetCore.Identity;
using System;


namespace DataLibrary.Data
{
    public class WebUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public DateTime CreatedAt { get; set; }
    }
}
