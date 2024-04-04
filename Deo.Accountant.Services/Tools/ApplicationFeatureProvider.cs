

using System.Reflection;
using Deo.Accountant.Services.Controllers.Bookkeeping;
using Deo.Accountant.Services.Controllers.Company;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Deo.Accountant.Services.Tools;

public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
{
    private string[] Assemblies { get; } = 
        new[] { "Deo.Mutiyat.Model.Bookkeeping" };

    public GenericTypeControllerFeatureProvider()
    {
        
    }

    public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
    {
        foreach (var assembly in this.Assemblies)
        {
            var loadedAssembly = Assembly.Load("Deo.Mutiyat.Model.Bookkeeping");
            var customClasses = loadedAssembly.GetExportedTypes();

            foreach (var candidate in customClasses)
            {
                // ignore default controller 
                if (candidate.FullName != null && candidate.FullName.Contains("BaseController")) continue;

                var propertyType = candidate.GetProperty("ID")
                   ?.PropertyType;
                if (propertyType == null) continue;

                var typeInfo = typeof(GBookkeeping<>).MakeGenericType(candidate).GetTypeInfo();


                feature.Controllers.Add(typeInfo);

            }

            var companyAssembly = Assembly.Load("Deo.Mutiyat.Model.Company");
            var compayClass = companyAssembly.GetExportedTypes();

            foreach (var candidate in compayClass)
            {
                // ignore default controller 
                if (candidate.FullName != null && candidate.FullName.Contains("BaseController")) continue;

                var propertyType = candidate.GetProperty("ID")
                   ?.PropertyType;
                if (propertyType == null) continue;

                var typeInfo = typeof(Makarr<>).MakeGenericType(candidate).GetTypeInfo();


                feature.Controllers.Add(typeInfo);

            }
        }
    }
}
