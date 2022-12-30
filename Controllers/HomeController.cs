using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers{

    [ApiController] //para n retornar html 

    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/obter")]
        public List<Tarefa> Get([FromServices] AppDbContext context){
                return context.Tarefas.ToList();
        }

        [HttpPost]
        [Route("/enviar")]
        public Tarefa Post(
            [FromBody] Tarefa tarefa,
            [FromServices] AppDbContext context){
                context.Tarefas.Add(tarefa);
                context.SaveChanges();
                return tarefa;
        }
    }

}