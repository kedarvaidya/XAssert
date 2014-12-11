using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XAssert;
using XAssert.Expect;

namespace XAssert.Tests
{
	public class ExpectTests : AssertFlavorTestsBase
	{
		#region Sameness
		public override void AreSame_CorrectInput(object left, object right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(left).To.Be.SameAs(right));
		}

		public override void AreSame_IncorrectInput(object left, object right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(left).To.Be.SameAs(right));
		}

		public override void AreNotSame_CorrectInput(object left, object right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(left).To.Not.Be.SameAs(right));
		}

		public override void AreNotSame_IncorrectInput(object left, object right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(left).To.Not.Be.SameAs(right));
		}
		#endregion

		#region Equality
		public override void AreEqual_CorrectInput(object left, object right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(left).To.Be.EqualTo(right));
		}

		public override void AreEqual_IncorrectInput(object left, object right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(left).To.Be.EqualTo(right));
		}

		public override void AreNotEqual_CorrectInput(object left, object right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(left).To.Not.Be.EqualTo(right));
		}

		public override void AreNotEqual_IncorrectInput(object left, object right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(left).To.Not.Be.EqualTo(right));
		}
		#endregion

		#region Null and defaults

		public override void ObjectIsNull_CorrectInput(object obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(obj).To.Be.Null());
		}

		public override void ObjectIsNull_IncorrectInput(object obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(obj).To.Be.Null());
		}

		public override void ObjectIsNotNull_CorrectInput(object obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(obj).To.Not.Be.Null());
		}

		public override void ObjectIsNotNull_IncorrectInput(object obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(obj).To.Not.Be.Null());
		}

		public override void NullableValueIsNull_CorrectInput(int? obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(obj).To.Be.Null());
		}

		public override void NullableValueIsNull_IncorrectInput(int? obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(obj).To.Be.Null());
		}

		public override void NullableValueIsNotNull_CorrectInput(int? obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(obj).To.Not.Be.Null());
		}
		public override void NullableValueIsNotNull_IncorrectInput(int? obj)
		{

			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(obj).To.Not.Be.Null());
		}

		public override void IsDefaultStruct_CorrectInput(int obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(obj).To.Be.Default());
		}

		public override void IsDefaultClass_CorrectInput(string obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(obj).To.Be.Default());
		}

		public override void IsDefaultStruct_IncorrectInput(int obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(obj).To.Be.Default());
		}

		public override void IsDefaultClass_IncorrectInput(string obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(obj).To.Be.Default());
		}

		public override void IsNotDefaultStruct_CorrectInput(int obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(obj).To.Not.Be.Default());
		}

		public override void IsNotDefaultClass_CorrectInput(string obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(obj).To.Not.Be.Default());
		}

		public override void IsNotDefaultStruct_IncorrectInput(int obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(obj).To.Not.Be.Default());
		}

		public override void IsNotDefaultClass_IncorrectInput(string obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(obj).To.Not.Be.Default());
		}

		#endregion

		#region Booleans

		public override void IsTrue_CorrectInput(bool value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(value).To.Be.True());
		}

		public override void IsTrue_IncorrectInput(bool value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(value).To.Be.True());
		}

		public override void IsFalse_CorrectInput(bool value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(value).To.Be.False());
		}

		public override void IsFalse_IncorrectInput(bool value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(value).To.Be.False());
		}

		public override void IsNotTrue_CorrectInput(bool value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(value).To.Not.Be.True());
		}

		public override void IsNotTrue_IncorrectInput(bool value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(value).To.Not.Be.True());
		}

		public override void IsNotFalse_CorrectInput(bool value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(value).To.Not.Be.False());
		}

		public override void IsNotFalse_IncorrectInput(bool value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(value).To.Not.Be.False());
		}

		#endregion

		#region Numbers

		public override void IsNaN_CorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(value).To.Be.NaN());
		}

		public override void IsNaN_IncorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(value).To.Be.NaN());
		}

		public override void IsNotNaN_CorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(value).To.Not.Be.NaN());
		}

		public override void IsNotNaN_IncorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(value).To.Not.Be.NaN());
		}

		public override void IsPositiveInfinity_CorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(value).To.Be.PositiveInfinity());
		}

		public override void IsPositiveInfinity_IncorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(value).To.Be.PositiveInfinity());
		}

		public override void IsNotPositiveInfinity_CorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(value).To.Not.Be.PositiveInfinity());
		}

		public override void IsNotPositiveInfinity_IncorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(value).To.Not.Be.PositiveInfinity());
		}

		public override void IsNegativeInfinity_CorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(value).To.Be.NegativeInfinity());
		}

		public override void IsNegativeInfinity_IncorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(value).To.Be.NegativeInfinity());
		}

		public override void IsNotNegativeInfinity_CorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(value).To.Not.Be.NegativeInfinity());
		}

		public override void IsNotNegativeInfinity_IncorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(value).To.Not.Be.NegativeInfinity());
		}

		#endregion

		#region Guids
		public override void GuidIsEmpty_CorrectInput(Guid value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(value).To.Be.Empty());
		}

		public override void GuidIsEmpty_IncorrectInput(Guid value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(value).To.Be.Empty());
		}

		public override void GuidIsNotEmpty_CorrectInput(Guid value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(value).To.Not.Be.Empty());
		}

		public override void GuidIsNotEmpty_IncorrectInput(Guid value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(value).To.Not.Be.Empty());
		}

		#endregion

		#region Comparison

		public override void IsGreaterThan_CorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(left).To.Be.GreaterThan(right));
		}

		public override void IsGreaterThan_IncorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(left).To.Be.GreaterThan(right));
		}

		public override void IsLessThan_CorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(left).To.Be.LessThan(right));
		}

		public override void IsLessThan_IncorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(left).To.Be.LessThan(right));
		}

		public override void IsGreaterThanOrEqualTo_CorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(left).To.Be.GreaterThanOrEqualTo(right));
		}

		public override void IsGreaterThanOrEqualTo_IncorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(left).To.Be.GreaterThanOrEqualTo(right));
		}

		public override void IsLessThanOrEqualTo_CorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(left).To.Be.LessThanOrEqualTo(right));
		}

		public override void IsLessThanOrEqualTo_IncorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(left).To.Be.LessThanOrEqualTo(right));
		}

		public override void IsNotGreaterThan_CorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(left).To.Not.Be.GreaterThan(right));
		}

		public override void IsNotGreaterThan_IncorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(left).To.Not.Be.GreaterThan(right));
		}

		public override void IsNotLessThan_CorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(left).To.Not.Be.LessThan(right));
		}

		public override void IsNotLessThan_IncorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(left).To.Not.Be.LessThan(right));
		}

		public override void IsNotGreaterThanOrEqualTo_CorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(left).To.Not.Be.GreaterThanOrEqualTo(right));
		}

		public override void IsNotGreaterThanOrEqualTo_IncorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(left).To.Not.Be.GreaterThanOrEqualTo(right));
		}

		public override void IsNotLessThanOrEqualTo_CorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(left).To.Not.Be.LessThanOrEqualTo(right));
		}

		public override void IsNotLessThanOrEqualTo_IncorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(left).To.Not.Be.LessThanOrEqualTo(right));
		}

		#endregion

		#region Strings

		public override void StringContains_CorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(str).To.Contain(part, comparison));
		}

		public override void StringContains_IncorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(str).To.Contain(part, comparison));
		}

		public override void StringDoesNotContain_CorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(str).To.Not.Contain(part, comparison));
		}

		public override void StringDoesNotContain_IncorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(str).To.Not.Contain(part, comparison));
		}

		public override void StringStartsWith_CorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(str).To.StartWith(part, comparison));
		}

		public override void StringStartsWith_IncorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(str).To.StartWith(part, comparison));
		}

		public override void StringDoesNotStartWith_CorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(str).To.Not.StartWith(part, comparison));
		}

		public override void StringDoesNotStartWith_IncorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(str).To.Not.StartWith(part, comparison));
		}

		public override void StringEndsWith_CorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(str).To.EndWith(part, comparison));
		}

		public override void StringEndsWith_IncorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(str).To.EndWith(part, comparison));
		}

		public override void StringDoesNotEndWith_CorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(str).To.Not.EndWith(part, comparison));
		}

		public override void StringDoesNotEndWith_IncorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(str).To.Not.EndWith(part, comparison));
		}

		public override void StringMatches_CorrectInput(string str, string pattern, RegexOptions options)
		{
			Regex r = new Regex(pattern, options);
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(str).To.Match(r));
		}

		public override void StringMatches_IncorrectInput(string str, string pattern, RegexOptions options)
		{
			Regex r = new Regex(pattern, options);
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(str).To.Match(r));
		}

		public override void StringDoesNotMatch_CorrectInput(string str, string pattern, RegexOptions options)
		{
			Regex r = new Regex(pattern, options);
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(str).To.Not.Match(r));
		}

		public override void StringDoesNotMatch_IncorrectInput(string str, string pattern, RegexOptions options)
		{
			Regex r = new Regex(pattern, options);
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(str).To.Not.Match(r));
		}

		#endregion

		#region Collections

		public override void CollectionIsEmpty_CorrectInput(int[] enumerable)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(enumerable.AsEnumerable()).To.Be.Empty());
		}

		public override void CollectionIsEmpty_IncorrectInput(int[] enumerable)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(enumerable.AsEnumerable()).To.Be.Empty());
		}

		public override void CollectionIsNotEmpty_CorrectInput(int[] enumerable)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(enumerable.AsEnumerable()).To.Not.Be.Empty());
		}

		public override void CollectionIsNotEmpty_IncorrectInput(int[] enumerable)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(enumerable.AsEnumerable()).To.Not.Be.Empty());
		}

		public override void CollectionContains_CorrectInput(int[] enumerable, int item)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(enumerable.AsEnumerable()).To.Contain(item));
		}

		public override void CollectionContains_IncorrectInput(int[] enumerable, int item)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(enumerable.AsEnumerable()).To.Contain(item));
		}

		public override void CollectionDoesNotContain_CorrectInput(int[] enumerable, int item)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(enumerable.AsEnumerable()).To.Not.Contain(item));
		}

		public override void CollectionDoesNotContain_IncorrectInput(int[] enumerable, int item)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(enumerable.AsEnumerable()).To.Not.Contain(item));
		}

		#endregion

		#region Types

		public override void IsOfType_CorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(obj).To.Be.OfType(type));
		}

		public override void IsOfType_IncorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(obj).To.Be.OfType(type));
		}

		public override void IsOfNotType_CorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(obj).To.Not.Be.OfType(type));
		}

		public override void IsOfNotType_IncorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(obj).To.Not.Be.OfType(type));
		}

		public override void IsOfTypeAssignableFrom_CorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(obj).To.Be.OfTypeAssignableFrom(type));
		}

		public override void IsOfTypeAssignableFrom_IncorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(obj).To.Be.OfTypeAssignableFrom(type));
		}

		public override void IsNotOfTypeAssignableFrom_CorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(obj).To.Not.Be.OfTypeAssignableFrom(type));
		}

		public override void IsNotOfTypeAssignableFrom_IncorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(obj).To.Not.Be.OfTypeAssignableFrom(type));
		}

		public override void IsOfTypeAssignableTo_CorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(obj).To.Be.OfTypeAssignableTo(type));
		}

		public override void IsOfTypeAssignableTo_IncorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(obj).To.Be.OfTypeAssignableTo(type));
		}

		public override void IsNotOfTypeAssignableTo_CorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(obj).To.Not.Be.OfTypeAssignableTo(type));
		}

		public override void IsNotOfTypeAssignableTo_IncorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(obj).To.Not.Be.OfTypeAssignableTo(type));
		}

		#endregion

		#region Exceptions

		public override void Throws_CorrectInput(Action action)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(action).To.Throw<DivideByZeroException>());
		}

		public override void Throws_IncorrectInput(Action action)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(action).To.Throw<DivideByZeroException>());
		}

		public override void DoesNotThrow_CorrectInput(Action action)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => this.Expect(action).To.Not.Throw<DivideByZeroException>());
		}

		public override void DoesNotThrow_IncorrectInput(Action action)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => this.Expect(action).To.Not.Throw<DivideByZeroException>());
		}

		#endregion
	}
}
