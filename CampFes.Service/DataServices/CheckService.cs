using CampFes.Models.Regis;
using CampFes.Service.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CampFes.Service.DataServices
{
    public class CheckService : ICheckService
    { 
        private IConfiguration Configuration { get; }

        public CheckService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 查詢報到資訊
        /// </summary>
        /// <param name="nick_name"></param>
        /// <param name="phone"></param>
        /// <param name="MSG"></param>
        /// <returns></returns>
        public VM_Checkinfo? CheckInfo(string? nick_name, string? phone, ref string MSG)
        {
            try
            {
                using SqlConnection sConn = new(Configuration.GetConnectionString("AzureConnStr"));
                string sql = @"SP_CAMPFES_CHECKINFO";

                DynamicParameters parameters = new();
                parameters.Add("@MSG", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 200);
                parameters.Add("@NICKNAME", nick_name);
                parameters.Add("@PHONE", phone);

                var checkInfo = sConn.Query<VM_Checkinfo>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList().FirstOrDefault();

                var msg = parameters.Get<string>("MSG");

                if (!string.IsNullOrWhiteSpace(msg))
                {
                    MSG = msg;
                }

                return checkInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 報到作業
        /// </summary>
        /// <param name="rid"></param>
        /// <param name="nick_name"></param>
        /// <returns></returns>
        public string CheckIn(string? rid, string? nick_name)
        {
            try
            {
                using SqlConnection sConn = new(Configuration.GetConnectionString("AzureConnStr"));
                string sql = @"SP_CAMPFES_CHECKIN";

                DynamicParameters parameters = new();
                parameters.Add("@MSG", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 200);
                parameters.Add("@RID", rid);
                parameters.Add("@NICKNAME", nick_name);

                var memberInfo = sConn.Execute(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);

                var msg = parameters.Get<string>("MSG");

                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
