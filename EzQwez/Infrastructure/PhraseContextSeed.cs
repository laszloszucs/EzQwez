using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public class PhraseContextSeed : IPhraseContextSeed
    {
        private readonly PhraseContext _context;
        private readonly ILogger _logger;

        public PhraseContextSeed(PhraseContext context, ILogger<PhraseContextSeed> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);

            if (!await _context.Phrases.AnyAsync())
            {
                _logger.LogInformation("Generating inbuilt Phrases");

                await _context.AddAsync(new Phrase
                {
                    English = "TestEnglishPhrase",
                    Hungarian = "TestHungarianPhrase"

                });

                _logger.LogInformation("Phrases generation completed");
            }

            if (_context.ChangeTracker.HasChanges())
            {
                await _context.SaveChangesAsync();

                _logger.LogInformation("Seeding initial data completed");
            }
        }
    }
}
