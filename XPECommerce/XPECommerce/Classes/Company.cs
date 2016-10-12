using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPECommerce.Classes
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Logo { get; set; }

        public object LogoFile { get; set; }

        public int DepartmentId { get; set; }

        public int CityId { get; set; }

        public object Department { get; set; }

        public object City { get; set; }

        public object Categories { get; set; }

        public object Taxes { get; set; }

        public object Products { get; set; }

        public object Warehouses { get; set; }

        public object CompanyCustomers { get; set; }

        public object CompanySuppliers { get; set; }

        public object Orders { get; set; }

        public object Purchases { get; set; }

        public object Sales { get; set; }
    }

}
