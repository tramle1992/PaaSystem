using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataMigrationApp
{
    public enum  WorkerTask
    {
        GenerateDummyApplicationSSNNumber,
        GenerateDummyApplicationSpouseSSN,        
        GenerateDummyClientInfoSSNNumber,
        GenerateDummyClientInfoEmail,
        MigrateDataClientInfoManagementCompany,
        MigrateDataClientInfoReportType,
        MigrateDataClientInfoClient,
        MigrateDataClientInfoSpecialPrice,
        MigrateDataInfoResource,
        MigrateDataApplication,
        MigrateDataInvoice,
        UpdateCustomerNumberSetting,
        MigrateUserRole,
        MigrationZipCode,
        MigrationInfoResourceFilePath,
        FixInvoiceDivisionForClient,
        FixInvoiceDivisionForApplication,
        FixInvoiceDivisionForInvoice,
        UpdateClientInfoData,
        UpdateAppData,
        FixClientCustomerSince,
    }
}
