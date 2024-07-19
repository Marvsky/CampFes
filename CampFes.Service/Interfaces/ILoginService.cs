using CampFes.Models.Login;

namespace CampFes.Service.Interfaces
{
    public interface ILoginService
    {
        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="nick_name"></param>
        /// <param name="fingerprint"></param>
        /// <param name="MSG"></param>
        /// <returns></returns>
        VM_UserInfo? Register(string? nick_name, string? fingerprint, ref string MSG);

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="nick_name"></param>
        /// <param name="fingerprint"></param>
        /// <param name="MSG"></param>
        /// <returns></returns>
        VM_UserInfo? Login(string? nick_name, string? fingerprint, ref string MSG);
    }
}
