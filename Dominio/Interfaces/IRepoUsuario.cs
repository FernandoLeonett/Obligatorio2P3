namespace Dominio.Interfaces
{
    public interface IRepoUsuario : IRepositorio<Usuario>
    {
        Usuario Login(Usuario u);


    }
}
