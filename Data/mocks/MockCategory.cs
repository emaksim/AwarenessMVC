using Awarenessmvc.Data.Interfaces;
using Awarenessmvc.Data.Models;
using System.Collections.Generic;

namespace Awarenessmvc.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryName = "Электромобили", Desc = "Совеременный вид транспорта"},
                new Category{CategoryName = "Классические", Desc = "Двигатель внутреннего сгорания"}
            };
    }
}