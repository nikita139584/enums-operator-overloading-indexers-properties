using System.Runtime.CompilerServices;

class Student // CLASS !!!
{
    private string lastName = "Stashko";
    private string Name = "Nikita";
    private string patronymic = "Sehrijovich";
    private int dateOfBirth = 28092010;
    private string homeAddress = "Sadovaja 3";
    private long phoneNumber = 380123456789;
    private int[] credits;
    private int[] coursework;
    private int[] exams;

    public Student(int creditsCount = 3, int courseworkCount = 3, int examsCount = 3)
    {
        credits = new int[creditsCount];
        coursework = new int[courseworkCount];
        exams = new int[examsCount];
    }
    public void SetCredits(int[] credits)
    {
        this.credits = credits;
    }
    public int[] GetCredits()
    {
        return credits;
    }

    public void SetCoursework(int[] coursework)
    {
        this.coursework = coursework;
    }
    public int[] GetCoursework()
    {
        return coursework;
    }

    public void SetExams(int[] exams)
    {
        this.exams = exams;
    }
    public int[] GetExams()
    {
        return exams;
    }

    public void SetName(string Name)
    {
        this.Name = Name;
    }
    public string GetName()
    {
        return Name;
    }

    public void SetLastName(string lastName)
    {
        this.lastName = lastName;
    }
    public string GetLastName()
    {
        return lastName;
    }

    public void SetPatronymic(string patronymic)
    {
        this.patronymic = patronymic;
    }
    public string GetPatronymic()
    {
        return patronymic;
    }

    public void SetDateOfBirth(int dateOfBirth)
    {
        this.dateOfBirth = dateOfBirth;
    }
    public int GetDateOfBirth()
    {
        return dateOfBirth;
    }

    public void SetHomeAddress(string homeAddress)
    {
        this.homeAddress = homeAddress;
    }
    public string GetHomeAddress()
    {
        return homeAddress;
    }

    public void SetPhoneNumber(long phoneNumber)
    {
        this.phoneNumber = phoneNumber;
    }
    public long GetPhoneNumber()
    {
        return phoneNumber;
    }
    public double GetAverageCredit()
    {
        if (credits == null || credits.Length == 0) return 0;
        return credits.Average();
    }


    public static bool operator >(Student a, Student b)
    {
        return a.GetAverageCredit() > b.GetAverageCredit();
    }

    public static bool operator <(Student a, Student b)
    {
        return a.GetAverageCredit() < b.GetAverageCredit();
    }

    public static bool operator ==(Student a, Student b)
    {
        return a.GetAverageCredit() == b.GetAverageCredit();
    }

    public static bool operator !=(Student a, Student b)
    {
        return a.GetAverageCredit() != b.GetAverageCredit();
    }

    public static void Print(in Student student)
    {

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine(student.GetName());
        Console.WriteLine(student.GetLastName());
        Console.WriteLine(student.GetPatronymic());
        Console.WriteLine(student.GetDateOfBirth());
        Console.WriteLine(student.GetHomeAddress());
        Console.WriteLine(student.GetPhoneNumber());

        Console.WriteLine("\nЗаліки:");
        foreach (int mark in student.GetCredits())
            Console.Write(mark + " ");

        Console.WriteLine("\nКурсові:");
        foreach (int mark in student.GetCoursework())
            Console.Write(mark + " ");

        Console.WriteLine("\nЕкзамени:");
        foreach (int mark in student.GetExams())
            Console.Write(mark + " ");



    }
    public static bool operator true(Student st)
    {
        return st.GetAverageCredit() >= 7;
    }

    public static bool operator false(Student st)
    {
        return st.GetAverageCredit() < 7;
    }
}



class Group
{
    private List<Student> students;
    private string groupName;
    private string specialization;
    private int courseNumber;

    public Group()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        groupName = "Невідома група";
        specialization = "Невідома спеціалізація";
        courseNumber = 1;
        students = new List<Student>();
    }


    public Group(List<Student> existingStudents)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        groupName = "Група на основі списку";
        specialization = "Не вказано";
        courseNumber = 1;
        students = new List<Student>(existingStudents);
    }


    public Group(Group other)
    {
        groupName = other.groupName;
        specialization = other.specialization;
        courseNumber = other.courseNumber;
        students = new List<Student>(other.students);
    }

    public void SetName(string groupName)
    {
        this.groupName = groupName;
    }
    public void SetSpecialization(string specialization)
    {
        this.specialization = specialization;
    }
    public void SetCourse(int courseNumber)
    {
        this.courseNumber = courseNumber;
    }

    public string GetName()
    {
        return groupName;
    }
    public string GetSpecialization()
    {
        return specialization;
    }
    public int GetCourse()
    {
        return courseNumber;
    }

    public void AddStudent(Student s)
    {
        students.Add(s);
    }


    public void TransferStudent(Group toGroup, Student student)
    {
        if (students.Contains(student))
        {
            students.Remove(student);
            toGroup.AddStudent(student);
        }
    }

    public void ShowAllStudents()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine($"\nГрупа: {groupName}");
        Console.WriteLine($"Спеціалізація: {specialization}");
        Console.WriteLine($"Курс: {courseNumber}\n");

        Console.WriteLine("Студенти групи:");
        foreach (Student st in students)
        {
            Console.WriteLine($"{st.GetLastName()} {st.GetName()}");
        }

        Console.WriteLine();
    }
    public int StudentCount()
    {
        return students.Count;
    }
    public static bool operator ==(Group a, Group b)
    {
        return a.StudentCount == b.StudentCount;
    }

    public static bool operator !=(Group a, Group b)
    {
        return a.StudentCount != b.StudentCount;
    }

}

class Program
{
    static void Main()
    {
        Student s1 = new Student();
        s1.SetName("Nikita");
        s1.SetLastName("Stashko");

        Student s2 = new Student();
        s2.SetName("Ivan");
        s2.SetLastName("Petrenko");


        Group g1 = new Group();
        g1.SetName("KP-12");
        g1.SetSpecialization("Комп'ютерні науки");
        g1.SetCourse(1);

        g1.AddStudent(s1);
        g1.AddStudent(s2);

        Console.WriteLine("Група 1:");
        g1.ShowAllStudents();


        Group g2 = new Group();
        g2.SetName("KP-13");
        g2.SetSpecialization("Інженерія ПЗ");
        g2.SetCourse(1);

        g1.TransferStudent(g2, s2);

        Console.WriteLine("Після переведення:\n");

        Console.WriteLine("Група 1:");
        g1.ShowAllStudents();

        Console.WriteLine("Група 2:");
        g2.ShowAllStudents();
    }
}