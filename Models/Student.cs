namespace EduHub.Models;

public class Student
{
    public string StudentId { get; private set; }
    public string FullName { get; private set; }

    private Student(string studentId, string fullName)
    {
        StudentId = studentId;
        FullName = fullName;
    }

    public static Student Create(string studentId, string fullName)
    {
        if (string.IsNullOrWhiteSpace(studentId))
            throw new ArgumentException(
                "Ma sinh vien khong duoc de trong.");

        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException(
                "Ho ten khong duoc de trong.");

        return new Student(studentId.Trim(), fullName.Trim());
    }

    public override string ToString()
    {
        return $"{StudentId} - {FullName}";
    }
}