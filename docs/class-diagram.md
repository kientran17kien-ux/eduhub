# EduHub – Class Diagram

```mermaid
classDiagram
    class Student {
        -string StudentId
        -string FullName
        +Create(studentId, fullName)$ Student
    }

    class Event {
        -string EventId
        -string Name
        -string Location
        -DateTime EventDate
        +Create(eventId, name, location, eventDate)$ Event
    }

    class Registration {
        -string RegistrationId
        -Student Student
        -Event Event
        -DateTime RegisteredAt
        +Create(registrationId, student, event)$ Registration
    }

    class EventManager {
        -List~Student~ students
        -List~Event~ events
        -List~Registration~ registrations
        +AddStudent(student)
        +AddEvent(event)
        +Register(studentId, eventId)
        +PrintReport()
    }

    Student "1" --> "0..*" Registration : registrations
    Event "1" --> "0..*" Registration : registrations
    EventManager o-- Student : manages
    EventManager o-- Event : manages
    EventManager o-- Registration : manages
```

## Relationships and foreign keys

- Một Student có thể có nhiều Registration.
- Một Event có thể có nhiều Registration.
- Mỗi Registration tham chiếu đến một Student và một Event.
- Nếu lưu vào cơ sở dữ liệu quan hệ, Registration có thể sử dụng StudentId và EventId làm khóa ngoại.
- Các thuộc tính được bảo vệ bằng private setter; các đối tượng được tạo thông qua phương thức Create().