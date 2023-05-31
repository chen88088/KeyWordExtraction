using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordExtraction
{
    /// <summary>
    /// 發出請求的物件
    /// </summary>
    public class AskAiRequest
    {
        /// <summary>
        /// RequestParameter -- prompt
        /// </summary>
        public string Prompt { get; set; }

        /// <summary>
        /// RequestParameter -- message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// RequestParameter -- temperature
        /// </summary>
        public double Temperature { get; set; }

        /// <summary>
        /// RequestParameter -- max_Tokens
        /// </summary>
        public int Max_Tokens { get; set; }

        /// <summary>
        /// RequestParameter -- presence_Penalty
        /// </summary>
        public double Presence_Penalty { get; set; }


    }
}
