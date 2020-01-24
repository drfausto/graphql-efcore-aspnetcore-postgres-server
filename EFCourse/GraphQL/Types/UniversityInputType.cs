using GraphQL.Types;

namespace EFCourse.GraphQL {
	public class UniversityInputType : InputObjectGraphType {
    public UniversityInputType() {
      Name = "UniversityInputType";
      Field<NonNullGraphType<StringGraphType>>("name");
      Field<NonNullGraphType<StringGraphType>>("city");
      Field<NonNullGraphType<StringGraphType>>("state");
      Field<NonNullGraphType<StringGraphType>>("country");
    }
  }
}
