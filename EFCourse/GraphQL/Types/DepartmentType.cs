using GraphQL.Types;
using EFCourse.Models;

namespace EFCourse.GraphQL {
  public class DepartmentType : ObjectGraphType<Department> {
    public DepartmentType() {
      Field(i => i.Name);
      // Falta universityId y/o university         
      // Falta lista de Cursos
    }
  }
}