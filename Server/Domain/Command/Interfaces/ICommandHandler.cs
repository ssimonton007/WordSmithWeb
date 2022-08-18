////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: ICommandHandler.cs
//FileType: Visual C# Source file
//Author : Steve Simonton
//Created On : 8/15/2022
//Last Modified On : 
//Copy Rights : TechTock LLC
//Description : CommandHandler Definition Interface
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSmith.Command
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    internal interface ICommandHandler<in TCommand, out TResult> where TCommand : ICommand<TResult>
    {
        TResult Execute();
    }

}
