using GraphQL.Types;

namespace EFCourse.GraphQL {
  public class DepartmentInputType : InputObjectGraphType {
    public DepartmentInputType() {
      Name = "DepartmentInputType";
      Field<NonNullGraphType<StringGraphType>>("name");
      Field<NonNullGraphType<IntGraphType>>("universityID");
    }
  }
}