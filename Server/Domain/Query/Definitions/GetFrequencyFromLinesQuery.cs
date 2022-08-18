////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: GetFrequencyFromLinesQuery.cs
//FileType: Visual C# Source file
//Author : Steve Simonton
//Created On : 3/25/2022
//Last Modified On : 
//Copy Rights : TechTock LLC
//Description : Query Definition - Gets Dictionary of Words and the number of times it was used in text
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Concurrent;
using WordSmith.Query;

namespace WordSmith.Query.Definitions
{
    /// <summary>
    /// Gets Dictionary of Words and the number of times it was used in text
    /// </summary>
    internal class GetFrequencyFromLinesQuery : IQuery<ConcurrentDictionary<string, int>> 
    {
        /// <summary>
        /// Text to sample for word frequency
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Word list to ignore in the sampling 
        /// </summary>
        public string ExcludeWords { get; private set; }

        /// <summary>
        /// Query Definition Constructor
        /// </summary>
        /// <param name="text">Text to sample for word frequency</param>
        /// <param name="excludeWords">Word list to ignore in the sampling</param>
        public GetFrequencyFromLinesQuery(string text, string excludeWords)
        {
            Text = text;
            ExcludeWords = excludeWords;
        }
    }
}
