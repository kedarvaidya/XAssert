using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XAssert;

namespace XAssert.Tests
{
	public class DefaultAssertProviderTests : AssertProviderTestsBase
	{
		private DefaultAssertProvider assertProvider;

		public DefaultAssertProviderTests()
		{
			assertProvider = new DefaultAssertProvider();
		}

		#region Sameness
		public override void AreSame_CorrectInput(object o, object o2)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.AreSame(o, o2));
		}

		public override void AreSame_IncorrectInput(object o, object o2)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.AreSame(o, o2));
		}

		public override void AreNotSame_CorrectInput(object o, object o2)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.AreNotSame(o, o2));
		}

		public override void AreNotSame_IncorrectInput(object o, object o2)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.AreNotSame(o, o2));
		}
		#endregion

		#region Equality
		public override void AreEqual_CorrectInput(object o, object o2)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.AreEqual(o, o2, EqualityComparer<object>.Default));
		}

		public override void AreEqual_IncorrectInput(object o, object o2)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.AreEqual(o, o2, EqualityComparer<object>.Default));
		}

		public override void AreNotEqual_CorrectInput(object o, object o2)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.AreNotEqual(o, o2, EqualityComparer<object>.Default));
		}

		public override void AreNotEqual_IncorrectInput(object o, object o2)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.AreNotEqual(o, o2, EqualityComparer<object>.Default));
		}
		#endregion

		#region Null and defaults

		public override void ObjectIsNull_CorrectInput(object o)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsNull(o));
		}

		public override void ObjectIsNull_IncorrectInput(object o)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsNull(o));
		}

		public override void ObjectIsNotNull_CorrectInput(object o)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsNotNull(o));
		}

		public override void ObjectIsNotNull_IncorrectInput(object o)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsNotNull(o));
		}

		public override void NullableValueIsNull_CorrectInput(int? i)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsNull(i));
		}

		public override void NullableValueIsNull_IncorrectInput(int? i)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsNull(i));
		}

		public override void NullableValueIsNotNull_CorrectInput(int? i)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsNotNull(i));
		}
		public override void NullableValueIsNotNull_IncorrectInput(int? i)
		{

			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsNotNull(i));
		}

		public override void IsDefaultStruct_CorrectInput(int i)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsDefault(i));
		}

		public override void IsDefaultClass_CorrectInput(string s)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsDefault(s));
		}

		public override void IsDefaultStruct_IncorrectInput(int i)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsDefault(i));
		}

		public override void IsDefaultClass_IncorrectInput(string s)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsDefault(s));
		}

		public override void IsNotDefaultStruct_CorrectInput(int i)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsNotDefault(i));
		}

		public override void IsNotDefaultClass_CorrectInput(string s)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsNotDefault(s));
		}

		public override void IsNotDefaultStruct_IncorrectInput(int i)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsNotDefault(i));
		}

		public override void IsNotDefaultClass_IncorrectInput(string s)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsNotDefault(s));
		}

		#endregion

		#region Booleans

		public override void IsTrue_CorrectInput(bool b)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsTrue(b));
		}

		public override void IsTrue_IncorrectInput(bool b)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsTrue(b));
		}

		public override void IsFalse_CorrectInput(bool b)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsFalse(b));
		}

		public override void IsFalse_IncorrectInput(bool b)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsFalse(b));
		}

		#endregion

		#region Numbers

		public override void IsNaN_CorrectInput(double b)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsNaN(b));
		}

		public override void IsNaN_IncorrectInput(double b)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsNaN(b));
		}

		public override void IsNotNaN_CorrectInput(double b)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsNotNaN(b));
		}

		public override void IsNotNaN_IncorrectInput(double b)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsNotNaN(b));
		}

		public override void IsPositiveInfinity_CorrectInput(double b)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsPositiveInfinity(b));
		}

		public override void IsPositiveInfinity_IncorrectInput(double b)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsPositiveInfinity(b));
		}

		public override void IsNotPositiveInfinity_CorrectInput(double b)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsNotPositiveInfinity(b));
		}

		public override void IsNotPositiveInfinity_IncorrectInput(double b)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsNotPositiveInfinity(b));
		}

		public override void IsNegativeInfinity_CorrectInput(double b)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsNegativeInfinity(b));
		}

		public override void IsNegativeInfinity_IncorrectInput(double b)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsNegativeInfinity(b));
		}

		public override void IsNotNegativeInfinity_CorrectInput(double b)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsNotNegativeInfinity(b));
		}

		public override void IsNotNegativeInfinity_IncorrectInput(double b)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsNotNegativeInfinity(b));
		}

		#endregion

		#region Guids
		public override void GuidIsEmpty_CorrectInput(Guid g)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsEmpty(g));
		}

		public override void GuidIsEmpty_IncorrectInput(Guid g)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsEmpty(g));
		}

		public override void GuidIsNotEmpty_CorrectInput(Guid g)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsNotEmpty(g));
		}

		public override void GuidIsNotEmpty_IncorrectInput(Guid g)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsNotEmpty(g));
		}

		#endregion

		#region Comparison

		public override void IsGreaterThan_CorrectInput(double d1, double d2)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsGreaterThan(d1, d2, Comparer<double>.Default));
		}

		public override void IsGreaterThan_IncorrectInput(double d1, double d2)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsGreaterThan(d1, d2, Comparer<double>.Default));
		}

		public override void IsLessThan_CorrectInput(double d1, double d2)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsLessThan(d1, d2, Comparer<double>.Default));
		}

		public override void IsLessThan_IncorrectInput(double d1, double d2)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsLessThan(d1, d2, Comparer<double>.Default));
		}

		public override void IsGreaterThanOrEqualTo_CorrectInput(double d1, double d2)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsGreaterThanOrEqual(d1, d2, Comparer<double>.Default));
		}

		public override void IsGreaterThanOrEqualTo_IncorrectInput(double d1, double d2)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsGreaterThanOrEqual(d1, d2, Comparer<double>.Default));
		}

		public override void IsLessThanOrEqualTo_CorrectInput(double d1, double d2)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsLessThanOrEqual(d1, d2, Comparer<double>.Default));
		}

		public override void IsLessThanOrEqualTo_IncorrectInput(double d1, double d2)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsLessThanOrEqual(d1, d2, Comparer<double>.Default));
		}

		#endregion

		#region Strings

		public override void StringContains_CorrectInput(string s, string p, StringComparison c)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.Contains(s, p, c));
		}

		public override void StringContains_IncorrectInput(string s, string p, StringComparison c)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.Contains(s, p, c));
		}

		public override void StringDoesNotContain_CorrectInput(string s, string p, StringComparison c)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.DoesNotContain(s, p, c));
		}

		public override void StringDoesNotContain_IncorrectInput(string s, string p, StringComparison c)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.DoesNotContain(s, p, c));
		}

		public override void StringStartsWith_CorrectInput(string s, string p, StringComparison c)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.StartsWith(s, p, c));
		}

		public override void StringStartsWith_IncorrectInput(string s, string p, StringComparison c)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.StartsWith(s, p, c));
		}

		public override void StringDoesNotStartWith_CorrectInput(string s, string p, StringComparison c)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.DoesNotStartWith(s, p, c));
		}

		public override void StringDoesNotStartWith_IncorrectInput(string s, string p, StringComparison c)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.DoesNotStartWith(s, p, c));
		}

		public override void StringEndsWith_CorrectInput(string s, string p, StringComparison c)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.EndsWith(s, p, c));
		}

		public override void StringEndsWith_IncorrectInput(string s, string p, StringComparison c)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.EndsWith(s, p, c));
		}

		public override void StringDoesNotEndWith_CorrectInput(string s, string p, StringComparison c)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.DoesNotEndWith(s, p, c));
		}

		public override void StringDoesNotEndWith_IncorrectInput(string s, string p, StringComparison c)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.DoesNotEndWith(s, p, c));
		}

		public override void StringMatches_CorrectInput(string s, string p, RegexOptions o)
		{
			Regex r = new Regex(p, o);
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.Matches(s, r));
		}

		public override void StringMatches_IncorrectInput(string s, string p, RegexOptions o)
		{
			Regex r = new Regex(p, o);
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.Matches(s, r));
		}

		public override void StringDoesNotMatch_CorrectInput(string s, string p, RegexOptions o)
		{
			Regex r = new Regex(p, o);
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.DoesNotMatch(s, r));
		}

		public override void StringDoesNotMatch_IncorrectInput(string s, string p, RegexOptions o)
		{
			Regex r = new Regex(p, o);
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.DoesNotMatch(s, r));
		}

		#endregion

		#region Collections

		public override void CollectionIsEmpty_CorrectInput(int[] c)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsEmpty(c));
		}

		public override void CollectionIsEmpty_IncorrectInput(int[] c)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsEmpty(c));
		}

		public override void CollectionIsNotEmpty_CorrectInput(int[] c)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsNotEmpty(c));
		}

		public override void CollectionIsNotEmpty_IncorrectInput(int[] c)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsNotEmpty(c));
		}

		public override void CollectionContains_CorrectInput(int[] c, int i)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.Contains(c, i, EqualityComparer<int>.Default));
		}

		public override void CollectionContains_IncorrectInput(int[] c, int i)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.Contains(c, i, EqualityComparer<int>.Default));
		}

		public override void CollectionDoesNotContain_CorrectInput(int[] c, int i)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.DoesNotContain(c, i, EqualityComparer<int>.Default));
		}

		public override void CollectionDoesNotContain_IncorrectInput(int[] c, int i)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.DoesNotContain(c, i, EqualityComparer<int>.Default));
		}

		#endregion

		#region Types

		public override void IsOfType_CorrectInput(Type t, object o)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsOfType(t, o));
		}

		public override void IsOfType_IncorrectInput(Type t, object o)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsOfType(t, o));
		}

		public override void IsOfNotType_CorrectInput(Type t, object o)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsNotOfType(t, o));
		}

		public override void IsOfNotType_IncorrectInput(Type t, object o)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsNotOfType(t, o));
		}

		public override void IsOfTypeAssignableFrom_CorrectInput(Type t, object o)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsOfTypeAssignableFrom(t, o));
		}

		public override void IsOfTypeAssignableFrom_IncorrectInput(Type t, object o)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsOfTypeAssignableFrom(t, o));
		}

		public override void IsNotOfTypeAssignableFrom_CorrectInput(Type t, object o)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsNotOfTypeAssignableFrom(t, o));
		}

		public override void IsNotOfTypeAssignableFrom_IncorrectInput(Type t, object o)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsNotOfTypeAssignableFrom(t, o));
		}

		public override void IsOfTypeAssignableTo_CorrectInput(Type t, object o)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsOfTypeAssignableTo(t, o));
		}

		public override void IsOfTypeAssignableTo_IncorrectInput(Type t, object o)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsOfTypeAssignableTo(t, o));
		}

		public override void IsNotOfTypeAssignableTo_CorrectInput(Type t, object o)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.IsNotOfTypeAssignableTo(t, o));
		}

		public override void IsNotOfTypeAssignableTo_IncorrectInput(Type t, object o)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.IsNotOfTypeAssignableTo(t, o));
		}

		#endregion

		#region Exceptions

		public override void Throws_CorrectInput(Action action)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.Throws<DivideByZeroException>(action));
		}

		public override void Throws_IncorrectInput(Action action)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.Throws<Exception>(action));
		}

		public override void DoesNotThrow_CorrectInput(Action action)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => assertProvider.DoesNotThrow<Exception>(action));
		}

		public override void DoesNotThrow_IncorrectInput(Action action)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => assertProvider.DoesNotThrow<DivideByZeroException>(action));
		}

		#endregion
	}
}
