using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace RealEstate.HtmlHelpers
{
    public static class FileResize
    {
        public static void ImageResize(int width,int height,string srcImagePath,string trgImagePath)
        {
            Bitmap myBitmap = new Bitmap(HttpContext.Current.Server.MapPath(srcImagePath));//Burda alacağımız resmin yolunu belirtiyor
            Bitmap image = new Bitmap(myBitmap, width, height);

            image.Save(HttpContext.Current.Server.MapPath(trgImagePath));

            image.Dispose();
            myBitmap.Dispose();
        }
    }
}