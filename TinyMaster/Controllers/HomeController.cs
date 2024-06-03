﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TinyMaster.Models;
using TinyMaster.Models.Entities;
using TinyMaster.ViewModels;

namespace TinyMaster.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly TinyMasterDbContext _db;

        public HomeController(TinyMasterDbContext db)
        {
            _db = db;
        }


        List<HomeViewModel> homeViewModel = new List<HomeViewModel>();

        [HttpGet]
        public ActionResult Home()
        {

            List<ProductModel> model = new List<ProductModel>();
            foreach (var item in _db.Urunler)
            {

                ProductModel product = new ProductModel
                {
                    Id = item.Id,
                    Isim = item.Isim,
                    Aciklama = item.Aciklama,
                    FotoUrl = item.FotoUrl,
                    Fiyat = item.Fiyat
                };
                model.Add(product);
            }



            for (int i = 0; i < model.Count(); i++)
            {
                HomeViewModel viewModel = new HomeViewModel();

                viewModel.UrunId = model[i].Id;
                viewModel.UrunAdi = model[i].Isim;
                viewModel.UrunFiyat = model[i].Fiyat;
                viewModel.FotoUrl = model[i].FotoUrl;
                viewModel.Aciklama = model[i].Aciklama;

                homeViewModel.Add(viewModel);
            }

            return View(homeViewModel);
        }

        [HttpPost]
        public ActionResult Index(int UrunId)
        {



            return View("Index");
        }
    }
}