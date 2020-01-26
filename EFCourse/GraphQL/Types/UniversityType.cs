using GraphQL.DataLoader;
using GraphQL.Types;
using System.Collections.Generic;
using EFCourse.Models;
using EFCourse.Store;

namespace EFCourse.GraphQL {
  public class UniversityType : ObjectGraphType<University> {
    public UniversityType(IDataStore dataStore, IDataLoaderContextAccessor accessor) {
      Field(i => i.UniversityId);
      Field(i => i.Name);         
      Field(i => i.City);         
      Field(i => i.Country);
      Field(i => i.State);
        // Resolves departments of this university
      Field<ListGraphType<DepartmentType>, IEnumerable<Department>>()
      .Name("Departments")
      .ResolveAsync(ctx => {
        var dptoLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, Department>
          ("GetDepartmentByUniversityId", dataStore.GetDepartmentByUniversityIdAsync);
        return dptoLoader.LoadAsync(ctx.Source.UniversityId);
      });
    }
  }
}