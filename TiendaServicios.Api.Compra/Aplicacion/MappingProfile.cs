using AutoMapper;
using TiendaServicios.Api.Compra.Modelo;
using TiendaServicios.Api.Compra.Remote;

namespace TiendaServicios.Api.Compra.Aplicacion
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Carrito, CarritoDTO>()
                .ForMember(dest => dest.CarritoId, src => src.MapFrom(x => x.CarritoId))
                .ForMember(dest => dest.FechaCreacion, src => src.MapFrom(x => x.FechaCreacion))
                .ReverseMap();

            CreateMap<CarritoDetalle, CarritoDetalleDTO>() 
                .ReverseMap();

            CreateMap<LibroRemote, CarritoDetalleDTO>()
                .ForMember(dest => dest.TituloLibro, src => src.MapFrom(x => x.Titulo))
                .ForMember(dest => dest.AutorLibro, src => src.MapFrom(x => x.AutorNombre))
                .ForMember(dest => dest.FechaPublicacion, src => src.MapFrom(x => x.FechaPublicacion))
                .ReverseMap();
        }
    }
}
