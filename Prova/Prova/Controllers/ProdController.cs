using Microsoft.AspNetCore.Mvc;

namespace Prova.Controllers
{

    public class ProdController : Controller
    { 
        private readonly AppContext _appCont;

        public ProdController(AppContext appContext)
        {
            _appCont = appContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdId, NomeProd")] Prod produto)
        {
            if (ModelState.IsValid)
            {
                _appCont.Add(produto);
                await _appCont.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }


        public async Task<IActionResult> Delete<Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _appCont.Prod.FirstOrDefauntAsync(m => m.Id == id);
            if (id == null)
            {
                return NotFound();
            }

            return View(produtos);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var produtos = await _appCont.Prod.FindAsync(id);
            _appCont.Prod.Remove(produto);
            await _appCont.SaveChangeAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
