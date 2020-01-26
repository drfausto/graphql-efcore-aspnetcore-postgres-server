using GraphQL.Types;
using EFCourse.Models;
using EFCourse.Store;

namespace EFCourse.GraphQL {
  public class CourseMutation : ObjectGraphType {
    public CourseMutation(IDataStore dataStore) {
      Field<UniversityType, University>()
        .Name("createUniversity")
        .Argument<NonNullGraphType<UniversityInputType>>("university", "university input")
        .ResolveAsync(ctx => {
          var univ = ctx.GetArgument<University>("university");
          return dataStore.CreateUniversityAsync(univ);
        });

      Field<DepartmentType, Department>()
        .Name("createDepartment")
        .Argument<NonNullGraphType<DepartmentInputType>>("department", "department input")
        .ResolveAsync(ctx => {
          var dpto = ctx.GetArgument<Department>("department");
          return dataStore.CreateDepartmentAsync(dpto);
        });

      Field<CourseType, Course>()
        .Name("createCourse")
        .Argument<NonNullGraphType<CourseInputType>>("course", "course input")
        .ResolveAsync(ctx => {
          var course = ctx.GetArgument<Course>("course");
          return dataStore.CreateCourseAsync(course);
        });			
    }
  }
}