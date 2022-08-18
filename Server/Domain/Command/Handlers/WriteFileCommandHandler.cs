////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: WriteFileCommandHandler.cs
//FileType: Visual C# Source file
//Author : Steve Simonton
//Created On : 3/25/2022
//Last Modified On : 
//Copy Rights : TechTock LLC
//Description : The Command Handler for Deleting a Network Location Object
////////////////////////////////////////////////////////////////////////////////////////////////////////

using WordSmith.Command;
using WordSmith.Command.Responses;

namespace FiberBASEDB.Command
{
    /// <summary>
    /// The Command Handler for Deleting a Network Location Object
    /// </summary>
    internal class WriteFileCommandHandler : ICommandHandler<WriteFileCommand, CommandResponse>
    {
        /// <summary>
        /// Private Property of the Command Definition
        /// </summary>
        private readonly WriteFileCommand _command;

        /// <summary>
        /// Command Handler Constructor
        /// </summary>
        /// <param name="command">The Command Definition</param>
        public WriteFileCommandHandler(WriteFileCommand command)
        {
            _command = command;
        }

        /// <summary>
        /// Executes the Command's behavior
        /// </summary>
        /// <returns>A CommandResponse Object</returns>
        public CommandResponse Execute()
        {
            //Create a new CommandResponse and set the Success to false
            CommandResponse _response = new CommandResponse() { Success = false };

            try
            {
                WriteStringToFileAsync(_command.Text);

                //Set the response to Success=true
                _response.Success = true;

                //Set the response message
                _response.Message = "NetworkLocation Deleted Successfully";
            }
            catch (Exception ex)
            {
                //Set the response to Success=false
                _response.Success = false;

                //Set the Response Message
                _response.Message = "Error : " + ex.Message;
            }

            //Return the CommapndResponse
            return _response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static async Task WriteStringToFileAsync(string text)
        {
            //string text =
            //    "A class is the most powerful data type in C#. Like a structure, " +
            //    "a class defines the data and behavior of the data type. ";

            await File.WriteAllTextAsync(@"C:\Temp\ServiceAllies\WritenText.txt", text);
        }
    }
}
