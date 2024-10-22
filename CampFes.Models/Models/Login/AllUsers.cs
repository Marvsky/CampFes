using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampFes.Models.Login
{
    /// <summary>
    /// 註冊使用者
    /// </summary>
    public class AllUsers
    {
        /// <summary>
        /// 序號
        /// </summary>
        [Column(TypeName = "int")]
        [Comment("序號")]
        public int SNO {  get; set; }

        /// <summary>
        /// 報名序號
        /// </summary>
        [Column(TypeName = "int")]
        [Comment("報名序號")]
        public int? GROUPNO { get; set; }

        /// <summary>
        /// 報到代表人
        /// </summary>
        [Column(TypeName = "nvarchar(20)")]
        [Comment("報到代表人")]
        public string? CHECKER { get; set; }

        /// <summary>
        /// 暱稱
        /// </summary>
        [Column(TypeName = "nvarchar(20)")]
        [Comment("暱稱")]
        public string? NICK_NAME { get; set; }

        /// <summary>
        /// 營位
        /// </summary>
        [Column(TypeName = "varchar(10)")]
        [Comment("營位")]
        public string? AREA { get; set; }

        /// <summary>
        /// 權限角色
        /// </summary>
        [Column(TypeName = "varchar(20)")]
        [Comment("權限角色")]
        public string? ROLE {  get; set; }

        /// <summary>
        /// 電子身分證
        /// </summary>
        [Column(TypeName = "varchar(8)")]
        [Comment("電子身分證")]
        public string? UNI_QRCODE { get; set; }
    }
}
