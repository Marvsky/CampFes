using CampFes.Models.Qrcode;

namespace CampFes.Service.Interfaces
{
    public interface IQrcodeService
    {
        /// <summary>
        /// 查詢全部QRCODE名單
        /// </summary>
        /// <param name="MSG"></param>
        /// <returns></returns>
        List<NamePlate> GetQRCodeList(ref string MSG);
    }
}
