using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CollectionMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillUser();
        }
    }
    protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBHelper obj = new DBHelper();
        DataTable dt = obj.GetTable("select  sum(amount) from  UserCollection Where  userid='" + ddlUser.SelectedValue + "'");
        if (dt.Rows.Count > 0)
        {
            txtTotalDue.Text = dt.Rows[0][0].ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DBHelper obj = new DBHelper();
        if (obj.NonQuery("insert into CollectionMaster (UserId,Amount) values ('" + ddlUser.SelectedValue + "','" + txtAmount.Text + "') "))
        {
            DataTable dt = obj.GetTable("select  sum(amount) from  CollectionMaster Where  userid='" + ddlUser.SelectedValue + "'");
            lblDue.Text = Convert.ToString(Convert.ToInt32(txtTotalDue.Text) - Convert.ToInt32(dt.Rows[0][0] + ""));
        }
    }
    private void FillUser()
    {
        DBHelper obj = new DBHelper();
        DataTable dt = obj.GetTable("select * from UserMaster order by 1 desc");
        ddlUser.DataSource = dt;
        ddlUser.DataTextField = "FirstName";
        ddlUser.DataValueField = "UserId";
        ddlUser.DataBind();
    }
}