using GraphQL.Types;
using EFCourse.Models;
using EFCourse.Store;

namespace EFCourse.GraphQL {
  public class CourseType : ObjectGraphType<Course> {
    public CourseType(IDataStore dataStore) {
      Field(i => i.CourseID);
      Field(i => i.Name);
      Field(i => i.Description);
      Field(i => i.DepartmentId);        
        // Resolves department to which this course belongs
      Field<DepartmentType, Department>() 
        .Name("Department")        
        .ResolveAsync(ctx => {
          var dpto = ctx.Source.DepartmentId;          
          return dataStore.GetDepartmentByIdAsync(dpto);
        });
    }
  }
}