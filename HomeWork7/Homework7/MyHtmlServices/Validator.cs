using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Homework7.MyHtmlServices;

public static class Validator
{
    public static IHtmlContent Validate(PropertyInfo propertyInfo, object model)
    {
        if (model is null) return null;
        var attributes = propertyInfo.GetCustomAttributes<ValidationAttribute>();
        foreach (var attr in attributes)
        {
            var value = propertyInfo.GetValue(model);
            if (attr.IsValid(value)) continue;
            var span = new TagBuilder("span")
            {
                Attributes =
                {
                    {"class", "text-danger"},
                    {"data-for", "propertyInfo.Name"},
                    {"data-replace", "true"}
                }
            };
            return span.InnerHtml.Append(attr.ErrorMessage ?? attr.FormatErrorMessage(propertyInfo.Name)!);
        }

        return null;
    }
} 