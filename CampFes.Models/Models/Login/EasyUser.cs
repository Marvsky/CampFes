using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampFes.Models.Login
{
    /// <summary>
    /// 註冊使用者
    /// </summary>
    public class EasyUser
    {
        [Key]
        public int UID { get; set; }

        /// <summary>
        /// 暱稱
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [Comment("暱稱")]
        public string? NICK_NAME { get; set; }

        /// <summary>
        /// 手機指紋
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(max)")]
        [Comment("手機指紋")]
        public string? FINGERPRINT { get; set; }

        /// <summary>
        /// 電子身分證
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(max)")]
        [Comment("電子身分證")]
        public string? UNI_QRCODE { get; set; }

        /// <summary>
        /// 登入狀態 N:未登入 Y:登入中
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(1)")]
        [Comment("是否登入中")]
        public string? IS_LOGIN { get; set; }

        /// <summary>
        /// PID
        /// </summary>
        [Column(TypeName = "int")]
        [Comment("闖關獎品編號")]
        public int? PID { get; set; }

        /// <summary>
        /// 領取紀錄 N:未領取 Y:已領取
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(1)")]
        [Comment("領取紀錄")]
        public string? IS_RECIEVED { get; set; } = "N";

        /// <summary>
        /// 備註
        /// </summary>
        [Column(TypeName = "nvarchar(100)")]
        [Comment("備註")]
        public string? REMARK { get; set; }

        /// <summary>
        /// 權限角色
        /// </summary>
        [Column(TypeName = "varchar(10)")]
        [Comment("權限角色")]
        public string? ROLE {  get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        [Column(TypeName = "datetime")]
        [Comment("建立時間")]
        public DateTime? CREATE_TIME { get; set; }
    }
}
