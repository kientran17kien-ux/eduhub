using EduHub.Models;
using System.Linq;

namespace EduHub.Services;

public class EventManager
{
    private readonly List<Student> students = new();
    private readonly List<Event> events = new();
    private readonly List<Registration> registrations = new();

    public void AddStudent(Student student)
    {
        if (student == null)
            throw new ArgumentException("Sinh vien khong hop le.");

        if (students.Any(s => s.StudentId == student.StudentId))
            throw new InvalidOperationException("Ma sinh vien da ton tai.");

        students.Add(student);
    }

    public void AddEvent(Event eventItem)
    {
        if (eventItem == null)
            throw new ArgumentException("Su kien khong hop le.");

        if (events.Any(e => e.EventId == eventItem.EventId))
            throw new InvalidOperationException("Ma su kien da ton tai.");

        events.Add(eventItem);
    }

    public Registration Register(string studentId, string eventId)
    {
        Student? student = students.FirstOrDefault(
            s => s.StudentId == studentId);

        Event? eventItem = events.FirstOrDefault(
            e => e.EventId == eventId);

        if (student == null)
            throw new InvalidOperationException("Khong tim thay sinh vien.");

        if (eventItem == null)
            throw new InvalidOperationException("Khong tim thay su kien.");

        if (registrations.Any(r =>
            r.Student.StudentId == studentId &&
            r.Event.EventId == eventId))
        {
            throw new InvalidOperationException(
                "Sinh vien da dang ky su kien nay.");
        }

        Registration registration = Registration.Create(
            $"REG{registrations.Count + 1:000}",
            student,
            eventItem);

        registrations.Add(registration);
        return registration;
    }

    public void PrintReport()
    {
        Console.WriteLine("\n========== BAO CAO EDUHUB ==========");
        Console.WriteLine($"Tong so sinh vien: {students.Count}");
        Console.WriteLine($"Tong so su kien: {events.Count}");
        Console.WriteLine($"Tong luot dang ky: {registrations.Count}");

        foreach (Event eventItem in events)
        {
            Console.WriteLine($"\nSu kien: {eventItem}");

            var attendees = registrations
                .Where(r => r.Event.EventId == eventItem.EventId)
                .ToList();

            Console.WriteLine($"So nguoi dang ky: {attendees.Count}");

            foreach (Registration registration in attendees)
            {
                Console.WriteLine(
                    $"  {registration.Student.StudentId} - " +
                    registration.Student.FullName);
            }
        }

        Console.WriteLine("====================================");
    }
}
