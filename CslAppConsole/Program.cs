using CslAppConsole.Models;
using CslAppConsole.Services;
using System;

namespace CslAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Db db = new Db())
            {
                db.Database.EnsureCreated();
                Todo todo = new Todo();
                todo.Description = "Task 1";
                todo.Done = true;

                db.Todo.Add(todo);
                db.SaveChanges();
            }
            Console.WriteLine("Done ...");
        }
    }
}
