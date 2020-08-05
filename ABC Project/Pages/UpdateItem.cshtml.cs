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
    public class UpdateItemModel : PageModel
    {
        public string Message1 { get; set; }
        public string Message2 { get; set; }

        [BindProperty]
        public string ItemCode { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public string Quantity { get; set; }

        [BindProperty]
        public string UnitPrice { get; set; }

        public void OnGet()
        {
        }

        public void OnPostFirstAction()
        {
            Item GotItem;
            ABC_POS ABCHardware = new ABC_POS();
            GotItem = ABCHardware.FindItem(ItemCode);
            Message1 = GotItem.ItemCode + "---" + GotItem.Description + "---" + GotItem.UnitPrice+ "---" + GotItem.Quantity;
        }

        public void OnPostSecondAction()
        {
            bool Confirmation;
            Item ModItem = new Item();
            ModItem.ItemCode = ItemCode;
            ModItem.Description =Description;
            ModItem.Quantity = Quantity;
            ModItem.UnitPrice = UnitPrice;

            ABC_POS ABCHardware = new ABC_POS();
            Confirmation = ABCHardware.ModifyItem(ModItem);
            if(Confirmation)
            {
                Message2 = "Item Modified";
                ItemCode = "";
                Description = "";
                Quantity = "";
                UnitPrice = "";
            }

            else
            {
                Message2 = "Item not modified";
            }
        }
    }
}