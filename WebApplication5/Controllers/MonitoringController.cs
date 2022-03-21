using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

namespace WebApplication5.Controllers
{
    public class MonitoringController : Controller
    {
        private DataContex db = new DataContex();

        // GET: Drons
        public ActionResult Index()
        {
            return View(db.Database.SqlQuery<DronSensor>("select d.id, d.Latitude, d.Longitude, d.Absolute, s.Type, s.Sektor " +
              "from Drons as d join Detekcijas as det on d.Id = det.DronId join Sensors as s on s.Id = det.SensorId").ToList());
            //return View(db.dron.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
