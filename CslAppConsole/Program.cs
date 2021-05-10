using CslAppConsole.Models;
using CslAppConsole.Services;
using System;
using System.Linq;

namespace CslAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Db db = new Db())
            {
                db.Database.EnsureCreated();
                //Todo todo = new();
                //todo.Description = "Task 4";
                //todo.Done = true;

                //db.Todo.Add(todo);
                //db.SaveChanges();

                Todo todo = db.Todo.Find(1);
                todo.Done = !todo.Done;
                db.SaveChanges();

                db.Todo.ToList()
                    .ForEach(x =>
                    {
                        Console.WriteLine("{0} {1} {2} {3} {4}", x.Id, x.Description, x.Done, x.CreatedAt, x.UpdatedAt);
                    });
            }
            Console.WriteLine("");
            Console.WriteLine("Done ...");
        }
    }
}
