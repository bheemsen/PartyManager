using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Login : System.Web.UI.Page
{
    DBHelper obj = new DBHelper();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataTable dt = obj.GetTable("select * from UserMaster Where Email='" + txtUserName.Text + "'");
        if (dt.Rows.Count > 0 && txtPassword.Text == dt.Rows[0]["UserPassword"].ToString())
        {
            Session["UserId"] = dt.Rows[0][0].ToString();
            Session["Email"] = dt.Rows[0]["Email"].ToString();
            Session["UserName"] = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
        }
    }
}