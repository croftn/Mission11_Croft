namespace Mission11_Croft.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
