XAssert
=======

XAssert is a test runner agnostic assertion framework for .NET. It is set of portable class libraries compatible with .NET 4+, Silverlight 5+, Windows 8+ and Windows Phone 8+.

XAssert comes in two flavors:
- [XAssert.Should](#XAssert.Should)
- [XAssert.Expect](#XAssert.Expect)

## XAssert.Should
### Installation with NuGet
`PM> Install-Package XAssert.Should -Pre`

### Usage
The following code shows some example usage:
```C#
using System;
using XAssert.Should;

public class Suite
{
	public void ShouldTests()
	{
		object x = new object();
		object y = new object();

		x.Should().Be.SameAs(x);
		x.Should().Not.Be.SameAs(y);

		x.Should().Be.EqualTo(x);
		x.Should().Not.Be.EqualTo(y);

		x = null;
		x.Should().Be.Null();
		y.Should().Not.Be.Null();
		x.Should().Be.Default<object>();
		y.Should().Not.Be.Default<object>();

		true.Should().Be.True();
		false.Should().Not.Be.True();
		false.Should().Be.False();
		true.Should().Not.Be.False();

		double zero = 0.0;
		Double.NaN.Should().Be.NaN();
		zero.Should().Not.Be.NaN();
		Double.PositiveInfinity.Should().Be.PositiveInfinity();
		zero.Should().Not.Be.PositiveInfinity();
		Double.NegativeInfinity.Should().Be.NegativeInfinity();
		zero.Should().Not.Be.NegativeInfinity();

		Guid.Empty.Should().Be.Empty();
		Guid.NewGuid().Should().Not.Be.Empty();

		1.Should().Be.GreaterThan(0);
		1.Should().Not.Be.GreaterThan(1);
		1.Should().Not.Be.GreaterThan(2);
		0.Should().Be.LessThan(1);
		0.Should().Not.Be.LessThan(0);
		0.Should().Not.Be.LessThan(-1);

		1.Should().Be.GreaterThanOrEqualTo(0);
		1.Should().Be.GreaterThanOrEqualTo(1);
		1.Should().Not.Be.GreaterThanOrEqualTo(2);
		0.Should().Be.LessThanOrEqualTo(1);
		0.Should().Be.LessThanOrEqualTo(0);
		0.Should().Not.Be.LessThanOrEqualTo(-1);

		"The string".Should().Contain("str");
		"The string".Should().Not.Contain("str2");
		"The string".Should().StartWith("The");
		"The string".Should().Not.StartWith("The2");
		"The string".Should().EndWith("string");
		"The string".Should().Not.EndWith("string2");

		new object[0].Should().Be.Empty();
		new int[] { 1 }.Should().Not.Be.Empty();
		new int[] { 1,2,3,4,5 }.Should().Contain(1);
		new int[] { 1,2,3,4,5 }.Should().Not.Contain(6);

		1.Should().Be.OfType<int>();
		1.Should().Not.Be.OfType<string>();

		Action action = () => { int z = 0; var r = 1 / z; };
		action.Should().Throw<DivideByZeroException>();
		action.Should().Not.Throw<ArgumentNullException>();
	}
}

```

## XAssert.Expect
### Installation with NuGet
`PM> Install-Package XAssert.Expect -Pre`

### Usage
The following code shows some example usage:
```C#
using System;
using XAssert.Expect;

public class Suite
{
	public void ExpectTests()
	{
		object x = new object();
		object y = new object();

		this.Expect(x).To.Be.SameAs(x);
		this.Expect(x).To.Not.Be.SameAs(y);

		this.Expect(x).To.Be.EqualTo(x);
		this.Expect(x).To.Not.Be.EqualTo(y);

		x = null;
		this.Expect(x).To.Be.Null();
		this.Expect(y).To.Not.Be.Null();
		this.Expect(x).To.Be.Default<object>();
		this.Expect(y).To.Not.Be.Default<object>();

		this.Expect(true).To.Be.True();
		this.Expect(false).To.Not.Be.True();
		this.Expect(false).To.Be.False();
		this.Expect(true).To.Not.Be.False();

		double zero = 0.0;
		this.Expect(Double.NaN).To.Be.NaN();
		this.Expect(zero).To.Not.Be.NaN();
		this.Expect(Double.PositiveInfinity).To.Be.PositiveInfinity();
		this.Expect(zero).To.Not.Be.PositiveInfinity();
		this.Expect(Double.NegativeInfinity).To.Be.NegativeInfinity();
		this.Expect(zero).To.Not.Be.NegativeInfinity();

		this.Expect(Guid.Empty).To.Be.Empty();
		this.Expect(Guid.NewGuid()).To.Not.Be.Empty();

		this.Expect(1).To.Be.GreaterThan(0);
		this.Expect(1).To.Not.Be.GreaterThan(1);
		this.Expect(1).To.Not.Be.GreaterThan(2);
		this.Expect(0).To.Be.LessThan(1);
		this.Expect(0).To.Not.Be.LessThan(0);
		this.Expect(0).To.Not.Be.LessThan(-1);

		this.Expect(1).To.Be.GreaterThanOrEqualTo(0);
		this.Expect(1).To.Be.GreaterThanOrEqualTo(1);
		this.Expect(1).To.Not.Be.GreaterThanOrEqualTo(2);
		this.Expect(0).To.Be.LessThanOrEqualTo(1);
		this.Expect(0).To.Be.LessThanOrEqualTo(0);
		this.Expect(0).To.Not.Be.LessThanOrEqualTo(-1);

		this.Expect("The string").To.Contain("str");
		this.Expect("The string").To.Not.Contain("str2");
		this.Expect("The string").To.StartWith("The");
		this.Expect("The string").To.Not.StartWith("The2");
		this.Expect("The string").To.EndWith("string");
		this.Expect("The string").To.Not.EndWith("string2");

		this.Expect(new object[0]).To.Be.Empty();
		this.Expect(new int[] { 1 }).To.Not.Be.Empty();
		this.Expect(new int[] { 1,2,3,4,5 }).To.Contain(1);
		this.Expect(new int[] { 1,2,3,4,5 }).To.Not.Contain(6);

		this.Expect(1).To.Be.OfType<int>();
		this.Expect(1).To.Not.Be.OfType<string>();

		Action action = () => { int z = 0; var r = 1 / z; };
		this.Expect(action).To.Throw<DivideByZeroException>();
		this.Expect(action).To.Not.Throw<ArgumentNullException>();
	}
}

```

## License
[MIT](LICENSE)
