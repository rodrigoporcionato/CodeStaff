public class RequireHttpsAttribute : ActionFilterAttribute
    {
        public bool RequireSecure = false;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var httpsPort = Convert.ToInt32(ConfigurationManager.AppSettings["httpsPort"]);
            var httpPort = Convert.ToInt32(ConfigurationManager.AppSettings["httpPort"]);
            var request = filterContext.HttpContext.Request;
            var response = filterContext.HttpContext.Response;

            if (httpsPort > 0 && RequireSecure)
            {
                string url = null;
                if (httpsPort > 0)
                {
                    url = "https://" + request.Url.Host + request.RawUrl;

                    if (httpsPort != 443)
                    {
                        var builder = new UriBuilder(url) { Port = httpsPort };
                        url = builder.Uri.ToString();
                    }
                }
                if (httpsPort != request.Url.Port)
                {
                    filterContext.Result = new RedirectResult(url);
                }
            }
            // se for uma conexao segura e não está requerendo um SSL, retira o ssl e volta para http.
            else if (filterContext.HttpContext.Request.IsSecureConnection && !RequireSecure)
            {
                filterContext.Result = new RedirectResult(filterContext.HttpContext.Request.Url.ToString().Replace("https:", "http:").Replace(httpsPort.ToString(), httpPort.ToString())); 
                filterContext.Result.ExecuteResult(filterContext);
            }
            base.OnActionExecuting(filterContext);
        }    

    }
