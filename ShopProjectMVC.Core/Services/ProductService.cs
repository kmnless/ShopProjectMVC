using ShopProjectMVC.Core.Interfaces;
using ShopProjectMVC.Core.Models;

namespace ShopProjectMVC.Core.Services;

public class ProductService : IProductService
{
    private readonly IRepository _repository;

    public ProductService(IRepository repository)
    {
        _repository = repository;
    }

    public Task<Product> AddProduct(Product product)
    {
        return _repository.Add(product);
    }

    public async Task<Order> BuyProduct(int userId, int productId)
    {
        Product product = await _repository.GetById<Product>(productId);
        User user = await _repository.GetById<User>(userId);
        Order order = new Order() {Product = product, User = user, CreatedAt=DateTime.Now};
        return await _repository.Add(order);
    }

    public Task DeleteProduct(int id)
    {
        return _repository.Delete<Product>(id);
    }

    public IEnumerable<Product> GetAll()
    {
        return _repository.GetAll<Product>();
    }

    public IEnumerable<Category> GetAllCategories()
    {
        return _repository.GetAll<Category>();
    }

    public Task<Product> GetProductById(int id)
    {
        return _repository.GetById<Product>(id);
    }

    public Task<Product> UpdateProduct(Product product)
    {
        return _repository.Update<Product>(product);
    }
}
