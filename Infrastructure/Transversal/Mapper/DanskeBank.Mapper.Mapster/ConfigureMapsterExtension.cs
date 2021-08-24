using DanskeBank.Application.Contract.Notification;
using DanskeBank.Constants.Constants;
using DanskeBank.Domain.Notification;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.Mapper.Mapster
{
    public static class ConfigureMapsterExtension
    {
        public static IServiceCollection ConfigureMapster(this IServiceCollection services)
        {
            services.AddSingleton<IMap, MapsterMapper>();

            TypeMappings();

            return services;
        }

        private static void TypeMappings()
        {
            //TypeAdapterConfig<BaseResult, IResponseBase>.NewConfig()
            //            .Map(dest => dest.ErrorMessage, src => src.Message);

            //TypeAdapterConfig<typeof(ValueResult<>), typeof(IResponseBase<>)>.NewConfig()
            //        .Map(dest => dest.ErrorMessage, src => src.Message);

            NotificationMappings();

        }

        private static void NotificationMappings()
        {
            TypeAdapterConfig<NotificationDto, Notification>.NewConfig()
                                  .Map(dest => dest.SendDate, src => src.SendDate.ToString(DateConstants.DATE_FORMAT));

            TypeAdapterConfig<Notification, NotificationDto>.NewConfig()
                      .Map(dest => dest.SendDate, src => DateTime.ParseExact(src.SendDate, DateConstants.DATE_FORMAT, null));

            TypeAdapterConfig<Notification, NotificationDto>.NewConfig()
                  .Map(dest => dest.SendDate, src => DateTime.ParseExact(src.SendDate, DateConstants.DATE_FORMAT, null));

        }
    }
}
