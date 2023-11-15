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
                new GeekFolder { Name = "Creating Digital Images", ParentId = null },
                new GeekFolder { Name = "Resources", ParentId = 1 },
                new GeekFolder { Name = "Evidence", ParentId = 1 },
                new GeekFolder { Name = "Graphic Products", ParentId = 1 },
                new GeekFolder { Name = "Primary Sources", ParentId = 2 },
                new GeekFolder { Name = "Secondary Sources", ParentId = 2 },
                new GeekFolder { Name = "Process", ParentId = 4 },
                new GeekFolder { Name = "Final Product", ParentId = 4 },

            };

            context.GeekFolders.AddRange(geekFolders);
            context.SaveChanges();
        }
    }
}
