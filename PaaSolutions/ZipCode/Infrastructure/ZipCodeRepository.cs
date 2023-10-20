using Common.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZipCodeContext.Domain.Model;
using Dapper;

namespace ZipCodeContext.Infrastructure
{
    public class ZipCodeRepository : Repository<ZipCode, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ZipCodeRepository()
        {
        }
        public override void Add(ZipCode item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string insertStatement = @"insert into zipcode (zipcode_id, zipcode_name, zipcode_type, city, city_type, county, state, state_code, timezone, gmt_offset, dst, latitude, longitude, area_code) values (@zipcode_id, @zipcode_name, @zipcode_type, @city, @city_type, @county, @state, @state_code, @timezone, @gmt_offset, @dst, @latitude, @longitude, @area_code)";

                    var args = new DynamicParameters();
                    args.Add("zipcode_id", item.ZipCodeId);
                    args.Add("zipcode_name", item.ZipCodeName);
                    args.Add("zipcode_type", item.ZipCodeType);
                    args.Add("city", item.City);
                    args.Add("city_type", item.CityType);
                    args.Add("county", item.County);
                    args.Add("state", item.State);
                    args.Add("state_code", item.StateCode);
                    args.Add("timezone", item.TimezoneName);
                    args.Add("gmt_offset", item.GMTOffset);
                    args.Add("dst", item.DST);
                    args.Add("latitude", item.Latitude);
                    args.Add("longitude", item.Longitude);
                    args.Add("area_code", item.AreaCode);

                    cn.Execute(insertStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override ZipCode Find(string id)
        {
            throw new NotImplementedException();
        }

        public override void Remove(ZipCode item)
        {
            throw new NotImplementedException();
        }

        public override void Update(ZipCode item)
        {
            throw new NotImplementedException();
        }
        
        public void RemoveAll()
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from zipcode";

                    cn.Execute(deleteStatement);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public List<ZipCode> FindAll()
        {
            List<ZipCode> zipcodes = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select * from zipcode";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    if (result != null)
                    {
                        zipcodes = new List<ZipCode>();
                        foreach (var item in result)
                        {
                            if (item != null && !string.IsNullOrEmpty(item.zipcode_id))
                            {
                                ZipCode zc = new ZipCode(item.zipcode_id);

                                zc.AreaCode = item.area_code;
                                zc.City = item.city;
                                zc.CityType = item.city_type;
                                zc.County = item.county;
                                zc.DST = item.dst;
                                zc.GMTOffset = item.gmt_offset;
                                zc.Latitude = item.latitude;
                                zc.Longitude = item.longitude;
                                zc.State = item.state;
                                zc.StateCode = item.state_code;
                                zc.ZipCodeName = item.zipcode_name;
                                zc.TimezoneName = item.timezone;

                                zipcodes.Add(zc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return zipcodes;
        }

        public List<ZipCode> FindAllByColumn(string column)
        {
            List<ZipCode> zipcodes = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = string.Empty;

                    if (column == "ALL")
                    {
                        findStatement = string.Format(@"select city, state, zipcode_name, county from zipcode group by city, state, zipcode_name, county order by city, state, zipcode_name, county ");
                    }
                    else if (column == "Area_Code")
                    {
                        findStatement = string.Format(@"select city, state, zipcode_name, {0} from zipcode group by city, state, zipcode_name, {0} order by city, state, zipcode_name, {0}", column.ToLower());
                    }
                    else
                    {
                        findStatement = string.Format(@"select city, state, {0} from zipcode group by city, state, {0} order by city, state, {0}", column.ToLower());
                    }

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    if (result != null)
                     {
                        zipcodes = new List<ZipCode>();
                        foreach (var item in result)
                        {
                            if (item != null)
                            {
                                var id = new Guid();
                                ZipCode zc = new ZipCode(id.ToString());
                                if (column.Equals("County"))
                                {
                                    zc.City = item.city;
                                    zc.County = item.county;
                                    zc.State = item.state;
                                }
                                else if (column.Equals("Area_Code"))
                                {
                                    zc.City = item.city;
                                    zc.AreaCode = item.area_code;
                                    zc.State = item.state;
                                    zc.ZipCodeName = item.zipcode_name;
                                }
                                else if (column.Equals("ALL"))
                                {
                                    zc.City = item.city;
                                    zc.ZipCodeName = item.zipcode_name;
                                    zc.State = item.state;
                                    zc.County = item.county;
                                }
                                zipcodes.Add(zc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return zipcodes;
        }
    }
}
