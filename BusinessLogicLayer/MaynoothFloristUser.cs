using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogicLayer
{
    [Serializable]
    public class MaynoothFloristUser
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PassWord { get; set; }

        public string RegDate { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IRepository Repository { private get; set; }

        public IList<MaynoothFloristUser> GetUsers()
        {
            return Repository.GetUsers();
        }

                    
        public bool IsValid(MaynoothFloristUser user, string userName, string passWord)
        {
          
            var userExist = (from x in user.Repository.GetUsers()
                             where x.UserName == user.UserName && x.PassWord == user.PassWord
                             select x).FirstOrDefault();

            if (userExist != null)
            {
                user.FirstName = userExist.FirstName;
                user.LastName = userExist.LastName;

                return true;
            }

            return false;
        }
    }
}
