using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampFes.Models.System
{
    /// <summary>
    /// 
    /// </summary>
    public class Function
    {
        /// <summary>
        /// 順序
        /// </summary>
        [Column(TypeName = "int")]
        [Comment("順序")]
        public int? ORDER { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        [Column(TypeName = "nvarchar(20)")]
        [Comment("名字")]
        public string? NAME { get; set; }

        /// <summary>
        /// 路由
        /// </summary>
        [Column(TypeName = "varchar(20)")]
        [Comment("路由")]
        public string? ROUTE { get; set; }

        /// <summary>
        /// 授權等級
        /// </summary>
        [Column(TypeName = "int")]
        [Comment("授權等級")]
        public int? ACCESS_LV { get; set; }

        /// <summary>
        /// 說明
        /// </summary>
        [Column(TypeName = "varchar(100)")]
        [Comment("說明")]
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Column(TypeName = "nvarchar(200)")]
        [Comment("備註")]
        public string? REMARK { get; set; }
    }
}
