using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ABC.Domain;
namespace ABC.Pages
{
    public class DeleteItemModel : PageModel
    {
        [BindProperty]
        public string ItemCode { get; set; }
        [BindProperty]
        public string Flag { get; set; }

        public string Message1 { get; set; }
        public string Message2 { get; set; }

        public void OnGet()
        {
        }

        public void OnPostFirstAction()
        {
            Item GotItem;
            ABC_POS ABCHardware = new ABC_POS();
            GotItem = ABCHardware.FindItem(ItemCode);
            Message1 = GotItem.ItemCode + "---" + GotItem.Description + "---" + GotItem.UnitPrice+ "---"+GotItem.Quantity + "---" + GotItem.Flag;

        }

        public void OnPostSecondAction()
        {
            ABC_POS ABCHardware = new ABC_POS();
            bool Confirmation;
            Confirmation = ABCHardware.RemoveItem(ItemCode,Flag);
            if (Confirmation)
            {
                Message2 = "Item Deleted";
                ItemCode = "";
            }
            else
            {
                Message2 = "Item not deleted";
                ItemCode = "";
            }
        }
    }
}