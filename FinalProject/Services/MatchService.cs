using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalCsharpProject;
//This code fetches a user's matches from a database using Entity Framework Core based on the provided user ID.
public class MatchService
{
    private readonly ApplicationDbContext _context;

    public MatchService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserProfile>> GetMatches(string userId)
    {
        var user = await _context.UserProfiles.Include(u => u.LikedUsers)
            .FirstOrDefaultAsync(u => u.UserId == userId);

        if (user == null)
            return new List<UserProfile>();

        var matches = user.LikedUsers.Where(u => u.LikedUsers.Any(l => l.UserId == userId))
            .Select(u => u.UserProfile)
            .ToList();

        return matches;
    }
}
