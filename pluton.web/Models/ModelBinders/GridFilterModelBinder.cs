using System.Web;
using System.Web.Mvc;
using pluton.web.Models.Common.Grid;

namespace pluton.web.Models.ModelBinders
{
    public class GridFilterModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;
            return new GridFilter
                {
                    AlphaFilter =
                        {
                            AlphaPropName = request.QueryString["AlphaPropName"],
                            BeginFrom = request.QueryString["BeginFrom"]
                        },
                    PropertyFilter =
                        {
                            PropertyName = request.QueryString["PropertyName"],
                            PropertyValue = request.QueryString["PropertyValue"]
                        }
                };
        }
    }
}