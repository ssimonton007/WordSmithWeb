using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSmithWeb.Shared
{
    public class WordResult
    {
        public WordResult(){}

        public WordResult(string strWord, int intCount)
        {
            word = strWord;
            count = intCount;
        }

        public string word { get; set; }

        public int count { get; set; }
    }
}
