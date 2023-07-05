﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Board;
using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public BoardController(TaskBoardAppDbContext context)
        {
            data = context;
        }

        public async Task<IActionResult> All()
        {
            var boards = await data
                              .Boards
                              .Select(b => new BoarderViewModel()
                               {
                                   Id = b.Id,
                                   Name = b.Name,
                                   Tasks = b.Tasks
                                            .Select(t => new TaskViewModel()
                                             {
                                                 Id = t.Id,
                                                 Title = t.Title,
                                                 Description = t.Description,
                                                 Owner = t.Owner.UserName
                                             })
                               })
                              .ToListAsync();

            return View(boards);
        }
    }
}
