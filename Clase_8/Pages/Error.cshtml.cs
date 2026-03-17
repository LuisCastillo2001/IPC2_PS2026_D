using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase_8.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    public string RequestId { get; set; } = string.Empty;

    public bool ShowRequestId => RequestId != string.Empty;

    public void OnGet()
    {
        if (Activity.Current != null && Activity.Current.Id != null && Activity.Current.Id != string.Empty)
        {
            RequestId = Activity.Current.Id;
            return;
        }

        RequestId = HttpContext.TraceIdentifier;
    }
}

