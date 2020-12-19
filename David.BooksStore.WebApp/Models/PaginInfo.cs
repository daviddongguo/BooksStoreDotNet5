﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace David.BooksStore.WebApp.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get
            {
                // return the max pages
                return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            }
        }
    }
}
