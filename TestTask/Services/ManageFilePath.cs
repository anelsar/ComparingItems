using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Services
{
    public class ManageFilePath : IGetPath
    {
        public string GetPath(string rootDirectory, string fileName)
        {
            var path = HttpContext.Current.Server.MapPath("/" + rootDirectory);
            path += ("\\"+fileName) ;
            return path;
        }
    }
}