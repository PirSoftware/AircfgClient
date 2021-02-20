using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AirCfgTestProject.Controllers
{
    public class HomeController : Controller
    {
        #region Private Fields

        private readonly ILogger<HomeController> _logger;

        #endregion Private Fields

        #region Public Constructors

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #endregion Public Constructors

        #region Public Methods

        public IActionResult Index()
        {
            return Json("{ok:'OK'}");
        }

        #endregion Public Methods
    }
}