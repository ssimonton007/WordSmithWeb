using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSmithWeb.Shared
{
    public class UploadedBookRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string BookFileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] BookContent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IgnoredWordsFileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] IgnoreWordsContent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int RequestedResults { get; set; }
    }
}
