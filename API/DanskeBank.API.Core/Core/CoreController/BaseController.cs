using DanskeBank.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace DanskeBank.API.Core.Core.CoreController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        public IMap _map { get; set; }
        public BaseController(IMap map)
        {
            _map = map;
        }
    }
}
