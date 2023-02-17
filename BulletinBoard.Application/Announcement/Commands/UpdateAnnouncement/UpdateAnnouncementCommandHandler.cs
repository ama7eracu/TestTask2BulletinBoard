using BulletinBoard.Application.Common.Exceptions;
using BulletinBoard.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Application.Announcement.Commands.UpdateAnnouncement;

public class UpdateAnnouncementCommandHandler:IRequestHandler<UpdateAnnouncementCommand>
{
    private readonly IBulletinBoardDbContext _context;

    public UpdateAnnouncementCommandHandler(IBulletinBoardDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Announcements.FirstOrDefaultAsync(announcement =>
            announcement.Id == request.Id, cancellationToken);

        if (entity == null || entity.AuthorId != request.AuthorId)
        {
            throw new NotFoundException(nameof(Domain.Announcement), request.Id);
        }

        entity.Context = request.Context;
        entity.EditTime=DateTime.Now;
        entity.Title = request.Title;
        entity.StartTime = request.StartTime;
        entity.EndTime = request.EndTime;

        await _context.SaveChangesAsync(cancellationToken);
    }
}