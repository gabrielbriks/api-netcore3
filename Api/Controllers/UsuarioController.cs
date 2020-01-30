using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {


        //Criando o primeiro metodo GET
        [HttpGet]
        [Route("")]//Se deixarmos vazio ele puxa a rota do pai definido lá em cima
                        //Utilizando uma Task para deixar o metodo de forma assincrona
        public async Task<ActionResult<List<Usuario>>> Get([FromServices] DataContext context)
        {
            var usuarios = await context.Usuarios.ToListAsync();
            return usuarios;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Usuario>> Post(
            [FromServices] DataContext context,//Recebendo o servço
            [FromBody]Usuario model) //Recebendo o corpo da requisição
        {
            if (ModelState.IsValid)//Validando a categoria
            {
                context.Usuarios.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}



//Ja tenho um cara que salva o Usuario em um banco do tipo DataContext
//Preciso de um outro cara para fazer uma requisição HTTP lá no GitHub

