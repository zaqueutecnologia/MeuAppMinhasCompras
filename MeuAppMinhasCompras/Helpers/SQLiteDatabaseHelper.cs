﻿using MeuAppMinhasCompras.Models;
using SQLite;

namespace MeuAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;
        
        public SQLiteDatabaseHelper(string path) 
        {  
            _conn = new SQLiteAsyncConnection(path); 
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> insert(Produto p) 
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Produto>> update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
            );
        }

        public Task<int> Delete(int id) 
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id); 
        } 

        public Task<List<Produto>> GetAll() 
        {
          return _conn.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(String q) 
        {
            string sql = "SELECT * Produto WHERE descricao LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }
    }
}
