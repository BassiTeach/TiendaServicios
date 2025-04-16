using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using TiendaServicios.Api.Libro.Aplicacion;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Tests
{
    public class LibrosServiceTest
    {
        private IEnumerable<LibreriaMaterial> GetDataTest()
        {
            A.Configure<LibreriaMaterial>()
                .Fill(x => x.Titulo).AsArticleTitle()
                .Fill(x => x.LibreriaMaterialGuid, () => { return Guid.NewGuid(); });

            var lista = A.ListOf<LibreriaMaterial>(30);
            lista[0].LibreriaMaterialGuid = null;
            return lista;
        }

        //private Mock<LibroContexto> createContexto()
        //{
        //    var data = GetDataTest().AsQueryable();
        //    var dbSet = new Mock<DbSet<LibreriaMaterial>>();
        //    dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.Provider).Returns(data.Provider);
        //    dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.Expression).Returns(data.Expression);
        //    dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.ElementType).Returns(data.ElementType);
        //    dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
        //}

        [Fact]
        public void GetLibros()
        {
            var mockContexto = new Mock<LibroContexto>();
            
            var mockMapper = new Mock<IMapper>();
            Consulta.Ejecuta mockManejador = new Consulta.Ejecuta(mockContexto.Object, mockMapper.Object);

        }
    }
}
