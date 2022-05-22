using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace peliculasAPI.Filtros
{
    public class MiFiltroDeAccion : IActionFilter
    {
        private readonly ILogger<MiFiltroDeAccion> logger;

        public MiFiltroDeAccion(ILogger<MiFiltroDeAccion> logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context) //Antes de ejecutar la acción
        {
            logger.LogInformation("Antes de ejecutar la acción");
        }
        public void OnActionExecuted(ActionExecutedContext context) //Después de ejecutar la acción
        {
            logger.LogInformation("Después de ejecutar la acción");
        }


    }
}
