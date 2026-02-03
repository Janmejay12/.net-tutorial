using product_mania.DAL;

namespace product_mania.BLL
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private const string invalidString = "Price must be positive";
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task AddProductAsync(Product product)
        {
            if(product.Name == null || product.Name.Contains(invalidString))
            {
                throw new InvalidOperationException("Product name contains :" + invalidString);
            }

            if(product.Price <= 0)
                throw new InvalidOperationException("Product price is less than zero ");

            await _repository.AddAsync(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
           return await _repository.GetAllAsync();
        }

        public Task<Product> GetProductById(int id)
        {
           return _repository.GetByIdAsync(id);
        }
    }
    public interface IProductService
    {
        Task AddProductAsync(Product product);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductById(int id);
    }
}
