using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaaApplication.Forms;
using System.Text;
using System.Threading;
using Core.Application.AutoMap;
using Invoice.Application.AutoMap;
using TimeCard.AutoMap;
using ZipCodeContext.Application.AutoMap;
using SystemConfiguration.Application.AutoMap;
using CreditReport.Application.AutoMap;

namespace PaaApplication
{
    static class Program 
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            

            using (Mutex mutex = new Mutex(false, @"Global\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Application instance already running!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                GC.Collect();
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                AppDomain.CurrentDomain.UnhandledException += (sender, args) => HandleException((Exception)args.ExceptionObject);
                Application.ThreadException += (sender, args) => HandleException((Exception)args.Exception);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                AutoMapper.Mapper.Initialize(a =>
                {
                    a.AddProfile<CoreContextMapping>();
                    a.AddProfile<CopyContextMapping>();
                    a.AddProfile<InvoiceContextMapping>();
                    a.AddProfile<TimeCardItemMapping>();
                    a.AddProfile<ZipCodeContextMapping>();
                    a.AddProfile<SysConfigContextMapping>();
                    a.AddProfile<CreditReportContextMapping>();
                });
                Application.Run(new FormLogin());
            }
        }

        static void HandleException(Exception ex)
        {
            var sb = new StringBuilder();
            //sb.AppendFormat("Error on thread ID {0}", Thread.CurrentThread.ManagedThreadId);
            //sb.AppendLine().AppendLine();
            sb.AppendLine(ex.Message);
            _logger.Error(ex);

            //Environment.Exit(1);
        }

        private static string appGuid = "39D3698B-2047-48B2-BD1E-EEF1F0CFAAA3";
    }
}

