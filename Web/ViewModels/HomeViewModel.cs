using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Web.ViewModels
{
    public class HomeViewModel
    {
        public Owner Owner { get; set; }
        public List<PortfolioItem> portfolioItems { get; set; }

    }
}
