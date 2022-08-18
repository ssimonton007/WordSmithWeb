////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: GetFrequencyFromLinesQueryHandler.cs
//FileType: Visual C# Source file
//Author : Steve Simonton
//Created On : 3/25/2022
//Last Modified On : 
//Copy Rights : TechTock LLC
//Description : Query Definition Handler - Handles getting all Network Locations Query
////////////////////////////////////////////////////////////////////////////////////////////////////////



using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using WordSmith.Query.Definitions;

namespace WordSmith.Query.Handlers
{
    /// <summary>
    /// Query Definition Handler - Handles getting all Network Locations Query
    /// </summary>
    internal class GetFrequencyFromLinesQueryHandler : IQueryHandler<GetFrequencyFromLinesQuery, ConcurrentDictionary<string, int>>
    {
        /// <summary>
        /// The Query Definition
        /// </summary>
        private readonly GetFrequencyFromLinesQuery _query;

        private List<string> _ignoreWordLines;
        private static ConcurrentDictionary<string, int> _ignoredWords;
        private static readonly char[] separators = { ' ', '#' };

        /// <summary>
        /// Query Definition Handler Constructor
        /// </summary>
        /// <param name="query"></param>
        public GetFrequencyFromLinesQueryHandler(GetFrequencyFromLinesQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// The Query Handler Get Method
        /// </summary>
        /// <returns></returns>
        public ConcurrentDictionary<string, int> Get()
        {
            ConcurrentDictionary<string, int> _return = new ConcurrentDictionary<string, int>();

            try
            {
                if(_query.ExcludeWords.Length != 0)
                {
                    //Get list of lines from the exclude list of words
                    _ignoreWordLines = ReadLines(_query.ExcludeWords);

                    //Now get a list of all of the exclude words
                    _ignoredWords = GetIgnoreWords(_ignoreWordLines);
                }

                //Now get list of lines in the Text file
                List<string> lines = ReadLines(_query.Text);

                //Now process the list of lines to determine the number of times they
                //where used.
                _return = GetFrequencyFromLinesQuery(lines);

            }
            catch (Exception)
            {
                throw;
            }

            return _return;
        }

        /// <summary>
        /// Reads a text stream and creates a List string
        /// </summary>
        /// <param name="text">The text that is being sampled</param>
        /// <returns></returns>
        private static List<string> ReadLines(string text)
        {
            List<string> lines = new List<string>();

            //Get an in memory stream for the text
            using (var fileStream = GenerateStreamFromString(text))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        //Add the line from the text file to the List of string
                        lines.Add(line);
                    }
                }
            }
            return lines;
        }

        /// <summary>
        /// This will count the number of words in the List of sting 
        /// </summary>
        /// <param name="lines">A List of lines (string)</param>
        /// <returns>Dictionary of words and how many times they were used</returns>
        private static ConcurrentDictionary<string, int> GetFrequencyFromLinesQuery(List<string> lines)
        {
            ConcurrentDictionary<string, int> freqeuncyDictionary = new ConcurrentDictionary<string, int>();
            char[] separators = { ' ' };
            string strippedWord = "";

            //Parallel.ForEach(lines, line =>
            foreach (string line in lines)
            {
                //Now take each line an split it into the individual words and remove any white space
                var words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                //Let's go through each of the words and add and count them
                foreach (var word in words)
                {
                    
                    var pattern = @"[,\.\-\;\""]";
                    strippedWord = Regex.Replace(word, pattern, string.Empty);

                    if (_ignoredWords != null)
                    {
                        //Is the word found in the Ignore Words Dictionary?
                        if (!IgnoreWord(strippedWord.ToLower()))
                        {
                            //Has the word already been added to the returning Dictionary?
                            if (freqeuncyDictionary.ContainsKey(strippedWord.ToLower()))
                            {
                                freqeuncyDictionary[strippedWord.ToLower()] = freqeuncyDictionary[strippedWord.ToLower()] + 1;
                            }
                            else
                            {
                                //Let's Add or Update the number of times the word was used. 
                                freqeuncyDictionary.AddOrUpdate(strippedWord.ToLower(), 1, (key, oldValue) => oldValue + 1);
                            }
                        }
                    }
                }
            }

            return freqeuncyDictionary;
        }

        /// <summary>
        /// Create a Memory Stream from a string of text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static Stream GenerateStreamFromString(string text)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// Gets the words that will be used to filter the returned list of words
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        private static ConcurrentDictionary<string, int> GetIgnoreWords(List<string> lines)
        {
            ConcurrentDictionary<string, int> _return = new ConcurrentDictionary<string, int>();

            List<string> words = new List<string>();
            foreach (var line in lines)
            {
                //We treat the # symbol as a comment, so let's just ignore these lines
                if ((!line.Contains("#") && (line != "")))
                {
                    words.Add(line);
                }
            }

            foreach (var word in words)
            {
                //Check to see if the Dictionary already contains the word. 
                if (_return.ContainsKey(word.ToLower()))
                {
                    _return[word.ToLower()] = _return[word.ToLower()] + 1;
                }
                else
                {
                    //Add or Update the Dictionary
                    _return.AddOrUpdate(word.ToLower(), 1, (key, oldValue) => oldValue + 1);
                }
            }

            return _return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private static bool IgnoreWord(string word)
        {
            bool _return = false;

            if (_ignoredWords.ContainsKey(word.ToLower())) { _return = true; }

            return _return;
        }

    }
}
