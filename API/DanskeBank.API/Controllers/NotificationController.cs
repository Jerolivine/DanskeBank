using DanskeBank.API.Core.Core.Base.Response.Concrete;
using DanskeBank.API.Core.Core.CoreController;
using DanskeBank.Application.Contract.Core;
using DanskeBank.Application.Contract.Notification;
using DanskeBank.Application.Service.Notification.Abstract;
using DanskeBank.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DanskeBank.API.Controllers
{

    [AllowAnonymous]
    public class NotificationController : BaseController
    {
        private readonly INotificationService _notificationService;

        public NotificationController(
            IMap map,
            INotificationService notificationService) : base(map)
        {
            _notificationService = notificationService;
        }


        [HttpPost("Add")]
        public ValueResponse<int> Add([FromBody] NotificationDto request)
        {
            ValueResult<int> result = _notificationService.Add(request);

            ValueResponse<int> resposne = _map.Map<ValueResponse<int>>(result);
            return resposne;

        }

        [HttpPost("GetNotificationsByCompanyId")]
        public ValueResponse<NotificationReportDto> GetNotificationsByCompanyId([FromBody] GetNotificationsByCompanyIdRequest request)
        {
            ValueResult<NotificationReportDto> result = _notificationService.GetNotificationsByCompanyId(request.CompanyId);

            ValueResponse<NotificationReportDto> resposne = _map.Map<ValueResponse<NotificationReportDto>>(result);
            return resposne;

        }
    }
}
