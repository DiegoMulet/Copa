using System.Threading.Tasks;
using AutoMapper;
using Copa.Domain;
using Copa.Repository;
using Copa.WebApi.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Copa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaveController : ControllerBase
    {
        public readonly ICopaRepository _repo;
        public IMapper _mapper { get; }
        
        public ChaveController(ICopaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var chaves = await _repo.GetAllChaveAssync(false);

                var results = _mapper.Map<ChaveDto[]>(chaves);
                
                return Ok(results);
                
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }    

        [HttpGet("{ChaveId}")]
        public async Task<IActionResult> Get(int ChaveId)
        {
            try
            {
                var chave = await _repo.GetAllChaveAssyncById(ChaveId);

                var results = _mapper.Map<ChaveDto[]>(chave);

                return Ok(results);
                
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }            
        }

        [HttpPost]
        public async Task<IActionResult> Post(ChaveDto model)
        {
             try
            {
                var chave = _mapper.Map<Chave>(model);

                _repo.Add(chave);

                if( await _repo.SaveChangesAssync())
                {
                    return Created($"/api/chave/{chave.Id}", _mapper.Map<ChaveDto>(chave)); 
                }
                
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
            return BadRequest();            
        }

        [HttpPut("{ChaveId}")]
        public async Task<IActionResult> Put(int ChaveId,ChaveDto model)
        {
            try
            {
                var chave = await _repo.GetAllChaveAssyncById(ChaveId);
                if(chave == null) return NotFound();
                
                _mapper.Map(model,chave);
                
                _repo.Update(chave);
                
                if(await _repo.SaveChangesAssync())
                {
                    return Created($"/api/chave/{chave.Id}", _mapper.Map<ChaveDto>(chave));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();
        }

        [HttpDelete("{ChaveId}")]
        public async Task<IActionResult> Delete(int ChaveId)
        {
            try
            {
                var chave = await _repo.GetAllChaveAssyncById(ChaveId);
                if(chave == null) return NotFound();
                
                _repo.Delete(chave);
                
                if(await _repo.SaveChangesAssync())
                {
                    return Ok();
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();
        }

    }
}