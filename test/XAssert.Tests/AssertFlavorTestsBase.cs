using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace XAssert.Tests
{
	public abstract class AssertFlavorTestsBase : AssertProviderTestsBase
	{
		#region Sameness

		public abstract override void AreSame_CorrectInput(object left, object right);

		public abstract override void AreSame_IncorrectInput(object left, object right);

		public abstract override void AreNotSame_CorrectInput(object left, object right);

		public abstract override void AreNotSame_IncorrectInput(object left, object right);

		#endregion

		#region Equality

		public abstract override void AreEqual_CorrectInput(object left, object right);

		public abstract override void AreEqual_IncorrectInput(object left, object right);

		public abstract override void AreNotEqual_CorrectInput(object left, object right);

		public abstract override void AreNotEqual_IncorrectInput(object left, object right);

		#endregion

		#region Nulls and defaults

		public abstract override void ObjectIsNull_CorrectInput(object obj);

		public abstract override void ObjectIsNull_IncorrectInput(object obj);

		public abstract override void ObjectIsNotNull_CorrectInput(object obj);

		public abstract override void ObjectIsNotNull_IncorrectInput(object obj);

		public abstract override void NullableValueIsNull_CorrectInput(int? obj);

		public abstract override void NullableValueIsNull_IncorrectInput(int? obj);

		public abstract override void NullableValueIsNotNull_CorrectInput(int? obj);

		public abstract override void NullableValueIsNotNull_IncorrectInput(int? obj);

		public abstract override void IsDefaultStruct_CorrectInput(int obj);

		public abstract override void IsDefaultClass_CorrectInput(string obj);

		public abstract override void IsDefaultStruct_IncorrectInput(int obj);

		public abstract override void IsDefaultClass_IncorrectInput(string obj);

		public abstract override void IsNotDefaultStruct_CorrectInput(int obj);

		public abstract override void IsNotDefaultClass_CorrectInput(string obj);

		public abstract override void IsNotDefaultStruct_IncorrectInput(int obj);

		public abstract override void IsNotDefaultClass_IncorrectInput(string obj);

		#endregion

		#region Boolean

		public abstract override void IsTrue_CorrectInput(bool value);

		public abstract override void IsTrue_IncorrectInput(bool value);

		public abstract override void IsFalse_CorrectInput(bool value);

		public abstract override void IsFalse_IncorrectInput(bool value);

		[Theory]
		[InlineData(false)]
		public abstract void IsNotTrue_CorrectInput(bool value);

		[Theory]
		[InlineData(true)]
		public abstract void IsNotTrue_IncorrectInput(bool value);

		[Theory]
		[InlineData(true)]
		public abstract void IsNotFalse_CorrectInput(bool value);

		[Theory]
		[InlineData(false)]
		public abstract void IsNotFalse_IncorrectInput(bool value);

		#endregion

		#region Numbers

		public abstract override void IsNaN_CorrectInput(double value);

		public abstract override void IsNaN_IncorrectInput(double value);

		public abstract override void IsNotNaN_CorrectInput(double value);

		public abstract override void IsNotNaN_IncorrectInput(double value);

		public abstract override void IsPositiveInfinity_CorrectInput(double value);

		public abstract override void IsPositiveInfinity_IncorrectInput(double value);

		public abstract override void IsNotPositiveInfinity_CorrectInput(double value);

		public abstract override void IsNotPositiveInfinity_IncorrectInput(double value);

		public abstract override void IsNegativeInfinity_CorrectInput(double value);

		public abstract override void IsNegativeInfinity_IncorrectInput(double value);

		public abstract override void IsNotNegativeInfinity_CorrectInput(double value);

		public abstract override void IsNotNegativeInfinity_IncorrectInput(double value);

		#endregion

		#region Guids

		public abstract override void GuidIsEmpty_CorrectInput(Guid value);

		public abstract override void GuidIsEmpty_IncorrectInput(Guid value);

		public abstract override void GuidIsNotEmpty_CorrectInput(Guid value);

		public abstract override void GuidIsNotEmpty_IncorrectInput(Guid value);

		#endregion

		#region Comparison

		public abstract override void IsGreaterThan_CorrectInput(double left, double right);

		public abstract override void IsGreaterThan_IncorrectInput(double left, double right);

		public abstract override void IsLessThan_CorrectInput(double left, double right);

		public abstract override void IsLessThan_IncorrectInput(double left, double right);

		public abstract override void IsGreaterThanOrEqualTo_CorrectInput(double left, double right);

		public abstract override void IsGreaterThanOrEqualTo_IncorrectInput(double left, double right);

		public abstract override void IsLessThanOrEqualTo_CorrectInput(double left, double right);

		public abstract override void IsLessThanOrEqualTo_IncorrectInput(double left, double right);

		[Theory]
		[InlineData(1, 2)]
		[InlineData(2, 2)]
		public abstract void IsNotGreaterThan_CorrectInput(double left, double right);

		[Theory]
		[InlineData(2, 1)]
		public abstract void IsNotGreaterThan_IncorrectInput(double left, double right);

		[Theory]
		[InlineData(2, 1)]
		[InlineData(2, 2)]
		public abstract void IsNotLessThan_CorrectInput(double left, double right);

		[Theory]
		[InlineData(1, 2)]		
		public abstract void IsNotLessThan_IncorrectInput(double left, double right);

		[Theory]
		[InlineData(1, 2)]

		public abstract void IsNotGreaterThanOrEqualTo_CorrectInput(double left, double right);

		[Theory]
		[InlineData(2, 1)]
		[InlineData(2, 2)]
		public abstract void IsNotGreaterThanOrEqualTo_IncorrectInput(double left, double right);

		[Theory]
		[InlineData(2, 1)]
		
		public abstract void IsNotLessThanOrEqualTo_CorrectInput(double left, double right);

		[Theory]
		[InlineData(1, 2)]
		[InlineData(2, 2)]
		public abstract void IsNotLessThanOrEqualTo_IncorrectInput(double left, double right);

		#endregion

		#region Strings

		public abstract override void StringContains_CorrectInput(string str, string part, StringComparison comparison);

		public abstract override void StringContains_IncorrectInput(string str, string part, StringComparison comparison);

		public abstract override void StringDoesNotContain_CorrectInput(string str, string part, StringComparison comparison);

		public abstract override void StringDoesNotContain_IncorrectInput(string str, string part, StringComparison comparison);

		public abstract override void StringStartsWith_CorrectInput(string str, string part, StringComparison comparison);

		public abstract override void StringStartsWith_IncorrectInput(string str, string part, StringComparison comparison);

		public abstract override void StringDoesNotStartWith_CorrectInput(string str, string part, StringComparison comparison);

		public abstract override void StringDoesNotStartWith_IncorrectInput(string str, string part, StringComparison comparison);

		public abstract override void StringEndsWith_CorrectInput(string str, string part, StringComparison comparison);

		public abstract override void StringEndsWith_IncorrectInput(string str, string part, StringComparison comparison);

		public abstract override void StringDoesNotEndWith_CorrectInput(string str, string part, StringComparison comparison);

		public abstract override void StringDoesNotEndWith_IncorrectInput(string str, string part, StringComparison comparison);

		public abstract override void StringMatches_CorrectInput(string str, string pattern, RegexOptions options);

		public abstract override void StringMatches_IncorrectInput(string str, string pattern, RegexOptions options);

		public abstract override void StringDoesNotMatch_CorrectInput(string str, string pattern, RegexOptions options);

		public abstract override void StringDoesNotMatch_IncorrectInput(string str, string pattern, RegexOptions options);

		#endregion

		#region Collections

		public abstract override void CollectionIsEmpty_CorrectInput(int[] enumerable);

		public abstract override void CollectionIsEmpty_IncorrectInput(int[] enumerable);

		public abstract override void CollectionIsNotEmpty_CorrectInput(int[] enumerable);

		public abstract override void CollectionIsNotEmpty_IncorrectInput(int[] enumerable);

		public abstract override void CollectionContains_CorrectInput(int[] enumerable, int item);

		public abstract override void CollectionContains_IncorrectInput(int[] enumerable, int item);

		public abstract override void CollectionDoesNotContain_CorrectInput(int[] enumerable, int item);

		public abstract override void CollectionDoesNotContain_IncorrectInput(int[] enumerable, int item);

		#endregion

		#region Types

		public abstract override void IsOfType_CorrectInput(Type type, object obj);

		public abstract override void IsOfType_IncorrectInput(Type type, object obj);

		public abstract override void IsOfNotType_CorrectInput(Type type, object obj);

		public abstract override void IsOfNotType_IncorrectInput(Type type, object obj);

		public abstract override void IsOfTypeAssignableFrom_CorrectInput(Type type, object obj);

		public abstract override void IsOfTypeAssignableFrom_IncorrectInput(Type type, object obj);

		public abstract override void IsNotOfTypeAssignableFrom_CorrectInput(Type type, object obj);

		public abstract override void IsNotOfTypeAssignableFrom_IncorrectInput(Type type, object obj);

		public abstract override void IsOfTypeAssignableTo_CorrectInput(Type type, object obj);

		public abstract override void IsOfTypeAssignableTo_IncorrectInput(Type type, object obj);

		public abstract override void IsNotOfTypeAssignableTo_CorrectInput(Type type, object obj);

		public abstract override void IsNotOfTypeAssignableTo_IncorrectInput(Type type, object obj);

		#endregion

		#region Exceptions

		public abstract override void Throws_CorrectInput(Action action);

		public abstract override void Throws_IncorrectInput(Action action);

		public abstract override void DoesNotThrow_CorrectInput(Action action);

		public abstract override void DoesNotThrow_IncorrectInput(Action action);

		#endregion
	}
}
