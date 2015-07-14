
using System;
using System.Collections.Generic;
using pluton.dal.Entities;
using pluton.web.Models;
using AutoMapper;

namespace pluton.web.Infrastructure
{
    public static class Mappings
    {
        public static void Init()
        {
            Mapper.CreateMap<User, UserItemModel>()
                .ForMember(x => x.Initials, cfg => cfg.MapFrom(y => string.Format("{0} {1}", y.FirstName, y.LastName)))
                .ForMember(x => x.Role, cfg => cfg.MapFrom(y => y.Role.RoleName))
                .ForMember(x => x.LastActivity, cfg => cfg.MapFrom(y => y.LastActive));

            Mapper.CreateMap<User, UserEntryModel>()
                  .ForMember(x => x.Email, cfg => cfg.MapFrom(y => y.EmailAddress))
                  .ForMember(x => x.Phone, cfg => cfg.MapFrom(y => y.PhoneNumber))
                  .ForMember(x => x.DefaultRoleId, cfg => cfg.MapFrom(y => y.Role.Id))
                  .ForMember(x => x.IsActive, cfg => cfg.MapFrom(y => y.Active));
            //            Mapper.CreateMap<IEnumerable<User>, IEnumerable<UserItemModel>>();

            Mapper.CreateMap<UserEntryModel, User>()
                  .ForMember(x => x.EmailAddress, cfg => cfg.MapFrom(y => y.Email))
                  .ForMember(x => x.PhoneNumber, cfg => cfg.MapFrom(y => y.Phone))
                  .ForMember(x => x.Active, cfg => cfg.MapFrom(y => y.IsActive))
                  .ForMember(x => x.Id, cfg => cfg.Ignore());

            Mapper.CreateMap<UserRequest, UserRequestItemModel>()
                .ForMember(x => x.UserId, cfg => cfg.MapFrom(y => y.User != null ? (Guid?)y.User.Id : null));
        }
    }
}