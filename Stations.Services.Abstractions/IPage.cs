namespace Stations.Services.Abstractions
{
    using System.Collections.Generic;

    public interface IPage<T> where T : class
    {
        int Count { get; set; }

        IEnumerable<T> Items { get; set; }
    }
}