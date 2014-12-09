using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace XAssert
{
	public interface IAssertProvider
	{
		#region Sameness
		/// <summary>
		/// Asserts that two objects are the same instance
		/// </summary>
		/// <typeparam name="T">The type of the objects to be compared</typeparam>
		/// <param name="first">The first object to be checked</param>
		/// <param name="second">The second object to be checked</param>
		/// <param name="message">The message to show on failure</param>
		/// <remarks>
		/// Even if two objects are equal, they might not be same
		/// </remarks>
		void AreSame<T>(T first, T second, string message) where T : class;

		/// <summary>
		/// Asserts that two objects are not the same instance
		/// </summary>
		/// <typeparam name="T">The type of the objects to be compared</typeparam>
		/// <param name="first">The first object to be checked</param>
		/// <param name="second">The second object to be checked</param>
		/// <param name="message">The message to show on failure</param>
		/// <remarks>
		/// Even if two objects are equal, they might not be same
		/// </remarks>
		void AreNotSame<T>(T first, T second, string message) where T : class;
		#endregion

		#region Equality
		/// <summary>
		/// Asserts that two objects are equal using a custom equality comparer
		/// </summary>
		/// <typeparam name="T">The type of the objects to be compared</typeparam>
		/// <param name="first">The first object to be checked</param>
		/// <param name="second">The second object to be checked</param>
		/// <param name="equalityComparer">The custom comparer</param>
		/// <param name="message">The message to show on failure</param>
		void AreEqual<T>(T first, T second, IEqualityComparer<T> equalityComparer, string message);

		/// <summary>
		/// Asserts that two objects are not equal using a custom equality comparer
		/// </summary>
		/// <typeparam name="T">The type of the objects to be compared</typeparam>
		/// <param name="first">The first object to be checked</param>
		/// <param name="second">The second object to be checked</param>
		/// <param name="equalityComparer">The custom comparer</param>
		/// <param name="message">The message to show on failure</param>
		void AreNotEqual<T>(T first, T second, IEqualityComparer<T> equalityComparer, string message);

		#endregion

		#region Nulls and defaults
		/// <summary>
		/// Asserts that object is null
		/// </summary>
		/// <typeparam name="T">The type of object to be checked</typeparam>
		/// <param name="obj">The object to be checked</param>
		/// <param name="message">The message to show on failure</param>
		void IsNull<T>(T obj, string message) where T : class;

		/// <summary>
		/// Asserts that object is not null
		/// </summary>
		/// <typeparam name="T">The type of object to be checked</typeparam>
		/// <param name="obj">The object to be checked</param>
		/// <param name="message">The message to show on failure</param>
		void IsNotNull<T>(T obj, string message) where T : class;

		/// <summary>
		/// Asserts that Nullable of value is null
		/// </summary>
		/// <typeparam name="T">The type of value to be checked</typeparam>
		/// <param name="value">Nullable of value to be checked</param>
		/// <param name="message">The message to show on failure</param>
		void IsNull<T>(Nullable<T> value, string message) where T : struct;

		/// <summary>
		/// Asserts that Nullable of value is not null
		/// </summary>
		/// <typeparam name="T">The type of value to be checked</typeparam>
		/// <param name="value">Nullable of value to be checked</param>
		/// <param name="message">The message to show on failure</param>
		void IsNotNull<T>(Nullable<T> value, string message) where T : struct;

		/// <summary>
		/// Asserts that object has default value
		/// </summary>
		/// <typeparam name="T">The type of object to be checked</typeparam>
		/// <param name="obj">The object to be checked</param>
		/// <param name="message">The message to show on failure</param>
		void IsDefault<T>(T obj, string message);

		/// <summary>
		/// Asserts that object does not have default value
		/// </summary>
		/// <typeparam name="T">The type of object to be checked</typeparam>
		/// <param name="obj">The object to be checked</param>
		/// <param name="message">The message to show on failure</param>
		void IsNotDefault<T>(T obj, string message);
		#endregion

		#region Boolean
		/// <summary>
		/// Assert that boolean value is true
		/// </summary>
		/// <param name="value">The object to be checked</param>
		/// <param name="message">The message to show on failure</param>
		void IsTrue(bool value, string message);

		/// <summary>
		/// Assert that boolean value is false
		/// </summary>
		/// <param name="value">The object to be checked</param>
		/// <param name="message">The message to show on failure</param>
		void IsFalse(bool value, string message);
		#endregion

		#region Numbers
		/// <summary>
		/// Asserts that value is NaN
		/// </summary>
		/// <param name="value">The value to check</param>
		/// <param name="message">The message to show on failure</param>
		void IsNaN(double value, string message);

		/// <summary>
		/// Asserts that value is not NaN
		/// </summary>
		/// <param name="value">The value to check</param>
		/// <param name="message">The message to show on failure</param>
		void IsNotNaN(double value, string message);

		/// <summary>
		/// Asserts that value is Positive Infinity
		/// </summary>
		/// <param name="value">The value to check</param>
		/// <param name="message">The message to show on failure</param>
		void IsPositiveInfinity(double value, string message);

		/// <summary>
		/// Asserts that value is not Positive Infinity
		/// </summary>
		/// <param name="value">The value to check</param>
		/// <param name="message">The message to show on failure</param>
		void IsNotPositiveInfinity(double value, string message);

		/// <summary>
		/// Asserts that value is Negative Infinity
		/// </summary>
		/// <param name="value">The value to check</param>
		/// <param name="message">The message to show on failure</param>
		void IsNegativeInfinity(double value, string message);

		/// <summary>
		/// Asserts that value is not Negative Infinity
		/// </summary>
		/// <param name="value">The value to check</param>
		/// <param name="message">The message to show on failure</param>
		void IsNotNegativeInfinity(double value, string message);
		#endregion

		#region Guids
		/// <summary>
		/// Asserts that value is empty
		/// </summary>
		/// <param name="value">The guid to be checked</param>
		/// <param name="message">The message to show on failure</param>
		void IsEmpty(Guid value, string message);

		/// <summary>
		/// Asserts that value is not empty
		/// </summary>
		/// <param name="value">The guid to be checked</param>
		/// <param name="message">The message to show on failure</param>
		void IsNotEmpty(Guid value, string message);
		#endregion

		#region Comparison
		/// <summary>
		/// Assert that object is greater than a minimum value using a custom comparer
		/// </summary>
		/// <typeparam name="T">The type of object to be compared</typeparam>
		/// <param name="first">The object to be compared</param>
		/// <param name="second">The minimum value</param>
		/// <param name="comparer">The custom comparer</param>
		/// <param name="message">The message to show on failure</param>
		void IsGreaterThan<T>(T first, T second, IComparer<T> comparer, string message);

		/// <summary>
		/// Assert that object is less than a maximum value using a custom comparer
		/// </summary>
		/// <typeparam name="T">The type of object to be comparer</typeparam>
		/// <param name="first">The object to be compared</param>
		/// <param name="second">The maximum value</param>
		/// <param name="comparer">The custom comparer</param>
		/// <param name="message">The message to show on failure</param>
		void IsLessThan<T>(T first, T second, IComparer<T> comparer, string message);

		/// <summary>
		/// Assert that object is greater than or equal a minimum value using a custom comparer
		/// </summary>
		/// <typeparam name="T">The type of object to be compared</typeparam>
		/// <param name="first">The object to be compared</param>
		/// <param name="second">The minimum value</param>
		/// <param name="comparer">The custom comparer</param>
		/// <param name="message">The message to show on failure</param>
		void IsGreaterThanOrEqual<T>(T first, T second, IComparer<T> comparer, string message);

		/// <summary>
		/// Assert that object is less than or equal to a maximum value using a custom comparer
		/// </summary>
		/// <typeparam name="T">The type of object to be compared</typeparam>
		/// <param name="first">The object to be compared</param>
		/// <param name="second">The maximum value</param>
		/// <param name="comparer">The custom comparer</param>
		/// <param name="message">The message to show on failure</param>
		void IsLessThanOrEqual<T>(T first, T second, IComparer<T> comparer, string message);
		#endregion

		#region Strings
		/// <summary>
		/// Asserts that a string contains a sub-string using a comparison type
		/// </summary>
		/// <param name="str">The string to be checked</param>
		/// <param name="part">The sub-string to checked</param>
		/// <param name="stringComparison">The comparison type</param>
		/// <param name="message">The message to show on failure</param>
		void Contains(string str, string part, StringComparison stringComparison, string message);

		/// <summary>
		/// Asserts that a string does not contain a sub-string using a comparison type
		/// </summary>
		/// <param name="str">The string to be checked</param>
		/// <param name="part">The sub-string to checked</param>
		/// <param name="stringComparison">The comparison type</param>
		/// <param name="message">The message to show on failure</param>
		void DoesNotContain(string str, string part, StringComparison stringComparison, string message);

		/// <summary>
		/// Asserts that a string starts with a sub-string using a comparison type
		/// </summary>
		/// <param name="str">The string to be checked</param>
		/// <param name="part">The sub-string to checked</param>
		/// <param name="stringComparison">The comparison type</param>
		/// <param name="message">The message to show on failure</param>
		void StartsWith(string str, string part, StringComparison stringComparison, string message);

		/// <summary>
		/// Asserts that a string does not start with a sub-string using a comparison type
		/// </summary>
		/// <param name="str">The string to be checked</param>
		/// <param name="part">The sub-string to checked</param>
		/// <param name="stringComparison">The comparison type</param>
		/// <param name="message">The message to show on failure</param>
		void DoesNotStartWith(string str, string part, StringComparison stringComparison, string message);

		/// <summary>
		/// Asserts that a string ends with a sub-string using a comparison type
		/// </summary>
		/// <param name="str">The string to be checked</param>
		/// <param name="part">The sub-string to checked</param>
		/// <param name="stringComparison">The comparison type</param>
		/// <param name="message">The message to show on failure</param>
		void EndsWith(string str, string part, StringComparison stringComparison, string message);

		/// <summary>
		/// Asserts that a string does not end with a sub-string using a comparison type
		/// </summary>
		/// <param name="str">The string to be checked</param>
		/// <param name="part">The sub-string to checked</param>
		/// <param name="stringComparison">The comparison type</param>
		/// <param name="message">The message to show on failure</param>
		void DoesNotEndWith(string str, string part, StringComparison stringComparison, string message);

		/// <summary>
		/// Asserts that a string matches a regex
		/// </summary>
		/// <param name="str">The string to be checked</param>
		/// <param name="regex">The regex to checked</param>
		/// <param name="message">The message to show on failure</param>
		void Matches(string str, Regex regex, string message);

		/// <summary>
		/// Asserts that a string does not match a regex
		/// </summary>
		/// <param name="str">The string to be checked</param>
		/// <param name="regex">The regex to checked</param>
		/// <param name="message">The message to show on failure</param>
		void DoesNotMatch(string str, Regex regex, string message);
		#endregion

		#region Collections
		/// <summary>
		/// Asserts that a collection is empty
		/// </summary>
		/// <typeparam name="T">The type of items of collection</typeparam>
		/// <param name="enumerable">The collection to be checked</param>
		/// <param name="item">The item to be checked</param>
		/// <param name="message">The message to show on failure</param>
		void IsEmpty<T>(IEnumerable<T> enumerable, string message);

		/// <summary>
		/// Asserts that a collection is not empty
		/// </summary>
		/// <typeparam name="T">The type of items of collection</typeparam>
		/// <param name="enumerable">The collection to be checked</param>
		/// <param name="item">The item to be checked</param>
		/// <param name="message">The message to show on failure</param>
		void IsNotEmpty<T>(IEnumerable<T> enumerable, string message);

		/// <summary>
		/// Asserts that collection contains an item using a custom equality comparer
		/// </summary>
		/// <typeparam name="T">The type of items of collection/typeparam>
		/// <param name="enumerable">The collection to be checked</param>
		/// <param name="item">The item to be checked</param>
		/// <param name="comparer">The custom equality</param>
		/// <param name="message">The message to show on failure</param>
		void Contains<T>(IEnumerable<T> enumerable, T item, IEqualityComparer<T> equalityComparer, string message);

		/// <summary>
		/// Asserts that collection does not contain an item using a custom equality comparer
		/// </summary>
		/// <typeparam name="T">The type of items of collection/typeparam>
		/// <param name="enumerable">The collection to be checked</param>
		/// <param name="item">The item to be checked</param>
		/// <param name="comparer">The custom equality comparer</param>
		/// <param name="message">The message to show on failure</param>
		void DoesNotContain<T>(IEnumerable<T> enumerable, T item, IEqualityComparer<T> equalityComparer, string message);
		#endregion

		#region Type Checking
		/// <summary>
		/// Asserts whether object is exactly of specified type
		/// </summary>
		/// <param name="type">The specified type</param>
		/// <param name="obj">The object to be checked</param>
		/// <param name="message">The message to show on failure</param>
		/// <remarks>This fails even if object is instance of subtype of specified type</remarks>
		void IsOfType(Type type, object obj, string message);

		/// <summary>
		/// Asserts whether object is exactly not of specified type
		/// </summary>
		/// <param name="type">The specified type</param>
		/// <param name="obj">The object to be checked</param>
		/// <param name="message">The message to show on failure</param>
		/// <remarks>This succeeds even if object is instance of subtype of specified type</remarks>
		void IsNotOfType(Type type, object obj, string message);

		/// <summary>
		/// Asserts whether object can be assigned from instance of specified type
		/// </summary>
		/// <param name="type">The specified type</param>
		/// <param name="obj">The object to be checked</param>
		void IsOfTypeAssignableFrom(Type type, object obj, string message);

		/// <summary>
		/// Asserts whether object cannot be assigned from instance of specified type
		/// </summary>
		/// <param name="type">The specified type</param>
		/// <param name="obj">The object to be checked</param>
		void IsNotOfTypeAssignableFrom(Type type, object obj, string message);

		/// <summary>
		/// Asserts whether object can be assigned to instance of specified type
		/// </summary>
		/// <param name="type">The specified type</param>
		/// <param name="obj">The object to be checked</param>
		void IsOfTypeAssignableTo(Type type, object obj, string message);

		/// <summary>
		/// Asserts whether object cannot be assigned to instance of specified type
		/// </summary>
		/// <param name="type">The specified type</param>
		/// <param name="obj">The object to be checked</param>
		void IsNotOfTypeAssignableTo(Type type, object obj, string message);


		#endregion

		#region Exception Throwing

		/// <summary>
		/// Asserts whether the execution of code throws exception of specified type
		/// </summary>
		/// <typeparam name="TException">The specified exception type</typeparam>
		/// <param name="action">The code to be executed</param>
		/// <param name="message">The message to show on failure</param
		void Throws<TException>(Action action, string message) where TException : Exception;

		/// <summary>
		/// Asserts whether the execution of code does not throw exception of specified type
		/// </summary>
		/// <typeparam name="TException">The specified exception type</typeparam>
		/// <param name="action">The code to be executed</param>
		/// <param name="message">The message to show on failure</param
		void DoesNotThrow<TException>(Action action, string message) where TException : Exception;

		#endregion
	}
}
