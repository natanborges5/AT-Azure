using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPaises.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPaises.Resources.PaisesResource
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly ApiPaisesContext _context;
        private readonly IMapper _mapper;

        public PaisesController(ApiPaisesContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<PaisesController>
        [HttpGet]
        public IActionResult Get()
        {
            var list = buscarPaises();
           return Ok(list);
        }

  

        // GET api/<PaisesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var response = buscarPaisPorId(id);
                if (response == null)
                    return NotFound();

            return Ok(response);
        }


        // POST api/<PaisesController>
        [HttpPost]
        public IActionResult Post([FromBody] PaisesRequest paisesRequest)
        {
            var erros = paisesRequest.Erros();
            if (erros.Any())
                return UnprocessableEntity(erros);

            var response = criarPais(paisesRequest);
            return CreatedAtAction(nameof(Get), new {response.Id }, response);
        }


        // PUT api/<PaisesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] PaisesRequest request)
        {
            var response = buscarPaisPorId(id);
            if (response == null)
                return NotFound();

            alterarPais(id ,request);

            return NoContent();
        }


        // DELETE api/<PaisesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var response = buscarPaisPorId(id);
            if (response == null)
                return NotFound();

            ExcluirPais(id);

            return NoContent();
        }
        [HttpGet("{id}/estados")]
        public ActionResult GetEstadosDoPais([FromRoute] Guid id)
        {

            var pais = buscarPaisPorId(id);
            if (pais == null)
                return NotFound();

            var estados = pais.Estados;
            var response = _mapper.Map<List<EstadosResponse>>(pais.Estados);

            return Ok(response);


        }


        /////////////////////////////////////////////////////////////////////
        private void ExcluirPais(Guid id)
        {
            var pais = _context.Paises.Find(id);

            if (pais == null)
                return;
            _context.Paises.Remove(pais);
            _context.SaveChanges();
        }

        private PaisesResponse criarPais(PaisesRequest paisesRequest)
        {
            var pais = _mapper.Map<Paises>(paisesRequest);
            pais.Id = Guid.NewGuid();

            _context.Paises.Add(pais);
            _context.SaveChanges();
            return _mapper.Map<PaisesResponse>(pais);
        }
        private void alterarPais(Guid id, PaisesRequest request)
        {
            var pais = _context.Paises.Find(id);

            pais = _mapper.Map(request, pais);

            _context.Paises.Update(pais);
            _context.SaveChanges();

        }
        private PaisesResponse buscarPaisPorId(Guid id)
        {
            var pais = _context.Paises.Find(id);
            if (pais == null)
                return null;

            return _mapper.Map<PaisesResponse>(pais);
        }
        private IEnumerable<PaisesResponse> buscarPaises()
        {
            var paises = _context.Paises.ToList();
            return _mapper.Map<IEnumerable<PaisesResponse>>(paises);
        }
    }


    public class PaisesRequest
    {
        public string nome { get; set; }
        public string fotoBandeiraPais { get; set; }
        public string urlFoto { get; set; }

        public List<string> Erros()
        {
            return new List<string>();
        }
    }
    public class Paises
    {
        public Guid Id { get; set; }
        public string nome { get; set; }
        public string fotoBandeiraPais { get; set; }
        public string urlFoto { get; set; }
        public List<Estados> Estados { get; set; }
    }
    public class Estados
    {
        public int Id { get; set; }
        public string nomeEstado { get; set; }
        public string fotoEstado { get; set; }

    }
    public class PaisesResponse
    {
        public Guid Id { get; set; }
        public string nome { get; set; }
        public string fotoBandeiraPais { get; set; }
        public List<EstadosResponse> Estados { get; internal set; }
    }
    public class EstadosResponse
    {
        public string nomeEstado { get; set; }
        public string fotoEstado { get; set; }

    }

}
