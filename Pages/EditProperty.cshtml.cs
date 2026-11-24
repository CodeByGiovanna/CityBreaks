using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Pages;

public class EditPropertyModel : PageModel
{
    private readonly CityBreaksContext _context;

    public EditPropertyModel(CityBreaksContext context)
    {
        _context = context;
    }

    // Sem [BindProperty] de propósito: só os campos do TryUpdateModelAsync podem mudar
    public Property Property { get; set; } = null!;

    public SelectList Cities { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var property = await _context.Properties.FindAsync(id);
        if (property == null)
        {
            return NotFound();
        }

        Property = property;
        await LoadCitiesAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var propertyToUpdate = await _context.Properties.FindAsync(id);
        if (propertyToUpdate == null)
        {
            return NotFound();
        }

        if (await TryUpdateModelAsync(
                propertyToUpdate,
                nameof(Property),
                p => p.Name,
                p => p.PricePerNight,
                p => p.CityId))
        {
            await _context.SaveChangesAsync();

            var city = await _context.Cities.FindAsync(propertyToUpdate.CityId);
            return RedirectToPage("/CityDetails", new { name = city!.Name });
        }

        Property = propertyToUpdate;
        await LoadCitiesAsync();
        return Page();
    }

    private async Task LoadCitiesAsync()
    {
        var cities = await _context.Cities.OrderBy(c => c.Name).ToListAsync();
        Cities = new SelectList(cities, nameof(City.Id), nameof(City.Name));
    }
}