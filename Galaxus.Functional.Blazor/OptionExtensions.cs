using Microsoft.AspNetCore.Components;

namespace Galaxus.Functional.Blazor;

public static class OptionExtensions
{
    public static RenderFragment RenderIfSome<T>(
        this Option<T> value,
        Func<T, RenderFragment> content)
    {
        return value.IsSome
            ? builder => content(value.Unwrap())(builder)
            : _ => { }; // Return empty fragment if condition is false
    }

    public static RenderFragment RenderMatch<T>(
        this Option<T> value,
        Func<T, RenderFragment> onOptionIsSomeFragment,
        Func<RenderFragment> onOptionIsNoneFragment)
    {
        return value.IsSome
            ? builder => onOptionIsSomeFragment(value.Unwrap())(builder)
            : builder => onOptionIsNoneFragment()(builder);
    }
}
