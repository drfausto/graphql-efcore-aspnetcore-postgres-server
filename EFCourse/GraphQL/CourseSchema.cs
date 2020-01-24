using GraphQL;
using GraphQL.Types;

namespace EFCourse.GraphQL {
  public class CourseSchema : Schema {
    public CourseSchema(IDependencyResolver resolver) : base(resolver) {
      Query = resolver.Resolve<CourseQuery>();
      Mutation = resolver.Resolve<CourseMutation>();
    }
  }
}
