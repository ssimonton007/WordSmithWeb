////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: GetWordsQuery.cs
//FileType: Visual C# Source file
//Author : Steve Simonton
//Created On : 3/25/2022
//Last Modified On : 
//Copy Rights : TechTock LLC
//Description : XXXXXXXXX
////////////////////////////////////////////////////////////////////////////////////////////////////////

using WordSmith.Query;

namespace WordSmith.Query.Definitions
{
    /// <summary>
    /// 
    /// </summary>
    internal class GetWordsQuery : IQuery<IEnumerable<string>> 
    {
        public string Text { get; private set; }
        /// <summary>
        /// Query Definition Constructor
        /// </summary>
        /// <param name="text">Path to the text file to read</param>
        public GetWordsQuery(string text)
        {
            Text = text;
        }
    }
}
