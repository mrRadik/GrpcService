using AutoMapper;
using GrpcService.Domain.Entities;

namespace GrpcService.Application.Models;

public class FileDto
{
    public Guid FileGuid { get; set; }
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public byte[] Data { get; set; }
    public DateTime CreationDate { get; set; }

    private class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FileEntity, FileDto>()
                .ForMember(dest => dest.FileGuid, opt => opt.MapFrom(src => src.Guid))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.FileExtension, opt => opt.MapFrom(src => src.Extension))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationTime))
                ;
        }
    }
}