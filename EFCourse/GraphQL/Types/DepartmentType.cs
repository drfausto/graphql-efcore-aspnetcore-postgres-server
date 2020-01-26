using GraphQL.DataLoader;
using GraphQL.Types;
using System.Collections.Generic;
using EFCourse.Models;
using EFCourse.Store;

namespace EFCourse.GraphQL {
  public class DepartmentType : ObjectGraphType<Department> {
    public DepartmentType(IDataStore dataStore, IDataLoaderContextAccessor accessor) {
      Field(i => i.DepartmentId);
      Field(i => i.Name);
      Field(i => i.UniversityId);
        // Resolves university to which this department belongs
      Field<UniversityType, University>() 
        .Name("University")        
        .ResolveAsync(ctx => {
          var univ = ctx.Source.UniversityId;          
          return dataStore.GetUniversityByIdAsync(univ);
        });
        // Resolves courses of this department
      Field<ListGraphType<CourseType>, IEnumerable<Course>>()
      .Name("Courses")
      .ResolveAsync(ctx => {
        var courseLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, Course>
          ("GetCourseByDepartmentId", dataStore.GetCourseByDepartmentIdAsync);
        return courseLoader.LoadAsync(ctx.Source.DepartmentId);
      });
    }
  }
}