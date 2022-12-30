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
    }

}