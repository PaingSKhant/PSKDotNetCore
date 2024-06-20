﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSKDotNetCore.MvcApp_New_.Db;
using PSKDotNetCore.MvcApp_New_.Models;


namespace PSKDotNetCore.MvcApp_New_.Controllers;

public class BlogController : Controller
{
    private readonly AppDbContext _db;

    public BlogController(AppDbContext db)
    {
        _db = db;
    }
    public async Task<IActionResult> Index()
    {
        var lst = await _db.Blogs.ToListAsync();
        return View(lst);
    }

    [ActionName("Create")]
    public IActionResult BlogCreate()
    {

        return View("BlogCreate");
    }

    [HttpPost]
    [ActionName("Save")]
    public async Task<IActionResult>  BlogCreate(BlogModel blog) 
    { 
        await _db.Blogs.AddAsync(blog);
        var result = await _db.SaveChangesAsync();
        return Redirect("/Blog");
    }
}