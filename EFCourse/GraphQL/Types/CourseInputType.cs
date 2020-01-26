using GraphQL.Types;

namespace EFCourse.GraphQL {
  public class CourseInputType : InputObjectGraphType {
    public CourseInputType() {
      Name = "CourseInputType";
      Field<NonNullGraphType<IntGraphType>>("courseID");
      Field<NonNullGraphType<StringGraphType>>("name");
      Field<NonNullGraphType<StringGraphType>>("description");
      Field<NonNullGraphType<IntGraphType>>("departmentID");
    }
  }
}