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
                string path = "~/Images/graphs/";
                string filename = path + Guid.NewGuid();
                chart.ToWebImage("jpeg").Save(filename);
                return filename + ".jpeg";
            
        }
    }
}
