

using FluentValidation;
using System;
using System.Linq.Expressions;

namespace Asp.Net.Angular.Template.Contract.Common
{
    public static class ValidationMessageExtension
    {
        public static IRuleBuilderOptions<TModel, string> IsRequiredAndMustBeBetween<TModel>(this IRuleBuilderInitial<TModel, string> ruleBuilderInitial, int minimum, int maximum) =>
          ruleBuilderInitial.NotNull().Length(minimum, maximum);

        public static IRuleBuilderOptions<TModel, string> IsRequiredAndMustHaveLength<TModel>(this IRuleBuilderInitial<TModel, string> ruleBuilderInitial, string name, int exactLength) =>
         ruleBuilderInitial.NotNull().Length(exactLength).WithMessage($"{name} is required and length must be {exactLength } characters long");

    }
}
