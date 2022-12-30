using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers{

    [ApiController] //para n retornar html 

    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/todaslistas")]
        public List<Tarefa> Get([FromServices] AppDbContext context){
                return context.Tarefas.ToList();
        }

        [HttpGet]
        [Route("/{id:int}")]
        public Tarefa GetId(
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

        [HttpPut]
        [Route("/{id:int}")]
        public Tarefa Atualizar(
            int id,
            [FromBody] Tarefa tarefa,
            [FromServices] AppDbContext context)
        {
                var atualizar = context.Tarefas.FirstOrDefault(x=>x.Id == id);
                if(atualizar == null)
                    return tarefa;
                tarefa.Titulo = tarefa.Titulo;
                tarefa.Concluido = tarefa.Concluido;

                context.Tarefas.Update(tarefa);
                context.SaveChanges();
                return tarefa;
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