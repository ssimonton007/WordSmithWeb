////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: BookService.cs
//FileType: Visual C# Source file
//Author : Steve Simonton
//Created On : 8/15/2022
//Last Modified On : 
//Copy Rights : TechTock LLC
//Description : Everything books implementation
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Concurrent;
using WordSmith.Command;
using WordSmith.Query;
using WordSmith.Query.Definitions;
using WordSmith.Services.Interfaces;
using WordSmithWeb.Shared;

namespace WordSmith.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class BookService : IBookService
    {
        /// <summary>
        /// Gets a Dictionary of words and the number of times they are used within a text file
        /// </summary>
        /// <param name="text">The text that will sampled</param>
        /// <param name="excludeWords">A list of words that will be ignored when the Dictionary is returned</param>
        /// <param name="numberOfResults">The number of results that the user would like returned</param>
        /// <returns>Dictionary(string, int)</returns>
        public List<WordResult> GetFrequencyFromLines(string text, string excludeWords, int numberOfResults)
        {
            List<WordResult> _return= new List<WordResult>();
            Dictionary<string, int> _ordered = new Dictionary<string, int>();
            ConcurrentDictionary<string, int> _result= new ConcurrentDictionary<string, int>();
            try
            {
                //Get the Query Definition 
                var query = new GetFrequencyFromLinesQuery(text, excludeWords);
                //The WordSmithQueryHandlerFactory will return the correct implementation based on the query that is passed in
                var handler = WordSmithQueryHandlerFactory.Build(query);
                _result = handler.Get();

                //Now we need to order them in decending order based on the number of times they where used
                _ordered = _result.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                //Now we need to prune the dictionary back to the number of results requested in the 
                int count = 0;

                foreach (KeyValuePair<string, int> result in _ordered)
                {
                    if (count >= numberOfResults)
                    {
                        _ordered.Remove(result.Key);
                    }
                    count++;
                }

                WordResult WordResult = null;

                foreach (KeyValuePair<string, int> result in _ordered)
                {
                    WordResult = new WordResult(result.Key, result.Value);
                    _return.Add(WordResult);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return _return;
        }

        
    }
}
