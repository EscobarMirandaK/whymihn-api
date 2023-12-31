﻿namespace API.Models.Base
{
    public class PaginationResults
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalItems { get; set; }
    }
}
