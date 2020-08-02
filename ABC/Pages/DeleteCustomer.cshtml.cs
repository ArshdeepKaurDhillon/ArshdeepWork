using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ABC.Domain;
namespace ABC.Pages
{
    public class DeleteCustomerModel : PageModel
    {
        [BindProperty]
        public string CustomerName { get; set; }
        public string Message1 { get; set; }
        public string Message2 { get; set; }
        public void OnGet()
        {
        }

        public void OnPostFirstAction()
        {
            Customer GotCustomer;
            ABC_POS ABCHardware = new ABC_POS();
            GotCustomer = ABCHardware.FindCustomer(CustomerName);
            Message1 = GotCustomer.CustomerName + "---"+ GotCustomer.Address + "---"+ GotCustomer.City +"---"+
                GotCustomer.Province +"---"+ GotCustomer.PostalCode;

        }

        public void OnPostSecondAction()
        {
            ABC_POS ABCHardware = new ABC_POS();
            bool Confirmation;
            Confirmation = ABCHardware.RemoveCustomer(CustomerName);
           if(Confirmation)
            {
                Message2 = "Customer Deleted";
                CustomerName = "";


            }

            else
            {
                Message2 = "Customer not Deleted";
                CustomerName = "";

            }
        }
    }
}