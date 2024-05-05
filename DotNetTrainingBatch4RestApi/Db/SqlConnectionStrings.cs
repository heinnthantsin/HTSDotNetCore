﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch4RestApi.Db;

internal static class SqlConnectionStrings
{
    public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "nick", //server name
        InitialCatalog = "DotNetBatch4", // database name
        UserID = "sa",
        Password = "sasa@123",
        TrustServerCertificate = true
    };
}
