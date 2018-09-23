using System.Collections.Generic;

namespace Online_Store.Core.ProductServices
{
    public interface IProductService
    {
        string AddProduct(IList<string> parameters);
        string EditProduct(IList<string> parameters);
        string RemoveProductWithId(string productName);
        string ListAllProducts();
        string ListFeedbacksFromProduct(string productName);
        string ListProductsByCategory(string categoryName);
    }
}
