////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: WordSmithQueryHandlerFactory.cs
//FileType: Visual C# Source file
//Author : Steve Simonton
//Created On : 8/15/2022
//Last Modified On : 
//Copy Rights : TechTock LLC
//Description : This is the Factor for the Query Handlers.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Concurrent;
using WordSmith.Query.Definitions;
using WordSmith.Query.Handlers;

namespace WordSmith.Query
{
    internal static class WordSmithQueryHandlerFactory
    {
        #region Word Queries ************************************************************************************************
        
        /// <summary>
        /// The facotory for getting the correct handeler for the requested Query Definition
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryHandler<GetFrequencyFromLinesQuery, ConcurrentDictionary<string, int>> Build(GetFrequencyFromLinesQuery query)
        {
            return new GetFrequencyFromLinesQueryHandler(query);
        }

        #endregion *********************************************************************************************************

    }
}
