namespace DemandTec.SearchApi.Dto
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class PageReq
    {
        [Required, FromQuery]
        public int PageIndex { get; set; }

        [Required, FromQuery]
        public int PageSize { get; set; }
    }
}