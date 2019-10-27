using System.Globalization;
using System.Reflection;
using System.Resources;

namespace AuthenticationPortal.Contracts
{
    public static class CustomErrorCodes
    {
        private const string _resxFile = "AuthenticationPortal.Contracts.ErrorCodes";
        public static string getErrorMessage(int errorCode)
        {
            ResourceManager rm = new ResourceManager(_resxFile,
                                Assembly.GetExecutingAssembly());
            return rm.GetString(errorCode.ToString(), CultureInfo.CurrentCulture);
        }
    }
}
