namespace Malek_wafik.Interfaces
{
    public interface IUnitOfWork
    {
        public IBookRepository BookRepository { get; set; }
        public ISectionRepository SectionRepository { get; set; }
        public Task<int> CompleteAsync();
    }
}
