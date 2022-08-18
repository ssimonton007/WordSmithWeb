////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: WriteFileCommand.cs
//FileType: Visual C# Source file
//Author : Steve Simonton
//Created On : 3/25/2022
//Last Modified On : 
//Copy Rights : TechTock LLC
//Description : The Command Definition for writing a text string to disk
////////////////////////////////////////////////////////////////////////////////////////////////////////

using WordSmith.Command.Responses;

namespace WordSmith.Command
{
    /// <summary>
    /// 
    /// </summary>
    internal class WriteFileCommand : ICommand<CommandResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public WriteFileCommand(string text)
        {
            Text = text;
        }

    }
}
