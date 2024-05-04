using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalCsharpProject;
//This code defines a service for managing user profiles, including methods to fetch a user profile by ID 
// and update a user profile in the database.

public class ProfileService
{
    private readonly ApplicationDbContext _context;

    public ProfileService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserProfile> GetUserProfile(string userId)
    {
        return await _context.UserProfiles.FirstOrDefaultAsync(u => u.UserId == userId);
    }

    public async Task<bool> UpdateUserProfile(UserProfile userProfile)
    {
        _context.Entry(userProfile).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }
}
