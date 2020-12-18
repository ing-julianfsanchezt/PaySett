using Newtonsoft.Json;
using PaySettCompany.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaySettCompany.WebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string strFileName;
            string strFilePath = "";
            string strFolder;
            strFolder = Server.MapPath("~/Uploads/");
            // Get the name of the file that is posted.
            strFileName = pathFile.PostedFile.FileName;
            strFileName = Path.GetFileName(strFileName);
            if (pathFile.Value != "")
            {
                // Create the directory if it does not exist.
                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }
                // Save the uploaded file to the server.
                strFilePath = strFolder + strFileName;
                if (File.Exists(strFilePath))
                {
                    pathFile.PostedFile.SaveAs(strFilePath);
                    LabelUploaded.Text = "Cargado";
                }
                else
                {
                    pathFile.PostedFile.SaveAs(strFilePath);
                    LabelUploaded.Text = "Cargado";
                }
            }
            else
            {
                LabelUploaded.Text = "No se Cargo";
            }
            // Display the result of the upload.
            //frmConfirmation.Visible = true;
            ReadFile(strFilePath);
            ShowProducts();
        }

        private void ShowProducts()
        {
            List<ProductsList> result;
            using (PurchaseService.PurchaseClient service = new PurchaseService.PurchaseClient())
            {
               result = service.GetAllProducts().ToList();

            }

            GridView1.DataSource = result;
            GridView1.DataBind();

        }

        public void ReadFile(string strPath)
        {
            using (StreamReader jsonStream = File.OpenText(strPath))
            {
                var json = jsonStream.ReadToEnd();
                Purchase purchase = JsonConvert.DeserializeObject<Purchase>(json);
                RegisterPurchase(purchase);
            }
        }

        public void RegisterPurchase(Purchase p)
        {
            using (PurchaseService.PurchaseClient service = new PurchaseService.PurchaseClient())
            {
                service.InsertProduct(p);

            }
        }
    }

        
}