namespace DemandTec.SearchApi.Dto
{
    using System.Collections.Generic;

    public class PageResp<T>
    {
        public int Count { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
