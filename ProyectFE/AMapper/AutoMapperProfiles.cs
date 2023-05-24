using AutoMapper;
using Common;
using Domain;
using Models.Request;
using Models.Response;

namespace ProyectFE.AMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap(typeof(EResponseBase<>), typeof(EResponseBase<>));
            CreateMap<UsersRequestV1, User>().ReverseMap();
            CreateMap<UsersRequestV2, User>().ReverseMap();
            CreateMap<UsersRequestV3, User>().ReverseMap();
            CreateMap<User, UsersResponseV1>().ReverseMap();

            CreateMap<BranchOfficeRequestV1,  BranchOffice>().ReverseMap();
            CreateMap<BranchOfficeRequestV2, BranchOffice>().ReverseMap();
            CreateMap<BranchOffice, BranchOfficeResponseV1>().ReverseMap();

            CreateMap<UnitsRequestV1, Unit>().ReverseMap();
            CreateMap<UnitsRequestV2, Unit>().ReverseMap();
            CreateMap<Unit, UnitsResponseV1>().ReverseMap();

            CreateMap<UserRolesRequestV1,UserRole>().ReverseMap();
            CreateMap<UserRole, UserRolesResponseV1>().ReverseMap();
            CreateMap<UserRolesRequestV2, UserRole>().ReverseMap();
                     
            CreateMap<TypeClient, TypeClientsResponseV1>().ReverseMap();
            
            CreateMap<BoxesRequestV1, Box>().ReverseMap();
            CreateMap<BoxesRequestV2, Box>().ReverseMap();
            CreateMap<Box, BoxesResponseV1>().ReverseMap();
            
            CreateMap<CompanieRequestV1, Company>().ReverseMap();
            CreateMap<CompanieRequestV2, Company>().ReverseMap();
            CreateMap<Company, CompanieResponseV1>().ReverseMap();

            CreateMap<ClientRequestV1, Client>().ReverseMap();
            CreateMap<ClientRequestV2, Client>().ReverseMap();
            CreateMap<Client, ClientResponseV1>().ReverseMap();
        }
    }
}
