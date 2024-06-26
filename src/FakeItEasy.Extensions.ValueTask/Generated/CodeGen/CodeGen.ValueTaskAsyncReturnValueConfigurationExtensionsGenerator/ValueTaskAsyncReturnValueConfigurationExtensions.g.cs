﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by CodeGen.ValueTaskAsyncReturnValueConfigurationExtensionsGenerator.
//
//     Changes to this file will be lost when the project is rebuilt.
// </auto-generated>
//------------------------------------------------------------------------------
namespace FakeItEasy
{
    using System;
    using System.Threading.Tasks;
    using FakeItEasy.Configuration;

    public static partial class ValueTaskAsyncReturnValueConfigurationExtensions
    {
        /// <summary>
        /// Returns a failed ValueTask with the specified exception when the currently configured call gets called.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        /// <param name="exceptionFactory">A function that returns the exception to set on the returned ValueTask when a call that matches is invoked.</param>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <returns>The configuration object.</returns>
        public static IAfterCallConfiguredConfiguration<IReturnValueConfiguration<ValueTask>> ThrowsAsync<T1>(
            this IReturnValueConfiguration<ValueTask> configuration,
            Func<T1, Exception> exceptionFactory)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(exceptionFactory);

            return
                configuration.ReturnsLazily(
                    (T1 arg1) => new ValueTask(TaskHelper.FromException(exceptionFactory(arg1))));
        }

        /// <summary>
        /// Returns a failed ValueTask with the specified exception when the currently configured call gets called.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        /// <param name="exceptionFactory">A function that returns the exception to set on the returned ValueTask when a call that matches is invoked.</param>
        /// <typeparam name="T">The type of the returned ValueTask's result.</typeparam>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <returns>The configuration object.</returns>
        public static IAfterCallConfiguredConfiguration<IReturnValueConfiguration<ValueTask<T>>> ThrowsAsync<T, T1>(
            this IReturnValueConfiguration<ValueTask<T>> configuration,
            Func<T1, Exception> exceptionFactory)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(exceptionFactory);

            return configuration.ReturnsLazily((T1 arg1) => new ValueTask<T>(TaskHelper.FromException<T>(exceptionFactory(arg1))));
        }

        /// <summary>
        /// Returns a failed ValueTask with the specified exception when the currently configured call gets called.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        /// <param name="exceptionFactory">A function that returns the exception to set on the returned ValueTask when a call that matches is invoked.</param>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <returns>The configuration object.</returns>
        public static IAfterCallConfiguredConfiguration<IReturnValueConfiguration<ValueTask>> ThrowsAsync<T1, T2>(
            this IReturnValueConfiguration<ValueTask> configuration,
            Func<T1, T2, Exception> exceptionFactory)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(exceptionFactory);

            return
                configuration.ReturnsLazily(
                    (T1 arg1, T2 arg2) => new ValueTask(TaskHelper.FromException(exceptionFactory(arg1, arg2))));
        }

        /// <summary>
        /// Returns a failed ValueTask with the specified exception when the currently configured call gets called.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        /// <param name="exceptionFactory">A function that returns the exception to set on the returned ValueTask when a call that matches is invoked.</param>
        /// <typeparam name="T">The type of the returned ValueTask's result.</typeparam>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <returns>The configuration object.</returns>
        public static IAfterCallConfiguredConfiguration<IReturnValueConfiguration<ValueTask<T>>> ThrowsAsync<T, T1, T2>(
            this IReturnValueConfiguration<ValueTask<T>> configuration,
            Func<T1, T2, Exception> exceptionFactory)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(exceptionFactory);

            return configuration.ReturnsLazily((T1 arg1, T2 arg2) => new ValueTask<T>(TaskHelper.FromException<T>(exceptionFactory(arg1, arg2))));
        }

        /// <summary>
        /// Returns a failed ValueTask with the specified exception when the currently configured call gets called.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        /// <param name="exceptionFactory">A function that returns the exception to set on the returned ValueTask when a call that matches is invoked.</param>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <returns>The configuration object.</returns>
        public static IAfterCallConfiguredConfiguration<IReturnValueConfiguration<ValueTask>> ThrowsAsync<T1, T2, T3>(
            this IReturnValueConfiguration<ValueTask> configuration,
            Func<T1, T2, T3, Exception> exceptionFactory)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(exceptionFactory);

            return
                configuration.ReturnsLazily(
                    (T1 arg1, T2 arg2, T3 arg3) => new ValueTask(TaskHelper.FromException(exceptionFactory(arg1, arg2, arg3))));
        }

        /// <summary>
        /// Returns a failed ValueTask with the specified exception when the currently configured call gets called.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        /// <param name="exceptionFactory">A function that returns the exception to set on the returned ValueTask when a call that matches is invoked.</param>
        /// <typeparam name="T">The type of the returned ValueTask's result.</typeparam>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <returns>The configuration object.</returns>
        public static IAfterCallConfiguredConfiguration<IReturnValueConfiguration<ValueTask<T>>> ThrowsAsync<T, T1, T2, T3>(
            this IReturnValueConfiguration<ValueTask<T>> configuration,
            Func<T1, T2, T3, Exception> exceptionFactory)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(exceptionFactory);

            return configuration.ReturnsLazily((T1 arg1, T2 arg2, T3 arg3) => new ValueTask<T>(TaskHelper.FromException<T>(exceptionFactory(arg1, arg2, arg3))));
        }

        /// <summary>
        /// Returns a failed ValueTask with the specified exception when the currently configured call gets called.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        /// <param name="exceptionFactory">A function that returns the exception to set on the returned ValueTask when a call that matches is invoked.</param>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <typeparam name="T4">The type of the fourth argument of the faked method call.</typeparam>
        /// <returns>The configuration object.</returns>
        public static IAfterCallConfiguredConfiguration<IReturnValueConfiguration<ValueTask>> ThrowsAsync<T1, T2, T3, T4>(
            this IReturnValueConfiguration<ValueTask> configuration,
            Func<T1, T2, T3, T4, Exception> exceptionFactory)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(exceptionFactory);

            return
                configuration.ReturnsLazily(
                    (T1 arg1, T2 arg2, T3 arg3, T4 arg4) => new ValueTask(TaskHelper.FromException(exceptionFactory(arg1, arg2, arg3, arg4))));
        }

        /// <summary>
        /// Returns a failed ValueTask with the specified exception when the currently configured call gets called.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        /// <param name="exceptionFactory">A function that returns the exception to set on the returned ValueTask when a call that matches is invoked.</param>
        /// <typeparam name="T">The type of the returned ValueTask's result.</typeparam>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <typeparam name="T4">The type of the fourth argument of the faked method call.</typeparam>
        /// <returns>The configuration object.</returns>
        public static IAfterCallConfiguredConfiguration<IReturnValueConfiguration<ValueTask<T>>> ThrowsAsync<T, T1, T2, T3, T4>(
            this IReturnValueConfiguration<ValueTask<T>> configuration,
            Func<T1, T2, T3, T4, Exception> exceptionFactory)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(exceptionFactory);

            return configuration.ReturnsLazily((T1 arg1, T2 arg2, T3 arg3, T4 arg4) => new ValueTask<T>(TaskHelper.FromException<T>(exceptionFactory(arg1, arg2, arg3, arg4))));
        }

        /// <summary>
        /// Returns a failed ValueTask with the specified exception when the currently configured call gets called.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        /// <param name="exceptionFactory">A function that returns the exception to set on the returned ValueTask when a call that matches is invoked.</param>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <typeparam name="T4">The type of the fourth argument of the faked method call.</typeparam>
        /// <typeparam name="T5">The type of the fifth argument of the faked method call.</typeparam>
        /// <returns>The configuration object.</returns>
        public static IAfterCallConfiguredConfiguration<IReturnValueConfiguration<ValueTask>> ThrowsAsync<T1, T2, T3, T4, T5>(
            this IReturnValueConfiguration<ValueTask> configuration,
            Func<T1, T2, T3, T4, T5, Exception> exceptionFactory)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(exceptionFactory);

            return
                configuration.ReturnsLazily(
                    (T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => new ValueTask(TaskHelper.FromException(exceptionFactory(arg1, arg2, arg3, arg4, arg5))));
        }

        /// <summary>
        /// Returns a failed ValueTask with the specified exception when the currently configured call gets called.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        /// <param name="exceptionFactory">A function that returns the exception to set on the returned ValueTask when a call that matches is invoked.</param>
        /// <typeparam name="T">The type of the returned ValueTask's result.</typeparam>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <typeparam name="T4">The type of the fourth argument of the faked method call.</typeparam>
        /// <typeparam name="T5">The type of the fifth argument of the faked method call.</typeparam>
        /// <returns>The configuration object.</returns>
        public static IAfterCallConfiguredConfiguration<IReturnValueConfiguration<ValueTask<T>>> ThrowsAsync<T, T1, T2, T3, T4, T5>(
            this IReturnValueConfiguration<ValueTask<T>> configuration,
            Func<T1, T2, T3, T4, T5, Exception> exceptionFactory)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(exceptionFactory);

            return configuration.ReturnsLazily((T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => new ValueTask<T>(TaskHelper.FromException<T>(exceptionFactory(arg1, arg2, arg3, arg4, arg5))));
        }

        /// <summary>
        /// Returns a failed ValueTask with the specified exception when the currently configured call gets called.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        /// <param name="exceptionFactory">A function that returns the exception to set on the returned ValueTask when a call that matches is invoked.</param>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <typeparam name="T4">The type of the fourth argument of the faked method call.</typeparam>
        /// <typeparam name="T5">The type of the fifth argument of the faked method call.</typeparam>
        /// <typeparam name="T6">The type of the sixth argument of the faked method call.</typeparam>
        /// <returns>The configuration object.</returns>
        public static IAfterCallConfiguredConfiguration<IReturnValueConfiguration<ValueTask>> ThrowsAsync<T1, T2, T3, T4, T5, T6>(
            this IReturnValueConfiguration<ValueTask> configuration,
            Func<T1, T2, T3, T4, T5, T6, Exception> exceptionFactory)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(exceptionFactory);

            return
                configuration.ReturnsLazily(
                    (T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => new ValueTask(TaskHelper.FromException(exceptionFactory(arg1, arg2, arg3, arg4, arg5, arg6))));
        }

        /// <summary>
        /// Returns a failed ValueTask with the specified exception when the currently configured call gets called.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        /// <param name="exceptionFactory">A function that returns the exception to set on the returned ValueTask when a call that matches is invoked.</param>
        /// <typeparam name="T">The type of the returned ValueTask's result.</typeparam>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <typeparam name="T4">The type of the fourth argument of the faked method call.</typeparam>
        /// <typeparam name="T5">The type of the fifth argument of the faked method call.</typeparam>
        /// <typeparam name="T6">The type of the sixth argument of the faked method call.</typeparam>
        /// <returns>The configuration object.</returns>
        public static IAfterCallConfiguredConfiguration<IReturnValueConfiguration<ValueTask<T>>> ThrowsAsync<T, T1, T2, T3, T4, T5, T6>(
            this IReturnValueConfiguration<ValueTask<T>> configuration,
            Func<T1, T2, T3, T4, T5, T6, Exception> exceptionFactory)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(exceptionFactory);

            return configuration.ReturnsLazily((T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => new ValueTask<T>(TaskHelper.FromException<T>(exceptionFactory(arg1, arg2, arg3, arg4, arg5, arg6))));
        }

        /// <summary>
        /// Returns a failed ValueTask with the specified exception when the currently configured call gets called.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        /// <param name="exceptionFactory">A function that returns the exception to set on the returned ValueTask when a call that matches is invoked.</param>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <typeparam name="T4">The type of the fourth argument of the faked method call.</typeparam>
        /// <typeparam name="T5">The type of the fifth argument of the faked method call.</typeparam>
        /// <typeparam name="T6">The type of the sixth argument of the faked method call.</typeparam>
        /// <typeparam name="T7">The type of the seventh argument of the faked method call.</typeparam>
        /// <returns>The configuration object.</returns>
        public static IAfterCallConfiguredConfiguration<IReturnValueConfiguration<ValueTask>> ThrowsAsync<T1, T2, T3, T4, T5, T6, T7>(
            this IReturnValueConfiguration<ValueTask> configuration,
            Func<T1, T2, T3, T4, T5, T6, T7, Exception> exceptionFactory)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(exceptionFactory);

            return
                configuration.ReturnsLazily(
                    (T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => new ValueTask(TaskHelper.FromException(exceptionFactory(arg1, arg2, arg3, arg4, arg5, arg6, arg7))));
        }

        /// <summary>
        /// Returns a failed ValueTask with the specified exception when the currently configured call gets called.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        /// <param name="exceptionFactory">A function that returns the exception to set on the returned ValueTask when a call that matches is invoked.</param>
        /// <typeparam name="T">The type of the returned ValueTask's result.</typeparam>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <typeparam name="T4">The type of the fourth argument of the faked method call.</typeparam>
        /// <typeparam name="T5">The type of the fifth argument of the faked method call.</typeparam>
        /// <typeparam name="T6">The type of the sixth argument of the faked method call.</typeparam>
        /// <typeparam name="T7">The type of the seventh argument of the faked method call.</typeparam>
        /// <returns>The configuration object.</returns>
        public static IAfterCallConfiguredConfiguration<IReturnValueConfiguration<ValueTask<T>>> ThrowsAsync<T, T1, T2, T3, T4, T5, T6, T7>(
            this IReturnValueConfiguration<ValueTask<T>> configuration,
            Func<T1, T2, T3, T4, T5, T6, T7, Exception> exceptionFactory)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(exceptionFactory);

            return configuration.ReturnsLazily((T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => new ValueTask<T>(TaskHelper.FromException<T>(exceptionFactory(arg1, arg2, arg3, arg4, arg5, arg6, arg7))));
        }

        /// <summary>
        /// Returns a failed ValueTask with the specified exception when the currently configured call gets called.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        /// <param name="exceptionFactory">A function that returns the exception to set on the returned ValueTask when a call that matches is invoked.</param>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <typeparam name="T4">The type of the fourth argument of the faked method call.</typeparam>
        /// <typeparam name="T5">The type of the fifth argument of the faked method call.</typeparam>
        /// <typeparam name="T6">The type of the sixth argument of the faked method call.</typeparam>
        /// <typeparam name="T7">The type of the seventh argument of the faked method call.</typeparam>
        /// <typeparam name="T8">The type of the eighth argument of the faked method call.</typeparam>
        /// <returns>The configuration object.</returns>
        public static IAfterCallConfiguredConfiguration<IReturnValueConfiguration<ValueTask>> ThrowsAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
            this IReturnValueConfiguration<ValueTask> configuration,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, Exception> exceptionFactory)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(exceptionFactory);

            return
                configuration.ReturnsLazily(
                    (T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => new ValueTask(TaskHelper.FromException(exceptionFactory(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8))));
        }

        /// <summary>
        /// Returns a failed ValueTask with the specified exception when the currently configured call gets called.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        /// <param name="exceptionFactory">A function that returns the exception to set on the returned ValueTask when a call that matches is invoked.</param>
        /// <typeparam name="T">The type of the returned ValueTask's result.</typeparam>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <typeparam name="T4">The type of the fourth argument of the faked method call.</typeparam>
        /// <typeparam name="T5">The type of the fifth argument of the faked method call.</typeparam>
        /// <typeparam name="T6">The type of the sixth argument of the faked method call.</typeparam>
        /// <typeparam name="T7">The type of the seventh argument of the faked method call.</typeparam>
        /// <typeparam name="T8">The type of the eighth argument of the faked method call.</typeparam>
        /// <returns>The configuration object.</returns>
        public static IAfterCallConfiguredConfiguration<IReturnValueConfiguration<ValueTask<T>>> ThrowsAsync<T, T1, T2, T3, T4, T5, T6, T7, T8>(
            this IReturnValueConfiguration<ValueTask<T>> configuration,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, Exception> exceptionFactory)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(exceptionFactory);

            return configuration.ReturnsLazily((T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => new ValueTask<T>(TaskHelper.FromException<T>(exceptionFactory(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8))));
        }
    }
}
