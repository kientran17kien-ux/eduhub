namespace EduHub.Models;

public class Event
{
    public string EventId { get; private set; }
    public string Name { get; private set; }
    public string Location { get; private set; }
    public DateTime EventDate { get; private set; }

    private Event(string eventId, string name,
        string location, DateTime eventDate)
    {
        EventId = eventId;
        Name = name;
        Location = location;
        EventDate = eventDate;
    }

    public static Event Create(string eventId, string name,
        string location, DateTime eventDate)
    {
        if (string.IsNullOrWhiteSpace(eventId))
            throw new ArgumentException("Ma su kien khong duoc trong.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Ten su kien khong duoc trong.");

        if (string.IsNullOrWhiteSpace(location))
            throw new ArgumentException("Dia diem khong duoc trong.");

        if (eventDate == default)
            throw new ArgumentException("Ngay to chuc khong hop le.");

        return new Event(eventId.Trim(), name.Trim(),
            location.Trim(), eventDate);
    }

    public override string ToString()
    {
        return $"{EventId} - {Name} | {Location} | {EventDate:dd/MM/yyyy}";
    }
}
