namespace CarDealer.App
{
    using AutoMapper;
    using CarDealer.App.Import;
    using CarDealer.Models;

    class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierImportDto, Supplier>();
            CreateMap<Supplier, SupplierImportDto>();
            CreateMap<PartsImportDto, Part>();
            CreateMap<Part, PartsImportDto>();
            CreateMap<ImportCarsDto, Car>();
            CreateMap<Car, ImportCarsDto>();
        }
    }
}
