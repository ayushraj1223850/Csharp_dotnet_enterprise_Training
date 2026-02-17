using System;
using System.Collections.Generic;
using System.Linq;

public interface IStudent
{
    int StudentId { get; }
    string Name { get; }
    int Semester { get; }
}

public interface ICourse
{
    string CourseCode { get; }
    string Title { get; }
    int MaxCapacity { get; }
    int Credits { get; }
}

public class EnrollmentSystem<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<TCourse, List<TStudent>> _enrollments = new();

    public bool EnrollStudent(TStudent student, TCourse course)
    {
        if (!_enrollments.ContainsKey(course))
            _enrollments[course] = new List<TStudent>();

        if (_enrollments[course].Count >= course.MaxCapacity)
        {
            Console.WriteLine("Course is full!");
            return false;
        }

        if (_enrollments[course].Any(s => s.StudentId == student.StudentId))
        {
            Console.WriteLine("Student already enrolled!");
            return false;
        }

        if (course is LabCourse lab && student.Semester < lab.RequiredSemester)
        {
            Console.WriteLine("Prerequisite not met!");
            return false;
        }

        _enrollments[course].Add(student);
        return true;
    }

    public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
        => _enrollments.ContainsKey(course) ? _enrollments[course] : new List<TStudent>();

    public IEnumerable<TCourse> GetStudentCourses(TStudent student)
        => _enrollments.Where(e => e.Value.Contains(student)).Select(e => e.Key);

    public int CalculateStudentWorkload(TStudent student)
        => GetStudentCourses(student).Sum(c => c.Credits);
}

public class EngineeringStudent : IStudent
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Semester { get; set; }
    public string Specialization { get; set; }
}

public class LabCourse : ICourse
{
    public string CourseCode { get; set; }
    public string Title { get; set; }
    public int MaxCapacity { get; set; }
    public int Credits { get; set; }
    public int RequiredSemester { get; set; }
}

class Program
{
    static void Main()
    {
        var system = new EnrollmentSystem<EngineeringStudent, LabCourse>();

        var s1 = new EngineeringStudent { StudentId = 1, Name = "Aman", Semester = 2 };
        var s2 = new EngineeringStudent { StudentId = 2, Name = "Riya", Semester = 4 };

        var lab1 = new LabCourse { CourseCode = "CS101", Title = "Basic Lab", MaxCapacity = 1, Credits = 3, RequiredSemester = 1 };
        var lab2 = new LabCourse { CourseCode = "CS301", Title = "Advanced Lab", MaxCapacity = 2, Credits = 4, RequiredSemester = 3 };

        system.EnrollStudent(s1, lab1);
        system.EnrollStudent(s2, lab2);
        system.EnrollStudent(s1, lab2);   // fails prerequisite

        Console.WriteLine($"Riya workload: {system.CalculateStudentWorkload(s2)} credits");
    }
}
