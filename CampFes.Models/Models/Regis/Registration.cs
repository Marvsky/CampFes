using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampFes.Models.Regis
{
    /// <summary>
    /// 報到表
    /// </summary>
    public class Registration
    {
        [Key]
        public int RID { get; set; }

        /// <summary>
        /// 暱稱
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [Comment("報到人暱稱(可多人)")]
        public string? NICK_NAMES { get; set; }

        /// <summary>
        /// 手機
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(MAX)")]
        [Comment("報到人手機(可多組)")]
        public string? PHONES { get; set; }

        /// <summary>
        /// 領取品
        /// </summary>
        [Column(TypeName = "nvarchar(max)")]
        [Comment("領取品")]
        public string? ITEMS { get; set; }

        /// <summary>
        /// 營位
        /// </summary>
        [Column(TypeName = "varchar(10)")]
        [Comment("營位")]
        public string? AREA { get; set; }

        /// <summary>
        /// 領取紀錄
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(1)")]
        [Comment("領取紀錄")]
        public string? IS_RECIEVED { get; set; } = "N";

        /// <summary>
        /// 實際報到人
        /// </summary>
        [Column(TypeName = "nvarchar(20)")]
        [Comment("實際報到人")]
        public string? CHECKER { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Column(TypeName = "nvarchar(200)")]
        [Comment("備註")]
        public string? REMARK { get; set; }

        /// <summary>
        /// 更新時間
        /// </summary>
        [Column(TypeName = "datetime")]
        [Comment("更新時間")]
        public DateTime? UPDATE_TIME { get; set; }
    }
}
