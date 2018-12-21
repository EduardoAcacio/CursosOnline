﻿using CursosOnline.Domain.Cursos;
using Moq;
using Xunit;

namespace CursosOnline.Domain.Tests.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        [Fact]
        public void DeveAdicionarCurso()
        {
            var cursoDto = new CursoDto
            {
                Nome = "Curso A",
                CargaHoraria = 80,
                PublicoAlvoId = 1,
                Valor = 850.00,
                Descricao = "Descricao"
            };

            var cursoRepositorioMock = new Mock<ICursoRepositorio>();

            var armazenadorDeCurso = new ArmazenadorDeCurso(cursoRepositorioMock.Object);

            armazenadorDeCurso.Armazenar(cursoDto);

            cursoRepositorioMock.Verify(r => r.Adicionar(It.IsAny<Curso>()));
        }
    }

    public interface ICursoRepositorio
    {
        void Adicionar(Curso curso);
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
            var curso = 
                new Curso(cursoDto.Nome, cursoDto.CargaHoraria, PublicoAlvo.Estudante, cursoDto.Valor, cursoDto.Descricao);

            _cursoRepositorio.Adicionar(curso); 
        }
    }

    public class CursoDto
    { 
        public string Nome { get; set; }
        public double CargaHoraria { get; set; }
        public int PublicoAlvoId { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
    }
}