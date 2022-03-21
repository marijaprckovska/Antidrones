using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication5.Models;

namespace WebApplication5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static void createdrone()
        {
            DataContex db = new DataContex();
            Random random = new Random();
            while (true)
            {
                Thread.Sleep(random.Next(10000));
                // ovde treba vo baza da se vnesi dron
                double lat = random.NextDouble() * 90;
                double lon = random.NextDouble() * 180;
                Dron dron = new Dron();
                dron.Latitude = lat.ToString();
                dron.Longitude= lon.ToString();
                dron.Absolute = random.Next(2000);
                db.dron.Add(dron);
                db.SaveChanges();
                Sensor[] s = db.sensor.ToArray();
                int stop = random.Next(s.Count());
                int sensorId = 0;
                for (int i = 0; i<s.Count(); i++)
                {
                    if(i == stop)
                    {
                        sensorId = s[i].Id;
                    }
                }

                Detekcija det = new Detekcija();
                det.SensorId = sensorId;
                det.DronId = dron.Id;
                db.detekcija.Add(det);
                db.SaveChanges();

            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Thread t = new Thread(new ThreadStart(MvcApplication.createdrone));
            t.Start();
        }
    }
}
