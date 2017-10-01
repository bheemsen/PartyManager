using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserEvents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillUser();
            FillEvent();
        }
    }

    protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
    protected void ddlEvent_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBHelper obj = new DBHelper();
        DataTable dt = obj.GetTable("select * from EventMaster where EventId='" + ddlEvent.SelectedValue + "'");
        if (dt.Rows.Count > 0)
        {
            txtAount.Text = dt.Rows[0]["Amount"].ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DBHelper obj=new DBHelper();
        if (obj.NonQuery("insert into UserCollection (EventId,UserId,Amount) values ('" + ddlEvent.SelectedValue + "','" + ddlUser.SelectedValue + "','" + txtAount.Text + "')"))
        {
            FillGrid();
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
    private void FillEvent()
    {
        DBHelper obj = new DBHelper();
        DataTable dt = obj.GetTable("select * from EventMaster order by 1 desc");
        ddlEvent.DataSource = dt;
        ddlEvent.DataTextField = "EventName";
        ddlEvent.DataValueField = "EventId";
        ddlEvent.DataBind();
    }
    private void FillGrid()
    {
        DBHelper obj = new DBHelper();
        DataTable dt = obj.GetTable("select * from UserCollection Where UserId='" + ddlUser.SelectedValue + "'");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}