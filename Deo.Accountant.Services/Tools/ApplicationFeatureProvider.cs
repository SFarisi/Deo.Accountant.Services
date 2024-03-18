

using System.Reflection;
using Deo.Accountant.Services.Controllers.Bookkeeping;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Deo.Accountant.Services.Tools;

public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
{
    private string[] Assemblies { get; }

    public GenericTypeControllerFeatureProvider(string[] assemblies)
    {
        this.Assemblies = assemblies;
    }

    public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
    {

        var loadedAssembly = Assembly.Load("Deo.Mutiyat.Model.Bookkeeping");
        var customClasses = loadedAssembly.GetExportedTypes();
         
        foreach (var candidate in customClasses)
        {

            if (candidate.FullName != null && candidate.FullName.Contains("BaseController")) continue;

            var propertyType = candidate.GetProperty("ID")
               ?.PropertyType;
            if (propertyType == null) continue;

            var typeInfo = typeof(GBookkeeping<>).MakeGenericType(candidate).GetTypeInfo();


            feature.Controllers.Add(typeInfo);

        }

    }
}
