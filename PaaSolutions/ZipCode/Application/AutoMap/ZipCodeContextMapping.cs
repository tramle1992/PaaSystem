using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZipCodeContext.Application.Data;
using ZipCodeContext.Domain.Model;

namespace ZipCodeContext.Application.AutoMap
{
    public class ZipCodeContextMapping : AutoMapper.Profile
    {
        public ZipCodeContextMapping()
        {
            CreateMap<ZipCode, ZipCodeData>();
            CreateMap<ZipCodeData, ZipCode>();
        }
    }
}
