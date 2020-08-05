using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC.TechnicalServices;
using static ABC.Domain.Sale;

namespace ABC.Domain
{
    public class ABC_POS
    {
        public bool InsertItem(Item AcceptedItem)
        {
            bool Confirmation;
            Items ItemManager = new Items();
            Confirmation = ItemManager.AddItem(AcceptedItem);
            return Confirmation;

        }

        public bool InsertCustomer(Customer GotCustomer)
        {
            bool Confirmation;
            Customers CustomerManager = new Customers();
            Confirmation = CustomerManager.AddCustomer(GotCustomer);
            return Confirmation;

        }

        public Customer FindCustomer(string CustomerName)
        {
            Customer GotCustomer;
            Customers CustomerManager = new Customers();
            GotCustomer = CustomerManager.GetCustomer(CustomerName);
            return GotCustomer;

        }

        public bool RemoveCustomer(string CustomerName)
        {
            bool Confirmation2;
            Customers CustomerManager = new Customers();
            Confirmation2 = CustomerManager.DeleteCustomer(CustomerName);
            return Confirmation2;
        }

        public Item FindItem(string ItemCode)
        {
            Item GotItem;
            Items ItemManager = new Items();
            GotItem = ItemManager.GetItem(ItemCode);
            return GotItem;
        }

        public bool RemoveItem(string ItemCode,string Flag)
        {
            bool Confirmation1;
           Items ItemManager = new Items();
            Confirmation1 = ItemManager.UpdateFlag(ItemCode, Flag);
            return Confirmation1;
        }

        public bool ModifyCustomer(Customer ModCustomer)
        {
            bool Confirmation;
            Customers CustomerManager = new Customers();
            Confirmation = CustomerManager.UpdateCustomer(ModCustomer);
            return Confirmation;
        }

        public bool ModifyItem(Item ModItem)
        {
            bool Confirmation;
            Items ItemManager = new Items();
            Confirmation = ItemManager.UpdateItem(ModItem);
            return Confirmation;
        }

        public int ProcessSale(SaleItem ABCSale)
        {
            int SaleNumber;
            Sales SaleManager = new Sales();
           SaleNumber= SaleManager.AddSale(ABCSale);
            return SaleNumber;

        }

        public bool ModifyQuantity(Item ABCItem)
        {
            bool Confirmation;
           
            Items ItemManager = new Items();
            Confirmation = ItemManager.UpdateQuantity(ABCItem);
            return Confirmation;
        }



    }
}
