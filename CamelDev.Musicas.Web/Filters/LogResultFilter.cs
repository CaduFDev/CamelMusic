using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CamelDev.Musicas.Web.Filters
{
    public class LogResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string message = string.Format("[{0}] - Resultado: {1}/{2} | {3} ]", DateTime.Now.ToString(),
                    filterContext.RouteData.Values["Controller"].ToString(),
                    filterContext.RouteData.Values["Action"].ToString(),
                    filterContext.Result.ToString());
                    
            Debug.WriteLine(message);
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string message = string.Format("[{0}] - Processando resultados: {1}/{2} | {3} ]", DateTime.Now.ToString(),
                    filterContext.RouteData.Values["Controller"].ToString(),
                    filterContext.RouteData.Values["Action"].ToString(),
                    filterContext.Result.ToString());

            Debug.WriteLine(message);
        }
    }
}