using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.Domain.Model.Access;
using IdentityAccess.Infrastructure.Access;
using IdentityAccess.Infrastructure.Identity;
using Common.Infrastructure.Encryption;
using System.IO;
using System.Drawing.Imaging;

namespace DataMigrationApp
{
    public class IdentityAccessMigrationService
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IdentityAccessMigrationService(string sourceConnectionString)
        {
            this.SourceConnectionString = sourceConnectionString;
        }

        public string SourceConnectionString { get; set; }

        public void MigrateUser(BackgroundWorker bw)
        {
            try
            {
                DataTable sourceUserTable = new DataTable();

                UserRepository userRepository = new UserRepository();
                RoleRepository roleRepository = new RoleRepository();

                userRepository.RemoveAll();
                roleRepository.RemoveAll();                

                Role administrator = new Role(new RoleId(Guid.NewGuid().ToString()));
                administrator.RoleName = "Administrator";
                administrator.Remark = "";
                administrator.CreateBy = "Matt";

                Role executive = new Role(new RoleId(Guid.NewGuid().ToString()));
                executive.RoleName = "Executive";
                executive.Remark = "";
                executive.CreateBy = "Matt";

                Role reviewer = new Role(new RoleId(Guid.NewGuid().ToString()));
                reviewer.RoleName = "Reviewer";
                reviewer.Remark = "";
                reviewer.CreateBy = "Matt";

                Role screener = new Role(new RoleId(Guid.NewGuid().ToString()));
                screener.RoleName = "Screener";
                screener.Remark = "";
                screener.CreateBy = "Matt";
                

                roleRepository.Add(administrator);
                roleRepository.Add(executive);
                roleRepository.Add(reviewer);
                roleRepository.Add(screener);

                using (OleDbConnection sourceConnection = new OleDbConnection(SourceConnectionString))
                {
                    OleDbDataAdapter sourceAdapter = new OleDbDataAdapter();
                    sourceAdapter.SelectCommand = new OleDbCommand("select * from Users", sourceConnection);
                    sourceAdapter.Fill(sourceUserTable);
                }

                foreach (DataRow row in sourceUserTable.Rows)
                {
                    UserId userId = new UserId(Guid.NewGuid().ToString());
                    if (!string.IsNullOrEmpty(row["Name"].ToString()))
                    {
                        User user = new User();
                        RoleId roleId = new RoleId(screener.RoleId.Id);
                        user.UserId = userId;
                        user.RoleId = roleId.Id;
                        user.UserName = row["Name"].ToString();
                        string encryptPassword = (new MD5EncryptionService()).EncryptedValue("123");
                        user.Password = encryptPassword;
                        user.Address = (string.IsNullOrEmpty(row["Address"].ToString()) ? "" : row["Address"].ToString());
                        user.Other = (string.IsNullOrEmpty(row["Other"].ToString()) ? "" : row["Other"].ToString());
                        user.HiredDate = DateTime.UtcNow;
                        user.Status = IdentityAccess.CommonType.UserStatus.Active;
                        user.EmailAddress = "";

                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            (Properties.Resources.admin).Save(memoryStream, ImageFormat.Png);
                            byte[] imageData = memoryStream.ToArray();
                            user.Avatar = imageData;
                        }

                        userRepository.Add(user);
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                _logger.Error(ex);                
            }
        }
    }
}
