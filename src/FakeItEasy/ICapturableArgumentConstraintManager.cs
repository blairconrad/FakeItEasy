namespace FakeItEasy
{
    using System;

    /// <summary>
    /// Enables capture of argument constraints.
    /// </summary>
    /// <typeparam name="T">The type of argument to capture and/or constrain.</typeparam>
    [CLSCompliant(false)]
    public interface ICapturableArgumentConstraintManager<T> : INegatableArgumentConstraintManager<T>
    {
        /// <summary>
        /// Specifies where to capture argument values to.
        /// </summary>
        /// <param name="capturedArgument">Where to capture the argument values to.</param>
        /// <returns>A configuration object that may be used to further constrain the supplied argument.</returns>
        /// <remarks>
        /// Values are only captured if the call matches the configuration.
        /// When a call configuration includes one or more argument-capturing constraints, the argument
        /// values are only captured if the call is triggered. If an incoming call does not match what's
        /// configured for the method or property, no arguments are captured.
        /// </remarks>
        ICapturingArgumentConstraintManager<T> IsCapturedTo(CapturedArgument<T> capturedArgument);
    }
}
