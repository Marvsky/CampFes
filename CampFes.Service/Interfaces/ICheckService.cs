using CampFes.Models.Regis;

namespace CampFes.Service.Interfaces
{
    public interface ICheckService
    {
        /// <summary>
        /// 查詢報到資訊
        /// </summary>
        /// <param name="nick_name"></param>
        /// <param name="phone"></param>
        /// <param name="MSG"></param>
        /// <returns></returns>
        VM_Checkinfo? CheckInfo(string? nick_name, string? phone, ref string MSG);

        /// <summary>
        /// 報到作業
        /// </summary>
        /// <param name="rid"></param>
        /// <param name="nick_name"></param>
        /// <returns></returns>
        string CheckIn(string? rid, string? nick_name);
    }
}
