////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: WordSmithCommandHandlerFactory.cs
//FileType: Visual C# Source file
//Author : Steve Simonton
//Created On : 8/15/2022
//Last Modified On : 
//Copy Rights : TechTock LLC
//Description : This is the Factory for the Command Handlers.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using FiberBASEDB.Command;
using WordSmith.Command.Responses;

namespace WordSmith.Command
{
    internal static class WordSmithCommandHandlerFactory
    {
        #region File ************************************************************************************************

        /// <summary>
        /// Gets the WriteFileCommandHandler for the WriteFileCommand Definition
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static ICommandHandler<WriteFileCommand, CommandResponse> Build(WriteFileCommand command)
        {
            return new WriteFileCommandHandler(command);
        }

        #endregion *********************************************************************************************************

    }
}
