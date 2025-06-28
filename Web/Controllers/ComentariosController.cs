using Ftec.ProjetosWeb.RedeSocial.Aplicacao.DTO;
using Microsoft.AspNetCore.Mvc;
using Web.HTTPClient;

public class ComentariosController : Controller
{
    private APIHttpClient api = new APIHttpClient("https://localhost:5001/api/");

    public ActionResult Index()
    {
        var lista = api.Get<List<ComentarioDTO>>("comentarios");
        return View(lista);
    }

    [HttpPost]
    public ActionResult Criar(ComentarioDTO dto)
    {
        api.Post("comentarios", dto);
        return RedirectToAction("Index");
    }

    public ActionResult Apagar(Guid id)
    {
        api.Delete<Guid>("comentarios/", id);
        return RedirectToAction("Index");
    }
}