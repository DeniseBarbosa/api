using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers{

    [ApiController] //para n retornar html 

    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get(){
            return "Olá mundo";
        }
    }

}