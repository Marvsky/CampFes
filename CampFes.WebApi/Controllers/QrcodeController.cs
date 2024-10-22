using CampFes.Models.Login;
using CampFes.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using SixLabors.ImageSharp;
using System.IO.Compression;

namespace CampFes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrcodeController : ControllerBase
    {
        private ILogger Logger { get; }
        private IConfiguration Configuration { get; }
        private IQrcodeService QrcodeService { get; }


        public QrcodeController(ILogger<QrcodeController> ilogger, IConfiguration configuration, IQrcodeService qrcodeService)
        {
            Logger = ilogger;
            Logger.LogInformation("Nlog injeceted into QrcodeController");
            Configuration = configuration;
            QrcodeService = qrcodeService;
        }


        [HttpPost]
        [Route("generate-zip")]
        public IActionResult GenerateQRCodeZip()
        {
            try
            {
                string errMsg = "";

                List<AllUsers> qList = QrcodeService.getQRCodeList(ref errMsg);


                // 創建一個 MemoryStream 來存放 ZIP 檔案
                var zipStream = new MemoryStream(); // 這裡不要使用 using，讓 zipStream 由外部管理
                                                    // 創建 ZIP 檔案
                using (var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                {
                    var appUrl = Configuration.GetSection("RegisUrl").Value;

                    foreach (var user in qList)
                    {
                        string text = appUrl + user.UNI_QRCODE;
                        using QRCodeGenerator qrGenerator = new();
                        using QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
                        using PngByteQRCode qrCode = new(qrCodeData);
                        byte[] imageData = qrCode.GetGraphic(10);

                        using var image = Image.Load(imageData);

                        // 將圖片添加到 ZIP 檔案
                        var zipEntry = zipArchive.CreateEntry($"{user.NICK_NAME}.png");
                        using (var entryStream = zipEntry.Open())
                        {
                            // 將圖片保存到 ZIP 檔案中的 entryStream
                            image.SaveAsPng(entryStream);
                        }
                    }
                }

                // 設置 ZIP 文件流的位置到開始處
                zipStream.Seek(0, SeekOrigin.Begin);

                // 返回 ZIP 文件
                return File(zipStream, "application/zip", "qrcodes.zip");

            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{errMsg}", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }

}
