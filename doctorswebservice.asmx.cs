using Doctorservice;
using medical.medico;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace medical
{
    /// <summary>
    /// Summary description for doctorswebservice
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class doctorswebservice : System.Web.Services.WebService
    {

        [WebMethod]
        public void Getdoctorsdetail()
        {
            List<doctorservice> doctorlist = new List<doctorservice>();
            string cs = ConfigurationManager.ConnectionStrings["DOCTS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from doctortable", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    doctorservice dsc = new doctorservice();
                    dsc.slno = Convert.ToInt32(rdr["slno"]);
                    dsc.dphoto = Convert.ToString(rdr["dphoto"]);
                    dsc.dname = Convert.ToString(rdr["dname"]);
                    dsc.dspicilization = Convert.ToString(rdr["dspicilization"]);
                    dsc.dfee = Convert.ToInt32(rdr["dfee"]);
                    dsc.dclenic = Convert.ToString(rdr["dclenic"]);
                    dsc.location = Convert.ToString(rdr["location"]);

                    doctorlist.Add(dsc);

                }
            }

           JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(doctorlist));
        }

        [WebMethod]
        public void Getghdetails()
        {
            List<ghservice> doctorlist = new List<ghservice>();
            string cs = ConfigurationManager.ConnectionStrings["DOCTS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from govhospital", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ghservice dsc = new ghservice();
                    dsc.slno = Convert.ToInt32(rdr["slno"]);
                    dsc.name = Convert.ToString(rdr["name"]);
                    dsc.sector = Convert.ToString(rdr["sector"]);
                    dsc.destination = Convert.ToString(rdr["destination"]);
                    dsc.department = Convert.ToString(rdr["departmemnt"]);
                    dsc.location = Convert.ToString(rdr["location"]);

                    doctorlist.Add(dsc);

                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(doctorlist));
        }
    }
}
