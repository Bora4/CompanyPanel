using Ana_Panel.Models;
using Ana_Panel.Models.Domain;
using Ana_Panel.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ana_Panel.Controllers
{
    public class StorageController : Controller
	{
        private readonly SirketVeritabaniContext _context;
        public StorageController(SirketVeritabaniContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            List<IndexProductViewModel> productsList = new();
            foreach(var product in products)
            {
                
                var station = await _context.Stations.FindAsync(product.StationId);
                if(station != null)
                {
                    string stationname;
                    if (product.DestinationId != null)
                    {
                        var destination = await _context.Stations.FindAsync(product.DestinationId);
                        stationname = station.Name + "'den " + destination.Name + "'e gidiyor.";
                    } else
                    {
                        stationname = station.Name;
                    }
                    IndexProductViewModel indexProduct = new()
                    {
                        ProductId = product.ProductId,
                        Barcode = product.Barcode,
                        Name = product.Name,
                        Stock = product.Stock,
                        Color = product.Color,
                        DateCreated = product.DateCreated,
                        DateUpdated = product.DateUpdated,
                        StationName = stationname
                    };
                    productsList.Add(indexProduct);
                }

            }
            return View(productsList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel prod)
        {
            long? num;
            if (prod.Barcode == null)
            {
                Random rnd = new();
                num = rnd.Next();
            }
            else
            {
                num = prod.Barcode;
            }

            var station = await _context.Stations.FindAsync(prod.StationId);
            if(station != null)
            {
                prod.StationId = 1;
                var check = await _context.Products.FirstOrDefaultAsync(x => x.Barcode == num);
                if(check != null)
                {
                    check.Stock += prod.Stock;
                    check.DateUpdated = DateTime.Now;
                } else
                {
                    Product product = new()
                    {
                        Barcode = num,
                        Name = prod.Name,
                        Stock = prod.Stock,
                        Color = prod.Color,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        Station = station,
                    };
                    await _context.Products.AddAsync(product);
                }
                
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Add");

            

        }

        [HttpGet]
        public async Task<IActionResult> View(long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            
            if (product != null)
            {
                var station = await _context.Stations.FindAsync(product.StationId);
                if (station != null)
                {
                    var viewModel = new UpdateProductViewModel()
                    {
                        ProductId = product.ProductId,
                        Barcode = product.Barcode,
                        Name = product.Name,
                        Stock = product.Stock,
                        Color = product.Color,
                        DateCreated = product.DateCreated,
                        DateUpdated = product.DateUpdated,
                        StationId = product.StationId,
                        DestinationId = product.DestinationId,
                        StationName = station.Name
                    };
                    return await Task.Run(() => View("View", viewModel));
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateProductViewModel model)
        {
            var product = await _context.Products.FindAsync(model.ProductId);
            var station = await _context.Stations.FindAsync(model.StationId);
            if (product != null && station != null)
            {
                product.Barcode = model.Barcode;
                product.Name = model.Name;
                product.Stock = model.Stock;
                product.Color = model.Color;
                product.DateCreated = model.DateCreated;
                product.DateUpdated = DateTime.Now;
                product.Station = station;
                product.DestinationId = model.DestinationId;

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateProductViewModel model)
        {
            var product = await _context.Products.FindAsync(model.ProductId);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }
    }
}
