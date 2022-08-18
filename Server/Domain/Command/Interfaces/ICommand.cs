////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: ICommand.cs
//FileType: Visual C# Source file
//Author : Steve Simonton
//Created On : 8/15/2022
//Last Modified On : 
//Copy Rights : TechTock LLC
//Description : Command Definition Interface
////////////////////////////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSmith.Command
{
    internal interface ICommand<out TResult> { }
}
