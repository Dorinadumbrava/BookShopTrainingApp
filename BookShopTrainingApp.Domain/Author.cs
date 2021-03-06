﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopTrainingApp.Domain
{
    public class Author
    {
        public Author() { }
        public Author(string name, string surname, string biography)
        {
            Name = name;
            Surname = surname;
            Biography = biography;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }
        public IEnumerable<BookAuthor> Books { get; set; }
    }
}