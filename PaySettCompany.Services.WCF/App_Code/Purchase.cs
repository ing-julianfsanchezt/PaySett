using PaySettCompany.Business;
using PaySettCompany.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

public class Purchase : IPurchase
{
    public List<ProductsList> GetAllProducts()
    {
        PurchaseBusiness pb = new PurchaseBusiness();
        return pb.GetAllProducts();
    }

    public void InsertProduct(PaySettCompany.Entities.Purchase purchase)
    {
        PurchaseBusiness pb = new PurchaseBusiness();
        pb.InsertProduct(purchase);
    }
}
