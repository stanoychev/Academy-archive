using Bytes2you.Validation;
using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Online_Store.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordSecurityHasher hasher;
        private readonly IStoreContext context;
        private readonly ILoggedUserProvider loggedUserProvider;
        private readonly IModelFactory factory;

        public UserService(IPasswordSecurityHasher hasher, IStoreContext context, ILoggedUserProvider loggedUserProvider, IModelFactory factory)
        {
            Guard.WhenArgument(hasher, "passwordHasher").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(loggedUserProvider, "loggedUserProvider").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.context = context;
            this.hasher = hasher;
            this.loggedUserProvider = loggedUserProvider;
            this.factory = factory;
        }


        public string GeneratePasswordHash(string password)
        {
            return hasher.Hash(password);
        }

        public bool ValidateCredentials(string username, string password)
        {
            try
            {
                this.context.Users.Any();
            }
            catch (Exception)
            {
                return true;
            }

            if (!CheckUsername(username))
            {
                throw new Exception("Wrong Username");
            }

            var userPassword = this.context.Users.Single(u => u.Username == username).Password;
            if (!CheckPassword(password, userPassword))
            {
                throw new Exception("Wrong Password");
            }

            return true;
        }


        public bool CheckUsername(string username)
        {
            bool isTaken = false;
            try
            {
                isTaken = this.context.Users.Any(u => u.Username == username);
            }
            catch (Exception)
            {
                return false;
            }

            return isTaken;
        }

        public bool CheckPassword(string enteredPassword, string userPassword)
        {
            bool isLegit = hasher.Verify(enteredPassword, userPassword);

            return isLegit;
        }

        public bool IsUserLogged()
        {
            if (loggedUserProvider.CurrentUserId == -1)
            {
                return false;
            }
            return true;
        }

        public string AddToCart(IList<string> parameters)
        {
            Product product = this.factory.CreateProduct();
            string productIdStr = parameters[0];
            if (productIdStr == null)
            {
                try
                {
                    string nameInput = parameters[1];
                    product = this.context.Products.Single(p => p.ProductName == nameInput);
                }
                catch (Exception)
                {
                    return "There is no product with this Name!";
                }
            }
            else if (parameters[1] == null)
            {
                int productIdInput;
                try
                {
                    productIdInput = int.Parse(productIdStr);
                }
                catch (Exception)
                {
                    return "ID must be a Number!";
                }

                try
                {
                    product = this.context.Products.Single(p => p.Id == productIdInput);
                }
                catch (Exception)
                {
                    return "There is no product with this ID!";
                }
            }

            this.context.Users.Single(u => u.Id == this.loggedUserProvider.CurrentUserId)
                            .Cart.Products.Add(product);

            Console.WriteLine(this.context.Users.Single(u => u.Id == this.loggedUserProvider.CurrentUserId)
                .Cart.Products.Count);

            this.context.SaveChanges();

            return $"Product successfully added to cart";
        }
    }
}
