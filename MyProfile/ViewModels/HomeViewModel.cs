using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProfile.ViewModels
{
    public class HomeViewModel
    {
        public Owner Owner { get; set; }
        public IList<PortfolioItem> portfolioItems { get; set; }
    }
}
