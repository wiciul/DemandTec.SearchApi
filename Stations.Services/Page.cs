namespace Stations.Services
{
    using System.Collections.Generic;
    using Abstractions;

    public class Page<T> : IPage<T> where T : class
    {
        public int Count { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}