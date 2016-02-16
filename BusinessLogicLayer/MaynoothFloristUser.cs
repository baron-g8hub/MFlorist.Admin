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
        public int Id { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "PassWord")]
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

        public bool IsValid(MaynoothFloristUser user, string userName, string passWord, IList<MaynoothFloristUser> userList)
        {

            var userExist = (from x in userList
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
