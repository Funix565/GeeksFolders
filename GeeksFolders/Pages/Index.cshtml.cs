using GeeksFolders.Interfaces;
using GeeksFolders.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeeksFolders.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IGeekFolderRepository _repository;

        public IndexModel(ILogger<IndexModel> logger, IGeekFolderRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public GeekFolder Folder { get; set; }

        public async Task<IActionResult> OnGetAsync(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                Folder = await _repository.GetFolderByFullPathAsync("/");
            }
            else
            {
                Folder = await _repository.GetFolderByFullPathAsync(path);
                if (Folder == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }
    }
}