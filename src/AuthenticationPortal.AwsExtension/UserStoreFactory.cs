using AuthenticationPortal.Contracts;
using Autofac;
using System.Net;

namespace AuthenticationPortal.AwsExtension
{
    public class UserStoreFactory : IUserStoreFactory
    {
        private IContainer _container;

        public UserStoreFactory(IContainer container)
        {
            _container = container;
        }

        public IUserStore GetUserStore(string storeName)
        {
            switch (storeName)
            {
                case "Mongo":
                    return _container.ResolveNamed<IUserStore>("Mongo");
            }
            throw new CustomException(HttpStatusCode.InternalServerError, "Invalid_Store");
        }
    }
}
