using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace pluton.web.Infrastructure.Attributes
{
    public class LanguageReplacerAttribute : ActionFilterAttribute
    {
        // private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Response.Filter != null)
            {
                filterContext.HttpContext.Response.Filter =
                    new LocalizationStream(filterContext.HttpContext.Response.Filter, filterContext.HttpContext);
            }
        }

        public class LocalizationStream : MemoryStream
        {
            StreamWriter sw;
            HttpContextBase _httpContext;

            public LocalizationStream(Stream s, HttpContextBase context)
            {
                sw = new StreamWriter(s);
                _httpContext = context;
            }

            public override void Close()
            {
                var allBytes = this.ToArray();
                var content = Encoding.UTF8.GetString(allBytes);
                var lang = Localization.GetCurrentLanguage(_httpContext);
                var macroses = Regex.Matches(content, @"\[%[^\]]*%\]");
                foreach (var macros in macroses)
                {
                    //prevent not closing tag
                    if (macros.ToString().Contains("<") || macros.ToString().Contains(">")) continue;
                    var trimmedMacros = macros.ToString().Replace("[%", "").Replace("%]", "");
                    var translatedValue = Localization.Translate(trimmedMacros, lang);
                    content = content.Replace(macros.ToString(), translatedValue);
                }
                sw.Write(content);
                sw.Flush();
                sw.Close();
                base.Close();
            }
        }

    }
}