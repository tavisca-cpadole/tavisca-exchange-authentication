using System.Globalization;
using System.Reflection;
using System.Resources;

namespace AuthenticationPortal.Contracts
{
    public static class ResourceHelper
    {
        private const string _errorCodeFile = "AuthenticationPortal.Contracts.ErrorCodes";
        private const string _errorMessageFile = "AuthenticationPortal.Contracts.ErrorMessages";
        public static string getErrorData(string errorMessage, string field = "")
        {
            ResourceManager rm = new ResourceManager(_errorCodeFile,
                                Assembly.GetExecutingAssembly());
            return string.Format(rm.GetString(errorMessage, CultureInfo.CurrentCulture), field);
        }
        public static string getErrorCode(string errorMessage)
        {
            ResourceManager rm = new ResourceManager(_errorMessageFile,
                                Assembly.GetExecutingAssembly());
            return rm.GetString(errorMessage, CultureInfo.CurrentCulture);
        }

        //public static CustomException GetException(string name)
        //{
        //    return new BaseException(ErrorCodes._801, ErrorMessages.Login_Error);
        //}
    }
}
