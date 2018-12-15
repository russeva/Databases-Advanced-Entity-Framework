namespace Instagraph.App
{
    using AutoMapper;
    using Instagraph.DataProcessor.Dto.Import;
    using Instagraph.Models;

     public class InstagraphProfile : Profile
    {
        public InstagraphProfile()
        {
            CreateMap<ImportPicsDto, Picture>();
            CreateMap<Picture, ImportPicsDto>();

            CreateMap<ImportPostsDto, Post>();
            CreateMap<Post, ImportPostsDto>();
        }
    }
}
