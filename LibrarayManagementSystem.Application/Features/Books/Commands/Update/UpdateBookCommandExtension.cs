using LibraryManagementSystem.Domain.Entities;

namespace LibrarayManagementSystem.Application.Features.Books.Commands.Update
{
    internal static class UpdateBookCommandExtension
    {
        public static void ToEntity(this UpdateBookCommand command, Book book)
        {
            book.UpdateBook(
                command.Title,
                command.Author, 
                command.ISBN, 
                DateTime.Parse(command.PublishedDate), 
                command.ModifiedBy);   
        }
    }
}
