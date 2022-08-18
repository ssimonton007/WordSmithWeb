////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: IBookService.cs
//FileType: Visual C# Source file
//Author : Steve Simonton
//Created On : 8/15/2022
//Last Modified On : 
//Copy Rights : TechTock LLC
//Description : Interface for the internal book service interface
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSmithWeb.Shared;

namespace WordSmith.Services.Interfaces
{
    /// <summary>
    /// Interface for the internal book service interface
    /// </summary>
    public interface IBookService
    {
        #region Book ******************************************************************************

        /// <summary>
        /// Gets a Dictionary of words and the number of times they are used within a text file
        /// </summary>
        /// <param name="text">The text that will sampled</param>
        /// <param name="excludeWords">A list of words that will be ignored when the Dictionary is returned</param>
        /// <param name="numberOfResults">The number of results that the user would like returned</param>
        /// <returns></returns>
        List<WordResult> GetFrequencyFromLines(string text, string excludeWords, int numberOfResults);

        
        #endregion
    }




}

