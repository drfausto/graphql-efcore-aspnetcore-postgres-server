using GraphQL.Types;
using EFCourse.Models;

namespace EFCourse.GraphQL {
  public class CourseType : ObjectGraphType<Course> {
    public CourseType() {
      Field(i => i.Name);
      Field(i => i.Description);
      // Falta deoartmentId y/o department
    }
  }
}