using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPECommerce.Classes
{
    public class UserResponse
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Photo { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public Company Company { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsUser { get; set; }

        public bool IsCustomer { get; set; }

        public bool IsSupplier { get; set; }

        public string Password { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

    public string PhotoFullPath
        {
            get
            {
                if (!string.IsNullOrEmpty(Photo))
                {
                    return string.Format("http://tzecommerce.diskcode.info/{0}", Photo.Substring(1));
                }

                return string.Empty;
            }
        }
    }

}
