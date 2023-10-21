using mf_dev_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mf_dev_backend.Controllers
{
    public class VeiculosController : Controller
    {
        // variavel context conectada com o banco de dados
        private readonly AppDbContext _context;
        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        // retornando os dados de forma assíncrona 
        public async Task<IActionResult> Index()
        {
            var dados = await _context.Veiculos.ToListAsync();

            return View(dados);
        }
        // Adicionar novos Veículos
        public IActionResult Create()
        {
           return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Veiculos.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");


            }

            return View(veiculo);
        }
        // Editando informações dos Veículos
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados =await _context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost]
        public async Task <IActionResult> Edit(int id, Veiculo veiculo)
        {
            if (id != veiculo.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Veiculos.Update(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }
        // Visualização das informações dos Veículos
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);

        }
        // Deletando os dados dos Veículos
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);


            if (dados == null)
                return NotFound();

            _context.Veiculos.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }


    }
}
