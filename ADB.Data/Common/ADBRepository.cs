using ADB.Data.Data;
using Levshits.Logic.Common;

namespace ADB.Data.Common
{
    public class AdbRepository: Repository
    {
        public ClientData Client { get; set; } 
        public CityData City { get; set; } 
    }
}