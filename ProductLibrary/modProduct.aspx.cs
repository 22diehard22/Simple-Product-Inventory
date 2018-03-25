using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductLibrary
{
    public partial class modProduct : System.Web.UI.Page
    {
        database db = new database();
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // grab the ID of service were editing via the URL field. 
                id = Convert.ToInt32(Request.QueryString["field1"]);
                string[] arr = new string[4]; arr = db.returnProduct(id);
                /*
                                rtnArray[0] = reader["name"].ToString();
                                rtnArray[1] = reader["description"].ToString(); 
                                rtnArray[2] = reader["price"].ToString();
                                rtnArray[3] = reader["active"].ToString();
                 */

                tbName.Text = arr[0];
                tbDescription.Text = arr[1];
                tbPrice.Text = arr[2];
                activeCB.Checked = Convert.ToBoolean(arr[3]);
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            db.editProduct(Convert.ToInt32(Request.QueryString["field1"]), tbName.Text, tbDescription.Text, Convert.ToDouble(tbPrice.Text), activeCB.Checked);
            
        }
    }
}