using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicioWeb2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            MySqlConnection connection = new MySqlConnection("Database=crm_db;Data Source=172.16.1.8;User Id=root;Password=daco2018.");
            connection.Open();
            int contador = 0;
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from cjr_Oportunidades limit 0,10";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                contador++;
                //reader.GetString(0)
                //reader["column_name"].ToString()
            }
            reader.Close();


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}