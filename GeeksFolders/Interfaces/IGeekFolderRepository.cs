using GeeksFolders.Models;

namespace GeeksFolders.Interfaces
{
    public interface IGeekFolderRepository
    {
        Task<GeekFolder> GetFolderByFullPathAsync(string fullPath);
    }
}
