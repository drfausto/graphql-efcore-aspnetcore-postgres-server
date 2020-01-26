using System.Collections.Generic;
using GraphQL.DataLoader;
using GraphQL.Types;
using EFCourse.Models;
using EFCourse.Store;

namespace EFCourse.GraphQL { 
  public class CourseQuery : ObjectGraphType {
    public CourseQuery(IDataLoaderContextAccessor accessor, IDataStore dataStore) {
      Field<ListGraphType<UniversityType>, IEnumerable<University>>() 
      .Name("Universities")
      .ResolveAsync(ctx => { 
        var loader = accessor.Context.GetOrAddLoader( 
          "GetAllUniversities", () => dataStore.GetUniversitiesAsync()
        );
        return loader.LoadAsync();
      });
      
      Field<UniversityType, University>()
      .Name("University")
      .Argument<NonNullGraphType<IntGraphType>>("univId", "university univId")
      .ResolveAsync(ctx => {
        var univId = ctx.GetArgument<int>("univId");
        return dataStore.GetUniversityByIdAsync(univId);
      });
      
      Field<ListGraphType<DepartmentType>, IEnumerable<Department>>()
      .Name("Departments")
      .ResolveAsync(ctx => {
        return dataStore.GetDepartmentsAsync();
      });

      Field<DepartmentType, Department>()
      .Name("Deparment")
      .Argument<NonNullGraphType<IntGraphType>>("dptoId", "department dptoId")
      .ResolveAsync(ctx => {
        var dptoId = ctx.GetArgument<int>("dptoId");
        return dataStore.GetDepartmentByIdAsync(dptoId);
      });
      
      Field<ListGraphType<DepartmentType>, IEnumerable<Department>>()
      .Name("DepartmentsbyUniversity")
      .Argument<NonNullGraphType<IntGraphType>>("univId", "university univId")
      .ResolveAsync(ctx => {      
        var univId = ctx.GetArgument<int>("univId");
        return dataStore.GetDepartmentByUniversityIdAsync(univId);
      });

      Field<ListGraphType<CourseType>, IEnumerable<Course>>()
      .Name("Courses")
      .ResolveAsync(ctx => {
        return dataStore.GetCoursesAsync();
      });

      Field<CourseType, Course>()
      .Name("Course")
      .Argument<NonNullGraphType<IntGraphType>>("courId", "course courId")
      .ResolveAsync(ctx => {
        var courId = ctx.GetArgument<int>("courId");
        return dataStore.GetCourseByIdAsync(courId);
      });

    }
  }
}