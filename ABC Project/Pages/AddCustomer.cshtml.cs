using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

using ABC.Domain;

namespace ABC.Pages
{
    public class AddCustomerModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        public string CustomerName { get; set; }

        [BindProperty]
        public string Address { get; set; }

        [BindProperty]
        public string City { get; set; }

        [BindProperty]
        public string Province { get; set; }

        [BindProperty]
        [MaxLength(6),RegularExpression(@"^[a-z]{1}[0-9]{1}[a-z]{1}[0-9]{1}[a-z]{1}[0-9]{1}$")]
        public string PostalCode { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            
               
                Customer GotCustomer = new Customer();

                GotCustomer.CustomerName = CustomerName;
                GotCustomer.Address = Address;
                GotCustomer.City = City;
                GotCustomer.Province = Province;
                GotCustomer.PostalCode = PostalCode;

                bool Confirmation;
                ABC_POS ABCHardware = new ABC_POS();

            if (ModelState.IsValid)
            {
                Confirmation = ABCHardware.InsertCustomer(GotCustomer);
            if(Confirmation)
            { 

                    Message = "Customer added";
                    CustomerName = "";
                    Address = "";
                    City = "";
                    Province = "";
                    PostalCode = "";

            }
            }

            else
            {
                Message = "Customer not added";
           
                CustomerName = "";
                Address = "";
                City = "";
                Province = "";
                PostalCode = "";
            }


        }
    }
}