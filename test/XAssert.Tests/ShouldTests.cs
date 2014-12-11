using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XAssert;
using XAssert.Should;

namespace XAssert.Tests
{
	public class ShouldTests : AssertFlavorTestsBase
	{
		#region Sameness
		public override void AreSame_CorrectInput(object left, object right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => left.Should().Be.SameAs(right));
		}

		public override void AreSame_IncorrectInput(object left, object right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => left.Should().Be.SameAs(right));
		}

		public override void AreNotSame_CorrectInput(object left, object right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => left.Should().Not.Be.SameAs(right));
		}

		public override void AreNotSame_IncorrectInput(object left, object right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => left.Should().Not.Be.SameAs(right));
		}
		#endregion

		#region Equality
		public override void AreEqual_CorrectInput(object left, object right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => left.Should().Be.EqualTo(right));
		}

		public override void AreEqual_IncorrectInput(object left, object right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => left.Should().Be.EqualTo(right));
		}

		public override void AreNotEqual_CorrectInput(object left, object right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => left.Should().Not.Be.EqualTo(right));
		}

		public override void AreNotEqual_IncorrectInput(object left, object right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => left.Should().Not.Be.EqualTo(right));
		}
		#endregion

		#region Null and defaults

		public override void ObjectIsNull_CorrectInput(object obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => obj.Should().Be.Null());
		}

		public override void ObjectIsNull_IncorrectInput(object obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => obj.Should().Be.Null());
		}

		public override void ObjectIsNotNull_CorrectInput(object obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => obj.Should().Not.Be.Null());
		}

		public override void ObjectIsNotNull_IncorrectInput(object obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => obj.Should().Not.Be.Null());
		}

		public override void NullableValueIsNull_CorrectInput(int? obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => obj.Should().Be.Null());
		}

		public override void NullableValueIsNull_IncorrectInput(int? obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => obj.Should().Be.Null());
		}

		public override void NullableValueIsNotNull_CorrectInput(int? obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => obj.Should().Not.Be.Null());
		}
		public override void NullableValueIsNotNull_IncorrectInput(int? obj)
		{

			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => obj.Should().Not.Be.Null());
		}

		public override void IsDefaultStruct_CorrectInput(int obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => obj.Should().Be.Default());
		}

		public override void IsDefaultClass_CorrectInput(string obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => obj.Should().Be.Default());
		}

		public override void IsDefaultStruct_IncorrectInput(int obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => obj.Should().Be.Default());
		}

		public override void IsDefaultClass_IncorrectInput(string obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => obj.Should().Be.Default());
		}

		public override void IsNotDefaultStruct_CorrectInput(int obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => obj.Should().Not.Be.Default());
		}

		public override void IsNotDefaultClass_CorrectInput(string obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => obj.Should().Not.Be.Default());
		}

		public override void IsNotDefaultStruct_IncorrectInput(int obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => obj.Should().Not.Be.Default());
		}

		public override void IsNotDefaultClass_IncorrectInput(string obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => obj.Should().Not.Be.Default());
		}

		#endregion

		#region Booleans

		public override void IsTrue_CorrectInput(bool value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => value.Should().Be.True());
		}

		public override void IsTrue_IncorrectInput(bool value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => value.Should().Be.True());
		}

		public override void IsFalse_CorrectInput(bool value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => value.Should().Be.False());
		}

		public override void IsFalse_IncorrectInput(bool value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => value.Should().Be.False());
		}

		public override void IsNotTrue_CorrectInput(bool value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => value.Should().Not.Be.True());
		}

		public override void IsNotTrue_IncorrectInput(bool value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => value.Should().Not.Be.True());
		}

		public override void IsNotFalse_CorrectInput(bool value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => value.Should().Not.Be.False());
		}

		public override void IsNotFalse_IncorrectInput(bool value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => value.Should().Not.Be.False());
		}

		#endregion

		#region Numbers

		public override void IsNaN_CorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => value.Should().Be.NaN());
		}

		public override void IsNaN_IncorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => value.Should().Be.NaN());
		}

		public override void IsNotNaN_CorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => value.Should().Not.Be.NaN());
		}

		public override void IsNotNaN_IncorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => value.Should().Not.Be.NaN());
		}

		public override void IsPositiveInfinity_CorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => value.Should().Be.PositiveInfinity());
		}

		public override void IsPositiveInfinity_IncorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => value.Should().Be.PositiveInfinity());
		}

		public override void IsNotPositiveInfinity_CorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => value.Should().Not.Be.PositiveInfinity());
		}

		public override void IsNotPositiveInfinity_IncorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => value.Should().Not.Be.PositiveInfinity());
		}

		public override void IsNegativeInfinity_CorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => value.Should().Be.NegativeInfinity());
		}

		public override void IsNegativeInfinity_IncorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => value.Should().Be.NegativeInfinity());
		}

		public override void IsNotNegativeInfinity_CorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => value.Should().Not.Be.NegativeInfinity());
		}

		public override void IsNotNegativeInfinity_IncorrectInput(double value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => value.Should().Not.Be.NegativeInfinity());
		}

		#endregion

		#region Guids
		public override void GuidIsEmpty_CorrectInput(Guid value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => value.Should().Be.Empty());
		}

		public override void GuidIsEmpty_IncorrectInput(Guid value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => value.Should().Be.Empty());
		}

		public override void GuidIsNotEmpty_CorrectInput(Guid value)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => value.Should().Not.Be.Empty());
		}

		public override void GuidIsNotEmpty_IncorrectInput(Guid value)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => value.Should().Not.Be.Empty());
		}

		#endregion

		#region Comparison

		public override void IsGreaterThan_CorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => left.Should().Be.GreaterThan(right));
		}

		public override void IsGreaterThan_IncorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => left.Should().Be.GreaterThan(right));
		}

		public override void IsLessThan_CorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => left.Should().Be.LessThan(right));
		}

		public override void IsLessThan_IncorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => left.Should().Be.LessThan(right));
		}

		public override void IsGreaterThanOrEqualTo_CorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => left.Should().Be.GreaterThanOrEqualTo(right));
		}

		public override void IsGreaterThanOrEqualTo_IncorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => left.Should().Be.GreaterThanOrEqualTo(right));
		}

		public override void IsLessThanOrEqualTo_CorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => left.Should().Be.LessThanOrEqualTo(right));
		}

		public override void IsLessThanOrEqualTo_IncorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => left.Should().Be.LessThanOrEqualTo(right));
		}

		public override void IsNotGreaterThan_CorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => left.Should().Not.Be.GreaterThan(right));
		}

		public override void IsNotGreaterThan_IncorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => left.Should().Not.Be.GreaterThan(right));
		}

		public override void IsNotLessThan_CorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => left.Should().Not.Be.LessThan(right));
		}

		public override void IsNotLessThan_IncorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => left.Should().Not.Be.LessThan(right));
		}

		public override void IsNotGreaterThanOrEqualTo_CorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => left.Should().Not.Be.GreaterThanOrEqualTo(right));
		}

		public override void IsNotGreaterThanOrEqualTo_IncorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => left.Should().Not.Be.GreaterThanOrEqualTo(right));
		}

		public override void IsNotLessThanOrEqualTo_CorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => left.Should().Not.Be.LessThanOrEqualTo(right));
		}

		public override void IsNotLessThanOrEqualTo_IncorrectInput(double left, double right)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => left.Should().Not.Be.LessThanOrEqualTo(right));
		}

		#endregion

		#region Strings

		public override void StringContains_CorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => str.Should().Contain(part, comparison));
		}

		public override void StringContains_IncorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => str.Should().Contain(part, comparison));
		}

		public override void StringDoesNotContain_CorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => str.Should().Not.Contain(part, comparison));
		}

		public override void StringDoesNotContain_IncorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => str.Should().Not.Contain(part, comparison));
		}

		public override void StringStartsWith_CorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => str.Should().StartWith(part, comparison));
		}

		public override void StringStartsWith_IncorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => str.Should().StartWith(part, comparison));
		}

		public override void StringDoesNotStartWith_CorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => str.Should().Not.StartWith(part, comparison));
		}

		public override void StringDoesNotStartWith_IncorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => str.Should().Not.StartWith(part, comparison));
		}

		public override void StringEndsWith_CorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => str.Should().EndWith(part, comparison));
		}

		public override void StringEndsWith_IncorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => str.Should().EndWith(part, comparison));
		}

		public override void StringDoesNotEndWith_CorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => str.Should().Not.EndWith(part, comparison));
		}

		public override void StringDoesNotEndWith_IncorrectInput(string str, string part, StringComparison comparison)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => str.Should().Not.EndWith(part, comparison));
		}

		public override void StringMatches_CorrectInput(string str, string pattern, RegexOptions options)
		{
			Regex r = new Regex(pattern, options);
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => str.Should().Match(r));
		}

		public override void StringMatches_IncorrectInput(string str, string pattern, RegexOptions options)
		{
			Regex r = new Regex(pattern, options);
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => str.Should().Match(r));
		}

		public override void StringDoesNotMatch_CorrectInput(string str, string pattern, RegexOptions options)
		{
			Regex r = new Regex(pattern, options);
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => str.Should().Not.Match(r));
		}

		public override void StringDoesNotMatch_IncorrectInput(string str, string pattern, RegexOptions options)
		{
			Regex r = new Regex(pattern, options);
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => str.Should().Not.Match(r));
		}

		#endregion

		#region Collections

		public override void CollectionIsEmpty_CorrectInput(int[] enumerable)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => enumerable.AsEnumerable().Should().Be.Empty());
		}

		public override void CollectionIsEmpty_IncorrectInput(int[] enumerable)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => enumerable.AsEnumerable().Should().Be.Empty());
		}

		public override void CollectionIsNotEmpty_CorrectInput(int[] enumerable)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => enumerable.AsEnumerable().Should().Not.Be.Empty());
		}

		public override void CollectionIsNotEmpty_IncorrectInput(int[] enumerable)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => enumerable.AsEnumerable().Should().Not.Be.Empty());
		}

		public override void CollectionContains_CorrectInput(int[] enumerable, int item)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => enumerable.AsEnumerable().Should().Contain(item));
		}

		public override void CollectionContains_IncorrectInput(int[] enumerable, int item)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => enumerable.AsEnumerable().Should().Contain(item));
		}

		public override void CollectionDoesNotContain_CorrectInput(int[] enumerable, int item)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => enumerable.AsEnumerable().Should().Not.Contain(item));
		}

		public override void CollectionDoesNotContain_IncorrectInput(int[] enumerable, int item)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => enumerable.AsEnumerable().Should().Not.Contain(item));
		}

		#endregion

		#region Types

		public override void IsOfType_CorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => obj.Should().Be.OfType(type));
		}

		public override void IsOfType_IncorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => obj.Should().Be.OfType(type));
		}

		public override void IsOfNotType_CorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => obj.Should().Not.Be.OfType(type));
		}

		public override void IsOfNotType_IncorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => obj.Should().Not.Be.OfType(type));
		}

		public override void IsOfTypeAssignableFrom_CorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => obj.Should().Be.OfTypeAssignableFrom(type));
		}

		public override void IsOfTypeAssignableFrom_IncorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => obj.Should().Be.OfTypeAssignableFrom(type));
		}

		public override void IsNotOfTypeAssignableFrom_CorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => obj.Should().Not.Be.OfTypeAssignableFrom(type));
		}

		public override void IsNotOfTypeAssignableFrom_IncorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => obj.Should().Not.Be.OfTypeAssignableFrom(type));
		}

		public override void IsOfTypeAssignableTo_CorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => obj.Should().Be.OfTypeAssignableTo(type));
		}

		public override void IsOfTypeAssignableTo_IncorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => obj.Should().Be.OfTypeAssignableTo(type));
		}

		public override void IsNotOfTypeAssignableTo_CorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => obj.Should().Not.Be.OfTypeAssignableTo(type));
		}

		public override void IsNotOfTypeAssignableTo_IncorrectInput(Type type, object obj)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => obj.Should().Not.Be.OfTypeAssignableTo(type));
		}

		#endregion

		#region Exceptions

		public override void Throws_CorrectInput(Action action)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => action.Should().Throw<DivideByZeroException>());
		}

		public override void Throws_IncorrectInput(Action action)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => action.Should().Throw<DivideByZeroException>());
		}

		public override void DoesNotThrow_CorrectInput(Action action)
		{
			TestHelper.FailIfExceptionIsThrown<AssertException>(() => action.Should().Not.Throw<DivideByZeroException>());
		}

		public override void DoesNotThrow_IncorrectInput(Action action)
		{
			TestHelper.FailIfExceptionIsNotThrown<AssertException>(() => action.Should().Not.Throw<DivideByZeroException>());
		}

		#endregion
	}
}
