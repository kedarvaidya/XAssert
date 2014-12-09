using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace XAssert.Tests
{
	public abstract class AssertProviderTestsBase
	{
		#region Sameness

		public static IEnumerable<object[]> AreSame_CorrectInput_Data
		{
			get 
			{
				object o = "1";
				object o2 = o;
				yield return new object[] { o, o2 };
			}
		}

		[Theory]
		[MemberData("AreSame_CorrectInput_Data")]
		public abstract void AreSame_CorrectInput(object left, object right);

		public static IEnumerable<object[]> AreSame_IncorrectInput_Data
		{
			get
			{
				object o = "1";
				object o2 = "2";
				yield return new object[] { o, o2 };
			}
		}

		[Theory]
		[MemberData("AreSame_IncorrectInput_Data")]
		public abstract void AreSame_IncorrectInput(object left, object right);

		public static IEnumerable<object[]> AreNotSame_CorrectInput_Data
		{
			get
			{
				return AreSame_IncorrectInput_Data;
			}
		}

		[Theory]
		[MemberData("AreNotSame_CorrectInput_Data")]
		public abstract void AreNotSame_CorrectInput(object left, object right);

		public static IEnumerable<object[]> AreNotSame_IncorrectInput_Data
		{
			get
			{
				return AreSame_CorrectInput_Data;
			}
		}

		[Theory]
		[MemberData("AreNotSame_IncorrectInput_Data")]
		public abstract void AreNotSame_IncorrectInput(object left, object right);

		#endregion

		#region Equality

		public static IEnumerable<object[]> AreEqual_CorrectInput_Data
		{
			get
			{
				yield return new object[] { "1", "1" };
			}
		}

		[Theory]
		[MemberData("AreEqual_CorrectInput_Data")]
		public abstract void AreEqual_CorrectInput(object left, object right);


		public static IEnumerable<object[]> AreEqual_IncorrectInput_Data
		{
			get
			{
				yield return new object[] { "1", "2" };
			}
		}

		[Theory]
		[MemberData("AreEqual_IncorrectInput_Data")]
		public abstract void AreEqual_IncorrectInput(object left, object right);

		public static IEnumerable<object[]> AreNotEqual_CorrectInput_Data
		{
			get
			{
				return AreEqual_IncorrectInput_Data;
			}
		}

		[Theory]
		[MemberData("AreNotEqual_CorrectInput_Data")]
		public abstract void AreNotEqual_CorrectInput(object left, object right);

		public static IEnumerable<object[]> AreNotEqual_IncorrectInput_Data
		{
			get
			{
				return AreEqual_CorrectInput_Data;
			}
		}

		[Theory]
		[MemberData("AreNotEqual_IncorrectInput_Data")]
		public abstract void AreNotEqual_IncorrectInput(object left, object right);

		#endregion

		#region Nulls and defaults

		[Theory]
		[InlineData(null)]
		public abstract void ObjectIsNull_CorrectInput(object obj);

		[Theory]
		[InlineData("1")]
		public abstract void ObjectIsNull_IncorrectInput(object obj);

		[Theory]
		[InlineData("1")]
		public abstract void ObjectIsNotNull_CorrectInput(object obj);

		[Theory]
		[InlineData(null)]
		public abstract void ObjectIsNotNull_IncorrectInput(object obj);

		[Theory]
		[InlineData(null)]
		public abstract void NullableValueIsNull_CorrectInput(int? obj);

		[Theory]
		[InlineData(1)]
		public abstract void NullableValueIsNull_IncorrectInput(int? obj);

		[Theory]
		[InlineData(1)]

		public abstract void NullableValueIsNotNull_CorrectInput(int? obj);

		[Theory]
		[InlineData(null)]
		public abstract void NullableValueIsNotNull_IncorrectInput(int? obj);

		[Theory]
		[InlineData(default(int))]
		public abstract void IsDefaultStruct_CorrectInput(int obj);

		[Theory]
		[InlineData(default(string))]
		public abstract void IsDefaultClass_CorrectInput(string obj);

		[Theory]
		[InlineData(1)]
		public abstract void IsDefaultStruct_IncorrectInput(int obj);

		[Theory]
		[InlineData("s")]
		public abstract void IsDefaultClass_IncorrectInput(string obj);

		[Theory]
		[InlineData(1)]
		public abstract void IsNotDefaultStruct_CorrectInput(int obj);

		[Theory]
		[InlineData("s")]
		public abstract void IsNotDefaultClass_CorrectInput(string obj);

		[Theory]
		[InlineData(default(int))]
		public abstract void IsNotDefaultStruct_IncorrectInput(int obj);

		[Theory]
		[InlineData(default(string))]
		public abstract void IsNotDefaultClass_IncorrectInput(string obj);

		#endregion

		#region Boolean

		[Theory]
		[InlineData(true)]
		public abstract void IsTrue_CorrectInput(bool value);

		[Theory]
		[InlineData(false)]
		public abstract void IsTrue_IncorrectInput(bool value);

		[Theory]
		[InlineData(false)]
		public abstract void IsFalse_CorrectInput(bool value);

		[Theory]
		[InlineData(true)]
		public abstract void IsFalse_IncorrectInput(bool value);

		#endregion

		#region Numbers

		[Theory]
		[InlineData(Double.NaN)]
		public abstract void IsNaN_CorrectInput(double value);

		[Theory]
		[InlineData(1.0)]
		public abstract void IsNaN_IncorrectInput(double value);

		[Theory]
		[InlineData(1.0)]
		public abstract void IsNotNaN_CorrectInput(double value);

		[Theory]
		[InlineData(Double.NaN)]
		public abstract void IsNotNaN_IncorrectInput(double value);

		[Theory]
		[InlineData(Double.PositiveInfinity)]
		public abstract void IsPositiveInfinity_CorrectInput(double value);

		[Theory]
		[InlineData(1.0)]
		public abstract void IsPositiveInfinity_IncorrectInput(double value);

		[Theory]
		[InlineData(1.0)]
		public abstract void IsNotPositiveInfinity_CorrectInput(double value);

		[Theory]
		[InlineData(Double.PositiveInfinity)]
		public abstract void IsNotPositiveInfinity_IncorrectInput(double value);

		[Theory]
		[InlineData(Double.NegativeInfinity)]
		public abstract void IsNegativeInfinity_CorrectInput(double value);

		[Theory]
		[InlineData(1.0)]
		public abstract void IsNegativeInfinity_IncorrectInput(double value);

		[Theory]
		[InlineData(1.0)]
		public abstract void IsNotNegativeInfinity_CorrectInput(double value);

		[Theory]
		[InlineData(Double.NegativeInfinity)]
		public abstract void IsNotNegativeInfinity_IncorrectInput(double value);

		#endregion

		#region Guids

		public static IEnumerable<object[]> GuidIsEmpty_CorrectInput_Data
		{
			get { yield return new object[] { Guid.Empty }; }
		}

		[Theory]
		[MemberData("GuidIsEmpty_CorrectInput_Data")]
		public abstract void GuidIsEmpty_CorrectInput(Guid value);

		public static IEnumerable<object[]> GuidIsEmpty_IncorrectInput_Data
		{
			get { yield return new object[] { Guid.Parse("{E2F741CD-5C2A-43B9-8437-D249CC9D5DA1}") }; }
		}

		[Theory]
		[MemberData("GuidIsEmpty_IncorrectInput_Data")]
		public abstract void GuidIsEmpty_IncorrectInput(Guid value);

		public static IEnumerable<object[]> GuidIsNotEmpty_CorrectInput_Data
		{
			get { return GuidIsEmpty_IncorrectInput_Data; }
		}

		[Theory]
		[MemberData("GuidIsNotEmpty_CorrectInput_Data")]
		public abstract void GuidIsNotEmpty_CorrectInput(Guid value);

		public static IEnumerable<object[]> GuidIsNotEmpty_IncorrectInput_Data
		{
			get { return GuidIsEmpty_CorrectInput_Data; }
		}

		[Theory]
		[MemberData("GuidIsNotEmpty_IncorrectInput_Data")]
		public abstract void GuidIsNotEmpty_IncorrectInput(Guid value);

		#endregion

		#region Comparison

		[Theory]
		[InlineData(2, 1)]
		public abstract void IsGreaterThan_CorrectInput(double left, double right);

		[Theory]
		[InlineData(1, 2)]
		[InlineData(2, 2)]
		public abstract void IsGreaterThan_IncorrectInput(double left, double right);

		[Theory]
		[InlineData(1, 2)]
		public abstract void IsLessThan_CorrectInput(double left, double right);

		[Theory]
		[InlineData(2, 1)]
		[InlineData(2, 2)]
		public abstract void IsLessThan_IncorrectInput(double left, double right);

		[Theory]
		[InlineData(2, 1)]
		[InlineData(2, 2)]
		public abstract void IsGreaterThanOrEqualTo_CorrectInput(double left, double right);

		[Theory]
		[InlineData(1, 2)]
		public abstract void IsGreaterThanOrEqualTo_IncorrectInput(double left, double right);

		[Theory]
		[InlineData(1, 2)]
		[InlineData(2, 2)]
		public abstract void IsLessThanOrEqualTo_CorrectInput(double left, double right);

		[Theory]
		[InlineData(2, 1)]
		public abstract void IsLessThanOrEqualTo_IncorrectInput(double left, double right);

		#endregion

		#region Strings

		[Theory]
		[InlineData("abcdabcef", "bcd", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "bcd", StringComparison.CurrentCultureIgnoreCase)]
		[InlineData("abcdabcef", "bcd", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "bcd", StringComparison.InvariantCultureIgnoreCase)]
		[InlineData("abcdabcef", "bcd", StringComparison.Ordinal)]
		[InlineData("abcdabcef", "bcd", StringComparison.OrdinalIgnoreCase)]
		public abstract void StringContains_CorrectInput(string str, string part, StringComparison comparison);

		[Theory]
		[InlineData("abcdabcef", "bcz", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "bcz", StringComparison.CurrentCultureIgnoreCase)]
		[InlineData("abcdabcef", "bcz", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "bcz", StringComparison.InvariantCultureIgnoreCase)]
		[InlineData("abcdabcef", "bcz", StringComparison.Ordinal)]
		[InlineData("abcdabcef", "bcz", StringComparison.OrdinalIgnoreCase)]
		[InlineData("abcdabcef", "bcD", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "bcD", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "bcD", StringComparison.Ordinal)]
		public abstract void StringContains_IncorrectInput(string str, string part, StringComparison comparison);

		[Theory]
		[InlineData("abcdabcef", "bcz", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "bcz", StringComparison.CurrentCultureIgnoreCase)]
		[InlineData("abcdabcef", "bcz", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "bcz", StringComparison.InvariantCultureIgnoreCase)]
		[InlineData("abcdabcef", "bcz", StringComparison.Ordinal)]
		[InlineData("abcdabcef", "bcz", StringComparison.OrdinalIgnoreCase)]
		[InlineData("abcdabcef", "bcD", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "bcD", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "bcD", StringComparison.Ordinal)]
		public abstract void StringDoesNotContain_CorrectInput(string str, string part, StringComparison comparison);

		[Theory]
		[InlineData("abcdabcef", "bcd", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "bcd", StringComparison.CurrentCultureIgnoreCase)]
		[InlineData("abcdabcef", "bcd", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "bcd", StringComparison.InvariantCultureIgnoreCase)]
		[InlineData("abcdabcef", "bcd", StringComparison.Ordinal)]
		[InlineData("abcdabcef", "bcd", StringComparison.OrdinalIgnoreCase)]
		public abstract void StringDoesNotContain_IncorrectInput(string str, string part, StringComparison comparison);

		[Theory]
		[InlineData("abcdabcef", "abcd", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "abcd", StringComparison.CurrentCultureIgnoreCase)]
		[InlineData("abcdabcef", "abcd", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "abcd", StringComparison.InvariantCultureIgnoreCase)]
		[InlineData("abcdabcef", "abcd", StringComparison.Ordinal)]
		[InlineData("abcdabcef", "abcd", StringComparison.OrdinalIgnoreCase)]
		public abstract void StringStartsWith_CorrectInput(string str, string part, StringComparison comparison);

		[Theory]
		[InlineData("abcdabcef", "abZ", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "abZ", StringComparison.CurrentCultureIgnoreCase)]
		[InlineData("abcdabcef", "abZ", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "abZ", StringComparison.InvariantCultureIgnoreCase)]
		[InlineData("abcdabcef", "abZ", StringComparison.Ordinal)]
		[InlineData("abcdabcef", "abZ", StringComparison.OrdinalIgnoreCase)]
		[InlineData("abcdabcef", "abC", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "abC", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "abC", StringComparison.Ordinal)]
		public abstract void StringStartsWith_IncorrectInput(string str, string part, StringComparison comparison);


		[Theory]
		[InlineData("abcdabcef", "abZ", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "abZ", StringComparison.CurrentCultureIgnoreCase)]
		[InlineData("abcdabcef", "abZ", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "abZ", StringComparison.InvariantCultureIgnoreCase)]
		[InlineData("abcdabcef", "abZ", StringComparison.Ordinal)]
		[InlineData("abcdabcef", "abZ", StringComparison.OrdinalIgnoreCase)]
		[InlineData("abcdabcef", "abC", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "abC", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "abC", StringComparison.Ordinal)]

		public abstract void StringDoesNotStartWith_CorrectInput(string str, string part, StringComparison comparison);

		[Theory]
		[InlineData("abcdabcef", "abcd", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "abcd", StringComparison.CurrentCultureIgnoreCase)]
		[InlineData("abcdabcef", "abcd", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "abcd", StringComparison.InvariantCultureIgnoreCase)]
		[InlineData("abcdabcef", "abcd", StringComparison.Ordinal)]
		[InlineData("abcdabcef", "abcd", StringComparison.OrdinalIgnoreCase)]
		public abstract void StringDoesNotStartWith_IncorrectInput(string str, string part, StringComparison comparison);

		[Theory]
		[InlineData("abcdabcef", "ef", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "ef", StringComparison.CurrentCultureIgnoreCase)]
		[InlineData("abcdabcef", "ef", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "ef", StringComparison.InvariantCultureIgnoreCase)]
		[InlineData("abcdabcef", "ef", StringComparison.Ordinal)]
		[InlineData("abcdabcef", "ef", StringComparison.OrdinalIgnoreCase)]
		public abstract void StringEndsWith_CorrectInput(string str, string part, StringComparison comparison);

		[Theory]
		[InlineData("abcdabcef", "fg", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "fg", StringComparison.CurrentCultureIgnoreCase)]
		[InlineData("abcdabcef", "fg", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "fg", StringComparison.InvariantCultureIgnoreCase)]
		[InlineData("abcdabcef", "fg", StringComparison.Ordinal)]
		[InlineData("abcdabcef", "fg", StringComparison.OrdinalIgnoreCase)]
		[InlineData("abcdabcef", "Ef", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "Ef", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "Ef", StringComparison.Ordinal)]
		public abstract void StringEndsWith_IncorrectInput(string str, string part, StringComparison comparison);

		[Theory]
		[InlineData("abcdabcef", "fg", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "fg", StringComparison.CurrentCultureIgnoreCase)]
		[InlineData("abcdabcef", "fg", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "fg", StringComparison.InvariantCultureIgnoreCase)]
		[InlineData("abcdabcef", "fg", StringComparison.Ordinal)]
		[InlineData("abcdabcef", "fg", StringComparison.OrdinalIgnoreCase)]
		[InlineData("abcdabcef", "Ef", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "Ef", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "Ef", StringComparison.Ordinal)]
		public abstract void StringDoesNotEndWith_CorrectInput(string str, string part, StringComparison comparison);

		[Theory]
		[InlineData("abcdabcef", "ef", StringComparison.CurrentCulture)]
		[InlineData("abcdabcef", "ef", StringComparison.CurrentCultureIgnoreCase)]
		[InlineData("abcdabcef", "ef", StringComparison.InvariantCulture)]
		[InlineData("abcdabcef", "ef", StringComparison.InvariantCultureIgnoreCase)]
		[InlineData("abcdabcef", "ef", StringComparison.Ordinal)]
		[InlineData("abcdabcef", "ef", StringComparison.OrdinalIgnoreCase)]
		public abstract void StringDoesNotEndWith_IncorrectInput(string str, string part, StringComparison comparison);

		[Theory]
		[InlineData("23.45", @"\d+", RegexOptions.None)]
		[InlineData("abc def", @"de", RegexOptions.None)]
		[InlineData("abc def", @"De", RegexOptions.IgnoreCase)]
		public abstract void StringMatches_CorrectInput(string str, string pattern, RegexOptions options);

		[Theory]
		[InlineData("23.45", @"\[A-Z]+", RegexOptions.None)]
		[InlineData("abc def", @"d e", RegexOptions.None)]
		[InlineData("abc def", @"De", RegexOptions.None)]
		public abstract void StringMatches_IncorrectInput(string str, string pattern, RegexOptions options);

		[Theory]
		[InlineData("23.45", @"\[A-Z]+", RegexOptions.None)]
		[InlineData("abc def", @"d e", RegexOptions.None)]
		[InlineData("abc def", @"De", RegexOptions.None)]
		public abstract void StringDoesNotMatch_CorrectInput(string str, string pattern, RegexOptions options);

		[Theory]
		[InlineData("23.45", @"\d+", RegexOptions.None)]
		[InlineData("abc def", @"de", RegexOptions.None)]
		[InlineData("abc def", @"De", RegexOptions.IgnoreCase)]
		public abstract void StringDoesNotMatch_IncorrectInput(string str, string pattern, RegexOptions options);

		#endregion

		#region Collections

		[Theory]
		[InlineData(new int[0])]
		public abstract void CollectionIsEmpty_CorrectInput(int[] enumerable);

		[Theory]
		[InlineData(new int[] { 1, 2, 3, 4, 5 })]
		public abstract void CollectionIsEmpty_IncorrectInput(int[] enumerable);

		[Theory]
		[InlineData(new int[] { 1, 2, 3, 4, 5 })]
		public abstract void CollectionIsNotEmpty_CorrectInput(int[] enumerable);

		[Theory]
		[InlineData(new int[0])]
		public abstract void CollectionIsNotEmpty_IncorrectInput(int[] enumerable);

		[Theory]
		[InlineData(new int[] { 1, 2, 3, 4, 5 }, 1)]
		public abstract void CollectionContains_CorrectInput(int[] enumerable, int i);

		[Theory]
		[InlineData(new int[] { 1, 2, 3, 4, 5 }, 11)]
		public abstract void CollectionContains_IncorrectInput(int[] enumerable, int i);

		[Theory]
		[InlineData(new int[] { 1, 2, 3, 4, 5 }, 11)]
		public abstract void CollectionDoesNotContain_CorrectInput(int[] enumerable, int i);

		[Theory]
		[InlineData(new int[] { 1, 2, 3, 4, 5 }, 1)]
		public abstract void CollectionDoesNotContain_IncorrectInput(int[] enumerable, int i);

		#endregion

		#region Types

		[Theory]
		[InlineData(typeof(int), 1)]
		public abstract void IsOfType_CorrectInput(Type type, object obj);

		[Theory]
		[InlineData(typeof(object), 1.0)]
		[InlineData(typeof(int), 1.0)]
		public abstract void IsOfType_IncorrectInput(Type type, object obj);

		[Theory]
		[InlineData(typeof(object), 1.0)]
		[InlineData(typeof(int), 1.0)]
		public abstract void IsOfNotType_CorrectInput(Type type, object obj);

		[Theory]
		[InlineData(typeof(int), 1)]
		public abstract void IsOfNotType_IncorrectInput(Type type, object obj);

		public static IEnumerable<object[]> IsOfTypeAssignableFrom_CorrectInput_Data
		{
			get
			{
				yield return new object[] { typeof(TestHelper.Base), new TestHelper.Base() };
				yield return new object[] { typeof(TestHelper.Derived), new TestHelper.Base() };
				yield return new object[] { typeof(TestHelper.Base), new object() };
			}
		}

		[Theory]
		[MemberData("IsOfTypeAssignableFrom_CorrectInput_Data")]
		public abstract void IsOfTypeAssignableFrom_CorrectInput(Type type, object obj);

		public static IEnumerable<object[]> IsOfTypeAssignableFrom_IncorrectInput_Data
		{
			get
			{
				yield return new object[] { typeof(TestHelper.Base), new TestHelper.Derived() };
				yield return new object[] { typeof(object), new TestHelper.Base() };
			}
		}

		[Theory]
		[MemberData("IsOfTypeAssignableFrom_IncorrectInput_Data")]
		public abstract void IsOfTypeAssignableFrom_IncorrectInput(Type type, object obj);

		public static IEnumerable<object[]> IsNotOfTypeAssignableFrom_CorrectInput_Data
		{
			get
			{
				return IsOfTypeAssignableFrom_IncorrectInput_Data;
			}
		}

		[Theory]
		[MemberData("IsNotOfTypeAssignableFrom_CorrectInput_Data")]
		public abstract void IsNotOfTypeAssignableFrom_CorrectInput(Type type, object obj);

		public static IEnumerable<object[]> IsNotOfTypeAssignableFrom_IncorrectInput_Data
		{
			get
			{
				return IsOfTypeAssignableFrom_CorrectInput_Data;
			}
		}

		[Theory]
		[MemberData("IsNotOfTypeAssignableFrom_IncorrectInput_Data")]
		public abstract void IsNotOfTypeAssignableFrom_IncorrectInput(Type type, object obj);
		public static IEnumerable<object[]> IsOfTypeAssignableTo_CorrectInput_Data
		{
			get
			{
				yield return new object[] { typeof(TestHelper.Base), new TestHelper.Base() };
				yield return new object[] { typeof(TestHelper.Base), new TestHelper.Derived() };
				yield return new object[] { typeof(object), new TestHelper.Base() };
			}
		}

		[Theory]
		[MemberData("IsOfTypeAssignableTo_CorrectInput_Data")]
		public abstract void IsOfTypeAssignableTo_CorrectInput(Type type, object obj);

		public static IEnumerable<object[]> IsOfTypeAssignableTo_IncorrectInput_Data
		{
			get
			{
				yield return new object[] { typeof(TestHelper.Derived), new TestHelper.Base() };
				yield return new object[] { typeof(TestHelper.Base), new object() };
			}
		}

		[Theory]
		[MemberData("IsOfTypeAssignableTo_IncorrectInput_Data")]
		public abstract void IsOfTypeAssignableTo_IncorrectInput(Type type, object obj);

		public static IEnumerable<object[]> IsNotOfTypeAssignableTo_CorrectInput_Data
		{
			get
			{
				return IsOfTypeAssignableTo_IncorrectInput_Data;
			}
		}

		[Theory]
		[MemberData("IsNotOfTypeAssignableTo_CorrectInput_Data")]
		public abstract void IsNotOfTypeAssignableTo_CorrectInput(Type type, object obj);

		public static IEnumerable<object[]> IsNotOfTypeAssignableTo_IncorrectInput_Data
		{
			get
			{
				return IsOfTypeAssignableTo_CorrectInput_Data;
			}
		}

		[Theory]
		[MemberData("IsNotOfTypeAssignableTo_IncorrectInput_Data")]
		public abstract void IsNotOfTypeAssignableTo_IncorrectInput(Type type, object obj);

		#endregion

		#region Exceptions

		public static IEnumerable<object[]> Throws_CorrectInput_Data
		{
			get
			{
				Action action = () =>
				{
					var zero = 0;
					var dbz = 1 / zero;
				};
				yield return new object[] { action };
			}
		}

		[Theory]
		[MemberData("Throws_CorrectInput_Data")]
		public abstract void Throws_CorrectInput(Action action);

		public static IEnumerable<object[]> Throws_IncorrectInput_Data
		{
			get
			{
				Action action = () =>
				{
				};
				yield return new object[] { action };
			}
		}

		[Theory]
		[MemberData("Throws_IncorrectInput_Data")]
		public abstract void Throws_IncorrectInput(Action action);

		public static IEnumerable<object[]> DoesNotThrow_CorrectInput_Data
		{
			get
			{
				return Throws_IncorrectInput_Data;
			}
		}

		[Theory]
		[MemberData("DoesNotThrow_CorrectInput_Data")]
		public abstract void DoesNotThrow_CorrectInput(Action action);

		public static IEnumerable<object[]> DoesNotThrow_IncorrectInput_Data
		{
			get
			{
				return Throws_CorrectInput_Data;
			}
		}

		[Theory]
		[MemberData("DoesNotThrow_IncorrectInput_Data")]
		public abstract void DoesNotThrow_IncorrectInput(Action action);

		#endregion
	}
}
