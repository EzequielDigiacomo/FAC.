using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace FAC.API.Filters
{
    public class ExceptionManagerFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _environment;
        public readonly IModelMetadataProvider _metadataProvider;

        public ExceptionManagerFilter(IWebHostEnvironment environment, IModelMetadataProvider metadataProvider)
        {
            _environment = environment;
            _metadataProvider = metadataProvider;
        }
        public void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult("ROMPISTE TODO MEN " + _environment.ApplicationName +
                "La excepcion del tipo : " + context.Exception.GetType());
        }
    }
}
