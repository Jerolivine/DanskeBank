using DanskeBank.Mapper;
using Microsoft.AspNetCore.Authorization;

namespace DanskeBank.API.Core.Core.CoreController
{
    [Authorize]
    public class AuthorizedController : BaseController
    {
        public AuthorizedController(IMap map) : base(map)
        {

        }
    }
}
