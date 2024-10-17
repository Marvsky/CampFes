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
        /// 刷讀QRCODE後 判斷註冊與登入狀態
        /// </summary>
        /// <param name="uni_qrcode"></param>
        /// <param name="fingerprint"></param>
        /// <returns></returns>
        public (string, string) CheckUserStatus(string? uni_qrcode, string? fingerprint)
        {
            try
            {
                using SqlConnection sConn = new(Configuration.GetConnectionString("AzureConnStr"));
                string sql = @"SP_CAMPFES_CHECK_USER_STATUS";

                DynamicParameters parameters = new();
                parameters.Add("@MSG", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 200);
                parameters.Add("@UNI_QRCODE", uni_qrcode);
                parameters.Add("@FINGERPRINT", fingerprint);

                sConn.Execute(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);

                var msg = parameters.Get<string>("MSG");
                var status = parameters.Get<string>("STATUS");

                return (status, msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="nick_name"></param>
        /// <param name="fingerprint"></param>
        /// <param name="MSG"></param>
        /// <returns></returns>
        public VM_UserInfo? Register(string? uni_qrcode, string? fingerprint, ref string MSG)
        {
            try
            {
                using SqlConnection sConn = new(Configuration.GetConnectionString("AzureConnStr"));
                string sql = @"SP_CAMPFES_REGIS";

                DynamicParameters parameters = new();
                parameters.Add("@MSG", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 200);
                parameters.Add("@UNI_QRCODE", uni_qrcode);
                parameters.Add("@FINGERPRINT", fingerprint);

                var memberInfo = sConn.Query<VM_UserInfo>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList().FirstOrDefault();

                MSG = parameters.Get<string>("MSG");

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
        public VM_UserInfo? Login(string? uni_qrcode, string? fingerprint, ref string MSG)
        {
            try
            {
                using SqlConnection sConn = new(Configuration.GetConnectionString("AzureConnStr"));
                string sql = @"SP_CAMPFES_LOGIN";

                DynamicParameters parameters = new();
                parameters.Add("@MSG", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 200);
                parameters.Add("@UNI_QRCODE", uni_qrcode);
                parameters.Add("@FINGERPRINT", fingerprint);

                var memberInfo = sConn.Query<VM_UserInfo>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList().FirstOrDefault();

                MSG = parameters.Get<string>("MSG");

                return memberInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public string? Logout(string? uid)
        {
            try
            {
                using SqlConnection sConn = new(Configuration.GetConnectionString("AzureConnStr"));
                string sql = @"SP_CAMPFES_LOGOUT";

                DynamicParameters parameters = new();
                parameters.Add("@MSG", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 200);
                parameters.Add("@UID", uid);

                sConn.Execute(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);

                var msg = parameters.Get<string>("MSG");
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 解除手機綁定
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="nick_name"></param>
        /// <returns></returns>
        public string? Unbind(string? uid, string? nick_name)
        {
            try
            {
                using SqlConnection sConn = new(Configuration.GetConnectionString("AzureConnStr"));
                string sql = @"SP_CAMPFES_LOGOUT";

                DynamicParameters parameters = new();
                parameters.Add("@MSG", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 200);
                parameters.Add("@UID", uid);
                parameters.Add("@NICK_NAME", nick_name);

                sConn.Execute(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);

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
