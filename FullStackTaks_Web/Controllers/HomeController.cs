using AutoMapper;
using FullStackTask_Web.Model;
using FullStackTask_Web.Models;
using FullStackTask_Web.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace FullStackTaks_Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IRepository<NaseljeDTO> _naseljeRepository;
        private readonly IRepository<DrzavaDTO> _drzavaRepository;

        public HomeController(IMapper mapper, IRepository<NaseljeDTO> naseljeRepository, IRepository<DrzavaDTO> drzavaRepository)
        {
            _mapper = mapper;
            _naseljeRepository = naseljeRepository;
            _drzavaRepository = drzavaRepository;
        }


        //Show all entities [10]
        public async Task<IActionResult> Index()
        {
            List<NaseljeDTO> naselja = new();
            List<DrzavaDTO> drzave = new();

            var naseljeResponse = await _naseljeRepository.GetAllAsync<ApiResponse>();
            var apiResponseJsonNaselja = Convert.ToString(naseljeResponse.Result);
            var jsonObjectNaselja = JsonConvert.DeserializeObject<dynamic>(apiResponseJsonNaselja);
            
            var resultJson = naseljeResponse.Result.ToString();
            dynamic resultData = JsonConvert.DeserializeObject<dynamic>(resultJson);
            int totalRecords = resultData.totalRecords;

            if (naseljeResponse != null && naseljeResponse.IsSuccess)
            {
                naselja = JsonConvert.DeserializeObject<List<NaseljeDTO>>(Convert.ToString(jsonObjectNaselja.items));
                
            }

            var drzaveResponse = await _drzavaRepository.GetAllAsync<List<DrzavaDTO>>();
            if (drzaveResponse != null)
            {
                drzave = drzaveResponse;
            }

            ViewBag.TotalRecords = totalRecords;
            ViewBag.Drzave = drzave;
            return View(naselja);
        }


        //Create new 
        public async Task<IActionResult> Create(NaseljeDTO naseljeDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _naseljeRepository.CreateAsync<ApiResponse>(naseljeDTO);
                if (response != null && response.IsSuccess)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, errorMessage = response?.ErrorMessage.FirstOrDefault() });
                }
            }
            return Json(new { success = false, errorMessage = "Neispravni podaci." });
        }


        //Update
        public async Task<IActionResult> Update(int id, NaseljeDTO naseljeDTO)
        {
            var response = await _naseljeRepository.GetAsync<ApiResponse>(id);
            if (response != null && response.IsSuccess)
            {
                NaseljeDTO model = JsonConvert.DeserializeObject<NaseljeDTO>(Convert.ToString(response.Result));
                return View(naseljeDTO);
            }
            return NotFound();
        }


        //Delete 
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _naseljeRepository.GetAsync<ApiResponse>(id);
            if (response != null && response.IsSuccess)
            {
                NaseljeDTO model = JsonConvert.DeserializeObject<NaseljeDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }


    }
}
