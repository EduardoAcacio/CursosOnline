namespace CursosOnline.Domain.Cursos
{
    public interface ICursoRepositorio
    {
        void Adicionar(Curso curso);
        Curso ObterPeloNome(string nome);
    }
}