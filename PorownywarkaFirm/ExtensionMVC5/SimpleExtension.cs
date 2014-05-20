using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ExtensionMVC5
{
    public static class SimpleExtension
    {
        public static object obj = new object();
        public static object GetUrlFromChart(this HtmlHelper helper, Chart chart)
        {
            lock (obj)
            {
                string path = HttpContext.Current.Server.MapPath("~/App_Data/graphs/");
                //string path = "~/App_Data/graphs/";
                string filename = path + Guid.NewGuid();
                chart.ToWebImage("jpeg").Save(filename);
                return new FilePathResult(filename, "image/jpeg").FileName + ".jpeg";
            }
        }
    }
}
