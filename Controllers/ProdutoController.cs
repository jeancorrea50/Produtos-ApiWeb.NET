﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosApiWeb.Data;
using ProdutosApiWeb.Models;

namespace ProdutosApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoDbContext _context;

        public ProdutoController(ProdutoDbContext context)
        {
            _context = context;
        }

        // GET: api/Produto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetProdutos()
        {
            return (await _context.Produtos.OrderBy(x => x.IdProduto).AsNoTracking().ToListAsync());
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> GetProdutoModel(int id)
        {
            var produtoModel = await _context.Produtos.FindAsync(id);

            if (produtoModel == null)
            {
                return NotFound();
            }

            return produtoModel;
        }

        // PUT: api/Produto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutoModel(int id, ProdutoModel produtoModel)
        {
            if (id != produtoModel.IdProduto)
            {
                return BadRequest();
            }

            _context.Entry(produtoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Produto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> PostProdutoModel(ProdutoModel produtoModel)
        {
            _context.Produtos.Add(produtoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdutoModel", new { id = produtoModel.IdProduto }, produtoModel);
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutoModel(int id)
        {
            var produtoModel = await _context.Produtos.FindAsync(id);
            if (produtoModel == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produtoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoModelExists(int id)
        {
            return _context.Produtos.Any(e => e.IdProduto == id);
        }
    }
}
