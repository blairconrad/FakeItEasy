﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by CodeGen.ArgumentValidationConfigurationExtensionsGenerator.
//
//     Changes to this file will be lost when the project is rebuilt.
// </auto-generated>
//------------------------------------------------------------------------------
namespace FakeItEasy
{
    using System;
    using System.Reflection;
    using FakeItEasy.Configuration;

    public static partial class ArgumentValidationConfigurationExtensions
    {
        /// <summary>
        /// Configures the call to be accepted when the specified predicate returns true.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <param name="configuration">The configuration.</param>
        /// <param name="argumentsPredicate">The argument predicate.</param>
        /// <returns>The configuration object.</returns>
        public static TInterface WhenArgumentsMatch<TInterface, T1>(
            this IArgumentValidationConfiguration<TInterface> configuration,
            Func<T1, bool> argumentsPredicate)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(argumentsPredicate);

            return configuration.WhenArgumentsMatch(args =>
            {
                ValueProducerSignatureHelper.AssertThatValueProducerSignatureSatisfiesCallSignature(
                    args.Method,
                    argumentsPredicate.GetMethodInfo(),
                    NameOfWhenArgumentsMatchFeature);

                return argumentsPredicate(args.Get<T1>(0));
            });
        }

        /// <summary>
        /// Configures the call to be accepted when the specified predicate returns true.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <param name="configuration">The configuration.</param>
        /// <param name="argumentsPredicate">The argument predicate.</param>
        /// <returns>The configuration object.</returns>
        public static TInterface WhenArgumentsMatch<TInterface, T1, T2>(
            this IArgumentValidationConfiguration<TInterface> configuration,
            Func<T1, T2, bool> argumentsPredicate)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(argumentsPredicate);

            return configuration.WhenArgumentsMatch(args =>
            {
                ValueProducerSignatureHelper.AssertThatValueProducerSignatureSatisfiesCallSignature(
                    args.Method,
                    argumentsPredicate.GetMethodInfo(),
                    NameOfWhenArgumentsMatchFeature);

                return argumentsPredicate(args.Get<T1>(0), args.Get<T2>(1));
            });
        }

        /// <summary>
        /// Configures the call to be accepted when the specified predicate returns true.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <param name="configuration">The configuration.</param>
        /// <param name="argumentsPredicate">The argument predicate.</param>
        /// <returns>The configuration object.</returns>
        public static TInterface WhenArgumentsMatch<TInterface, T1, T2, T3>(
            this IArgumentValidationConfiguration<TInterface> configuration,
            Func<T1, T2, T3, bool> argumentsPredicate)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(argumentsPredicate);

            return configuration.WhenArgumentsMatch(args =>
            {
                ValueProducerSignatureHelper.AssertThatValueProducerSignatureSatisfiesCallSignature(
                    args.Method,
                    argumentsPredicate.GetMethodInfo(),
                    NameOfWhenArgumentsMatchFeature);

                return argumentsPredicate(args.Get<T1>(0), args.Get<T2>(1), args.Get<T3>(2));
            });
        }

        /// <summary>
        /// Configures the call to be accepted when the specified predicate returns true.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <typeparam name="T4">The type of the fourth argument of the faked method call.</typeparam>
        /// <param name="configuration">The configuration.</param>
        /// <param name="argumentsPredicate">The argument predicate.</param>
        /// <returns>The configuration object.</returns>
        public static TInterface WhenArgumentsMatch<TInterface, T1, T2, T3, T4>(
            this IArgumentValidationConfiguration<TInterface> configuration,
            Func<T1, T2, T3, T4, bool> argumentsPredicate)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(argumentsPredicate);

            return configuration.WhenArgumentsMatch(args =>
            {
                ValueProducerSignatureHelper.AssertThatValueProducerSignatureSatisfiesCallSignature(
                    args.Method,
                    argumentsPredicate.GetMethodInfo(),
                    NameOfWhenArgumentsMatchFeature);

                return argumentsPredicate(args.Get<T1>(0), args.Get<T2>(1), args.Get<T3>(2), args.Get<T4>(3));
            });
        }

        /// <summary>
        /// Configures the call to be accepted when the specified predicate returns true.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <typeparam name="T4">The type of the fourth argument of the faked method call.</typeparam>
        /// <typeparam name="T5">The type of the fifth argument of the faked method call.</typeparam>
        /// <param name="configuration">The configuration.</param>
        /// <param name="argumentsPredicate">The argument predicate.</param>
        /// <returns>The configuration object.</returns>
        public static TInterface WhenArgumentsMatch<TInterface, T1, T2, T3, T4, T5>(
            this IArgumentValidationConfiguration<TInterface> configuration,
            Func<T1, T2, T3, T4, T5, bool> argumentsPredicate)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(argumentsPredicate);

            return configuration.WhenArgumentsMatch(args =>
            {
                ValueProducerSignatureHelper.AssertThatValueProducerSignatureSatisfiesCallSignature(
                    args.Method,
                    argumentsPredicate.GetMethodInfo(),
                    NameOfWhenArgumentsMatchFeature);

                return argumentsPredicate(args.Get<T1>(0), args.Get<T2>(1), args.Get<T3>(2), args.Get<T4>(3), args.Get<T5>(4));
            });
        }

        /// <summary>
        /// Configures the call to be accepted when the specified predicate returns true.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <typeparam name="T4">The type of the fourth argument of the faked method call.</typeparam>
        /// <typeparam name="T5">The type of the fifth argument of the faked method call.</typeparam>
        /// <typeparam name="T6">The type of the sixth argument of the faked method call.</typeparam>
        /// <param name="configuration">The configuration.</param>
        /// <param name="argumentsPredicate">The argument predicate.</param>
        /// <returns>The configuration object.</returns>
        public static TInterface WhenArgumentsMatch<TInterface, T1, T2, T3, T4, T5, T6>(
            this IArgumentValidationConfiguration<TInterface> configuration,
            Func<T1, T2, T3, T4, T5, T6, bool> argumentsPredicate)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(argumentsPredicate);

            return configuration.WhenArgumentsMatch(args =>
            {
                ValueProducerSignatureHelper.AssertThatValueProducerSignatureSatisfiesCallSignature(
                    args.Method,
                    argumentsPredicate.GetMethodInfo(),
                    NameOfWhenArgumentsMatchFeature);

                return argumentsPredicate(args.Get<T1>(0), args.Get<T2>(1), args.Get<T3>(2), args.Get<T4>(3), args.Get<T5>(4), args.Get<T6>(5));
            });
        }

        /// <summary>
        /// Configures the call to be accepted when the specified predicate returns true.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <typeparam name="T4">The type of the fourth argument of the faked method call.</typeparam>
        /// <typeparam name="T5">The type of the fifth argument of the faked method call.</typeparam>
        /// <typeparam name="T6">The type of the sixth argument of the faked method call.</typeparam>
        /// <typeparam name="T7">The type of the seventh argument of the faked method call.</typeparam>
        /// <param name="configuration">The configuration.</param>
        /// <param name="argumentsPredicate">The argument predicate.</param>
        /// <returns>The configuration object.</returns>
        public static TInterface WhenArgumentsMatch<TInterface, T1, T2, T3, T4, T5, T6, T7>(
            this IArgumentValidationConfiguration<TInterface> configuration,
            Func<T1, T2, T3, T4, T5, T6, T7, bool> argumentsPredicate)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(argumentsPredicate);

            return configuration.WhenArgumentsMatch(args =>
            {
                ValueProducerSignatureHelper.AssertThatValueProducerSignatureSatisfiesCallSignature(
                    args.Method,
                    argumentsPredicate.GetMethodInfo(),
                    NameOfWhenArgumentsMatchFeature);

                return argumentsPredicate(args.Get<T1>(0), args.Get<T2>(1), args.Get<T3>(2), args.Get<T4>(3), args.Get<T5>(4), args.Get<T6>(5), args.Get<T7>(6));
            });
        }

        /// <summary>
        /// Configures the call to be accepted when the specified predicate returns true.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="T1">The type of the first argument of the faked method call.</typeparam>
        /// <typeparam name="T2">The type of the second argument of the faked method call.</typeparam>
        /// <typeparam name="T3">The type of the third argument of the faked method call.</typeparam>
        /// <typeparam name="T4">The type of the fourth argument of the faked method call.</typeparam>
        /// <typeparam name="T5">The type of the fifth argument of the faked method call.</typeparam>
        /// <typeparam name="T6">The type of the sixth argument of the faked method call.</typeparam>
        /// <typeparam name="T7">The type of the seventh argument of the faked method call.</typeparam>
        /// <typeparam name="T8">The type of the eighth argument of the faked method call.</typeparam>
        /// <param name="configuration">The configuration.</param>
        /// <param name="argumentsPredicate">The argument predicate.</param>
        /// <returns>The configuration object.</returns>
        public static TInterface WhenArgumentsMatch<TInterface, T1, T2, T3, T4, T5, T6, T7, T8>(
            this IArgumentValidationConfiguration<TInterface> configuration,
            Func<T1, T2, T3, T4, T5, T6, T7, T8, bool> argumentsPredicate)
        {
            Guard.AgainstNull(configuration);
            Guard.AgainstNull(argumentsPredicate);

            return configuration.WhenArgumentsMatch(args =>
            {
                ValueProducerSignatureHelper.AssertThatValueProducerSignatureSatisfiesCallSignature(
                    args.Method,
                    argumentsPredicate.GetMethodInfo(),
                    NameOfWhenArgumentsMatchFeature);

                return argumentsPredicate(args.Get<T1>(0), args.Get<T2>(1), args.Get<T3>(2), args.Get<T4>(3), args.Get<T5>(4), args.Get<T6>(5), args.Get<T7>(6), args.Get<T8>(7));
            });
        }
    }
}
