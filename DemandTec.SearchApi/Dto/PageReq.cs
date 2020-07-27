namespace DemandTec.SearchApi.Dto
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class PageReq
    {
        [Required, FromQuery, Range(1, int.MaxValue)]
        public int PageIndex { get; set; }

        [Required, FromQuery, Range(1, int.MaxValue)]
        public int PageSize { get; set; }
    }
}