
using EduHub.Models;
using EduHub.Services;

EventManager manager = new();

try
{
    Student student1 = Student.Create("SV001", "Nguyen Van An");
    Student student2 = Student.Create("SV002", "Tran Thi Binh");
    Student student3 = Student.Create("SV003", "Le Van Cuong");

    manager.AddStudent(student1);
    manager.AddStudent(student2);
    manager.AddStudent(student3);

    Event event1 = Event.Create(
        "EV001",
        "Hoi thao Cong nghe thong tin",
        "Hoi truong A",
        new DateTime(2026, 11, 15));

    Event event2 = Event.Create(
        "EV002",
        "Ngay hoi viec lam",
        "Hoi truong B",
        new DateTime(2026, 11, 20));

    manager.AddEvent(event1);
    manager.AddEvent(event2);

    manager.Register("SV001", "EV001");
    manager.Register("SV002", "EV001");
    manager.Register("SV003", "EV002");
    manager.Register("SV001", "EV002");

    Console.WriteLine("Dang ky thanh cong!");

    manager.PrintReport();

    try
    {
        manager.Register("SV001", "EV001");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"\nDa chan dang ky trung: {ex.Message}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Loi: {ex.Message}");
}
