
namespace TravelSite.Models
{
    public enum Trip_Type
    {
        OneWay_Trip = 0,
        Return_Trip = 1,
        Multi_trip = 2,
    }

    public enum Product_Type
    {
        ARF = 0,
        HTL = 1,
        INS = 2,
    }

    public enum Cabin_Class
    {
        Economy = 0,
        PremiumEconomy = 1,
        Business = 2,
        First = 3,
    }


    public enum Caching_OF
    {
        AIRPORT_LIST = 0,
        AIRLINE_LIST = 1,
        COMPANY_CREDENTIAL_LIST = 2,
        BLACKLIST_AIRLINES = 3,
        ALL_LIST = 4,
    }


    public enum GDS
    {
        Amadeus = 0,
        Worldspan = 1,
        Sabre = 2,
        Multicom = 3,
        Galileo = 4,
        UAPI_Worldspan = 5,
        UAPI_Galileo = 6,
    }
}
