using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OleDb;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.SqlClient;

public partial class javascript : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<string> GetAutoCompleteData(string txt)
    {
        // your code to query the database goes here
        List<string> result = new List<string>();
        string QueryString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        using (SqlConnection obj_SqlConnection = new SqlConnection(QueryString))
        {
            using (SqlCommand obj_Sqlcommand = new SqlCommand("Select fcode from Faculty where fcode like @SearchText +'%' ", obj_SqlConnection))
            {
                obj_SqlConnection.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["fcode"].ToString().TrimEnd());
                }
            }
        }

        return result;
    }
}