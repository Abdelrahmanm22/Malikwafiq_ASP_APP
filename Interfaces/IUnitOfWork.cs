namespace Malek_wafik.Interfaces
{
    public interface IUnitOfWork
    {
        public IBookRepository BookRepository { get; set; }
        public Task<int> CompleteAsync();
    }
}
