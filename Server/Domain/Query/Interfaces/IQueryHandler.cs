////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: IQueryHandler.cs
//FileType: Visual C# Source file
//Author : Steve Simonton
//Created On : 8/15/2022
//Last Modified On : 
//Copy Rights : TechTock LLC
//Description : Query Handler Interface
////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace WordSmith.Query
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    internal interface IQueryHandler<in TQuery, out TResponse> where TQuery : IQuery<TResponse>
    {
        TResponse Get();
    }
}
