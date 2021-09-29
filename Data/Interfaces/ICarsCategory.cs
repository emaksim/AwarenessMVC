using Awarenessmvc.Data.Models;
using System.Collections.Generic;

namespace Awarenessmvc.Data.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}