using GeeksFolders.Data;
using GeeksFolders.Interfaces;
using GeeksFolders.Models;
using Microsoft.EntityFrameworkCore;

namespace GeeksFolders.Repository
{
    public class GeekFolderRepository : IGeekFolderRepository
    {
        private readonly GeeksFolderContext _context;

        public GeekFolderRepository(GeeksFolderContext context)
        {
            _context = context;
        }

        public async Task<GeekFolder> GetFolderByFullPathAsync(string fullPath)
        {
            return await _context.GeekFolders
                .Where(f => f.FullPath == fullPath)
                .Include(c => c.Children)
                .FirstOrDefaultAsync();
        }
    }
}
