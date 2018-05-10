using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public class BookManager
    {
        public static ObservableCollection<Book> GetBooks()
        {
            var Books = new ObservableCollection<Book>();

            Books.Add(new Book { BookId = 1, Title = "alpha", Author = "a", CoverImage = "Assets/1.jpg" });
            Books.Add(new Book { BookId = 2, Title = "Beta", Author = "b", CoverImage = "Assets/2.png" });
            Books.Add(new Book { BookId = 3, Title = "delta", Author = "c", CoverImage = "Assets/3.jpg" });

            return Books;

        }
    }
}
