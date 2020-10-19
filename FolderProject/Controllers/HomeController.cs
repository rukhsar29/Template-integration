using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Books.DTO;
using Books.Repository.Implementations;
using Books.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FolderProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUsers _user;
        public HomeController(IUsers us)
        {
            _user = us;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllUser()
        { 
            var data_ = await _user.GetUserDetails();
            //return View(data);
            return Json(new { data = data_ });

        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserParams insert)
        {
            var result = await _user.AddNewBook(insert);

            return Json(result);
        }
        public async Task<IActionResult> Delete(int id)
        {
             await _user.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var us = _user.GetEditUser(id);
            return Json(us);
        }
        [HttpPost]
        public IActionResult Edit(Users viewModel)
        {
            if (ModelState.IsValid)
            {
               _user.PostEditUser(viewModel);
            }
            return Json(new { data = true });

        }
    
    }
}