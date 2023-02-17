using MediatR;

namespace BulletinBoard.Application.Announcement.Commands.DeleteAnnouncement;

public class DeleteAnnouncementCommand : IRequest
{
    public Guid AuthorId { get; set; }
    public Guid Id { get; set; }
}