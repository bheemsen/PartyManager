using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EventMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillEvent();
        }
    }
    private void FillEvent()
    {
        DBHelper obj = new DBHelper();
        DataTable dt = obj.GetTable("select * from EventMaster order by 1 desc");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DBHelper obj = new DBHelper();
        if (obj.NonQuery("insert into EventMaster (EventName,Amount) values ('" + txtEventName.Text + "','" + txtAmount.Text + "')"))
            FillEvent();
    }
}