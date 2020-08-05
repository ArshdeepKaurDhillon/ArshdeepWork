using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ABC.Domain;
using ABC.TechnicalServices;
using static ABC.Domain.Sale;

namespace ABC.Pages
{
    public class ProcessSaleModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        public string TotalWithGST { get; set; }
        public string TotalSubTotal { get; private set; }
        [BindProperty]
        public int SaleNumber { get; set; }
        [BindProperty]
        public string SaleDate { get; set; }
        [BindProperty]
        public string CustomerName { get; set; }
        [BindProperty]
        public string Salesperson { get; set; }
        [BindProperty]
        public string Subtotal { get; set; }
        [BindProperty]
        public string Gst { get; set; }
        [BindProperty]
        public string SaleTotal { get; set; }
        [BindProperty]
        public string ItemCode { get; set; }
        [BindProperty]
        public string Quantity { get; set; }
        [BindProperty]
        public string ItemTotal { get; set; }
        [BindProperty]
        public string DTime { get; set; }
        [BindProperty]
        public string TotalWithGst { get; set; }

        public string Total { get; set; }
        public string Message1 { get; set; }
        public string Message2 { get; set; }
        public string Message3 { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {


            Item ABCItem = new Item();

            //TotalWithGST = Subtotal + Gst;


            SaleItem ABCSale = new SaleItem();


            ABCSale.ItemCode = ItemCode;
            ABCSale.Quantity = Quantity;

            ABC_POS ABCHardware = new ABC_POS();

            ABCItem = ABCHardware.FindItem(ItemCode);


            int Q = Convert.ToInt32(Quantity);
            int U = Convert.ToInt32(ABCItem.UnitPrice);
            int Total;
            Total = Q * U;

            Message2 = "Q-----" + Q + "U------" + U + "Total------" + Total;
            //ABCSale.ItemTotal = Total.ToString();

            ABCSale.ItemTotal = Total.ToString();
            Message3 = ABCSale.ItemTotal;


            ABCSale.SaleDate = SaleDate;
            ABCSale.CustomerName = CustomerName;
            ABCSale.Salesperson = Salesperson;
            ABCSale.Subtotal = Subtotal;
            ABCSale.Gst = Gst;
            ABCSale.SaleTotal = SaleTotal;

            DTime = DateTime.Now.ToString();
            ABCSale.Time = DTime;
            int SaleNumber;

            SaleNumber = ABCHardware.ProcessSale(ABCSale);
            Message = ABCSale.SaleNumber;

            int Q1, Q2, Q3;

            ABCItem = ABCHardware.FindItem(ItemCode);
            //ABCItem.Quantity
            Q1 = Convert.ToInt32(ABCItem.Quantity);
            Q2 = Convert.ToInt32(ABCSale.Quantity);

            Q3 = Q1 - Q2;
            ABCItem.Quantity = Convert.ToString(Q3);

            bool Confirmation;
            ABCItem.ItemCode = ABCSale.ItemCode;
            ABCItem.Quantity = Q3.ToString();

            Confirmation = ABCHardware.ModifyQuantity(ABCItem);


            SaleDate = "";
            CustomerName = "";
            Salesperson = "";
            Subtotal = "";
            Gst = "";
            SaleTotal = "";
            ItemTotal = "";
            ItemCode = "";
            SaleTotal = "";
            Quantity = "";


        }
    }
}