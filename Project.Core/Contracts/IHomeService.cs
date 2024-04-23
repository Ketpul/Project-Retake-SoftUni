using Project.Core.Models.OtherViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Contracts
{
    public interface IHomeService
    {
        Task<HomeIndexViewModel> IndexAsync();
    }
}
