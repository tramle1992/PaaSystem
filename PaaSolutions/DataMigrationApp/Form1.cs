using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;
using InfoResource.Domain.Model.InfoResource;
using InfoResource.Infrastructure.InfoResource;
using Invoice.Infrastructure;

namespace DataMigrationApp
{
    public partial class frmDataMigration : Form
    {
        private string sourceConnectionString = "";

        private MigrationService migrationService;

        private IdentityAccessMigrationService identityAccessMigrationService;

        private AppMigrationService appMigrationService;

        private InvoiceMigrationService invoiceMigrationService;

        private static List<object> arguments = new List<object>();

        private AppIdMappingRepository appIdMappingRepository = new AppIdMappingRepository();

        public Dictionary<string, string> appIdDictionary = new Dictionary<string, string>(); // oldAppId - newAppId

        public frmDataMigration()
        {
            InitializeComponent();

            migrationService = new MigrationService("");

            identityAccessMigrationService = new IdentityAccessMigrationService("");

            appMigrationService = new AppMigrationService("", this.appIdDictionary);

            invoiceMigrationService = new InvoiceMigrationService("", this.appIdDictionary);
        }

        private void chooseSourceFileButton_Click(object sender, EventArgs e)
        {
            sourceOpenFileDialog.Filter = "Mdb Files (.mdb)|*.mdb";
            sourceOpenFileDialog.FilterIndex = 1;
            sourceOpenFileDialog.Multiselect = true;
            DialogResult result = sourceOpenFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = sourceOpenFileDialog.FileName;
                chooseSourceFileTextBox.Text = file;

                sourceConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                    "Data Source=" + file + ";" +
                    "Persist Security Info=True;";
                migrationService.SourceConnectionString = sourceConnectionString;

                identityAccessMigrationService.SourceConnectionString = sourceConnectionString;

                appMigrationService.SourceConnectionString = sourceConnectionString;

                invoiceMigrationService.SourceConnectionString = sourceConnectionString;
            }
        }

        #region Generate dummy keys functions

        private void GenerateDummyClientEmail(BackgroundWorker bw)
        {
            try
            {
                DataTable clientTable = new DataTable();

                using (OleDbConnection sourceConnection = new OleDbConnection(sourceConnectionString))
                {
                    OleDbDataAdapter sourceAdapter = new OleDbDataAdapter();
                    sourceAdapter.SelectCommand = new OleDbCommand("SELECT PrimaryKey, Email FROM Clients", sourceConnection);
                    sourceAdapter.UpdateCommand = new OleDbCommand("UPDATE Clients SET Email = @Email WHERE PrimaryKey = @PrimaryKey", sourceConnection);
                    sourceAdapter.UpdateCommand.Parameters.Add("@AppSSN", OleDbType.VarWChar, 255, "Email");
                    OleDbParameter parameter = sourceAdapter.UpdateCommand.Parameters.Add("@PrimaryKey", OleDbType.Integer);
                    parameter.SourceColumn = "PrimaryKey";
                    parameter.SourceVersion = DataRowVersion.Original;
                    sourceAdapter.Fill(clientTable);

                    int numRows = clientTable.Rows.Count;

                    var loopCount = (numRows / 1000) + 1;

                    for (int i = 0; i <= loopCount; i++)
                    {
                        DataTable dtPage = clientTable.Rows.Cast<System.Data.DataRow>().Skip((i) * 1000).Take(1000).CopyToDataTable();

                        if (dtPage.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtPage.Rows)
                            {
                                var orgEmail = row["Email"].ToString();

                                if (!string.IsNullOrEmpty(orgEmail))
                                {
                                    row["Email"] = Faker.Internet.Email();
                                }

                                bw.ReportProgress((i * 100) / (loopCount - 1));
                            }
                        }
                        sourceAdapter.Update(dtPage);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }

        private void GenerateDummyApplicationAppSSN(BackgroundWorker bw)
        {
            try
            {
                chooseSourceFileTextBox.Enabled = false;
                DataTable applicationTable = new DataTable();

                using (OleDbConnection sourceConnection = new OleDbConnection(sourceConnectionString))
                {
                    OleDbDataAdapter sourceAdapter = new OleDbDataAdapter();
                    sourceAdapter.SelectCommand = new OleDbCommand("SELECT PrimaryKey, AppSSN FROM Applications", sourceConnection);
                    sourceAdapter.UpdateCommand = new OleDbCommand("UPDATE Applications SET AppSSN = @AppSSN WHERE PrimaryKey = @PrimaryKey", sourceConnection);
                    sourceAdapter.UpdateCommand.Parameters.Add("@AppSSN", OleDbType.VarWChar, 255, "AppSSN");

                    OleDbParameter parameter = sourceAdapter.UpdateCommand.Parameters.Add("@PrimaryKey", OleDbType.Integer);

                    parameter.SourceColumn = "PrimaryKey";
                    parameter.SourceVersion = DataRowVersion.Original;
                    sourceAdapter.Fill(applicationTable);

                    int numRows = applicationTable.Rows.Count;

                    var loopCount = (numRows / 1000) + 1;

                    for (int i = 0; i <= loopCount; i++)
                    {
                        DataTable dtPage = applicationTable.Rows.Cast<System.Data.DataRow>().Skip((i) * 1000).Take(1000).CopyToDataTable();

                        if (dtPage.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtPage.Rows)
                            {
                                var orgAppSSN = row["AppSSN"].ToString();

                                if (!string.IsNullOrEmpty(orgAppSSN))
                                {
                                    row["AppSSN"] = SSNFaker.GetSSNNumber();
                                }

                                bw.ReportProgress((i * 100) / (loopCount - 1));
                            }
                        }

                        sourceAdapter.Update(dtPage);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }

        private void GenerateDummyApplicationSpouseSSN(BackgroundWorker bw)
        {
            try
            {
                DataTable applicationTable = new DataTable();

                using (OleDbConnection sourceConnection = new OleDbConnection(sourceConnectionString))
                {
                    OleDbDataAdapter sourceAdapter = new OleDbDataAdapter();
                    sourceAdapter.SelectCommand = new OleDbCommand("SELECT PrimaryKey, SpouseSSN FROM Applications", sourceConnection);
                    sourceAdapter.UpdateCommand = new OleDbCommand("UPDATE Applications SET SpouseSSN = @SpouseSSN WHERE PrimaryKey = @PrimaryKey", sourceConnection);

                    sourceAdapter.UpdateCommand.Parameters.Add("@SpouseSSN", OleDbType.VarWChar, 255, "SpouseSSN");
                    OleDbParameter parameter = sourceAdapter.UpdateCommand.Parameters.Add("@PrimaryKey", OleDbType.Integer);

                    parameter.SourceColumn = "PrimaryKey";
                    parameter.SourceVersion = DataRowVersion.Original;
                    sourceAdapter.Fill(applicationTable);

                    int numRows = applicationTable.Rows.Count;

                    var loopCount = (numRows / 1000) + 1;

                    for (int i = 0; i <= loopCount; i++)
                    {
                        DataTable dtPage = applicationTable.Rows.Cast<System.Data.DataRow>().Skip((i) * 1000).Take(1000).CopyToDataTable();

                        if (dtPage.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtPage.Rows)
                            {
                                var orgAppSSN = row["SpouseSSN"].ToString();

                                if (!string.IsNullOrEmpty(orgAppSSN))
                                {
                                    row["SpouseSSN"] = SSNFaker.GetSSNNumber();
                                }

                                bw.ReportProgress((i * 100) / (loopCount - 1));
                            }
                        }

                        sourceAdapter.Update(dtPage);
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }

        #endregion

        #region TaskBackGroundWorker Events

        private void taskBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker bw = sender as BackgroundWorker;

            var workTask = (WorkerTask)e.Argument;
            switch (workTask)
            {
                case WorkerTask.GenerateDummyApplicationSSNNumber:
                    GenerateDummyApplicationAppSSN(bw);
                    break;
                case WorkerTask.GenerateDummyClientInfoEmail:
                    GenerateDummyClientEmail(bw);
                    break;
                case WorkerTask.GenerateDummyApplicationSpouseSSN:
                    GenerateDummyApplicationSpouseSSN(bw);
                    break;
                case WorkerTask.MigrateDataInfoResource:
                    migrationService.MigrateInfoResource(bw);
                    break;
                case WorkerTask.MigrateDataClientInfoManagementCompany:
                    migrationService.MigrateClientInfoManagementCompany(bw);
                    break;
                case WorkerTask.MigrateDataClientInfoReportType:
                    migrationService.MigrateClientInfoReportType(bw);
                    break;
                case WorkerTask.MigrateDataClientInfoClient:
                    migrationService.MigrateClientInfoClient(bw);
                    break;
                case WorkerTask.MigrateDataClientInfoSpecialPrice:
                    migrationService.MigrateClientInfoSpecialPrice(bw);
                    break;
                case WorkerTask.UpdateCustomerNumberSetting:
                    migrationService.InitialCustomerNumberSetting(bw);
                    break;
                case WorkerTask.MigrateUserRole:
                    identityAccessMigrationService.MigrateUser(bw);
                    break;
                case WorkerTask.MigrateDataApplication:
                    appMigrationService.MigrateApp(bw);
                    break;
                case WorkerTask.MigrateDataInvoice:
                    invoiceMigrationService.MigrateInvoice();
                    break;
                case WorkerTask.MigrationZipCode:
                    migrationService.MigrateZipCode(bw);
                    break;
                case WorkerTask.MigrationInfoResourceFilePath:
                    migrationService.MigrateInfoResourceFilePath(bw);
                    break;
                case WorkerTask.FixInvoiceDivisionForClient:
                    migrationService.FixInvoiceDivisionForClient(bw);
                    break;
                case WorkerTask.FixInvoiceDivisionForApplication:
                    migrationService.FixInvoiceDivisionForApplication(bw);
                    break;
                case WorkerTask.FixInvoiceDivisionForInvoice:
                    migrationService.FixInvoiceDivisionForInvoice(bw);
                    break;
                case WorkerTask.UpdateClientInfoData:
                    migrationService.UpdateClientInfoData(bw);
                    break;
                case WorkerTask.UpdateAppData:
                    appMigrationService.UpdateAppData(bw);
                    break;
                case WorkerTask.FixClientCustomerSince:
                    migrationService.FixClientCustomerSince(bw);
                    break;
            }
        }

        private void taskBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            taskProgressBar.Value = e.ProgressPercentage;
        }

        private void taskBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Update finised", "Migration App", MessageBoxButtons.OK);
            chooseSourceFileTextBox.Enabled = true;
            if (result == DialogResult.OK)
            {
                ResetProgressBar();
            }
        }

        #endregion

        private void ResetProgressBar()
        {
            taskProgressBar.Maximum = 100;
            taskProgressBar.Step = 1;
            taskProgressBar.Value = 0;
        }

        private void frmDataMigration_Load(object sender, EventArgs e)
        {

        }

        #region Events onClick
        private void dummySSNToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ResetProgressBar();
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.GenerateDummyApplicationSSNNumber);
        }

        private void dummySpouseSSNToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ResetProgressBar();
            chooseSourceFileTextBox.Enabled = true;
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.GenerateDummyApplicationSpouseSSN);
        }

        private void dummyEmailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ResetProgressBar();
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.GenerateDummyClientInfoEmail);
        }

        private void infoResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetProgressBar();
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.MigrateDataInfoResource);
        }

        private void managementCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetProgressBar();
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.MigrateDataClientInfoManagementCompany);
        }

        private void reportTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetProgressBar();
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.MigrateDataClientInfoReportType);
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetProgressBar();
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.MigrateDataClientInfoClient);
        }

        private void specialPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetProgressBar();
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.MigrateDataClientInfoSpecialPrice);
        }

        private void custNumberSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetProgressBar();
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.UpdateCustomerNumberSetting);
        }

        #endregion


        private void migrateAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.MigrateDataApplication);
        }

        private void migrationInvoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.MigrateDataInvoice);
        }

        private void infoResourceFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.MigrationInfoResourceFilePath);
        }
        private void createAppIdMappingTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            appIdMappingRepository.CreateTable();
        }

        private void dropAppIdMappingTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            appIdMappingRepository.DropTable();
        }

        private void migrationUserToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.MigrateUserRole);
        }

        private void migrateZipcodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.MigrationZipCode);
        }

        private void forClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This action will remove all empty invoice divisions of all clients. Do you want continue?",
                            "Confirmation",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                taskBackgroundWorker.RunWorkerAsync(WorkerTask.FixInvoiceDivisionForClient);
            }
        }

        private void forApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This action will convert invoice division of all applications from empty to \"None\". Do you want continue?",
                            "Confirmation",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                taskBackgroundWorker.RunWorkerAsync(WorkerTask.FixInvoiceDivisionForApplication);
            }
        }

        private void forInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This action will convert invoice division of all invoices from \"None\" to empty. Do you want continue?",
                            "Confirmation",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                taskBackgroundWorker.RunWorkerAsync(WorkerTask.FixInvoiceDivisionForInvoice);
            }
        }

        private void updateClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.UpdateClientInfoData);
        }

        private void updateApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.UpdateAppData);
        }

        private void fixCustomerSinceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taskBackgroundWorker.RunWorkerAsync(WorkerTask.FixClientCustomerSince);
        }
    }
}
