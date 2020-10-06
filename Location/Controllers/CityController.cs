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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Location.Controllers
{
    public class CityController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        private readonly IAreaRepository _areaRepository;

        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityController(ICountryRepository countryRepository, IAreaRepository areaRepository, ICityRepository cityRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _areaRepository = areaRepository;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }


 
        // GET: CityController
        public ActionResult Index()
        {
            var city = _cityRepository.FindAll().ToList();
            var model = _mapper.Map<List<City>, List<DetailsCityViewModel>>(city);
            return View(model);
        }

        // GET: CityController/Details/5
        public ActionResult Details(int id)
        {
            if (!_cityRepository.isExists(id))
            {
                return NotFound();
            }

            var city = _cityRepository.FindById(id);
            var model = _mapper.Map<DetailsCityViewModel>(city);
            return View(model);
        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            ViewData["SelectCountry"] = new SelectList(_countryRepository.FindAll(), "CountryId", "CountryName");
            ViewData["selectArea"] = new SelectList(_areaRepository.FindAll(), "AriaId", "AriaName");
            return View();
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatCityViewModel model)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var city = _mapper.Map<City>(model);

                var isSuccess = _cityRepository.Create(city);
                if (!isSuccess)
                    return View(model);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "در ثبت اطلاعات مشکلی به وجود آمده است");
                return View(model);

            }
        }

        // GET: CityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            var city = _cityRepository.FindById(id);
            var isSuccess = _cityRepository.Delete(city);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        //// POST: CityController/Delete/5
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
