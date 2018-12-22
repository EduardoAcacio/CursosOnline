using System;
using Bogus;
using CursosOnline.Domain.Cursos;
using CursosOnline.Domain.Tests._Util;
using Moq;
using Xunit;

namespace CursosOnline.Domain.Tests.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        private readonly CursoDto _cursoDto;
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;
        private readonly Mock<ICursoRepositorio> _cursoRepositorioMock;

        public ArmazenadorDeCursoTest()
        {
            var faker = new Faker();
            _cursoDto = new CursoDto
            {
                Nome = faker.Random.Words(),
                CargaHoraria = faker.Random.Double(50, 1000),
                PublicoAlvo = "Estudante",
                Valor = faker.Random.Double(1000,2000),
                Descricao = faker.Lorem.Paragraph()
            };

            _cursoRepositorioMock = new Mock<ICursoRepositorio>();
            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {
            _armazenadorDeCurso.Armazenar(_cursoDto);

            _cursoRepositorioMock.Verify(r => r.Adicionar(
                It.Is<Curso>(
                    c => c.Nome == _cursoDto.Nome && 
                    c.Descricao == _cursoDto.Descricao
                    )
                ));
        }

        [Fact]
        public void NaoDeveInformarPublicoAlvoInvalido()
        {
            var publicoAlvoInvalido = "Medico";
            _cursoDto.PublicoAlvo = publicoAlvoInvalido;

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDto))
                .ComMensagem("Publico Alvo Invalido");
        }
    }

    public interface ICursoRepositorio
    {
        void Adicionar(Curso curso);
        Curso ObterPeloNome(string nome);
    }

    public class ArmazenadorDeCurso
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public void Armazenar(CursoDto cursoDto)
        {
            Enum.TryParse(typeof(PublicoAlvo), cursoDto.PublicoAlvo, out var publicoAlvo);

            if(publicoAlvo == null)
                throw new ArgumentException("Publico Alvo Invalido");

            var curso = 
                new Curso(cursoDto.Nome, cursoDto.CargaHoraria, (PublicoAlvo)publicoAlvo, cursoDto.Valor, cursoDto.Descricao);

            _cursoRepositorio.Adicionar(curso); 
        }
    }

    public class CursoDto
    { 
        public string Nome { get; set; }
        public double CargaHoraria { get; set; }
        public string PublicoAlvo { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
    }
}
