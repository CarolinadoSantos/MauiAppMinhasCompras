using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteConnection _conn;
        public SQLiteDatabaseHelper(string path) 
        { 
            _conn = new SQLiteConnection(path);
            _conn.CreateTable<Produto>().Wait();
        }
        public Task<int> Insert(Produto p) 
        { 
            return _conn.Insert(p);
        }
        public Task<List<Produto>> Update(Produto p) 
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";

            return _conn.Query<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
            );
        }
        public Task<int> Delete(int id) 
        {
            return _conn.Table<Produto>().Delete(i  => i.Id == id);
        }
        public Task<List<Produto>> GetAll () 
        { 
            return _conn.Table<Produto>().ToList();
        }
        public Task<List<Produto>> Search (string q) 
        {
            string sql = "SELECT * Produto WHERE descricao LIKE '%" + q + "%'";

            return _conn.Query<Produto>(sql);
        }


    }
}
