using GeeksFolders.Models;

namespace GeeksFolders.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GeeksFolderContext context)
        {
            if (context.GeekFolders.Any())
            {
                return;
            }

            var geekFolders = new GeekFolder[]
            {
                new GeekFolder { Name = "/", ParentId = null, FullPath = "/" },
                new GeekFolder { Name = "Creating Digital Images", ParentId = 1, FullPath = "Creating Digital Images" },
                new GeekFolder { Name = "Resources", ParentId = 2, FullPath = "Creating Digital Images/Resources" },
                new GeekFolder { Name = "Evidence", ParentId = 2, FullPath = "Creating Digital Images/Evidence" },
                new GeekFolder { Name = "Graphic Products", ParentId = 2, FullPath = "Creating Digital Images/Graphic Products" },
                new GeekFolder { Name = "Primary Sources", ParentId = 3, FullPath = "Creating Digital Images/Resources/Primary Sources" },
                new GeekFolder { Name = "Secondary Sources", ParentId = 3, FullPath = "Creating Digital Images/Resources/Secondary Sources" },
                new GeekFolder { Name = "Process", ParentId = 5, FullPath = "Creating Digital Images/Graphic Products/Process" },
                new GeekFolder { Name = "Final Product", ParentId = 5, FullPath = "Creating Digital Images/Graphic Products/Final Product" },
            };

            context.GeekFolders.AddRange(geekFolders);
            context.SaveChanges();
        }
    }
}
