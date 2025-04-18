using System;
using StudentAPI.Data;
using StudentAPI.Models;

namespace StudentAPI
{

    public static class APIs
    {
        public static void Register(WebApplication app)
{
    app.MapGet("/students", (StudentContext context) => context.Students.ToArray());
    app.MapGet("/students/{Id}", (StudentContext context, int Id) => context.Students.Find(Id));
    app.MapPost("/students/create", (StudentContext context, Student newStudent) =>
    {
        context.Students.Add(newStudent);
        context.SaveChanges();
        return Results.Created($"/students/{newStudent.Id}", newStudent);
    });
    app.MapPost("/courses/create", (StudentContext context, Course course) =>
    {
        context.Courses.Add(course);
        context.SaveChanges();
        return Results.Created($"/course/{course.Id}", course);
    });
    app.MapGet("/courses", (StudentContext context) => context.Courses.ToArray());
    app.MapDelete("/students/delete/{Id}", (StudentContext context, int Id) =>
    {
        var student = context.Students.Find(Id);
        if (student == null)
        {
            return Results.NotFound();
        }
        context.Students.Remove(student);
        context.SaveChanges();
        return Results.NoContent();
    });
    app.MapPut("/students/update/{id}", (StudentContext context, int id, Student updatedStudent) =>
    {
    var student = context.Students.Find(id);
    if (student == null)
    {
        return Results.NotFound();
    }

    student.FirstName = updatedStudent.FirstName;
    student.LastName = updatedStudent.LastName;
    student.Age = updatedStudent.Age;

    context.SaveChanges();
    return Results.NoContent();
    });

}
}
}