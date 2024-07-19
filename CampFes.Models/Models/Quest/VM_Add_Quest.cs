﻿namespace CampFes.Models.Quest
{
    public class VM_Add_Quest
    {
        /// <summary>
        /// 問題
        /// </summary>
        public string? QUESTION { get; set; }

        /// <summary>
        /// 是否為複選題 不填為N
        /// </summary>
        public string? IS_MULTI { get; set; } = "N";

        /// <summary>
        /// 選項A
        /// </summary>
        public string? OPTION_A { get; set; }

        /// <summary>
        /// 選項B
        /// </summary>
        public string? OPTION_B { get; set; }

        /// <summary>
        /// 選項C
        /// </summary>
        public string? OPTION_C { get; set; }

        /// <summary>
        /// 選項D
        /// </summary>
        public string? OPTION_D { get; set; }

        /// <summary>
        /// 答案(複選填法ex: AB)
        /// </summary>
        public string? CORRECT { get; set; }

        /// <summary>
        /// 提示
        /// </summary>
        public string? HINT { get; set; }

        /// <summary>
        /// 出題者
        /// </summary>
        public string? AUTHOR { get; set; }
    }
}
