using System;
using System.Collections.Generic;
using System.Linq;

public interface IPatient
{
    int PatientId { get; }
    string Name { get; }
    DateTime DateOfBirth { get; }
    BloodType BloodType { get; }
}

public enum BloodType { A, B, AB, O }

public class PriorityQueue<T> where T : IPatient
{
    private SortedDictionary<int, Queue<T>> _queues = new();

    public void Enqueue(T patient, int priority)
    {
        if (priority < 1 || priority > 5)
            throw new Exception("Priority must be 1-5");

        if (!_queues.ContainsKey(priority))
            _queues[priority] = new Queue<T>();

        _queues[priority].Enqueue(patient);
    }

    public T Dequeue()
    {
        foreach (var q in _queues.OrderBy(q => q.Key))
        {
            if (q.Value.Count > 0)
                return q.Value.Dequeue();
        }
        throw new Exception("Queue empty");
    }

    public T Peek()
    {
        foreach (var q in _queues.OrderBy(q => q.Key))
        {
            if (q.Value.Count > 0)
                return q.Value.Peek();
        }
        throw new Exception("Queue empty");
    }
}

public class MedicalRecord<T> where T : IPatient
{
    private List<string> diagnoses = new();
    private Dictionary<DateTime, string> treatments = new();

    public void AddDiagnosis(string diagnosis, DateTime date)
        => diagnoses.Add($"{date.ToShortDateString()} - {diagnosis}");

    public void AddTreatment(string treatment, DateTime date)
        => treatments[date] = treatment;

    public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
        => treatments.OrderBy(t => t.Key);
}

public class PediatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public double Weight { get; set; }
}

public class GeriatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public int MobilityScore { get; set; }
}

class Program
{
    static void Main()
    {
        var queue = new PriorityQueue<IPatient>();

        var child = new PediatricPatient
        {
            PatientId = 1,
            Name = "Rahul",
            DateOfBirth = new DateTime(2018, 1, 1),
            BloodType = BloodType.A,
            Weight = 18
        };

        var old = new GeriatricPatient
        {
            PatientId = 2,
            Name = "Mr Sharma",
            DateOfBirth = new DateTime(1950, 1, 1),
            BloodType = BloodType.O,
            MobilityScore = 3
        };

        queue.Enqueue(child, 1);
        queue.Enqueue(old, 3);

        Console.WriteLine("Next patient: " + queue.Dequeue().Name);

        var record = new MedicalRecord<IPatient>();
        record.AddDiagnosis("Fever", DateTime.Now);
        record.AddTreatment("Paracetamol", DateTime.Now);

        Console.WriteLine("\nTreatment History:");
        foreach (var t in record.GetTreatmentHistory())
            Console.WriteLine($"{t.Key} : {t.Value}");
    }
}
