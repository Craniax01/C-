# C# Syntax Cheatsheet for Java Programmers

**TL;DR version**  
**Target:** C# 14 and .NET 10

A quick Java-to-C# translation guide for the core syntax used in the first part of a C# course.

## The mental model

- C# and Java both use braces, semicolons, classes, methods, inheritance, interfaces, and exceptions.
- C# is case-sensitive: `Name` and `name` are different.
- Prefer C# aliases: `string`, `bool`, `int`, `double`, and `object`.
- Types, methods, properties, and namespaces use `PascalCase`.
- Variables and parameters use `camelCase`.
- C# class members are `private` by default; Java members without a modifier have package-level access.
- `var` means compile-time type inference, not dynamic typing.
- New .NET projects usually enable nullable reference types. Use `string?` when `null` is intentional.

### Naming example

These are conventions, not compiler rules. C# can compile other styles, but these names follow the usual C# style:

```csharp
namespace CSharpCourse.StudentManagement;

public class Student
{
    public string FirstName { get; set; }

    public int CalculateTotal(int currentScore, int bonusScore)
    {
        int totalScore = currentScore + bonusScore;
        return totalScore;
    }
}
```

- **PascalCase:** `Student`, `CalculateTotal`, `FirstName`, `CSharpCourse`
- **camelCase:** `currentScore`, `bonusScore`, `totalScore`
- Private fields commonly use `_camelCase`, such as `_isEnrolled`.

## Keyword translation

| Java | C# | Quick rule |
| --- | --- | --- |
| `import java.util.List;` | `using System.Collections.Generic;` | Use `using` for namespaces. |
| `String` | `string` | Use the lowercase C# alias. |
| `boolean` | `bool` | `bool` is the C# keyword. |
| `Integer` | `int?` for a nullable number | Use `int` for a normal number. |
| `Double` | `double?` for a nullable number | Use `double` for a normal number. |
| `final` field | `readonly` field | Assign during initialization or the constructor. |
| `extends` and `implements` | `:` | Put all base types after one colon. |
| `@Override` | `override` | The base method must be `virtual` or `abstract`. |
| `System.out.println()` | `Console.WriteLine()` | `WriteLine` adds a newline. |
| `System.out.print()` | `Console.Write()` | `Write` does not add a newline. |
| `length()` | `.Length` | String length is a property. |
| `toUpperCase()` | `.ToUpper()` | C# method names use PascalCase. |
| `equals()` | `==` or `.Equals()` | For strings, C# `==` compares values. |
| `void printAll(String... values)` | `void PrintAll(params string[] values)` | Use `params` for variable arguments. |
| `new ArrayList<T>()` | `new List<T>()` | Use `List<T>` for a resizable list. |
| `HashMap<K, V>` | `Dictionary<K, V>` | Use a dictionary for key-value pairs. |
| `package` | `namespace` | Namespaces organize C# types. |
| `public static void main(String[] args)` | `Main(string[] args)` or top-level statements | `Main` starts with an uppercase `M`. |
| `getName()` / `setName()` | `Name { get; set; }` | C# commonly uses properties. |

## Variables and types

### Basic declarations

**Java**

```java
int count = 10;
long total = 100L;
double price = 19.99;
float ratio = 0.5f;
char grade = 'A';
boolean active = true;
String name = "Asha";
```

**C#**

```csharp
int count = 10;
long total = 100L;
double price = 19.99;
float ratio = 0.5f;
char grade = 'A';
bool active = true;
string name = "Asha";
```

### Type translation

| Purpose | Java | C# |
| --- | --- | --- |
| Whole number | `int` | `int` |
| Larger whole number | `long` | `long` |
| Decimal number | `double` | `double` |
| Single-precision number | `float` | `float` |
| Text | `String` | `string` |
| True/false | `boolean` | `bool` |
| Single character | `char` | `char` |
| Any object | `Object` | `object` |
| Nullable whole number | `Integer` | `int?` |
| Nullable decimal number | `Double` | `double?` |
| Money, when appropriate | `BigDecimal` | `decimal` |

### `var`

```csharp
var count = 10;
var name = "Asha";
var prices = new List<decimal>();
```

`var` gives the variable a fixed type at compile time. It does not allow the variable’s type to change later.

### `const` and `readonly`

**Java**

```java
final int maxStudents = 30;
```

**C#**

```csharp
const int MaxStudents = 30;
```

Use `readonly` for a field that can be assigned during initialization or in the constructor:

```csharp
public class Course
{
    public readonly string Code;

    public Course(string code)
    {
        Code = code;
    }
}
```

### Nullability

A normal `string` is expected to contain a value in a nullable-enabled project. Use `string?` when `null` is valid.

```csharp
string name = "Asha";
string? nickname = null;
int? marks = null;

if (nickname is not null)
{
    Console.WriteLine(nickname);
}
```

| Task | C# |
| --- | --- |
| Check for null | `value is null` or `value == null` |
| Check for non-null | `value is not null` or `value != null` |
| Null-safe fallback | `value ?? "Unknown"` |
| Assign only if currently null | `value ??= "Unknown"` |
| Empty string | `string.Empty` |

### Arrays and common collection names

```java
int[] marks = new int[3];
ArrayList<String> names = new ArrayList<>();
HashMap<String, Integer> scores = new HashMap<>();
```

```csharp
int[] marks = new int[3];
List<string> names = new List<string>();
Dictionary<string, int> scores = new Dictionary<string, int>();
```

Arrays have a fixed size. `List<T>` can grow, and `Dictionary<TKey, TValue>` stores key-value pairs.

## Strings

### Common operations

| Java | C# |
| --- | --- |
| `name.length()` | `name.Length` |
| `name.toUpperCase()` | `name.ToUpper()` |
| `name.toLowerCase()` | `name.ToLower()` |
| `name.contains("As")` | `name.Contains("As")` |
| `name.startsWith("A")` | `name.StartsWith("A")` |
| `name.endsWith("a")` | `name.EndsWith("a")` |
| `name.indexOf("s")` | `name.IndexOf("s")` |
| `name.substring(0, 3)` | `name.Substring(0, 3)` |
| `name.trim()` | `name.Trim()` |
| `name.equals("Asha")` | `name == "Asha"` or `name.Equals("Asha")` |
| `StringBuilder` | `StringBuilder` |

### String interpolation

**Java**

```java
String message = "Hello, " + name + "!";
```

**C#**

```csharp
string message = $"Hello, {name}!";
```

### Null or empty

**Java**

```java
if (name == null || name.isEmpty())
{
    System.out.println("No name");
}
```

**C#**

```csharp
if (string.IsNullOrEmpty(name))
{
    Console.WriteLine("No name");
}
```

Use `string.IsNullOrWhiteSpace(name)` when whitespace should also count as empty.

### Parsing without exceptions

Java usually wraps the parse in a `try`/`catch`. C# provides `TryParse`, which returns a `bool` instead of throwing.

**Java**

```java
try
{
    int value = Integer.parseInt(text);
    System.out.println(value);
}
catch (NumberFormatException ex)
{
    System.out.println("Not a number");
}
```

**C#**

```csharp
if (int.TryParse(text, out int value))
{
    Console.WriteLine(value);
}
else
{
    Console.WriteLine("Not a number");
}
```

`TryParse` also exists for `long`, `double`, `decimal`, `bool`, `DateTime`, and every enum.

## Control flow

The keywords are almost identical. The main differences are the enhanced `for` loop and the newer `switch` expression.

### `if` and `else`

**Java**

```java
if (marks >= 40)
{
    System.out.println("Pass");
}
else
{
    System.out.println("Fail");
}
```

**C#**

```csharp
if (marks >= 40)
{
    Console.WriteLine("Pass");
}
else
{
    Console.WriteLine("Fail");
}
```

The condition must be a `bool`. Unlike Java, C# will not let you use an `int` or `null` as a condition.

### `for` and `while`

**Java**

```java
for (int i = 0; i < 5; i++)
{
    System.out.println(i);
}

int attempts = 0;
while (attempts < 3)
{
    attempts++;
}
```

**C#**

```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
}

int attempts = 0;
while (attempts < 3)
{
    attempts++;
}
```

C# also has `do`/`while`, which runs the body at least once.

### `foreach` — the enhanced `for` loop

Java's `for (String name : names)` becomes `foreach` in C#.

**Java**

```java
for (String name : names)
{
    System.out.println(name);
}
```

**C#**

```csharp
foreach (string name in names)
{
    Console.WriteLine(name);
}
```

Use `foreach` by default; it cannot be modified inside the loop. Use a `for` loop when you need the index or need to change the collection.

### `break` and `continue`

Both work the same as in Java.

```csharp
foreach (int mark in marks)
{
    if (mark < 0)
    {
        continue;
    }

    Console.WriteLine(mark);
}
```

### `switch`

**Java**

```java
switch (grade)
{
    case 'A':
        System.out.println("Excellent");
        break;
    default:
        System.out.println("Unknown");
}
```

**C#**

```csharp
switch (grade)
{
    case 'A':
        Console.WriteLine("Excellent");
        break;
    default:
        Console.WriteLine("Unknown");
        break;
}
```

C# also has a `switch` expression, which returns a value directly instead of using `break`:

```csharp
string result = grade switch
{
    'A' => "Excellent",
    'B' => "Good",
    _ => "Unknown"
};
```

| Task | C# |
| --- | --- |
| Loop over a collection | `foreach` |
| Loop with a counter | `for` or `while` |
| Skip the rest of this iteration | `continue` |
| Leave the loop entirely | `break` |
| Value from a multi-way branch | `switch` expression with `=>` |

## Methods

### Basic syntax

**Java**

```java
public static int add(int first, int second)
{
    return first + second;
}
```

**C#**

```csharp
public static int Add(int first, int second)
{
    return first + second;
}
```

Remember:

- The return type comes before the method name.
- A method declaration does not end with a semicolon.
- A method with no returned value uses `void`.
- C# method names usually use PascalCase.
- C# method members are `private` unless another access modifier is supplied.

### Expression-bodied methods

C# can express a short method with `=>`:

```csharp
public static int Add(int first, int second) => first + second;
```

### Optional and named arguments

```csharp
public static int Add(int first, int second = 0) => first + second;

int result = Add(5, second: 3);
```

Java usually uses a separate overloaded method for these calling styles.

### Variable arguments

**Java**

```java
public static void printAll(String... values)
{
}
```

**C#**

```csharp
public static void PrintAll(params string[] values)
{
}
```

Call it with multiple values:

```csharp
PrintAll("Asha", "Raman", "Sita");
```

### `out` parameters

A common C# method pattern returns a `bool` and places the result in an `out` parameter:

```csharp
public static bool TryGetLength(string text, out int length)
{
    if (string.IsNullOrEmpty(text))
    {
        length = 0;
        return false;
    }

    length = text.Length;
    return true;
}
```

```csharp
if (TryGetLength("C#", out int length))
{
    Console.WriteLine(length);
}
```

Java has no direct equivalent to C# `out`; it commonly returns a result object or uses a different design.

## Classes, constructors, and properties

### Java style

```java
public class Student
{
    private String name;

    public Student(String name)
    {
        this.name = name;
    }

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }
}
```

### C# style

```csharp
public class Student
{
    public string Name { get; set; }

    public Student(string name)
    {
        Name = name;
    }
}
```

Key differences:

- A C# constructor has no return type.
- `Name` is a property, so use `student.Name`, not `student.getName()`.
- C# auto-properties generate the backing storage.
- Properties normally use PascalCase.
- Use `private set;` when code outside the class should not change a property.
- Use a read-only property when the value should not change after construction.

### Read-only property

```csharp
public class Student
{
    public string Name { get; }

    public Student(string name)
    {
        Name = name;
    }
}
```

### Records

For a simple data-carrying type, a record is compact:

```csharp
public record Student(string Name, int Age);
```

```csharp
Student student = new Student("Asha", 20);
Console.WriteLine(student.Name);
```

## Inheritance and interfaces

**Java**

```java
public class Student extends Person implements IComparable<Student>
{
}
```

**C#**

```csharp
public class Student : Person, IComparable<Student>
{
}
```

C# uses one colon for both a base class and interfaces. Separate multiple base types with commas.

| Java | C# |
| --- | --- |
| `super.method()` | `base.Method()` |
| `implements` | `:` |
| `@Override` | `override` |
| Method that can be overridden | `virtual` method |
| Class that cannot be inherited | `sealed` class |
| Abstract class | `abstract` class |

### `virtual` and `override`

```csharp
public class Person
{
    public virtual string Describe() => "Person";
}

public class Student : Person
{
    public override string Describe() => "Student";
}
```

Use `base.Describe()` when the derived method should also call the base implementation.

## Access modifiers

| Java | C# | Meaning |
| --- | --- | --- |
| `private` | `private` | Accessible only inside the declaring type. |
| package-private | `internal` | C# has no package-level access; `internal` is assembly-wide. |
| `protected` | `protected` | Accessible in the declaring type and derived types. |
| `protected` plus package access | `protected internal` | Accessible to derived types or types in the same assembly. |
| `private` plus package access | `private protected` | Accessible only to derived types in the same assembly. |
| `public` | `public` | Accessible from outside the type or assembly boundary. |

## Exceptions

C# has no checked exceptions. Any method can throw any exception, so you are not forced to declare or catch them, and a missing `catch` will not stop compilation.

### Throwing and catching

**Java**

```java
try
{
    int result = Integer.parseInt(text);
    System.out.println(result);
}
catch (NumberFormatException ex)
{
    System.out.println("Not a number");
}
finally
{
    System.out.println("Done");
}
```

**C#**

```csharp
try
{
    int result = int.Parse(text);
    Console.WriteLine(result);
}
catch (FormatException)
{
    Console.WriteLine("Not a number");
}
finally
{
    Console.WriteLine("Done");
}
```

If you never use the exception object, omit the variable. Writing `catch (FormatException ex)` and not touching `ex` produces warning CS0168.

The keywords `try`, `catch`, `finally`, and `throw` are the same in both languages. The exception types differ.

| Java | C# |
| --- | --- |
| `throw new IllegalArgumentException("...")` | `throw new ArgumentException("...")` |
| `NullPointerException` | `NullReferenceException` or `ArgumentNullException` |
| `IllegalStateException` | `InvalidOperationException` |
| `NumberFormatException` | `FormatException` |
| `IndexOutOfBoundsException` | `IndexOutOfRangeException` |
| `ArithmeticException` | `DivideByZeroException` or `OverflowException` |
| Custom class extends `Exception` | Custom class inherits from `Exception` |

### Common exception types

| C# exception | Thrown when |
| --- | --- |
| `ArgumentNullException` | A method receives `null` for a parameter it cannot accept |
| `ArgumentException` | An argument has an invalid value |
| `FormatException` | Text cannot be parsed as the target type |
| `InvalidOperationException` | The object is not in a valid state for the operation |
| `IndexOutOfRangeException` | An index is outside the bounds of an array or list |
| `NullReferenceException` | A reference is `null` when a value was expected |
| `DivideByZeroException` | Dividing an integer by zero |
| `FileNotFoundException` | A required file is missing |
| `NotImplementedException` | A method body is left as `throw new NotImplementedException();` |

### Adding messages and inner exceptions

```csharp
public static int ParsePositive(string text)
{
    if (!int.TryParse(text, out int value) || value <= 0)
    {
        throw new ArgumentException("Value must be a positive number.", nameof(text));
    }

    return value;
}
```

C# has no `catch (IOException e)`-style filtering of the thrown object, but it does support a `when` clause to match conditions:

```csharp
try
{
    int value = ParsePositive("abc");
}
catch (ArgumentException ex) when (ex.ParamName == "text")
{
    Console.WriteLine("The text argument was wrong.");
}
```

| Task | C# |
| --- | --- |
| Throw | `throw new InvalidOperationException("message");` |
| Throw without a message | `throw new NotImplementedException();` |
| Catch everything | `catch (Exception ex)` |
| Catch and act | `try`/`catch`, then continue |
| Always run cleanup | `finally` |
| Rethrow the same exception | `throw;` |
| Catch without using the exception object | `catch (FormatException)` |

## Small program comparison

**Java**

```java
public class Main
{
    public static void main(String[] args)
    {
        String name = "Asha";
        System.out.println("Hello, " + name);
    }
}
```

**C#**

```csharp
using System;

string name = "Asha";
Console.WriteLine($"Hello, {name}");
```

A new .NET console app can use top-level statements like the C# example. A traditional C# entry point uses `public static void Main(string[] args)`.

## Common Java-to-C# mistakes

| Java habit | C# correction |
| --- | --- |
| Writing `String` everywhere | Use `string`. |
| Writing `Boolean` | Use `bool`. |
| Calling `name.length()` | Use `name.Length`. |
| Calling `name.toUpperCase()` | Use `name.ToUpper()`. |
| Using `import` | Use `using`. |
| Using `extends` and `implements` separately | Use one `:` and commas. |
| Calling `student.getName()` | Use `student.Name`. |
| Writing `main` in lowercase | Use `Main` or top-level statements. |
| Forgetting a semicolon | Add `;` after statements. |
| Assuming `var` is dynamic | Treat it as compile-time type inference. |
| Assuming members are package-visible | C# members default to `private`. |
| Using `System.out.println` | Use `Console.WriteLine`. |
| Writing `for (String n : list)` | Use `foreach (string n in list)`. |
| Declaring or catching checked exceptions | C# has none; any method can throw any exception. |
| Catching `NumberFormatException` | Catch `FormatException`. |
| Using `int.Parse` in a `try` | Prefer `int.TryParse`, which returns `false` instead of throwing. |

## Final checklist

Before running a C# file, check:

- Did I use `string` and `bool`?
- Did I capitalize method and property names?
- Did I add semicolons after statements?
- Did I use `using` instead of `import`?
- Did I use a property instead of a Java-style getter?
- Did I write `Main` with an uppercase `M`, or use top-level statements?
- Did I remember that C# members are private by default?
- Did I use `string?` or another nullable type when `null` is intentional?
- Did I use `foreach` instead of a Java-style enhanced `for` loop?
- Did I use `int.TryParse` instead of `int.Parse` where the input might be invalid?

## Official references

- [C# language guide](https://learn.microsoft.com/en-us/dotnet/csharp/)
- [C# language reference](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
- [Nullable reference types](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/null-safety/nullable-reference-types)
- [Classes, structs, and records](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented)
- [Record types](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/records)
- [C# in Visual Studio Code](https://code.visualstudio.com/docs/languages/csharp)
