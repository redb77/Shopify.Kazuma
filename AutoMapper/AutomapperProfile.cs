using AutoMapper;
using Shopify.Domain.Customer;
using Shopify.Domain.Loyalty;

namespace Shopify.BusinessLogic
{

    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerResponse, CustomerDocument>().ForMember(c => c.points, option => option.Ignore());
            CreateMap<CustomerDocument, CustomerResponse>().ForMember(c => c.points, option => option.Ignore()); ;

            CreateMap<Points, PointsDocument>();
            CreateMap<PointsDocument, Points>();

            CreateMap<CardType, CardTypeDocument>();
            CreateMap<CardTypeDocument, CardType>();



            CreateMap<ShopifySharp.DiscountCode, DiscountCodeDocument>();
            CreateMap<DiscountCodeDocument, Domain.Customer.DiscountCode>();

            CreateMap<Shopify.Domain.ShopifyStoreFront.Customer, Shopify.Domain.Customer.CustomerResponse>();
        }
    }



}
