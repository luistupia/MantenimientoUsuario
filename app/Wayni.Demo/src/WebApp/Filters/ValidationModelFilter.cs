using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;
using Wayni.Shared.Common.Wrappers;

namespace WebApp.Filters;

public class ValidationModelFilter : IAsyncActionFilter
{
    private readonly IServiceProvider _serviceProvider;

    public ValidationModelFilter(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        await ValidateActionArguments(context);

        if (!context.ModelState.IsValid)
        {
            var messages = string.Join("; ", context.ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => !string.IsNullOrWhiteSpace(x.ErrorMessage) ? x.ErrorMessage : x.Exception!.Message.ToString()));

            var content = new ContentResult
            {
                Content = JsonSerializer.Serialize(BaseResponse<string>.Error($"Error Validation: {messages}")),
                StatusCode = StatusCodes.Status422UnprocessableEntity,
                ContentType = "Application/json"
            };

            context.Result = content;
            return;
        }

        await next();
    }

    private async Task ValidateActionArguments(ActionExecutingContext context)
    {
        foreach (var (_, value) in context.ActionArguments)
        {
            if (value is null)
                continue;
            await ValidateAsync(value, context.ModelState);
        }
    }

    private async Task ValidateAsync(object value, ModelStateDictionary modelState)
    {
        var validator = GetValidator(value.GetType());
        if (validator == null)
            return;

        var context = new ValidationContext<object>(value);
        var result = await validator.ValidateAsync(context);
        result.AddToModelState(modelState, string.Empty);
    }

    private IValidator GetValidator(Type targetType)
    {
        var validatorType = typeof(IValidator<>).MakeGenericType(targetType);
        var validator = (IValidator)_serviceProvider.GetService(validatorType)!;
        return validator;
    }
}