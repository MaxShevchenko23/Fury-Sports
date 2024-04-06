using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using sport_shop_dal.Data;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;

namespace sport_shop_dal.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly FurySportsContext context;

        public ProductRepository(FurySportsContext context)
        {
            this.context = context;
        }

        public async Task<Product?> CreateAsync(Product source)
        {
            var entity = await context.Products.AddAsync(source);
            await context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Products.FirstOrDefaultAsync(e => e.Id == id) ?? throw new DBException($"Record with meantioned id={id} was not found");
            context.Products.Remove(entity);
            await context.SaveChangesAsync(true);
        }

        public async Task DeleteAsync(Product source)
        {
            context.Products.Remove(source);
            await context.SaveChangesAsync(true);
        }

        public async Task<Product?> GetAsync(int id)
        {
            var entity = await context.Products.FirstOrDefaultAsync(e => e.Id == id);

            return entity;
        }

        public Product Update(Product source)
        {
            var entity = context.Products.Update(source);
            context.SaveChanges(true);
            return entity.Entity;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var entities = await context.Products.ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<Product>> GetAllDecreasingAsync()
        {
            var entities = await GetAllAsync();
            return entities.OrderByDescending(e => e.Id);
        }

        public async Task<IEnumerable<Product>?> Filter(string? name,
            int? categoryId,
            int? manufacturerId,
            string? description,
            decimal? minPrice,
            decimal? maxPrice,
            int? quantity,
            IEnumerable<Specification>? specs,
            int pageSize,
            int pageNumber)
        {
            //convert products to queryable
            var productsQueryable = context.Products.AsQueryable();

            //var to return
            IEnumerable<Product> result;

            //filtering by properties
            if (!name.IsNullOrEmpty())
            {
                productsQueryable = productsQueryable.Where(e => e.Name.Contains(name));
            }

            if (!description.IsNullOrEmpty())
            {
                productsQueryable = productsQueryable.Where(e => e.Name.Contains(description));
            }

            if (categoryId.HasValue)
            {
                //to be able to pass the nullable value
                int temp = categoryId.Value;

                //productsQueryable = productsQueryable.Where(e => e.CategoryId == categoryId);
                FilterByCategories(temp, ref productsQueryable);
            }

            if (manufacturerId.HasValue)
            {
                productsQueryable = productsQueryable.Where(e => e.ManufacturerId == manufacturerId);
            }

            if (minPrice.HasValue)
            {
                productsQueryable = productsQueryable.Where(e => e.Price > minPrice);
            }

            if (maxPrice.HasValue)
            {
                productsQueryable = productsQueryable.Where(e => e.Price < maxPrice);
            }

            if (quantity.HasValue)
            {
                productsQueryable = productsQueryable.Where(e => e.Quantity < quantity);
            }

            if (!specs.IsNullOrEmpty())
            {
                result = await SearchBySpecs(productsQueryable, specs);
            }
            else
            {
                result = productsQueryable.ToList();
            }

            result = result.OrderByDescending(a => a.Id)
                               .Skip(pageSize * (pageNumber - 1))
                               .Take(pageSize);

            return result;
        }

        void FilterByCategories(int categoryId, ref IQueryable<Product> source)
        {

            HashSet<int> categoryIds = new();
            categoryIds.Add(categoryId);
            //var category = context.Categories.FirstOrDefault(e => e.Id == categoryId);


            //добавить логику если RootCategoryId != null
            //if (category.RootCategoryId == null)
            //{
            CollectAllChildCategories(categoryId, ref categoryIds);
            //}

            source = source.Where(e => categoryIds.Contains(e.CategoryId));

            var temp = source.ToList();
            foreach (var item in temp)
            {
                Console.WriteLine($"{item.Name}");
            }

            //throw new NotImplementedException();
        }

        void CollectAllChildCategories(int categoryId, ref HashSet<int> categoryIds)
        {
            var childCategories = context.Categories.Where(e => e.RootCategoryId == categoryId);

            if (childCategories.Count() > 0)
            {
                foreach (var child in childCategories)
                {
                    categoryIds.Add(child.Id);
                    CollectAllChildCategories(child.Id,  ref categoryIds);
                }
            }
            else
            {
                categoryIds.Add(categoryId);
            }
        }


        async Task<IEnumerable<Product>> SearchBySpecs(
            IQueryable<Product> productsQueryable,
            IEnumerable<Specification> sourceSpecs)
        {
            //lists filtered products
            var filtered = await productsQueryable.ToListAsync();

            //var to return
            List<Product> result = new();

            foreach (Product p in filtered)
            {
                //temp var to define whether the product specs contain all elements from sourceSpecs
                //if temp = sourceSpecs.Count => then product is added to result list
                int temp = 0;

                foreach (Specification spec in sourceSpecs)
                {
                    if (p.Specifications.Any(s => s.SpecificationName == spec.SpecificationName &&
                    s.SpecificationValue == spec.SpecificationValue))
                    {
                        temp++;
                    }
                }
                if (sourceSpecs.Count() == temp)
                {
                    result.Add(p);
                }

            }


            return result;
        }
    }
}
