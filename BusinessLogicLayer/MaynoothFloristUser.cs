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

       

        public bool IsValid(MaynoothFloristUser user, string userName, string passWord)
        {

            //// Check if item exist
            //if (Repository.IsItemExist((decimal)item.ItemID, item.ItemKeyTypeCode, item.MfgLocationNo) && isNew)
            //{
            //    return string.Format(
            //            "Item ID: {0} for Manufacturing Location: {1} - {2} already exist. Item ID must be unique",
            //            item.ItemID, item.MfgLocationNo, item.MfgLocationName);
            //}


            // Check if user exist
            if (Repository.IsUserExist((MaynoothFloristUser) user, userName, passWord))
            {
                return true;
            }

            return false;
        }

    }
}
