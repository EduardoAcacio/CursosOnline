using CursosOnline.Domain._Base;

namespace CursosOnline.Domain.Cursos
{
    public interface ICursoRepositorio : IRepositorio<Curso>
    {
        Curso ObterPeloNome(string nome);
    }
}