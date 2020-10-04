using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Location.Data;
using Location.Models;
using Location.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Location.Repository;

namespace Location.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
     
        // GET: CountryController
        public ActionResult Index()
        {
            var country = _countryRepository.FindAll().ToList();
            var model = _mapper.Map<List<Country>, List<DetailsCountryViewModel>>(country);

            return View(model);
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            if (!_countryRepository.isExists(id))
            {
                return NotFound();
            }
            
            var Country = _countryRepository.FindById(id);
            var model = _mapper.Map<DetailsCountryViewModel>(Country);
            return View(model);
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCountryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var Country = _mapper.Map<Country>(model);
                var isSuccess = _countryRepository.Create(Country);
                if(!isSuccess)
                    return View(model);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "در ثبت اطلاعات مشکلی به وجود آمده است");
                return View(model);
                
            }
        }

        // GET: CountryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DetailsCountryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var Country = _mapper.Map<Country>(model);
                var isSuccess = _countryRepository.Update(Country);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "در ویرایش اطلاعات مشکلی به وجود آمده است");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "در ثبت اطلاعات مشکلی به وجود آمده است");
                return View(model);
            }
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            var country = _countryRepository.FindById(id);
            var isSuccess = _countryRepository.Delete(country);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
           
        }

        //// POST: CountryController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
