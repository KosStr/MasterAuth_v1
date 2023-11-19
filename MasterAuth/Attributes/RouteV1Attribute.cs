using Microsoft.AspNetCore.Mvc;

namespace MasterAuth.Attributes
{
    public class RouteV1Attribute : RouteAttribute
    {
        #region Constructor

        public RouteV1Attribute(string template) : base($"api/v1/{template}")
        {
        }

        #endregion
    }
}
