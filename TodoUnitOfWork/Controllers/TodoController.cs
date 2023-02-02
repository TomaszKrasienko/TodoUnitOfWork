using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoUnitOfWork.Data.Repositories;
using TodoUnitOfWork.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoUnitOfWork.Controllers
{
    public class TodoController : Controller
    {
        private readonly IGenericUnitOfWork _genericUnitOfWork;
        public TodoController(IGenericUnitOfWork genericUnitOfWork)
        {
            _genericUnitOfWork = genericUnitOfWork;
        }
        public IActionResult Index()
        {
            var items = _genericUnitOfWork.Repository<TodoTask>().GetAll();
            return View(items);
        }
        public IActionResult Delete(Guid taskId)
        {
            TodoTask task = _genericUnitOfWork.Repository<TodoTask>().GetById(x => x.Id == taskId);
            _genericUnitOfWork.Repository<TodoTask>().Delete(task);
            _genericUnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(Guid taskId)
        {
            TodoTask task = _genericUnitOfWork.Repository<TodoTask>().GetById(x => x.Id == taskId);
            return View(task);
        }
        public IActionResult AddTask()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TodoTask todoTask)
        {
            _genericUnitOfWork.Repository<TodoTask>().Add(todoTask);
            _genericUnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
}

