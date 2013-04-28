using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chore_Schedule
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlConnection cnHome = new SqlConnection(ConfigurationManager.ConnectionStrings["cnsHome"].ConnectionString);
                SqlDataAdapter myDA = new SqlDataAdapter("dbo.spGetCurrentSchedule", cnHome);
                myDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "dbo.spGetCurrentSchedule");
                gvSchedule.DataSource = myDS.Tables["dbo.spGetCurrentSchedule"].DefaultView;
                gvSchedule.DataBind();
                myDA.Dispose();
                cnHome.Close();
            }
        }
    }
}