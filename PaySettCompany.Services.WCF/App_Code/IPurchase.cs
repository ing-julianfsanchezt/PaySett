using PaySettCompany.Entities;
using System;
using System.Collections.Generic;
using System.ServiceModel;


[ServiceContract]
public interface IPurchase
{
    [OperationContract]
    List<ProductsList> GetAllProducts();

    [OperationContract]
    void InsertProduct(PaySettCompany.Entities.Purchase purchase);
}
