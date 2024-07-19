using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampFes.Models.Login
{
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
        /// 手機
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(max)")]
        [Comment("指紋")]
        public string? FINGERPRINT { get; set; }

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
