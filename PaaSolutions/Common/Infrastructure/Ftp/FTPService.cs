using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure.FTPService
{
    public class FTPService
    {
        private string host = null;
        private string user = null;
        private string pass = null;
        private FtpWebRequest ftpRequest = null;
        private FtpWebResponse ftpResponse = null;

        /* Construct Object */
        public FTPService(string hostIP, string userName, string password) { host = hostIP; user = userName; pass = password; }

        public void createDirectory(string newDirectory)
        {
            try
            {
                if (newDirectory.IndexOf('/') > 0)
                {
                    string[] subDirs = newDirectory.Split('/');
                    string currentDir = "";

                    if (subDirs.Length > 0)
                    {
                        foreach (string dir in subDirs)
                        {
                            try
                            {
                                currentDir = currentDir + "/" + dir;
                                ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + currentDir);

                                ftpRequest.Credentials = new NetworkCredential(user, pass);

                                ftpRequest.UseBinary = true;
                                ftpRequest.UsePassive = true;
                                ftpRequest.KeepAlive = true;

                                ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;

                                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

                                ftpResponse.Close();
                                ftpRequest = null;
                            }
                            catch (Exception ex) { }
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }

        public bool IsValidFolder(string path, string ftpUser, string ftpPassword)
        {
            bool IsExists = true;
            try
            {
                if (path.IndexOf('/') > 0)
                {
                    string[] subDirs = path.Split('/');
                    string currentDir = "";

                    if (subDirs.Length > 0)
                    {
                        foreach (string dir in subDirs)
                        {
                            try
                            {
                                currentDir = currentDir + "/" + dir;
                                ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + currentDir);

                                ftpRequest.Credentials = new NetworkCredential(user, pass);

                                ftpRequest.UseBinary = true;
                                ftpRequest.UsePassive = true;
                                ftpRequest.KeepAlive = true;

                                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;

                                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

                                ftpResponse.Close();
                                ftpRequest = null;
                            }
                            catch (Exception ex) {
                                IsExists = false;
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                IsExists = false;
            }
            return IsExists;
        }

        public void upload(string remoteFile, string localFile)
        {
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
                ftpRequest.Credentials = new NetworkCredential(user, pass);

                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

                StreamReader sourceStream = new StreamReader(localFile);
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
                ftpRequest.ContentLength = fileContents.Length;

                Stream requestStream = ftpRequest.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();

                response.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }

        public void uploadFileDoc(string remoteFile, string localFile)
        {
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
                ftpRequest.Credentials = new NetworkCredential(user, pass);

                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;               

                using (FileStream fs = File.OpenRead(localFile))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                    Stream requestStream = ftpRequest.GetRequestStream();
                    requestStream.Write(buffer, 0, buffer.Length);
                    requestStream.Flush();
                    requestStream.Close();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }

        public void DeleteFile(string path)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host + "/" + path);
                request.Credentials = new NetworkCredential(user, pass);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }

        public bool CheckIfFileExistsOnServer(string path)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host + "/" + path);
            request.Credentials = new NetworkCredential(user, pass);
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    return false;
            }
            return false;
        }  
    }
}
