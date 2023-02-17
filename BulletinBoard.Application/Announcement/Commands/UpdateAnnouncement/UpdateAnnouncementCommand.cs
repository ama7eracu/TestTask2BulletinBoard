using MediatR;

namespace BulletinBoard.Application.Announcement.Commands.UpdateAnnouncement;

public class UpdateAnnouncementCommand:IRequest
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public string Title { get; set; }
    public string Context { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    
}