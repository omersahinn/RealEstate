using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RealEstate.Repositories
{
    public class GetFiles
    {
        public static List<string> GetLanguageFiles(string filePath)
        {
            var lFiles = from l in new DirectoryInfo(HttpContext.Current.Server.MapPath(filePath)).GetFiles()
                         select l;
            List<string> names = new List<string>();
            names.Add("Seçiniz...");
            foreach (var item in lFiles)
            {
                if (!item.Name.Contains("cs")&&item.Name!="lang.resx")
                names.Add(item.Name);
            }
            return names;
        }
        public static List<string> GetViewvsFiles()
        {
            List<string> pages = new List<string>();
            var vDirectory = from d in new DirectoryInfo(HttpContext.Current.Server.MapPath("/Areas/Administrator/Views/")).GetDirectories() select d;

            foreach (DirectoryInfo item in vDirectory)
            {
                var files = item.GetFiles();

                foreach (var items in files)
                {
                    pages.Add(item.Name + "/" + items.Name);
                }
            }
            return pages;
        }
    }
}