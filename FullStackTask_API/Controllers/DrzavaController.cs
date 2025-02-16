using AutoMapper;
using FullStackTask_API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FullStackTask_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrzavaController : ControllerBase
    {



        protected ApiResponse _response;
        private readonly IRepository<Drzava> _drzavaRepository;
        private readonly IMapper _mapper;

        public DrzavaController(ApiResponse response, IRepository<Drzava> drzavaRepository, IMapper mapper)
        {
            _response = response;
            _drzavaRepository = drzavaRepository;
            _mapper = mapper;
        }




        //Get All Drzava entities
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            try
            {
                IEnumerable<Drzava> drzave = await _drzavaRepository.GetAllAsync();
                _response.Result = drzave;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(drzave);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.NoContent;
            }

            return _response;
        }





        //Get Single Drzava
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> Get(int id)
        {
            try
            {
                if (id.Equals(null))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var result = await _drzavaRepository.GetAsync(id);
                if (result == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(result);
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
        public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateDrzavaDTO drzavaDTO) 
        {
            try
            {
                if (drzavaDTO.Equals(null))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                Drzava model = _mapper.Map<Drzava>(drzavaDTO);
                await _drzavaRepository.CreateNewAsync(model);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex) 
            {
                _response.ErrorMessage = new List<string> { ex.Message };
                _response.StatusCode= HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
            }
        
            return _response;
        }




        //Update
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> Update(int id, [FromBody] DrzavaDTO drzavaDTO)
        {
            try
            {
                if (id != drzavaDTO.Id || drzavaDTO.Equals(null))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                Drzava model = _mapper.Map<Drzava>(drzavaDTO);
                await _drzavaRepository.UpdateAsync(model);
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
        public async Task<ActionResult<ApiResponse>> Delete(int id, [FromBody] DrzavaDTO drzavaDTO)
        {
            try
            {
                if (id.Equals(null))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var model =  await _drzavaRepository.GetAsync(id);

                if (model == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound();
                }

                await _drzavaRepository.DeleteAsync(model);
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
