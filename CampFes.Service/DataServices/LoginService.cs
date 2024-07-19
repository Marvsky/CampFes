using CampFes.Models.Login;
using CampFes.Service.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CampFes.Service.DataServices
{
    public class LoginService : ILoginService
    { 
        private IConfiguration Configuration { get; }

        public LoginService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="nick_name"></param>
        /// <param name="fingerprint"></param>
        /// <param name="MSG"></param>
        /// <returns></returns>
        public VM_UserInfo? Register(string? nick_name, string? fingerprint, ref string MSG)
        {
            try
            {
                using SqlConnection sConn = new(Configuration.GetConnectionString("AzureConnStr"));
                string sql = @"SP_CAMPFES_REGIS";

                DynamicParameters parameters = new();
                parameters.Add("@MSG", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 200);
                parameters.Add("@NICKNAME", nick_name);
                parameters.Add("@FINGERPRINT", fingerprint);

                var memberInfo = sConn.Query<VM_UserInfo>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList().FirstOrDefault();

                var msg = parameters.Get<string>("MSG");

                if (!string.IsNullOrWhiteSpace(msg))
                {
                    MSG = msg;
                }

                return memberInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="nick_name"></param>
        /// <param name="fingerprint"></param>
        /// <param name="MSG"></param>
        /// <returns></returns>
        public VM_UserInfo? Login(string? nick_name, string? fingerprint, ref string MSG)
        {
            try
            {
                using SqlConnection sConn = new(Configuration.GetConnectionString("AzureConnStr"));
                string sql = @"SP_CAMPFES_LOGIN";

                DynamicParameters parameters = new();
                parameters.Add("@MSG", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 200);
                parameters.Add("@NICKNAME", nick_name);
                parameters.Add("@FINGERPRINT", fingerprint);

                var memberInfo = sConn.Query<VM_UserInfo>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList().FirstOrDefault();

                var msg = parameters.Get<string>("MSG");

                if (!string.IsNullOrWhiteSpace(msg))
                {
                    MSG = msg;
                }

                return memberInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
