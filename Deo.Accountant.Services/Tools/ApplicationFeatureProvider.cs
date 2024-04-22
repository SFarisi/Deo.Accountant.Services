

using System.Reflection;
using Deo.Accountant.Services.Controllers.Bookkeeping;
using Deo.Accountant.Services.Controllers.Company;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Deo.Accountant.Services.Tools;

public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
{
    private string[] BookkeepingAssemblies { get; } =
        new[] { "Deo.Mutiyat.Model.Bookkeeping" };

    private string[] MakarrAssemblies { get; } =
    new[] { "Deo.Mutiyat.Model.Company", "Deo.Mutiyat.Model.User", "Deo.Mutiyat.Model.Branch" , "Deo.Mutiyat.Model.User.Template" };

    public GenericTypeControllerFeatureProvider()
    {

    }

    public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
    {
        foreach (var assembly in this.BookkeepingAssemblies)
        {
            var loadedAssembly = Assembly.Load(assembly);
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
        }
        foreach (var assembly in this.MakarrAssemblies)
        {
            var companyAssembly = Assembly.Load(assembly);
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
