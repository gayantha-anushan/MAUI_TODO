using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data
{
    public class TodoItemDatabase
    {
        SQLiteAsyncConnection Database;

        public TodoItemDatabase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<TodoModel>();
        }
        public async Task<List<TodoModel>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<TodoModel>().ToListAsync();
        }
        public async Task<TodoModel> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<TodoModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public async Task<int> SaveItemAsync(TodoModel item)
        {
            await Init();
            if (item.ID != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }
        public async Task<int> DeleteItemAsync(TodoModel item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }

    }
}
