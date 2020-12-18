using PaySettCompany.Data;
using PaySettCompany.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySettCompany.Business
{
    public class PurchaseBusiness
    {
        public List<ProductsList> GetAllProducts()
        {
            PurchaseRepository pr = new PurchaseRepository();
            return pr.GetAllProducts();
        }

        public void InsertProduct(Purchase purchase)
        {
            PurchaseRepository pr = new PurchaseRepository();
            pr.InsertProduct(purchase);
        }

    }
}
