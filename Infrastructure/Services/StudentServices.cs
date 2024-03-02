using Dapper;
using Domain.Models;

namespace Infrastructure.Services;
public class StudentServices
{
    private readonly DataContext.DapperContext _context;

    public StudentServices()
    {
        _context = new DataContext.DapperContext();
    }
    public List<Students> GetStudents()
    {
        var sql = "select * from students";
        return _context.Connection().Query<Students>(sql).ToList();
    }
    public void AddStudent(Students student)
    {
       var sql = "insert into Students (name,age) values (@name,@age)";
       _context.Connection().Execute(sql,student);
       System.Console.WriteLine("Group added !");
       
    }
    public void UpdateStudents(Students student)
    {
        var sql = "update students set name = @name, age = @age where id = @id";
        _context.Connection().Execute(sql,student);
        System.Console.WriteLine("Students updated");
    }
    public void DeleteStudents(int id)
    {
        var sql = "delete from students where id = @id";
        _context.Connection().Execute(sql);
        System.Console.WriteLine("Students deleted");
    }

    public List<Students> GetStudentsByGroup(int groupId)
    {
            var query = "select * from students where GroupId = @GroupId";
            return _context.Connection().Query<Students>(query, new {GroupId = groupId}).ToList();
        
    }
    public List<StudentGroup> GetGroupWithStudents()
    {
        var sql0 = "select  from groups;";
        var listId = _context.Connection().Query<int>(sql0).ToList();
        var sql1 = @"
               select * from groups where CourseId=@id;
               select * from students where GroupId = @id;
                ";
        var studentgroup = new List<StudentGroup>();
        foreach (var id in listId)
        {
            using (var multiple = _context.Connection().QueryMultiple(sql1, new { Id = id }))
            {
                var student = new StudentGroup();
                student.groups = multiple.ReadFirst<Groups>();
                student.ListStudents = multiple.Read<Students>().ToList();
                studentgroup.Add(student);
            }
        }

        return studentgroup;
    }

    public List<CourseGroup> GetGroupWithCourses()
    {
        var sql0 = "select from Courses;";
        var listId = _context.Connection().Query<int>(sql0).ToList();
        var sql1 = @"
               select * from Courses where groupId=@id;
               select * from groups where CourseId = @id;
                ";
        var coursegroup = new List<CourseGroup>();
        foreach (var id in listId)
        {
            using (var multiple = _context.Connection().QueryMultiple(sql1, new { Id = id }))
            {
                var course = new CourseGroup();
                course.courses = multiple.ReadFirst<Courses>();
                course.ListGroups = multiple.Read<Groups>().ToList();
                coursegroup.Add(course);
            }
        }

        return coursegroup;
    }
    





}
