namespace EduHub.Models;

public class Registration
{
    public string RegistrationId { get; private set; }
    public Student Student { get; private set; }
    public Event Event { get; private set; }
    public DateTime RegisteredAt { get; private set; }

    private Registration(string registrationId,
        Student student, Event eventItem)
    {
        RegistrationId = registrationId;
        Student = student;
        Event = eventItem;
        RegisteredAt = DateTime.Now;
    }

    public static Registration Create(string registrationId,
        Student student, Event eventItem)
    {
        if (string.IsNullOrWhiteSpace(registrationId))
            throw new ArgumentException("Ma dang ky khong duoc trong.");

        if (student == null)
            throw new ArgumentException("Sinh vien khong hop le.");

        if (eventItem == null)
            throw new ArgumentException("Su kien khong hop le.");

        return new Registration(registrationId.Trim(),
            student, eventItem);
    }
}
