using BulletinBoard.Application.Common.Exceptions;
using BulletinBoard.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Application.Announcement.Commands.DeleteAnnouncement;

public class DeleteAnnouncementCommandHandler:IRequestHandler<DeleteAnnouncementCommand>
{
    private readonly IBulletinBoardDbContext _context;

    public DeleteAnnouncementCommandHandler(IBulletinBoardDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(DeleteAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Announcements.FirstOrDefaultAsync(announcement =>
            announcement.Id == request.Id, cancellationToken);
        
        if(entity==null || entity.AuthorId!=request.AuthorId)
        {
            throw new NotFoundException(nameof(Domain.Announcement), request.Id);
        }

        _context.Announcements.Remove(entity);
        
        await _context.SaveChangesAsync(cancellationToken);
        
    }
}