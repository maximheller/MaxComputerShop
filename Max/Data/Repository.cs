using Max.Models;
using Microsoft.EntityFrameworkCore;

namespace Max.Data
{
    public class Repository : IRepository
    {
        private readonly ShopContext context; // field

        public Repository(ShopContext context)
        {
            this.context = context;            
        }

        public IEnumerable<Processor> Processors => context.Processors  // Property
            .Include(p => p.Manufacturer)
            .Include(p => p.Categories);



        //public IEnumerable<Processor> Processors // Property
        //{
        //    get
        //    {                
        //        return context.Processors
        //           .Include(p => p.Manufacturer)
        //           .Include(p => p.Categories);
        //    } 
        //}





        public IEnumerable<Ram> Rams => context.Rams.Include(p => p.Manufacturer);

        public IEnumerable<Manufacturer> Manufacturers => context.Manufacturers; //.Include(m => m.Processors);

        public IEnumerable<Category> Categories => context.Categories.Include(c => c.Processors);

        public IEnumerable<User> Users => context.Users;

        public IEnumerable<Order> Orders => context.Orders;




        public void Delete(Manufacturer manufacturer)
        {
            context.Manufacturers.Remove(manufacturer);
            context.SaveChanges();
        }

        public void Delete(Processor processor)
        { 
            context.Processors.Remove(processor);
            context.SaveChanges();
        }
        public void Add(Processor processor)
        {
            context.Processors.Add(processor);
            context.SaveChanges();
        }
        public void Update(Processor processor)
        {
            context.Processors.Update(processor);
            context.SaveChanges();
        }


        public async void Delete(Ram ram)
        {
            context.Rams.Remove(ram);
            context.SaveChanges();
        }
        public void Add(Ram ram)
        {
            context.Rams.Add(ram);
            context.SaveChanges();
        }
        public void Update(Ram ram)
        {
            context.Rams.Update(ram);
            context.SaveChanges();
        }
        public void Update(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }

        public void AddProcessorToCategory(int processorId, int categoryId)
        {           
            Func<Processor, bool> predicate = p => p.Id == processorId;
            Processor? processor = Processors.SingleOrDefault(predicate);           
            Category? category = Categories.SingleOrDefault(c => c.Id == categoryId); 

            if (category != null && processor != null)
            {
                category.Processors.Add(processor);
            }

            context.SaveChanges();
        }

        public void DeleteProcessorFromCategory(int processorId, int categoryId)
        {           
            Processor? processor = Processors.SingleOrDefault(p => p.Id == processorId);
            Category? category = Categories.SingleOrDefault(c => c.Id == categoryId);

            if (category != null && processor != null)
            {
                category.Processors.Remove(processor);
            }

            context.SaveChanges();
        }

        public void AddCategoriesToProcessor(int[] categoryIds, Processor processor)
        {
            foreach (Category category in Categories.ToArray()) // all categories  {1, 2, 3, 4};
            {
                if (categoryIds.Contains(category.Id))  // 1 3
                {
                    if (!processor.Categories.Contains(category))
                    {
                        processor.Categories.Add(category);                        
                    }
                }
                else // 2 4
                {
                    if (processor.Categories.Contains(category))
                    {
                        processor.Categories.Remove(category);
                    }
                }               
            }
            context.SaveChanges();
        }



        public void Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        //public void Login

        //public void AddProcessorToCategory(int processorId, int categoryId)
        //{
        //    // TODO 
        //    Func<Processor, bool> predicate = p => p.Id == processorId;
        //    Processor? processor = context.Processors.SingleOrDefault(predicate);

        //    Category? category = context.Categories.SingleOrDefault(c => c.Id == categoryId); // gamers

        //    if (category != null && processor != null)
        //    {
        //        CategoryProcessor categoryProcessor = new CategoryProcessor
        //        {
        //            CategoryId = categoryId, 
        //            ProcessorId = processorId 
        //        };
        //        context.CategoryProcessors.Add(categoryProcessor);
        //    }

        //    context.SaveChanges();


        //}


    }
}
