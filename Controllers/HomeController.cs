using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers{

    [ApiController] //para n retornar html 

    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/todaslistas")]
        public List<Tarefa> ObterTodos([FromServices] AppDbContext context){
                return context.Tarefas.ToList();
        }

        [HttpGet]
        [Route("/{id:int}")]
        public Tarefa ObterPorId(
            int id,
            [FromServices] AppDbContext context)
        {
                return context.Tarefas.FirstOrDefault(x=>x.Id == id);
        }

        [HttpPost]
        [Route("/cadastrar")]
        public Tarefa Post(
            [FromBody] Tarefa tarefa,
            [FromServices] AppDbContext context){
                context.Tarefas.Add(tarefa);
                context.SaveChanges();
                return tarefa;
        }

        [HttpPut ("/{id:int}")]
        public IActionResult Put(
           [FromRoute] int id,
            [FromBody] Tarefa tarefa,
            [FromServices] AppDbContext context)
        {
                var atualizar = context.Tarefas.FirstOrDefault(x=>x.Id == id);
                if(atualizar == null)
                    return NotFound();
                atualizar.Titulo = tarefa.Titulo;
                atualizar.Concluido = tarefa.Concluido;

                context.Tarefas.Update(atualizar);
                context.SaveChanges();
                return Ok(atualizar);
        }


        [HttpDelete]
        [Route("/{id:int}")]
        public Tarefa Excluir(
            int id,
            //[FromBody] Tarefa tarefa,
            [FromServices] AppDbContext context)
        {
                var excluir = context.Tarefas.FirstOrDefault(x=>x.Id == id);
            
                context.Tarefas.Remove(excluir);
                context.SaveChanges();
                return excluir;
        }
        


    }

}