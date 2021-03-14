using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLibrary.Models
{
    public class Library
    {
        public int Id { get; set; }
        public Address Address { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<LibraryMember> LibraryMembers { get; set; }
    }
}
