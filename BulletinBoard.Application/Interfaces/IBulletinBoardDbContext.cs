using BulletinBoard.Domain;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Application.Interfaces;

public interface IBulletinBoardDbContext
{
    DbSet<Domain.Announcement> Announcements { get; set; }
    DbSet<Author> Authors { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}