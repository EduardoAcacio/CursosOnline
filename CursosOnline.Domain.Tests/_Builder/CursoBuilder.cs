using CursosOnline.Domain.Cursos;

namespace CursosOnline.Domain.Tests._Builder
{
    public class CursoBuilder
    {
        private string _nome = "informatica básica";
        private double _cargaHoraria = 80;
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
        private double _valor = 950;
        private string _descricao = "Uma descricao";

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public CursoBuilder ComCargaHoraria(double cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder ComValor(double valor)
        {
            _valor = valor; ;
            return this;
        }

        public CursoBuilder ComPublicoAlvo(PublicoAlvo publicAlvo)
        {
            _publicoAlvo = publicAlvo;
            return this;
        }

        public CursoBuilder ComDescricacao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public Curso Build()
        {
            return new Curso(_nome, _cargaHoraria, _publicoAlvo, _valor, _descricao);
        }
    }
}
