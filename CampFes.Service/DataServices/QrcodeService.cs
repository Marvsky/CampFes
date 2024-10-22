using CampFes.Models.Login;
using CampFes.Service.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CampFes.Service.DataServices
{
    public class QrcodeService : IQrcodeService
    { 
        private IConfiguration Configuration { get; }

        public QrcodeService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 查詢全部QRCODE名單
        /// </summary>
        /// <param name="MSG"></param>
        /// <returns></returns>
        public List<AllUsers> getQRCodeList(ref string MSG)
        {
            try
            {
                using SqlConnection sConn = new(Configuration.GetConnectionString("AzureConnStr"));
                string sql = @"SP_CAMPFES_QRCODE_LIST";

                DynamicParameters parameters = new();
                parameters.Add("@MSG", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 200);
                var qrCodeList = sConn.Query<AllUsers>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();

                var msg = parameters.Get<string>("MSG");

                if (!string.IsNullOrWhiteSpace(msg))
                {
                    MSG = msg;
                }

                return qrCodeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
