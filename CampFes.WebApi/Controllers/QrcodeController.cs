using CampFes.Models.Qrcode;
using CampFes.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using SixLabors.ImageSharp;
using System.IO.Compression;
using Microsoft.Reporting.NETCore;
using Microsoft.AspNetCore.Hosting;

namespace CampFes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrcodeController : ControllerBase
    {
        private readonly IWebHostEnvironment WebHostEnvironment;
        private ILogger Logger { get; }
        private IConfiguration Configuration { get; }
        private IQrcodeService QrcodeService { get; }

        //角色分類
        private static readonly string[] StaffRole = ["Admin", "Staff", "Staff_NP", "Supplier", "Performer", "Performer_NP"];
        private static readonly string[] GuestRole = ["Guest", "Player"];
        private static readonly string[] EntourageRole = ["Entourage"];

        public QrcodeController(IWebHostEnvironment webHostEnvironment, ILogger<QrcodeController> ilogger, IConfiguration configuration, IQrcodeService qrcodeService)
        {
            WebHostEnvironment = webHostEnvironment;
            Logger = ilogger;
            Logger.LogInformation("Nlog injeceted into QrcodeController");
            Configuration = configuration;
            QrcodeService = qrcodeService;
        }

        /// <summary>
        /// 產生QRCODE圖檔
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("generate-zip")]
        public IActionResult GenerateQRCodeZip()
        {
            try
            {
                string errMsg = "";

                List<NamePlate> qList = QrcodeService.GetQRCodeList(ref errMsg);


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

        /// <summary>
        /// 產生名牌ZIP
        /// </summary>
        /// <param name="filter">1:Staff 2:一般 3:表演者隨行 無:全部</param>
        /// <returns></returns>
        [HttpPost]
        [Route("generatePlate-zip")]
        public IActionResult GenerateFamousQRCodeZip(string? filter)
        {
            try
            {
                string ZipFIleName = "Qrcodes";
                string errMsg = "";

                List<NamePlate> qList = QrcodeService.GetQRCodeList(ref errMsg);

                //篩選名牌身分組
                switch (filter)
                {
                    case "1": //Staff
                        qList = qList.Where(x => StaffRole.Contains(x.ROLE)).ToList();
                        ZipFIleName = "Staff";
                        break;
                    case "2": //一般參加者
                        qList = qList.Where(x => GuestRole.Contains(x.ROLE)).ToList();
                        ZipFIleName = "Guest";
                        break;
                    case "3": //隨行者
                        qList = qList.Where(x => EntourageRole.Contains(x.ROLE)).ToList();
                        ZipFIleName = "Entourage";
                        break;
                    default: //全部
                        break;
                }

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
                        string qrCodeBase64 = Convert.ToBase64String(imageData);

                        string rdlcName = "";
                        bool is_staff = StaffRole.Any(x => x == user.ROLE);
                        bool is_guest = GuestRole.Any(x => x == user.ROLE);
                        bool is_entourage = EntourageRole.Any(x => x == user.ROLE);
                        if (is_staff)
                            rdlcName = "Staff.rdlc";
                        else if (is_entourage)
                            rdlcName = "Entourage.rdlc";
                        else //訪客
                            rdlcName = "Guest.rdlc";

                        // 將 QRCode 圖片數據傳遞給 RDLC 報表
                        var ReportPath = Path.Combine(WebHostEnvironment.ContentRootPath, "RDLC", rdlcName);
                        LocalReport localReport = new()
                        {
                            ReportPath = ReportPath,

                            // 啟用外部圖片支持
                            EnableExternalImages = true
                        };

                        List<ReportParameter> parameters =
                        [
                            new ReportParameter("NICK_NAME", user.NICK_NAME),
                            new ReportParameter("QRCODE", qrCodeBase64)
                        ];
                        localReport.SetParameters(parameters);

                        // 設置裝置資訊參數，以自定義 PNG 的輸出寬度和高度
                        string deviceInfo = $@"
                        <DeviceInfo>
                            <OutputFormat>PNG</OutputFormat>
                            <PageWidth>17.7cm</PageWidth>
                            <PageHeight>11.2cm</PageHeight>
                            <MarginTop>0.1cm</MarginTop>
                            <MarginLeft>0.1cm</MarginLeft>
                            <MarginRight>0.1cm</MarginRight>
                            <MarginBottom>0.1cm</MarginBottom>
                        </DeviceInfo>";

                        // 渲染 RDLC 為 PNG 格式
                        byte[] renderedBytes = localReport.Render(
                            "Image", // 渲染成圖片
                            deviceInfo,
                            out string mimeType, out string encoding, out string fileNameExtension,
                            out string[] streams, out Warning[] warnings);

                        // 將渲染後的 PNG 圖片存入 ZIP 文件
                        var zipEntry = zipArchive.CreateEntry($"{user.SNO}_{user.NICK_NAME ?? user.QRCODE}.png");
                        using var entryStream = zipEntry.Open();
                        entryStream.Write(renderedBytes, 0, renderedBytes.Length);
                    }
                }

                // 設置 ZIP 文件流的位置到開始處
                zipStream.Seek(0, SeekOrigin.Begin);

                // 返回 ZIP 文件
                return File(zipStream, "application/zip", $"{ZipFIleName}.zip");

            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{errMsg}", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }

}
