using Max.Models;

namespace Max.Data
{
    public interface IRepository
    {

        IEnumerable<Processor> Processors { get; }
        IEnumerable<Ram> Rams { get; }
        IEnumerable<Manufacturer> Manufacturers { get; }
        IEnumerable<Category> Categories { get; }
        IEnumerable<User> Users { get; }
        IEnumerable<Order> Orders { get; }

        void Add(Processor processor);
        void Delete(Processor processor);
        void Update(Processor processor);

        void Add(Ram ram);
        void Delete(Ram ram);
        void Update(Ram ram);

        void AddProcessorToCategory(int processorId, int categoryId);
        void DeleteProcessorFromCategory(int processorId, int categoryId);
        void AddCategoriesToProcessor(int[] categoryIds, Processor processor);

        void Add(User user);
        void Update(User user);
    }
}
