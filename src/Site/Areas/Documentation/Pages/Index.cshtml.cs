using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DocsTest.Areas.Documentation.Pages
{
    public class IndexModel : PageModel
    {
        private IWebHostEnvironment _env;

        public string Slug
        {
            get
            {
                return (RouteData.Values["slug"] as string)?.Trim('/');
            }
        }

        public string Source
        {
            get
            {
                var pathToFile = Path.Combine(
                    _env.WebRootPath,
                    "_/documentation",
                    Slug ?? "",
                    "index.html"
                );
                using (StreamReader reader = System.IO.File.OpenText(pathToFile))
                {
                    return reader.ReadToEnd();
                }

            }
        }

        public IndexModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void OnGet()
        {

        }
    }
}
