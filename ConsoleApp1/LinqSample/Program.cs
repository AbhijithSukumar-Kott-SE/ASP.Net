//LINQ learnings

//filtering
List<int> numbers = [10, 13, 15, 20, 22, 25, 27];

var filteredNumbers = numbers.Where(num => num % 2 == 1).ToList();

Console.WriteLine(string.Join(" , ", filteredNumbers));

//Select
var squaredNumbers = numbers.Select(n => n * n).ToList();
Console.WriteLine(string.Join(" , ", squaredNumbers));


//Sorting with OrderBy and OrderByDescending
var ascendingOrder = numbers.OrderBy(n => n).ToList();
Console.WriteLine(string.Join(", ", ascendingOrder));

var descendingOrder = numbers.OrderByDescending(n => n).ToList();
Console.WriteLine(string.Join(" , ",descendingOrder));

//Aggregation methods
int sum = numbers.Sum();
Console.WriteLine(sum);

int count = numbers.Count();
Console.WriteLine(count);

int min = numbers.Min();
Console.WriteLine(min);

int max = numbers.Max();
Console.WriteLine(max);

double avg = numbers.Average();
Console.WriteLine(avg);



var employess = new List<Employee>
{
    new() {Name="Bob",Department="QA"},
    new() {Name="Steeve",Department="QA"},
    new() {Name="Mark",Department="SDE"},
    new() {Name="Sunny",Department="QA"},
    new() {Name="Dev",Department="SDE"}
};

var groupByDepartment = employess.GroupBy(emp => emp.Department);

foreach(var group in groupByDepartment)
{
    Console.WriteLine($"Department: {group.Key}");
    foreach (var employee in group)
    {
        Console.WriteLine($"  - {employee.Name}");
    }
}



//Joining Two Collections with Join
var employees = new List<Staff>
{
    new() { Id = 1, Name = "Ram", DepartmentId = 101 },
    new() { Id = 2, Name = "Sita", DepartmentId = 102 }
};

var departments = new List<Department>
{
    new() { Id = 101, Name = "IT" },
    new() { Id = 102, Name = "HR" }
};

var employeeWithDepartment = employees.Join(
    departments,
    emp => emp.DepartmentId,
    dept => dept.Id,
    (emp, dept) => new { emp.Name, Department = dept.Name }
    );

foreach (var item in employeeWithDepartment)
{
    Console.WriteLine($"{item.Name} - {item.Department}");
}

class Employee
{
    public string? Name { get; set; }

    public string? Department { get; set; }
}

class Staff
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int DepartmentId { get; set; }
}


class Department
{
    public int Id { get; set; }

    public string  Name { get; set; }
}
