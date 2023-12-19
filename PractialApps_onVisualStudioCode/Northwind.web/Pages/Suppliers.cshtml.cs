
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;

namespace Northwind.Web.Pages;
public class SuppliersModel : PageModel
{
    public IEnumerable<Supplier> Suppliers {get; set;}

    private NorthwindContext db;

    public void OnGet()
    {
        ViewData["Title"]="Suppliers Page";
        Suppliers = db.Suppliers.OrderBy(c => c.Country).ThenBy(c =>c.CompanyName);
    }

    public SuppliersModel(NorthwindContext northWindInjected)
    {
        db=northWindInjected;
    }

}