using API.Data;
using API.Models;
using API.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly TarefasDB _dbContext;
        
        public UsuarioRepositorio(TarefasDB tarefasDB) 
        {
            _dbContext = tarefasDB;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            if (_dbContext == null)
            {
                throw new Exception("Não há conexão com o banco de dados");
            }
            var usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            if (usuario == null)
            {
                throw new Exception($"Usuario para o Id:{id} não foi encontrado");
            }
            return usuario;

        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o Id:{id} não foi encontrado");
            }
            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;
            _dbContext.Usuarios.Update(usuarioPorId);
            _dbContext.SaveChanges();
            return usuarioPorId;    
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o Id:{id} não foi encontrado");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
