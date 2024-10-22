using CampFes.Models.Login;

namespace CampFes.Service.Interfaces
{
    public interface IQrcodeService
    {
        /// <summary>
        /// 查詢全部QRCODE名單
        /// </summary>
        /// <param name="MSG"></param>
        /// <returns></returns>
        List<AllUsers> getQRCodeList(ref string MSG);
    }
}
