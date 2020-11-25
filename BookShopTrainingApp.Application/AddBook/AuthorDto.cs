using System;
using System.Linq;
using BookShopTrainingApp.Domain;
using BookShopTrainingApp.Persistence;

namespace BookShopTrainingApp.Application.AddBook
{
    public class AuthorDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }

        internal Author GetFromDatabase(IBookShopContext context)
        {
            var author = context.Authors.FirstOrDefault(x => x.Name == this.Name && x.Surname == this.Surname);
            if (author == null)
            {
                var authorToAdd = new Author(this.Name, this.Surname, this.Biography);
                context.Authors.Add(authorToAdd);
                return authorToAdd;
            }
            else
            {
                return author;
            }
        }
    }
}