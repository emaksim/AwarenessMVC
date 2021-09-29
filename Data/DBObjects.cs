using Awarenessmvc.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Awarenessmvc.Data
{
    public class DBObjects
    {
        public static void Initialize(AppDBContent content)
        {
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(x => x.Value));

            if (!content.Car.Any())
            {
                content.AddRange(
                    new List<Car>
                    {
                        new Car
                        {
                            Name = "Tesla",
                            ShortDesc = "aaaaa",
                            LongDesc = "sadasdasdasdasdsada",
                            Img = "/img/tesla.jpg",
                            Price = 4500,
                            IsFavourite = true,
                            Available = true,
                            Category = Categories["Электромобили"]

                        },
                        new Car
                        {
                            Name = "Ford Fiesta",
                            ShortDesc = "aaaaaa",
                            LongDesc = "asdasdasdadasd",
                            Img = "/img/tesla.jpg",
                            Price = 4500,
                            IsFavourite = true,
                            Available = true,
                            Category = Categories["Классические"]
                        }
                    });
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> _categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    var list = new Category[]
                    {
                        new Category {CategoryName = "Электромобили", Desc = "Совеременный вид транспорта"},
                        new Category {CategoryName = "Классические", Desc = "Двигатель внутреннего сгорания"}
                    };

                    _categories = new Dictionary<string, Category>();
                    foreach (var el in list)
                    {
                        _categories.Add(el.CategoryName, el);
                    }
                }

                return _categories;
            }
        }
    }
}