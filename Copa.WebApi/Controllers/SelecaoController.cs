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
    public class SelecaoController : ControllerBase
    {
        public readonly ICopaRepository _repo;
        public readonly IMapper _mapper;
        
        public SelecaoController(ICopaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var selecoes = await _repo.GetAllSelecaoAssync(false);
                var results = _mapper.Map<SelecaoDto[]>(selecoes);
                return Ok(results);
                
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }    

        [HttpGet("{SelecaoId}")]
        public async Task<IActionResult> Get(int SelecaoId)
        {
            try
            {
                var selecao = await _repo.GetAllSelecaoAssyncById(SelecaoId);
                var results = _mapper.Map<SelecaoDto>(selecao);

                return Ok(results);
                
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }            
        }

        [HttpPost]
        public async Task<IActionResult> Post(SelecaoDto model)
        {
             try
            {
                var selecao = _mapper.Map<Selecao>(model);
                _repo.Add(selecao);

                if( await _repo.SaveChangesAssync())
                {
                    return Created($"/api/selecao/{selecao.Id}", _mapper.Map<SelecaoDto>(selecao)); 
                }
                
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
            return BadRequest();            
        }

        [HttpPut("{SelecaoId}")]
        public async Task<IActionResult> Put(int SelecaoId,SelecaoDto model)
        {
            try
            {
                var selecao = await _repo.GetAllSelecaoAssyncById(SelecaoId);
                if(selecao == null) return NotFound();
                
                _mapper.Map(model,selecao);
                _repo.Update(selecao);
                
                if(await _repo.SaveChangesAssync())
                {
                    return Created($"/api/selecao/{selecao.Id}", _mapper.Map<SelecaoDto>(selecao));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();
        }

        [HttpDelete("{SelecaoId}")]
        public async Task<IActionResult> Delete(int SelecaoId)
        {
            try
            {
                var selecao = await _repo.GetAllSelecaoAssyncById(SelecaoId);
                if(selecao == null) return NotFound();
                
                _repo.Delete(selecao);
                
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