
using System.Web.Mvc;
using Mars.Common.UnitOfWork;

namespace pluton.web.Controllers
{
    public abstract class BaseController : Controller
    {
        public readonly IUnitOfWork UnitOfWork;

        protected BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}