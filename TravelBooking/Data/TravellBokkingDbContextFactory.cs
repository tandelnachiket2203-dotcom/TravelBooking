using Humanizer.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace TravelBooking.Data
{
    // Design-time factory to allow EF tools to create the DbContext when the app's
    // normal service provider or configuration can't be loaded at design time.
    public class TravellBokkingDbContextFactory : IDesignTimeDbContextFactory<TravellBokkingDBContext>
    {
        public TravellBokkingDBContext CreateDbContext(string[] args)
        {
            // Attempt to locate the project directory (where the .csproj and appsettings.json live)
            // by walking up parent directories from the current working directory.
            var current = Directory.GetCurrentDirectory();
            string? projectDir = null;
            var dir = new DirectoryInfo(current);
            while (dir != null)
            {
                // look for any .csproj in this directory
                var csprojFiles = Directory.GetFiles(dir.FullName, "*.csproj");
                if (csprojFiles.Length > 0)
                {
                    projectDir = dir.FullName;
                    break;
                }

                dir = dir.Parent;
            }

            // Fallback candidates to locate appsettings.json in case the EF tools run with
            // a different current directory. Prefer the project directory, then common
            // runtime/base directories. Pick the first candidate that actually contains
            // an appsettings.json file.
            var candidates = new[]
            {
                projectDir,
                Directory.GetCurrentDirectory(),
                AppContext.BaseDirectory,
                AppDomain.CurrentDomain.BaseDirectory
            };

            string? basePath = null;
            foreach (var c in candidates)
            {
                if (string.IsNullOrEmpty(c))
                    continue;

                try
                {
                    if (File.Exists(Path.Combine(c, "appsettings.json")))
                    {
                        basePath = c;
                        break;
                    }
                }
                catch
                {
                    // ignore and continue
                }
            }

            basePath ??= projectDir ?? AppContext.BaseDirectory ?? Directory.GetCurrentDirectory();

            // Build configuration from appsettings.json (if present) and environment variables.
            // Guard against malformed or unreadable appsettings.json by falling back to
            // environment variables if the file fails to load.
            IConfigurationRoot config;
            try
            {
                config = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                    .AddEnvironmentVariables()
                    .Build();
            }
            catch
            {
                config = new ConfigurationBuilder()
                    .AddEnvironmentVariables()
                    .Build();
            }

            

            var optionsBuilder = new DbContextOptionsBuilder<TravellBokkingDBContext>();
            optionsBuilder.UseSqlite("Data Source=app.db");

            return new TravellBokkingDBContext(optionsBuilder.Options);
        }
    }
}
