namespace System.Runtime.CompilerServices;

/// <summary>
/// Indicates which arguments to a method involving an interpolated string handler should be passed to that handler.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class InterpolatedStringHandlerArgumentAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InterpolatedStringHandlerArgumentAttribute"/> class.
    /// </summary>
    /// <param name="argument">The name of the argument that should be passed to the handler.</param>
    /// <remarks><see langword="null"/> may be used as the name of the receiver in an instance method.</remarks>
    public InterpolatedStringHandlerArgumentAttribute(string argument) => Arguments = new string[] { argument };

    /// <summary>
    /// Initializes a new instance of the <see cref="InterpolatedStringHandlerArgumentAttribute"/> class.
    /// </summary>
    /// <param name="arguments">The names of the arguments that should be passed to the handler.</param>
    /// <remarks><see langword="null"/> may be used as the name of the receiver in an instance method.</remarks>
    public InterpolatedStringHandlerArgumentAttribute(params string[] arguments) => Arguments = arguments;

    /// <summary>
    /// Gets the names of the arguments that should be passed to the handler.
    /// </summary>
    /// <remarks><see langword="null"/> may be used as the name of the receiver in an instance method.</remarks>
    public string[] Arguments { get; }
}