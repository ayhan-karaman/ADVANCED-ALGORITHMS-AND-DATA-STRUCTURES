namespace CustomTypes;

public class Student : IComparable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double GPA { get; set; }
    public Student(int id, string name, double gpa)
    {
        Id = id;
        Name = name;
        GPA = gpa;
    }
    public Student(){}

    public override string ToString() => $"{Id, -5} {Name, -15} {GPA, -5}";

    public int CompareTo(object? obj)
    {
       var other = (Student)obj;
        // if(this.GPA < other.GPA)
        //     return -1;
        // else if(this.GPA.Equals(other.GPA))
        //     return 1;
        // else 
        //     return 0;
        // return this.Id.CompareTo(other.Id);
        return this.Name.CompareTo(other.Name);
        // return this.GPA.CompareTo(other.GPA);
    }
}
