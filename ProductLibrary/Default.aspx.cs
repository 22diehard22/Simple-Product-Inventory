using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProductLibrary
{
    public partial class _Default : Page
    {
        database db = new database();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                addProductPanel.Visible = false;
            }
            DataTable returnedTable = new DataTable(); returnedTable = db.returnProducts();
            foreach (DataRow row in returnedTable.Rows)
            {
                string id = row["Id"].ToString();
                string name = row["name"].ToString();
                string description = row["description"].ToString();
                string price = row["price"].ToString();
                bool active = Convert.ToBoolean(row["active"].ToString()); // Should be able to only display on UI if this = true. 


                Label nameLbl = new Label(); nameLbl.Text = name;
                Label descriptionLbl = new Label(); descriptionLbl.Text = description;

                // Button delete: 
                Button btnDel = new Button();
                btnDel.Text = "Delete";
                btnDel.CommandArgument = id;
                btnDel.Click += delClick;
                // Button modify: 
                Button btnMod = new Button();
                btnMod.Text = "Modify";
                btnMod.CommandArgument = id;
                btnMod.Click += modClick;

                // Create HTML formating: 
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "col-md-4");
                div.InnerHtml = "<h2>" + name + "</h2> <p> Description: " + description + "</p>" + "<p>Price: " + price + "</p>";

                // Create a table to give me better formmatting options: 
                Table tbl = new Table();
                TableRow row1 = new TableRow();
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();

                //cell1.Controls.Add(nameLbl);
                cell2.Controls.Add(btnDel);
                cell3.Controls.Add(btnMod);

                row1.Cells.Add(cell1);
                row1.Cells.Add(cell2);
                row1.Cells.Add(cell3);
                tbl.Rows.Add(row1);
                cell1.Width = 150;

                tbl.CellPadding = 3;
                div.Controls.Add(tbl);
                if (active == true)
                {
                    productList.Controls.Add(div);
                }

            }
        }
        protected void delClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.CommandArgument);

            db.deleteProduct(id);
            Response.Redirect(Request.RawUrl);
        }
        protected void modClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect("/modProduct.aspx?field1=" + button.CommandArgument);
        }


        protected void addProductBtn_Click(object sender, EventArgs e)
        {
            // createAddProductForm();

            addProductPanel.Visible = true;
        }

        protected void cbActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e) // SQlite DB is having an issue 
            //-- Do not have a SQL server for this -- however If implemented you could use entity do so as such: 
            // SqlLite issue: Cannot select framework
        {
            //using (var db = new dbEntities())
            //{
            //    product newItem = new product
            //    {
            //        ID = db.products.Count() + 1,
            //        name = tbName.Text.ToString(),
            //        price = Convert.ToDouble(tbPrice.Text),
            //        active = cbActive.Checked,
            //        description = tbDescription.Text.ToString()
            //    };
            //    db.products.Add(newItem);
            //    db.SaveChanges();
            //    db.Dispose();
         
            try // So instead I have manually created the connectors for now. TODO: run a MSSQL server or fix the framework issue with SQLite
            {
                db.insertProduct(tbName.Text.ToString(), tbDescription.Text.ToString(), Convert.ToDouble(tbPrice.Text), cbActive.Checked);
                Response.Redirect(Page.Request.Url.AbsoluteUri); // Prevent button from being stored in the HTTP post request and calling the method on page refresh.
            }
            catch (Exception ex)
            {

            }

        }
        
    }
}

