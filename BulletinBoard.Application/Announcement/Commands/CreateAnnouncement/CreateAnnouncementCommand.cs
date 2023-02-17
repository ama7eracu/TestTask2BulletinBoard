using MediatR;

namespace BulletinBoard.Application.Announcement.Commands;

public class CreateAnnouncementCommand:IRequest<Guid>
{
    public string Title { get; set; }
    public string Context { get; set; }
    public Guid AuthorId { get; set; }
    public int Number { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime EditTime { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}