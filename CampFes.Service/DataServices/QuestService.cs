using CampFes.Models.Quest;
using CampFes.Service.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CampFes.Service.DataServices
{
    public class QuestService : IQuestService
    {
        private IConfiguration Configuration { get; }

        public QuestService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 新增題目
        /// </summary>
        /// <param name="add_Quest"></param>
        /// <returns></returns>
        public string ADD_QUEST(VM_Add_Quest add_Quest)
        {
            try
            {
                using SqlConnection sConn = new(Configuration.GetConnectionString("AzureConnStr"));
                string sql = @"SP_CAMPFES_ADD_QUEST";

                DynamicParameters parameters = new();
                parameters.Add("@MSG", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 200);
                parameters.Add("@QUESTION", add_Quest.QUESTION);
                parameters.Add("@IS_MULTI", add_Quest.IS_MULTI);
                parameters.Add("@OPTION_A", add_Quest.OPTION_A);
                parameters.Add("@OPTION_B", add_Quest.OPTION_B);
                parameters.Add("@OPTION_C", add_Quest.OPTION_C);
                parameters.Add("@OPTION_D", add_Quest.OPTION_D);
                parameters.Add("@CORRECT", add_Quest.CORRECT);
                parameters.Add("@HINT", add_Quest.HINT);
                parameters.Add("@AUTHOR", add_Quest.AUTHOR);

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
        /// 題目查詢
        /// </summary>
        /// <param name="MSG"></param>
        /// <returns></returns>
        public List<Question> QRY_QUEST(ref string MSG)
        {
            try
            {
                using SqlConnection sConn = new(Configuration.GetConnectionString("AzureConnStr"));
                string sql = @"SP_CAMPFES_QRY_QUEST";

                DynamicParameters parameters = new();
                parameters.Add("@MSG", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 200);

                var qList = sConn.Query<Question>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();

                var msg = parameters.Get<string>("MSG");

                if (!string.IsNullOrWhiteSpace(msg))
                {
                    MSG = msg;
                }

                return qList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 出題
        /// </summary>
        /// <param name="ans_Quest"></param>
        /// <param name="MSG"></param>
        /// <returns></returns>
        public VM_Post_Quest? ASK_QUEST(VM_Ask_Quest ans_Quest, ref string MSG)
        {
            try
            {
                using SqlConnection sConn = new(Configuration.GetConnectionString("AzureConnStr"));
                string sql = @"SP_CAMPFES_ASK_QUEST";

                DynamicParameters parameters = new();
                parameters.Add("@MSG", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 200);
                parameters.Add("@UID", ans_Quest.UID);
                parameters.Add("@FINGERPRINT", ans_Quest.FINGERPRINT);
                parameters.Add("@QRCODE", ans_Quest.QRCODE);

                var question = sConn.Query<VM_Post_Quest>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList().FirstOrDefault();

                var msg = parameters.Get<string>("MSG");

                if (!string.IsNullOrWhiteSpace(msg))
                {
                    MSG = msg;
                }

                return question;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 答題
        /// </summary>
        /// <param name="ans_Quest"></param>
        /// <param name="MSG"></param>
        /// <returns></returns>
        public string? ANSWER(VM_Ans_Quest ans_Quest, ref string MSG)
        {
            try
            {
                using SqlConnection sConn = new(Configuration.GetConnectionString("AzureConnStr"));
                string sql = @"SP_CAMPFES_ANSWER";

                DynamicParameters parameters = new();
                parameters.Add("@MSG", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 200);
                parameters.Add("@CORRECT", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 4);
                parameters.Add("@UID", ans_Quest.UID);
                parameters.Add("@QNO", ans_Quest.QNO);
                parameters.Add("@FINGERPRINT", ans_Quest.FINGERPRINT);
                parameters.Add("@ANSWER", ans_Quest.ANSWER);

                sConn.Execute(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);

                var msg = parameters.Get<string>("MSG");
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    MSG = msg;
                }

                var correct = parameters.Get<string>("CORRECT");

                return correct;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
