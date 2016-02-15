using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
   public class MaynoothFloristUser
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public string RegDate { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IRepository Repository { private get; set; }

        public IQueryable<MaynoothFloristUser> GetUsers()
        {
            return Repository.GetUsers();
        }

        public bool IsValid(MaynoothFloristUser user, string userName, string passWord)
        {
            
            return false;
        }
    }
}
