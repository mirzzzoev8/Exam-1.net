using Domain.Models;
using Infrastructure.Services;

var servise = new StudentServices();
// var student = new Students();
// student.Name = "Yusufjon";
// student.Age = 15;
// servise.AddStudent(student);

// var student2 = new Students();
// student2.Name = "davron";
// student2.Age = 18;
// servise.AddStudent(student2);

// var student1 = new Students();
// student1.Id = 1;
// student1.Name = "Yusufjon10";
// student1.Age = 150;
// servise.UpdateStudents(student1);

// var student3 = new Students();
// student3.Id = 2;
// student3.Name = "davron24";
// student3.Age = 200;
// servise.UpdateStudents(student3);

// servise.DeleteStudents(1);

// servise.GetStudentsByGroup(1);

// System.Console.WriteLine(servise.GetGroupWithStudents());
// foreach (var item in servise.GetGroupWithStudents())
// {
//     System.Console.WriteLine(item.groups);
//     System.Console.WriteLine(item.ListStudents);
// }

System.Console.WriteLine(servise.GetGroupWithCourses());
foreach (var item in servise.GetGroupWithCourses())
{
    System.Console.WriteLine(item.courses);
    System.Console.WriteLine(item.ListGroups);
}



