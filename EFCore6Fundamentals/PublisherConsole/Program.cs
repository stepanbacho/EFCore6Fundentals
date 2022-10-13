using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

using (PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
}
//GetAuthors();
//AddAuthor();
//GetAuthors();
AddAuthorWithBook();
GetAuthorsWithBooks();


void AddAuthor()
{
    var author = new Author { FirstName = "Josie", LastName = "Newf" };
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}
void AddAuthorWithBook()
{
    var auth = new Author { FirstName = "Julie", LastName = "Lerman" };
    auth.Books.Add(new Book
    {
        Title = "Programming Entity Framework",
        PublishDate = new DateTime(2009, 1, 1)
    });
    auth.Books.Add(new Book
    {
        Title = "Programming Entity Framework 2nd Ed",
        PublishDate = new DateTime(2010, 8, 1)
    });
    using var context = new PubContext();
    context.Authors.Add(auth);
    context.SaveChanges();
}

void GetAuthorsWithBooks()
{
    using var context = new PubContext();
    var auths = context.Authors.Include(a=> a.Books).ToList();
    foreach (var auth in auths)
    {
        Console.WriteLine(auth.FirstName + " " + auth.LastName);
        foreach (var book in auth.Books)
        {
            Console.WriteLine("*"+book.Title);
        }
    }
}

void GetAuthors()
{
    using var context = new PubContext();
    var authors = context.Authors.ToList();
    foreach (var auth in authors)
    {
        Console.WriteLine(auth.FirstName+" "+auth.LastName);
    }
}

