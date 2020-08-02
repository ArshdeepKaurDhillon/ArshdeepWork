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
    public class AddItemModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        [MaxLength(6), RegularExpression(@"^[a-z]{1}[0-9]{5}$")]
        public string ItemCode { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public string UnitPrice { get; set; }

        [BindProperty]
        public string Quantity { get; set; }

        [BindProperty]
        public string Flag { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
           
                Item AcceptedItem = new Item();
                AcceptedItem.ItemCode = ItemCode;
                AcceptedItem.Description = Description;
                AcceptedItem.UnitPrice = UnitPrice;
                AcceptedItem.Quantity = Quantity;
                AcceptedItem.Flag = Flag;

                bool Confirmation;
                ABC_POS ABCHardware = new ABC_POS();

            if (ModelState.IsValid)
            { 

           
                Confirmation = ABCHardware.InsertItem(AcceptedItem);

                if (Confirmation)
                {



                    Message = "Item added";
                    ItemCode = "";
                    Description = "";
                    UnitPrice = "";
                    Quantity = "";
                    Flag = "";
                }
            }





            else
            {
                Message = "Item not added";
                ItemCode = "";
                Description = "";
                UnitPrice = "";
                Quantity = "";
                Flag = "";

            }
              

           
        }
    }
}