using BulletinBoard.Application.Interfaces;
using MediatR;

namespace BulletinBoard.Application.Announcement.Commands.CreateAnnouncement;

public class CreateAnnouncementCommandHandler:IRequestHandler<CreateAnnouncementCommand,Guid>
{
    private readonly IBulletinBoardDbContext _context;

    public CreateAnnouncementCommandHandler(IBulletinBoardDbContext context)
    {
        _context = context;
    }
    
    public async Task<Guid> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcement = new Domain.Announcement
        {
            Context = request.Context,
            CreateDate = DateTime.Now,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            AuthorId = request.AuthorId,
            EditTime = null,
            Id = Guid.NewGuid(),
            Number = request.Number,
            Title = request.Title
        };

        _context.Announcements.Add(announcement);
        await _context.SaveChangesAsync(cancellationToken);

        return announcement.Id;
    }
}