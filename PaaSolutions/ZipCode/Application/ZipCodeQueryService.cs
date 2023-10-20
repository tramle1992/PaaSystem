using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZipCodeContext.Application.Data;
using ZipCodeContext.Domain.Model;
using ZipCodeContext.Infrastructure;

namespace ZipCodeContext.Application
{
    public class ZipCodeQueryService
    {
        private readonly ZipCodeRepository repository;

        public ZipCodeQueryService()
        {
            repository = new ZipCodeRepository();
        }

        public List<ZipCodeData> GetAll()
        {
            List<ZipCode> zipcodeList = repository.FindAll();
            List<ZipCodeData> zipcodeDataList = null;
            if (zipcodeList != null && zipcodeList.Count > 0)
            {
                zipcodeDataList = new List<ZipCodeData>(zipcodeList.Count);
                foreach (ZipCode zc in zipcodeList)
                {
                    if (zc != null && !string.IsNullOrEmpty(zc.ZipCodeId))
                    {
                        ZipCodeData zcData = AutoMapper.Mapper.Map<ZipCode, ZipCodeData>(zc);
                        zipcodeDataList.Add(zcData);
                    }
                }
            }
            return zipcodeDataList;
        }

        public List<ZipCodeData> GetAllByColumn(string column)
        {
            List<ZipCode> zipcodeList = repository.FindAllByColumn(column);
            List<ZipCodeData> zipcodeDataList = null;
            if (zipcodeList != null && zipcodeList.Count > 0)
            {
                zipcodeDataList = new List<ZipCodeData>(zipcodeList.Count);
                foreach (ZipCode zc in zipcodeList)
                {
                    if (zc != null && !string.IsNullOrEmpty(zc.ZipCodeId))
                    {
                        ZipCodeData zcData = AutoMapper.Mapper.Map<ZipCode, ZipCodeData>(zc);
                        zipcodeDataList.Add(zcData);
                    }
                }
            }
            return zipcodeDataList;
        }
    }
}
