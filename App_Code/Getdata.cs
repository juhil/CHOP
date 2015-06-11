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

/// <summary>
/// Summary description for Getdata
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Getdata : System.Web.Services.WebService
{

    public Getdata()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
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





