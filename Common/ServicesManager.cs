namespace Common
{
    public static class ServicesManager
    {
        private static string APIEndPoint = Constants.APIEndPoint;
        private static string BaseAddress = Common.ConfigSettingsReader.GetConfigurationValues(APIEndPoint);
        
        /// <summary>
        /// Constructs the uri by appending the service name to the BaseAdderess
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static string GetClientUri(string serviceName)
        {
            string uri = BaseAddress + Common.ConfigSettingsReader.GetConfigurationValues(serviceName);
            return uri;
        }
    }
   
  
}
