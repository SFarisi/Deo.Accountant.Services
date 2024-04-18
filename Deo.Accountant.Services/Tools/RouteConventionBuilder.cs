

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Deo.Accountant.Services.Tools;


public class GenericControllerRouteConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        if (controller.ControllerType.IsGenericType)
        {
            var genericType = controller.ControllerType.GenericTypeArguments[0];
            controller.ControllerName = genericType.Name;

            if (controller.Selectors.Count > 0)
            {
                var currentSelector = controller.Selectors[0];
                if (controller.ControllerType.Name.Contains("GBookkeeping"))
                    currentSelector.AttributeRouteModel = new AttributeRouteModel(new RouteAttribute($"Bookkeeping/{genericType.Name}"));
                else if (controller.ControllerType.Name.Contains("Makarr"))
                    currentSelector.AttributeRouteModel = new AttributeRouteModel(new RouteAttribute($"Makarr/{genericType.Name}"));
            }
            else
            {
                if (controller.ControllerType.Name.Contains("GBookkeeping"))
                    controller.Selectors.Add(new SelectorModel
                    {
                        AttributeRouteModel = new AttributeRouteModel(new RouteAttribute($"Bookkeeping/{genericType.Name}"))
                    });
                else if (controller.ControllerType.Name.Contains("Makarr"))
                    controller.Selectors.Add(new SelectorModel
                    {
                        AttributeRouteModel = new AttributeRouteModel(new RouteAttribute($"Makarr/{genericType.Name}"))
                    });
            }
        }
    }
}
