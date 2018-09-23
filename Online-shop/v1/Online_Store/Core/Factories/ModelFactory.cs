using System;
using Online_Store.Models;

namespace Online_Store.Core.Factories
{
    public class ModelFactory : IModelFactory
    {
        public User CreateUser(string username, string hashedPassword)
        {
            return new User(username, hashedPassword);
        }

        public Seller CreateSeller()
        {
            return new Seller();
        }

        public Cart CreateCart()
        {
            return new Cart();
        }

        public Product CreateProduct()
        {
            return new Product();
        }

        public Category CreateCategory()
        {
            return new Category();
        }
        public ShippingDetails CreateShippingDetails()
        {
            return new ShippingDetails();
        }

        public Sale CreateSale()
        {
            return new Sale();
        }

        public Feedback CreateFeedback()
        {
            return new Feedback();
        }
    }
}
