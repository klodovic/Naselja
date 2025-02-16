using AutoMapper;
using FullStackTask_API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FullStackTask_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NaseljeController : ControllerBase
    {


        protected ApiResponse _response;
        private readonly IRepository<Naselje> _naseljeRepository;
        private readonly IMapper _mapper;

        public NaseljeController(ApiResponse response, IRepository<Naselje> naseljeRepository, IMapper mapper)
        {
            _response = response;
            _naseljeRepository = naseljeRepository;
            _mapper = mapper;
        }





        //Get All Naselje entities with Drzava and paging 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<ApiResponse>> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var naselja = await _naseljeRepository.GetAllWithIncludesPageAsync(pageNumber, pageSize, n => n.Drzava);

                _response.Result = new
                {
                    Items = naselja.Results,
                    TotalRecords = naselja.RecordCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.NoContent;
            }
            return _response;
        }




        //Get Single Naselje with Drzava
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var naselje = await _naseljeRepository.GetSingleWithIncludesAsync(id, n => n.Drzava);
                if (naselje == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(naselje);
            }
            catch (Exception ex)
            {
                _response.ErrorMessage = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = false;
            }
            return _response;
        }





        //Create new
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateNaseljeDTO naseljeDTO)
        {
            try
            {
                if (naseljeDTO.Equals(null))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                Naselje model = _mapper.Map<Naselje>(naseljeDTO);
                await _naseljeRepository.CreateNewAsync(model);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessage = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
            }
            return _response;
        }





        //Update
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> Update(int id, [FromBody] NaseljeDTO naseljeDTO)
        {
            try
            {
                if (id != naseljeDTO.Id || naseljeDTO.Equals(null))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                Naselje model = _mapper.Map<Naselje>(naseljeDTO);
                await _naseljeRepository.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessage = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
            }
            return _response;
        }





        //Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id, [FromBody] NaseljeDTO naseljeDTO)
        {
            try
            {
                if (id.Equals(null))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var model = await _naseljeRepository.GetAsync(id);

                if (model == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound();
                }

                await _naseljeRepository.DeleteAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch
            {
                _response.IsSuccess = false;
            }

            return _response;
        }

    }
}
