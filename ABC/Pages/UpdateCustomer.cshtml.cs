using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ABC.Domain;

namespace ABC.Pages
{
    public class UpdateCustomerModel : PageModel
    {
        public string Message1 { get; set; }
        public string Message2 { get; set; }

        [BindProperty]
        public string CustomerName { get; set; }

        [BindProperty]
        public string Address { get; set; }

        [BindProperty]
        public string City { get; set; }

        [BindProperty]
        public string Province { get; set; }

        [BindProperty]
        public string PostalCode { get; set; }

        public void OnGet()
        {
        }

        public void OnPostFirstAction()
        {
            Customer GotCustomer;
            ABC_POS ABCHardware = new ABC_POS();
            GotCustomer = ABCHardware.FindCustomer(CustomerName);

            Message1 = GotCustomer.CustomerName + "---" + GotCustomer.Address + "---" + GotCustomer.City + "---" +
            GotCustomer.Province + "---" + GotCustomer.PostalCode;

        }

        public void OnPostSecondAction()
        {
            bool Confirmation;
            Customer ModCustomer = new Customer();
          ModCustomer.CustomerName = CustomerName;
            ModCustomer.Address = Address;
            ModCustomer.City = City;
            ModCustomer.Province = Province;
            ModCustomer.PostalCode = PostalCode;

            ABC_POS ABCHardware = new ABC_POS();
            Confirmation = ABCHardware.ModifyCustomer(ModCustomer);

            if(Confirmation)
            {
                Message2 = "Customer Modified";
                CustomerName = "";
                Address = "";
                City = "";
                Province = "";
                PostalCode = "";

            }

            else
            {
                Message2 = "Customer not modified";
                CustomerName = "";
                Address = "";
                City = "";
                Province = "";
                PostalCode = "";
            }
        }
    }
}