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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Location.Controllers
{
    public class AreaController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;

        public AreaController(ICountryRepository countryRepository, IAreaRepository areaRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _areaRepository = areaRepository;
            _mapper = mapper;   
        }

  
        // GET: AreaController
        public ActionResult Index()
        {
            var area = _areaRepository.FindAll().ToList();
            var model1 = _mapper.Map<List<Area>, List<DetailsAreaViewModel>>(area);
            return View(model1);
        }

        public ActionResult Details(int id)
        {
            if (!_areaRepository.isExists(id))
            {
                return NotFound();
            }

            var Country = _areaRepository.FindById(id);
            var model = _mapper.Map<DetailsAreaViewModel>(Country);
            return View(model);
        }

        // GET: AreaController/Create
        public ActionResult Create()
        {
           ViewData["selectCountry"]= new SelectList(_countryRepository.FindAll(), "CountryId", "CountryName");
            return View();
        }

        // POST: AreaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAreaViewModel model)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var Area = _mapper.Map<Area>(model);
                
                var isSuccess = _areaRepository.Create(Area);
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

        // GET: AreaController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var Country = _areaRepository.FindById((int) id);
            var model = _mapper.Map<DetailsAreaViewModel>(Country);
            return View(model);
        }

        // POST: AreaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int i, DetailsAreaViewModel model)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var Area = _mapper.Map<Area>(model);

                var isSuccess = _areaRepository.Update(Area);
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

        // GET: AreaController/Delete/5
        public ActionResult Delete(int id)
        {
            var country = _areaRepository.FindById(id);
            var isSuccess = _areaRepository.Delete(country);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: AreaController/Delete/5
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
