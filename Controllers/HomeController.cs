using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers{

    [ApiController] //para n retornar html 

    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/obter")]
        public string Get(){
            return "Obtendo informações";
        }
    }

}