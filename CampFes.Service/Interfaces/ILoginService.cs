using CampFes.Models.Login;

namespace CampFes.Service.Interfaces
{
    public interface ILoginService
    {
        /// <summary>
        /// 刷讀QRCODE後 判斷註冊與登入狀態
        /// </summary>
        /// <param name="uni_qrcode"></param>
        /// <param name="fingerprint"></param>
        /// <returns></returns>
        (string, string) CheckUserStatus(string? uni_qrcode, string? fingerprint);

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

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        string? Logout(string? uid);

        /// <summary>
        /// 解除手機綁定
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="nick_name"></param>
        /// <returns></returns>
        string? Unbind(string? uid, string? nick_name);
    }
}
