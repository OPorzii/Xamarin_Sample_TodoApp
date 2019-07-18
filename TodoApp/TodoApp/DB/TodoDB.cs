using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TodoApp.Model;

namespace TodoApp.DB
{
    public class TodoDB
    {
        readonly SQLiteAsyncConnection database;

        public TodoDB(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Todo>().Wait();
        }

        public Task<Todo> GetItem(int id)
        {
            return database.Table<Todo>().Where(item => item.ID == id).FirstOrDefaultAsync();
        }

        public Task<List<Todo>> GetAllData()
        {
            return database.Table<Todo>().ToListAsync();
        }

        public Task<int> SaveTodo(Todo todo)
        {
            return todo.ID == 0 ? database.InsertAsync(todo) : database.UpdateAsync(todo);
        }

        public Task<int> DeleteTodo(Todo todo)
        {
            return database.DeleteAsync(todo);
        }

    }
}
