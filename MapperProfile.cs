using AutoMapper;
using LLPApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LLPApp
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DeviceModelCreateViewModel, DeviceModel>();

            CreateMap<DeviceModel, DeviceModelEditViewModel>();
            CreateMap<DeviceModelEditViewModel, DeviceModel>();
        }
    }
}
