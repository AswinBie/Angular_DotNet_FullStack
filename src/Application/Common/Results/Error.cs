namespace Application.Common;

public sealed record Error(string Code, string Message)
{
    internal static Error None => new("None", string.Empty);
}