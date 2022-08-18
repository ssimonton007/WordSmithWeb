////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: GetWordsQueryHandler.cs
//FileType: Visual C# Source file
//Author : Steve Simonton
//Created On : 3/25/2022
//Last Modified On : 
//Copy Rights : TechTock LLC
//Description : Query Definition Handler - Handles getting all Network Locations Query
////////////////////////////////////////////////////////////////////////////////////////////////////////



using WordSmith.Query.Definitions;

namespace WordSmith.Query.Handlers
{
    /// <summary>
    /// Query Definition Handler - Handles getting all Network Locations Query
    /// </summary>
    internal class GetWordsQueryHandler : IQueryHandler<GetWordsQuery, IEnumerable<string>>
    {
        /// <summary>
        /// The Query Definition
        /// </summary>
        private readonly GetWordsQuery _query;

        /// <summary>
        /// Query Definition Handler Constructor
        /// </summary>
        /// <param name="query"></param>
        public GetWordsQueryHandler(GetWordsQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// The Query Handler Get Method
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            IEnumerable<string> _return;

            try
            {
                _return = ReadLines(_query.Text);

            }
            catch (Exception)
            {
                throw;
            }
            return _return;
        }

        private static List<string> ReadLines(string text)
        {
            //List<string> lines = new List<string>();
            //using (var fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            //{
            //    using (var streamReader = new StreamReader(fileStream))
            //    {
            //        string line;
            //        while ((line = streamReader.ReadLine()) != null)
            //        {
            //            lines.Add(line);
            //        }
            //    }
            //}
            //return lines;


            List<string> lines = new List<string>();
            using (var fileStream = GenerateStreamFromString(text))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            return lines;

        }

        private static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

    }
}
