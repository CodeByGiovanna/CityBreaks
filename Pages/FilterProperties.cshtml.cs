using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages;

public class FilterPropertiesModel : PageModel
{
    private readonly IPropertyService _propertyService;

    public FilterPropertiesModel(IPropertyService propertyService)
    {
        _propertyService = propertyService;
    }

    [BindProperty(SupportsGet = true)]
    public decimal? MinPrice { get; set; }

    [BindProperty(SupportsGet = true)]
    public decimal? MaxPrice { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? CityName { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? PropertyName { get; set; }

    public List<Property> Results { get; set; } = new();

    public List<string> AppliedFilters { get; set; } = new();

    public async Task OnGetAsync()
    {
        Results = await _propertyService.GetFilteredAsync(MinPrice, MaxPrice, CityName, PropertyName);

        if (MinPrice.HasValue) AppliedFilters.Add($"Preço mínimo: € {MinPrice.Value:N2}");
        if (MaxPrice.HasValue) AppliedFilters.Add($"Preço máximo: € {MaxPrice.Value:N2}");
        if (!string.IsNullOrWhiteSpace(CityName)) AppliedFilters.Add($"Cidade contém: \"{CityName}\"");
        if (!string.IsNullOrWhiteSpace(PropertyName)) AppliedFilters.Add($"Nome contém: \"{PropertyName}\"");
    }
}