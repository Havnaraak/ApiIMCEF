using ApiBase.Context;
using ApiBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBase.Methods;

namespace ApiBase.Controllers
{
    [ApiController]
    [Route("v1/pessoas")]
    public class PessoaController : ControllerBase
    {

        #region Get
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Pessoas>>> Get([FromServices] DataContext context)
        {
            var pessoas = await context.Pessoas.ToListAsync();

            return pessoas;
        }

        [HttpGet]
        [Route("IMC/{id:int}")]
        public async Task<ActionResult<string>> GetIMC([FromServices] DataContext context, int id)
        {

            var imc = CalculadoraIMC.CalcularIMC(await context.Pessoas
                .FirstOrDefaultAsync(x => x.ID == id));

            if (!imc.Equals("Pessoa não cadastrada"))
                return imc;
            else
                return BadRequest(imc);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Pessoas>> GetByID (
            [FromServices] DataContext context,
            int id)
        {
            var _pessoa = await context.Pessoas
                .FirstOrDefaultAsync(x => x.ID == id);

            if (_pessoa == null)
                return BadRequest("Pessoa não cadastrada");
            else 
                return _pessoa;
        }

        #endregion region

        #region Post
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Pessoas>> Post(
            [FromServices] DataContext context,
            [FromBody] Pessoas pessoa)
        {
            if (ModelState.IsValid)
            {
                if (await context.Pessoas.FirstOrDefaultAsync(x => x.ID == pessoa.ID) is null)
                {
                    context.Pessoas.Add(pessoa);
                    await context.SaveChangesAsync();
                    return pessoa;
                }
                else
                    return BadRequest("Pessoa já cadastrada");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion

        #region Put
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Pessoas>> Put(
            [FromServices] DataContext context,
            [FromBody] Pessoas pessoa)
        {
            if (ModelState.IsValid)
            {
                var _pessoa = await context.Pessoas
                   .FirstOrDefaultAsync(x => x.ID == pessoa.ID);

                if (_pessoa == null)
                    return BadRequest("Pessoa não encontrada");
                else
                {
                    _pessoa.Nome = pessoa.Nome;
                    _pessoa.Altura = pessoa.Altura;
                    _pessoa.Peso = pessoa.Peso;
                    _pessoa.Idade = pessoa.Idade;
                    _pessoa.CPF = pessoa.CPF;

                    context.SaveChanges();

                    return _pessoa;
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<string>> Delete(
            [FromServices] DataContext context,
            int id)
        {
            var _pessoa = await context.Pessoas
                .FirstOrDefaultAsync(x => x.ID == id);

            if (_pessoa is null)
                return BadRequest("Pessoa não encontrada");
            else
            {
                context.Pessoas.Remove(_pessoa);

                context.SaveChanges();

                return ("A pessoa foi removida com sucesso!");
            }

        }
        #endregion
    }
}
