using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using NationalParks.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Park> parks = new List<Park>();
            // Connect to MySql 
            using (MySqlConnection con = new MySqlConnection("server=project1dbv2-instance-1.car4qphjnllt.us-east-2.rds.amazonaws.com; user=admin;database=Parks;port=3306;password=password123"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Parks", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //Extract your data
                    Park park = new Park();
                    park.Id = Convert.ToInt32(reader["Id"]);
                    park.Name = reader["Name"].ToString();
                    park.State = reader["State"].ToString();
                    park.Date = Convert.ToInt32(reader["Date"]);
                    park.Image = reader["Image"].ToString();

                    parks.Add(park);
                }
                reader.Close();
            }


                return View(parks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public IActionResult Index(IFormCollection form)
        //{
        //    string p = form["filterselect"];
        //    IQueryable<> park = state.parks;
        //    if (p == "California")
        //    {
        //        park = park.Where(x => x.california);
        //    }
        //    else if (p == "Utah")
        //    {
        //        park = park.Where(x => x.utah);
        //    }
            
        //    ViewBag.ParkList = park;
        //    ViewBag.Selected = p;
        //    return View();
        //}

    }
}
