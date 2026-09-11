using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SonadaBeds.Web.Data;
namespace SonadaBeds.Web.Controllers;
public class HomeController(SonadaDbContext db):Controller{public async Task<IActionResult> Index()=>View(await db.Products.Include(x=>x.Category).Where(x=>x.Featured).ToListAsync()); public IActionResult Privacy()=>View(); public IActionResult Error()=>View(); [Route("sitemap.xml")] public async Task<IActionResult> Sitemap(){var products=await db.Products.Select(x=>x.Slug).ToListAsync();var xml="<?xml version=\"1.0\" encoding=\"UTF-8\"?><urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\"><url><loc>https://sonadabeds.co.uk/</loc></url>"+string.Join("",products.Select(x=>$"<url><loc>https://sonadabeds.co.uk/products/{x}</loc></url>"))+"</urlset>";return Content(xml,"application/xml");}}
