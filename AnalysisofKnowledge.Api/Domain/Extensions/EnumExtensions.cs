using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace AnalysisofKnowledge.Api.Domain.Extensions
{
    public static class EnumExtensions
    {
                /// <summary>
        ///     Gets all of the values of the specified <typeparamref name="TEnum"/>.
        /// </summary>
        /// <typeparam name="TEnum">
        ///     The type of the enum.
        /// </typeparam>
        /// <typeparam name="TOut">
        ///     The type to cast the output values to.
        /// </typeparam>
        /// <exception cref="System.ArgumentException">
        ///     TEnum must be an enumerated type.
        /// </exception>
        public static IEnumerable<TOut> GetValues<TEnum, TOut>()
            where TEnum : Enum =>
            Enum.GetValues(typeof(TEnum)).Cast<TOut>();

        /// <inheritdoc cref="GetValues{TEnum,TOut}"/>
        public static IEnumerable<TEnum> GetValues<TEnum>()
            where TEnum : Enum =>
            GetValues<TEnum, TEnum>();

        /// <summary>
        ///     Gets the full name of the given <paramref name="enumValue"/>
        ///     by concatenating its type(<typeparamref name="TEnum"/>) and value names.
        /// </summary>
        /// <typeparam name="TEnum">
        ///     The type of the enum.
        /// </typeparam>
        /// <param name="enumValue">
        ///     The instance of the enum.
        /// </param>
        /// <exception cref="System.ArgumentException">
        ///     TEnum must be an enumerated type.
        /// </exception>
        public static string GetFullName<TEnum>(this TEnum enumValue)
            where TEnum : Enum =>
            $"{typeof(TEnum).Name}_{enumValue.ToString()}";

        /// <summary>
        ///     Gets bitwise disjunction of all values of the specified <typeparamref name="TFlagEnum"/>
        ///     as a value of that enum.
        /// </summary>
        /// <typeparam name="TFlagEnum">
        ///     The type of the flag enum.
        /// </typeparam>
        /// <exception cref="System.ArgumentException">
        ///     TFlagEnum must be a flag enum.
        /// </exception>
        public static TFlagEnum GetAll<TFlagEnum>()
            where TFlagEnum : Enum =>
            (TFlagEnum) Enum.ToObject(typeof(TFlagEnum), GetAllNumber<TFlagEnum>());

        /// <summary>
        ///     Gets bitwise disjunction of all values of the specified <typeparamref name="TFlagEnum"/>
        ///     as a number.
        /// </summary>
        /// <typeparam name="TFlagEnum">
        ///     The type of the flag enum.
        /// </typeparam>
        /// <exception cref="System.ArgumentException">
        ///     TFlagEnum must be a flag enum.
        /// </exception>
        private static int GetAllNumber<TFlagEnum>()
            where TFlagEnum : Enum
        {
            var enumType = typeof(TFlagEnum);

            if (enumType.GetCustomAttribute(typeof(FlagsAttribute)) == null)
            {
                throw new NotFlagEnumTypeParamException<TFlagEnum>();
            }

            return Enum.GetValues(enumType)
                       .Cast<TFlagEnum>()
                       .Aggregate(0, (result, value) => result | Convert.ToInt32(value));
        }

        public static void MustBeInEnum<TEnum>(this int enumValue)
            where TEnum : struct, Enum
        {
            if (!Enum.IsDefined(typeof(TEnum), enumValue))
            {
                throw new BadEnumValueException<TEnum>(enumValue);
            }
        }

        /// <summary>
        ///     Throws an exception if the given <typeparamref name="TEnum"/> is not an Enum type.
        /// </summary>
        /// <typeparam name="TEnum">
        ///     The type.
        /// </typeparam>
        private static void MustBeEnumType<TEnum>()
            where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new NotEnumTypeParamException<TEnum>();
            }
        }

        /// <inheritdoc cref="MustBeEnumType{TEnum}"/>
        /// <param name="value">
        ///     For syntantic sugar.
        /// </param>
        // ReSharper disable once UnusedParameter.Global - sugar
        public static void MustBeOfEnumType<TEnum>(this TEnum? value)
            where TEnum : struct, IConvertible =>
            MustBeEnumType<TEnum>();

        /// <summary>
        ///     Checks if the given <paramref name="enumValue"/> equals to one of the <paramref name="allowedValues"/>.
        ///     Throws an exception if it does not.
        /// </summary>
        /// <typeparam name="TEnum">
        ///     The type of the enum.
        /// </typeparam>
        /// <param name="enumValue">
        ///     The value to check.
        /// </param>
        /// <param name="allowedValues">
        ///     The allowed enum values.
        /// </param>
        [AssertionMethod]
        public static void MustEqual<TEnum>(this TEnum enumValue, params TEnum[] allowedValues)
            where TEnum : struct, Enum, IConvertible
        {
            MustBeEnumType<TEnum>();

            if (allowedValues.Length == 0)
            {
                throw new ArgumentException($"{nameof(allowedValues)} must not be empty");
            }

            if (!allowedValues.Contains(enumValue))
            {
                throw allowedValues.Length == 1
                    ? new BadEnumValueException<TEnum>(enumValue, allowedValues[0])
                    : new BadEnumValueException<TEnum>(enumValue);
            }
        }

        public static bool IsDefined<TEnum>(this TEnum enumValue) => Enum.IsDefined(typeof(TEnum), enumValue);

        /// <summary>
        ///     Converts the given undelying <paramref name="enumValue"/> to the actual enum value.
        ///     Checks that the value exists.
        /// </summary>
        /// <param name="enumValue">
        ///     The underlying value of the enum.
        /// </param>
        /// <typeparam name="TEnum">
        ///     Type of the enum.
        /// </typeparam>
        public static TEnum ToEnum<TEnum>(this int enumValue)
            where TEnum : Enum
        {
            var enumType = typeof(TEnum);

            if (typeof(int) != Enum.GetUnderlyingType(enumType))
            {
                throw new ArgumentException(
                    $"Type of the {nameof(enumValue)} and the underlying type of the {nameof(TEnum)} do not match");
            }

            var result = (TEnum) Enum.ToObject(enumType, enumValue);

            if (!result.IsDefined())
            {
                throw new ArgumentException($"The value {result} is not defined in the {nameof(TEnum)}");
            }

            return result;
        }

        /// <summary>
        ///     Gets the provider of localized strings for the given <paramref name="enumValue"/>.
        /// </summary>
        /// <param name="enumValue">
        ///     The value of the enum.
        /// </param>
        [NotNull]
        public static LocalizedDisplay GetDisplay(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            var enumValueField = enumType.GetField(enumValue.ToString());

            var displayAttribute = enumValueField.GetCustomAttribute<DisplayAttribute>(false)
                ?? throw new InvalidOperationException(
                    $"Failed to find a {nameof(DisplayAttribute)} on the enum value {enumType.FullName}.{enumValue.ToString()}");

            return new LocalizedDisplay(displayAttribute);
        }

        /// <summary>
        ///     Determines whether bit fields of the <paramref name="flagValue"/>
        ///     are set in the given <paramref name="enumValue"/>.
        ///     <para/>
        ///     Compares the underlying values of the given enums regardless of their types.
        /// </summary>
        /// <param name="enumValue">
        ///     The value of the enum.
        /// </param>
        /// <param name="flagValue">
        ///     The value of the flag.
        /// </param>
        /// <typeparam name="TEnum">
        ///     The type of the <paramref name="enumValue"/>. Must have <c>int</c> as its underlying value.
        /// </typeparam>
        /// <typeparam name="TFlagEnum">
        ///     The type of the <paramref name="flagValue"/>. Must have <c>int</c> as its underlying value.
        /// </typeparam>
        /// <returns>
        ///     <c>true</c>, if the bit fields that are set in <paramref name="flagValue"/> are also set in the
        ///     <paramref name="enumValue"/>;
        ///     otherwise, <c>false</c>.
        /// </returns>
        public static bool HasFlagByValue<TEnum, TFlagEnum>(this TEnum enumValue, TFlagEnum flagValue)
            where TEnum : Enum
            where TFlagEnum : Enum
        {
            var enumValueInt = Convert.ToInt32(enumValue);
            var flagValueInt = Convert.ToInt32(flagValue);

            return (enumValueInt & flagValueInt) == flagValueInt;
        }

        public static string AsJsonArray<TEnum>(params TEnum[] stepTypes)
            where TEnum : Enum
        {
            if (typeof(TEnum).GetEnumUnderlyingType() != typeof(int))
            {
                throw new ArgumentException(@"The TEnum must have int as its underlying type", nameof(TEnum));
            }

            // ReSharper disable once SuspiciousTypeConversion.Global - type validate above
            return JsonConvert.SerializeObject(stepTypes.Cast<int>());
        }
    }
}