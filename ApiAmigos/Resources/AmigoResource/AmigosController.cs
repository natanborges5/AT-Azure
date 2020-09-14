using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAmigos.Data;
using ApiAmigos.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiAmigos.Resources.AmigoResource
{
    [Route("api/[controller]")]
    [ApiController]
    public  class AmigosController : ControllerBase
    {
        private readonly ApiAmigosContext _context;
        private readonly IMapper _mapper;

        public AmigosController(ApiAmigosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
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
        public IActionResult Post([FromBody] AmigosRequest amigosRequest)
        {
            var erros = amigosRequest.Erros();
            if (erros.Any())
                return UnprocessableEntity(erros);

            var response = criarPais(amigosRequest);
            return CreatedAtAction(nameof(Get), new { response.id }, response);
        }


        // PUT api/<PaisesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] AmigosRequest request)
        {
            var response = buscarPaisPorId(id);
            if (response == null)
                return NotFound();

            alterarPais(id, request);

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
 

        /////////////////////////////////////////////////////////////////////
        private void ExcluirPais(Guid id)
        {
            var pais = _context.Amigos.Find(id);

            if (pais == null)
                return;
            _context.Amigos.Remove(pais);
            _context.SaveChanges();
        }

        private AmigosResponse criarPais(AmigosRequest amigosRequest)
        {
            var amigo = _mapper.Map<Amigos>(amigosRequest);
            amigo.Id = Guid.NewGuid();

            _context.Amigos.Add(amigo);
            _context.SaveChanges();
            return _mapper.Map<AmigosResponse>(amigo);
        }
        private void alterarPais(Guid id, AmigosRequest request)
        {
            var amigo = _context.Amigos.Find(id);

            amigo = _mapper.Map(request, amigo);

            _context.Amigos.Update(amigo);
            _context.SaveChanges();

        }
        private AmigosResponse buscarPaisPorId(Guid id)
        {
            var amigo = _context.Amigos.Find(id);
            if (amigo == null)
                return null;

            return _mapper.Map<AmigosResponse>(amigo);
        }
        private IEnumerable<AmigosResponse> buscarPaises()
        {
            var amigos = _context.Amigos.ToList();
            return _mapper.Map<IEnumerable<AmigosResponse>>(amigos);
        }
    }
}
