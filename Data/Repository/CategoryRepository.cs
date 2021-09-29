using Awarenessmvc.Data.Interfaces;
using Awarenessmvc.Data.Models;
using System.Collections.Generic;

namespace Awarenessmvc.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent appDbContent;

        public CategoryRepository(AppDBContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Category> AllCategories => appDbContent.Category;
    }
}