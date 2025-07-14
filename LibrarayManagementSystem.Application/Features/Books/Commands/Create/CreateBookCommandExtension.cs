using LibraryManagementSystem.Domain.Entities;

namespace LibrarayManagementSystem.Application.Features.Books.Commands.Create
{
    public static class CreateBookCommandExtension
    {
        public static Book ToEntity(this CreateBookCommand command)
        {
            return Book.CreateBook(
                command.Title, 
                command.Author, 
                command.ISBN, 
                DateTime.Parse(command.PublishedDate), 
                "System");
        }
    }
}
