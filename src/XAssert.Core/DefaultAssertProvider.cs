using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using XAssert.Resources;

namespace XAssert
{
	public partial class DefaultAssertProvider : IAssertProvider
	{
		#region Sameness
		/// <inheritdoc />
		public void AreSame<T>(T first, T second, string message = null) where T : class
		{
			if (!Object.ReferenceEquals(first, second))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.AreSame, first, second));
		}

		/// <inheritdoc />
		public void AreNotSame<T>(T first, T second, string message = null) where T : class
		{
			if (Object.ReferenceEquals(first, second))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.AreNotSame, first, second));
		}
		#endregion

		#region Equality
		/// <inheritdoc />
		public void AreEqual<T>(T first, T second, IEqualityComparer<T> equalityComparer, string message = null)
		{
			if (!equalityComparer.Equals(first, second))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.AreEqual, first, second));
		}

		/// <inheritdoc />
		public void AreNotEqual<T>(T first, T second, IEqualityComparer<T> equalityComparer, string message = null)
		{
			if (equalityComparer.Equals(first, second))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.AreNotEqual, first, second));
		}

		#endregion

		#region Nulls and defaults
		/// <inheritdoc />
		public void IsNull<T>(T obj, string message = null) where T : class
		{
			if (null != obj)
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.ObjectIsNull, obj));
		}

		/// <inheritdoc />
		public void IsNotNull<T>(T obj, string message = null) where T : class
		{
			if (null == obj)
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.ObjectIsNotNull, obj));
		}

		/// <inheritdoc />
		public void IsNull<T>(Nullable<T> value, string message = null) where T : struct
		{
			if (null != value)
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.ValueIsNull, value));
		}

		/// <inheritdoc />
		public void IsNotNull<T>(Nullable<T> value, string message = null) where T : struct
		{
			if (null == value)
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.ValueIsNotNull, value));
		}

		/// <inheritdoc />
		public void IsDefault<T>(T obj, string message = null)
		{
			if (!EqualityComparer<T>.Default.Equals(default(T), obj))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsDefault, default(T), obj));
		}

		/// <inheritdoc />
		public void IsNotDefault<T>(T obj, string message = null)
		{
			if (EqualityComparer<T>.Default.Equals(default(T), obj))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsNotDefault, default(T), obj));
		}
		#endregion

		#region Boolean
		/// <inheritdoc />
		public void IsTrue(bool value, string message = null)
		{
			if (true != value)
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsTrue, value));
		}

		/// <inheritdoc />
		public void IsFalse(bool value, string message = null)
		{
			if (false != value)
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsFalse, value));
		}
		#endregion

		#region Numbers
		/// <inheritdoc />
		public void IsNaN(double value, string message = null)
		{
			if (!Double.IsNaN(value))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsNaN, value));
		}

		/// <inheritdoc />
		public void IsNotNaN(double value, string message = null)
		{
			if (Double.IsNaN(value))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsNotNaN, value));
		}

		/// <inheritdoc />
		public void IsPositiveInfinity(double value, string message = null)
		{
			if (!Double.IsPositiveInfinity(value))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsPositiveInfinity, value));
		}

		/// <inheritdoc />
		public void IsNotPositiveInfinity(double value, string message = null)
		{
			if (Double.IsPositiveInfinity(value))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsNotPositiveInfinity, value));
		}

		/// <inheritdoc />
		public void IsNegativeInfinity(double value, string message = null)
		{
			if (!Double.IsNegativeInfinity(value))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsNegativeInfinity, value));
		}

		/// <inheritdoc />
		public void IsNotNegativeInfinity(double value, string message = null)
		{
			if (Double.IsNegativeInfinity(value))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsNotNegativeInfinity, value));
		}
		#endregion

		#region Guids
		/// <inheritdoc />
		public void IsEmpty(Guid value, string message = null)
		{
			if (value != Guid.Empty)
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.GuidIsEmpty, value));
		}

		/// <inheritdoc />
		public void IsNotEmpty(Guid value, string message = null)
		{
			if (value == Guid.Empty)
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.GuidIsNotEmpty, value));
		}
		#endregion

		#region Comparison
		/// <inheritdoc />
		public void IsGreaterThan<T>(T first, T second, IComparer<T> comparer, string message = null)
		{
			if (comparer.Compare(first, second) <= 0)
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsGreaterThan, first, second));
		}

		/// <inheritdoc />
		public void IsLessThan<T>(T first, T second, IComparer<T> comparer, string message = null)
		{
			if (comparer.Compare(first, second) >= 0)
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsLessThan, first, second));
		}

		/// <inheritdoc />
		public void IsGreaterThanOrEqual<T>(T first, T second, IComparer<T> comparer, string message = null)
		{
			if (comparer.Compare(first, second) < 0)
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsGreaterThanOrEqual, first, second));
		}

		/// <inheritdoc />
		public void IsLessThanOrEqual<T>(T first, T second, IComparer<T> comparer, string message = null)
		{
			if (comparer.Compare(first, second) > 0)
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsLessThanOrEqual, first, second));
		}
		#endregion

		#region String
		/// <inheritdoc />
		public void Contains(string str, string part, StringComparison stringComparison, string message = null)
		{
			if (str.IndexOf(part, stringComparison) < 0)
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.StringContains, str, part));
		}

		/// <inheritdoc />
		public void DoesNotContain(string str, string part, StringComparison stringComparison, string message = null)
		{
			if (str.IndexOf(part, stringComparison) >= 0)
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.StringDoesNotContain, str, part));
		}

		/// <inheritdoc />
		public void StartsWith(string str, string part, StringComparison stringComparison, string message = null)
		{
			if (!str.StartsWith(part, stringComparison))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.StartsWith, str, part));
		}

		/// <inheritdoc />
		public void DoesNotStartWith(string str, string part, StringComparison stringComparison, string message = null)
		{
			if (str.StartsWith(part, stringComparison))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.DoesNotStartWith, str, part));
		}

		/// <inheritdoc />
		public void EndsWith(string str, string part, StringComparison stringComparison, string message = null)
		{
			if (!str.EndsWith(part, stringComparison))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.EndsWith, str, part));
		}

		/// <inheritdoc />
		public void DoesNotEndWith(string str, string part, StringComparison stringComparison, string message = null)
		{
			if (str.EndsWith(part, stringComparison))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.DoesNotEndWith, str, part));
		}

		/// <inheritdoc />
		public void Matches(string str, Regex regex, string message = null)
		{
			if (!regex.IsMatch(str))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.Matches, str, regex));
		}

		/// <inheritdoc />
		public void DoesNotMatch(string str, Regex regex, string message = null)
		{
			if (regex.IsMatch(str))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.DoesNotMatch, str, regex));
		}
		#endregion

		#region Collections
		/// <inheritdoc />
		public void IsEmpty<T>(IEnumerable<T> enumerable, string message = null)
		{
			if (enumerable.Any())
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.EnumerableIsEmpty, enumerable));
		}

		/// <inheritdoc />
		public void IsNotEmpty<T>(IEnumerable<T> enumerable, string message = null)
		{
			if (!enumerable.Any())
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.EnumerableIsNotEmpty, enumerable));
		}

		/// <inheritdoc />
		public void Contains<T>(IEnumerable<T> enumerable, T value, IEqualityComparer<T> equalityComparer, string message = null)
		{
			if (!enumerable.Contains(value, equalityComparer))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.EnumerableContains, enumerable, value));
		}

		/// <inheritdoc />
		public void DoesNotContain<T>(IEnumerable<T> enumerable, T value, IEqualityComparer<T> equalityComparer, string message = null)
		{
			if (enumerable.Contains(value, equalityComparer))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.EnumerableDoesNotContain, enumerable, value));
		}
		#endregion

		#region Type Checking
		/// <inheritdoc />
		public void IsOfType(Type type, object obj, string message = null)
		{
			if (obj.GetType() != type)
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsOfType, obj, type, obj.GetType()));
		}

		/// <inheritdoc />
		public void IsNotOfType(Type type, object obj, string message = null)
		{
			if (obj.GetType() == type)
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsNotOfType, obj, type, obj.GetType()));
		}

		/// <inheritdoc />
		public void IsOfTypeAssignableFrom(Type type, object obj, string message = null)
		{
			if (!obj.GetType().IsAssignableFrom(type))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsOfTypeAssignableFrom, obj, type, obj.GetType()));
		}

		/// <inheritdoc />
		public void IsNotOfTypeAssignableFrom(Type type, object obj, string message = null)
		{
			if (obj.GetType().IsAssignableFrom(type))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsNotOfTypeAssignableFrom, obj, type, obj.GetType()));
		}

		/// <inheritdoc />
		public void IsOfTypeAssignableTo(Type type, object obj, string message = null)
		{
			if (!type.IsAssignableFrom(obj.GetType()))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsOfTypeAssignableTo, obj, type, obj.GetType()));
		}

		/// <inheritdoc />
		public void IsNotOfTypeAssignableTo(Type type, object obj, string message = null)
		{
			if (type.IsAssignableFrom(obj.GetType()))
				throw new AssertException(message ?? this.Format(DefaultAssertProviderMessages.IsNotOfTypeAssignableTo, obj, type, obj.GetType()));
		}

		#endregion

		#region Exception Throwing

		/// <inheritdoc />
		public void Throws<TException>(Action action, string message = null) where TException : Exception
		{
			try
			{
				action();
			}
			catch(TException)
			{
				return;
			}

			throw new AssertException(message ?? Resources.DefaultAssertProviderMessages.Throws);
		}

		/// <inheritdoc />
		public void DoesNotThrow<TException>(Action action, string message = null) where TException : Exception
		{
			try
			{
				action();
			}
			catch (TException ex)
			{
				throw new AssertException(message ?? Resources.DefaultAssertProviderMessages.Throws, ex);
			}
		}

		#endregion

		#region Private methods

		private string Format(string format, params object[] args)
		{
			return String.Format(CultureInfo.CurrentCulture, format, args.Select(a => a == null ? "(null)" : a).ToArray());
		}

		#endregion
	}
}
