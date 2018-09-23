using Online_Store.Models;

namespace Online_Store.Core.Factories
{
    public interface IModelFactory
    {
        User CreateUser(string username, string hashedPassword);

        Seller CreateSeller();

        Cart CreateCart();

        Product CreateProduct();

        Category CreateCategory();

        ShippingDetails CreateShippingDetails();

        Sale CreateSale();

        Feedback CreateFeedback();
    }
}
