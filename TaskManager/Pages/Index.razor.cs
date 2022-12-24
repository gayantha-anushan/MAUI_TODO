using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data;

namespace TaskManager.Pages
{
    public partial class Index
    {
        private List<TodoModel> todoList = new();
        private string todoNow = "";

        protected override async Task OnInitializedAsync()
        {
            await LoadDetails();
            //return base.OnInitializedAsync();
        }

        private async Task LoadDetails()
        {
            todoList = await _todoItemDatabase.GetItemsAsync();
        }

        private async void deleteItem(TodoModel id)
        {
            int res = await _todoItemDatabase.DeleteItemAsync(id);
            Thread.Sleep(1000);
            if (res > 0)
            {
                await LoadDetails();
            }
        }
        private async void InsertItem()
        {
            TodoModel tm = new TodoModel();
            tm.ID = 0;
            tm.Todo = todoNow;
            int res = await _todoItemDatabase.SaveItemAsync(tm);
            Thread.Sleep(1000);
            if (res > 0)
            {
                await LoadDetails();
            }
        }
    }
}
