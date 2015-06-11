using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class _Default : System.Web.UI.Page
{
    public static string ConnectionString = "";
    SqlCommand com;
    int n;

    protected void Page_Load(object sender, EventArgs e)
    {
        ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        if (!IsPostBack)
        {
            this.BindData();



        }

    }

    private void BindData()
    {
        //  string strConnString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            string strQuery = "SELECT batch_year FROM Batch_year";
            using (SqlCommand cmd = new SqlCommand(strQuery))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    con.Open();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                    DPdeptno.DataSource = dt;
                    DPdeptno.DataTextField = "batch_year";
                    DPdeptno.DataValueField = "batch_year";
                    DPdeptno.DataBind();

                    con.Close();
                }
            }
        }
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetCity(string prefixText)
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select fcode from Faculty where fcode like @SearchText +'%'", con);
        cmd.Parameters.AddWithValue("@SearchText", prefixText);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        List<string> CityNames = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CityNames.Add(dt.Rows[i]["fcode"].ToString());
        }
        return CityNames;
    }
}
/*
[WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<string> GetCompanyName(string pre)
    {
        //   ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        List<string> allCompanyName = new List<string>();
        using (SqlConnection con = new SqlConnection(ConnectionString))
        {

            string strQuery = "SELECT fcode FROM Faculty where fcode like  @SearchText +'%'";
            using (SqlCommand cmd = new SqlCommand(strQuery))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    con.Open();
                    sda.SelectCommand = cmd;
                    cmd.Parameters.AddWithValue("@SearchText",pre);
                    SqlDataReader obj_result = cmd.ExecuteReader();
                    while (obj_result.Read())
                    {
                        allCompanyName.Add(obj_result["fcode"].ToString().TrimEnd());
                    }

                    con.Close();
                }
            }
        }
        return allCompanyName;
    }
    */
