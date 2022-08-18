////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: XXXXXXXXXX.cs
//FileType: Visual C# Source file
//Author : Steve Simonton
//Created On : 3/25/2022
//Last Modified On : 
//Copy Rights : TechTock LLC
//Description : XXXXXXXXX
////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace WordSmith.Command.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public CommandResponse()
        {
            this.Success= false;
            this.Message = "Intialized Message";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        public CommandResponse(Boolean success, string message)
        {
            this.Success = success;
            this.Message = message;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
    }
}
