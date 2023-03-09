using ServerManagerCore.Models;

namespace ServerManagerCore.Services
{
    internal class RconServicesBuilder
    {
        private TypeServer _typeServer;

        public RconServicesBuilder(TypeServer typeServer)
        {
           _typeServer = typeServer;
        }
        public IRconServices Get()
        {
            switch(_typeServer)
            {
                case TypeServer.Ark:
                    return new ArkRconServices();
                default:
                    throw new ArgumentException();
            }
        }
    }
}