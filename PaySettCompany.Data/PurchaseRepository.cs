using PaySettCompany.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PaySettCompany.Data
{
    public class PurchaseRepository
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
        public List<ProductsList> GetAllProducts()
        {
            List<ProductsList> AllProducts = new List<ProductsList>();

            SqlCommand cmd = new SqlCommand("SP_Get_Products ", con);
            cmd.CommandType = CommandType.StoredProcedure;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ProductsList pl = new ProductsList();

                pl.Code = reader["CodeP"].ToString();
                pl.Category = reader["CategoryName"].ToString();
                pl.ProductName = reader["NameP"].ToString();
                pl.Quantity = Convert.ToInt32(reader["QuantityP"]);
                pl.TotalCost = float.Parse(reader["UnitCostP"].ToString());

                AllProducts.Add(pl);
            }

            con.Close();
            return AllProducts;
        }

        public bool CategoryExist(Purchase p)
        {
            bool Status = false;
            for (int cat = 0; cat < p.Category.Count; cat++)
            {
                
                SqlCommand cmd = new SqlCommand("SP_Category_Exist", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Category", p.Category[cat].categoryName);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Status = true;
                }
                else
                {
                    Status = false;
                    CreateCategory(p.Category[cat].categoryName);
                }
                con.Close();
            }
                

            return Status;
        }

        private bool CreateCategory(string Category)
        {
            bool Status;
            SqlCommand cmd = new SqlCommand("SP_Create_Category", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Category", Category);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Status = true;
                
            }
            else
            {
                Status = false;
            }
            con.Close();
        

            return Status;
        }

        public int InsertProduct(Purchase p)
        {
            int Status = 0;
            if (CategoryExist(p))
            {
                for (int cat = 0; cat < p.Category.Count; cat++)
                {
                    for (int pro = 0; pro < p.Category[cat].Products.Count; pro++)
                    {
                        SqlCommand cmd = new SqlCommand("SP_Product_Ins", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Code", p.Category[cat].Products[pro].Code);
                        cmd.Parameters.AddWithValue("@Name", p.Category[cat].Products[pro].Name);
                        cmd.Parameters.AddWithValue("@Description", p.Category[cat].Products[pro].Description);
                        cmd.Parameters.AddWithValue("@Quantity", p.Category[cat].Products[pro].Quantity);
                        cmd.Parameters.AddWithValue("@UnitCost", p.Category[cat].Products[pro].UnitCost);
                        cmd.Parameters.AddWithValue("@Category", p.Category[cat].categoryName);

                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            Status = Status + 1;
                        }

                        con.Close();
                    }
                }

                
            }
            
            return Status;
        }
    }
}
