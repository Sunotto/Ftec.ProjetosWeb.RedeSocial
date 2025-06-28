using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ftec.ProjetosWeb.RedeSocial.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var result = new ViewResult
            {
                ViewName = "ErroPersonalizado",
                ViewData = new ViewDataDictionary(
                    new EmptyModelMetadataProvider(),
                    new ModelStateDictionary())
                {
                    ["MensagemErro"] = exception.Message
                }
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
