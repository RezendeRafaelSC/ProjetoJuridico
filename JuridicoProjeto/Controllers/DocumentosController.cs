﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JuridicoProjeto.Data;
using JuridicoProjeto.Models;
using Microsoft.AspNetCore.Authorization;

namespace JuridicoProjeto.Controllers
{
    [Authorize]
    public class DocumentosController : Controller
    {
        private readonly DataContext _context;

        public DocumentosController(DataContext context)
        {
            _context = context;
        }

        // GET: Documentos
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Documento.Include(d => d.Processo);
            return View(await dataContext.ToListAsync());
        }

        // GET: Documentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documento = await _context.Documento
                .Include(d => d.Processo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documento == null)
            {
                return NotFound();
            }

            return View(documento);
        }

        // GET: Documentos/Create
        public IActionResult Create()
        {
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "Id", "Id");
            return View();
        }

        // POST: Documentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Caminho,Extensao,ProcessoId")] Documento documento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "Id", "Id", documento.ProcessoId);
            return View(documento);
        }

        // GET: Documentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documento = await _context.Documento.FindAsync(id);
            if (documento == null)
            {
                return NotFound();
            }
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "Id", "Id", documento.ProcessoId);
            return View(documento);
        }

        // POST: Documentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Caminho,Extensao,ProcessoId")] Documento documento)
        {
            if (id != documento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentoExists(documento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProcessoId"] = new SelectList(_context.Processo, "Id", "Id", documento.ProcessoId);
            return View(documento);
        }

        // GET: Documentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documento = await _context.Documento
                .Include(d => d.Processo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documento == null)
            {
                return NotFound();
            }

            return View(documento);
        }

        // POST: Documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documento = await _context.Documento.FindAsync(id);
            if (documento != null)
            {
                _context.Documento.Remove(documento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentoExists(int id)
        {
            return _context.Documento.Any(e => e.Id == id);
        }
    }
}
