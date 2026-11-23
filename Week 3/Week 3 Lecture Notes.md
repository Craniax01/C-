# Week 3 — Operators, Control Flow and Exception Handling

**Module:** CS6004NI Application Development
**Week 3 of:** C# 14 on .NET 10

> **Toolchain note:** these notes assume the .NET 10 SDK and VS Code setup from [CSharp-DotNet-Setup.md](../Week%201/CSharp-DotNet-Setup.md). If you are translating from Java, keep [CSharp-Java-Syntax-Cheatsheet.md](../Week%201/CSharp-Java-Syntax-Cheatsheet.md) open beside this file. The worked project for this week is `OperatorsAndControlFlow/`, and the tasks are in [Week 3 Workshop - Operators, Control Flow and Exception Handling.md](Week%203%20Workshop%20-%20Operators,%20Control%20Flow%20and%20Exception%20Handling.md).

---

## Previously

Last week we covered [Week 2 — Variables and Datatypes](../Week%202/Week%202%20Lecture%20Notes.md): syntax essentials, variables and memory, strings, arrays and generic collections. You declared variables, chose types, stored values in arrays and lists, and printed them.

One thing to carry forward: a variable is a named box with a type, and the compiler checks that the value you put into the box has a compatible type. This week you make those values *do* something: compare them, combine them, branch on them, repeat actions and recover when something goes wrong.

---

## Overview of this week

- **Operators by operand count:** unary (one operand), binary (two), ternary (three).
- **Operators by function:** assignment, arithmetic, relational, logical, conditional and null coalescing.
- **Control flow:** `if`, `else if`, `else`, `switch`, `for`, `foreach`, `while`, `do-while`, `break` and `continue`.
- **Exception handling:** exceptions, `try`, `catch`, `finally`, `throw` and rethrow patterns.
- **Workshop:** six tasks in one console project, from reward points to a division calculator that survives bad input.

---

## 1. Operators

### 1.1 What an operator is

> **Analogy:** operators are the verbs of a programming language. The values they act on are the nouns (operands), and the whole phrase is an expression that produces a result.

```csharp
int result = 5 + 3;   // 5 and 3 are operands, + is the operator, the expression produces 8
```

| Part | Example | Role |
| --- | --- | --- |
| Operand | `5` | Value on the left |
| Operator | `+` | Action: add |
| Operand | `3` | Value on the right |
| Expression | `5 + 3` | Produces the result `8` |
| Statement | `int result = 5 + 3;` | Stores the result in a variable |

Why it matters in C#:

- Operators perform calculations: `+`, `-`, `*`, `/`, `%`.
- Operators compare values so the program can make decisions: `>`, `==`, `!=`.
- Operators are the building blocks of every expression, condition and loop.

### 1.2 Two ways to classify operators

**By number of operands** (the question the lecture asks first):

| Operator type | Description | Example |
| --- | --- | --- |
| Unary | Works on one operand; prefix (before) or postfix (after) | `--x`, `++i`, `!flag` |
| Binary | Works on two operands; the most common kind | `a + b`, `score > 100` |
| Ternary | Works on three operands; conditional assignment | `condition ? value1 : value2` |

**By function** (how the operator behaves):

| Function | Operators | Purpose |
| --- | --- | --- |
| Arithmetic | `+` `-` `*` `/` `%` | Calculate a number |
| Assignment | `=` `+=` `-=` `*=` `/=` `%=` | Store a value |
| Relational | `==` `!=` `>` `<` `>=` `<=` | Compare and produce `bool` |
| Logical | `&&` `\|\|` `!` | Combine booleans |
| Conditional | `?:` | Choose one of two values |
| Null coalescing | `??` `??=` | Supply a default for `null` |

The two classifications overlap. `++` is unary *and* arithmetic; `>` is binary *and* relational; `?:` is the only ternary operator in C#.

---

### 1.3 Unary operators

A unary operator acts on a single operand. In C# you use them to increment, decrement, negate or invert a boolean. They are common in counters, flags and loop control.

#### Increment: `++`

`++` increases a numeric or `char` operand by one. There are two forms, and they differ in *when* the new value is produced.

| Form | Name | Order of operations |
| --- | --- | --- |
| `++x` | Pre-increment | Increase `x`, then use the new value |
| `x++` | Post-increment | Use the current value of `x`, then increase it |

**Pre-increment — complete example:**

```csharp
int x = 10;
int y = ++x;                       // x becomes 11, then y receives 11
Console.WriteLine(y);              // output: 11
Console.WriteLine(x);              // output: 11
```

Step by step: `x` starts at `10`; `++x` changes it to `11`; the expression itself evaluates to `11`; `y` receives `11`.

**Post-increment — complete example:**

```csharp
int x = 10;
int y = x++;                       // y receives 10, then x becomes 11
Console.WriteLine(y);              // output: 10
Console.WriteLine(x);              // output: 11
```

Step by step: `x` starts at `10`; the expression `x++` evaluates to the old value `10`; `y` receives `10`; `x` is then increased to `11`.

#### Decrement: `--`

`--` decreases a numeric or `char` operand by one, with the same prefix/postfix distinction.

| Form | Name | Order of operations |
| --- | --- | --- |
| `--x` | Pre-decrement | Decrease `x`, then use the new value |
| `x--` | Post-decrement | Use the current value of `x`, then decrease it |

```csharp
int x = 10;
int y = --x;                       // x becomes 9, y receives 9
Console.WriteLine(y);              // output: 9

int a = 10;
int b = a--;                       // b receives 10, a becomes 9
Console.WriteLine(b);              // output: 10
Console.WriteLine(a);              // output: 9
```

#### Rules and quick tips

- Increment and decrement work on **numeric or `char` types only**. `++"hello"` is a compile-time error.
- In loops, `i++` is harmless because the returned value is ignored; only the side effect matters.
- > **Tip from the lecture:** to avoid confusion, put `++` and `--` on their own line rather than inside a complex expression. Compare `int y = x++;` with the clearer two-line form `int y = x; x++;`.
- The other common unary operator is `!` (logical NOT), covered in §1.6.

> **Analogy:** pre-increment is "take the next book from the shelf, then read its number"; post-increment is "read the number on the current book, then move to the next one".

---

### 1.4 Assignment operators

The simple assignment operator is `=`. It stores the value on its **right** in the variable on its **left**. A compound assignment performs an operation and stores the result back.

> **Trap from Week 2:** `=` assigns; `==` compares. `if (x = 5)` is a compile error (`CS0029`) because an assignment is not a `bool`.

| Operator | Meaning | Example | Equivalent to | Result when `x = 10` |
| --- | --- | --- | --- | --- |
| `=` | Assign the right-hand value | `x = 5;` | — | `x = 5` |
| `+=` | Add and assign | `x += 3;` | `x = x + 3;` | `x = 13` |
| `-=` | Subtract and assign | `x -= 4;` | `x = x - 4;` | `x = 6` |
| `*=` | Multiply and assign | `x *= 2;` | `x = x * 2;` | `x = 20` |
| `/=` | Divide and assign | `x /= 5;` | `x = x / 5;` | `x = 2` |
| `%=` | Remainder and assign | `x %= 3;` | `x = x % 3;` | `x = 1` |

Each row above assumes a **fresh** `x = 10`; the equivalences are evaluated independently.

```csharp
int score = 100;                   // simple assignment
score += 10;                       // same as score = score + 10 → 110
Console.WriteLine(score);          // output: 110
```

> **Analogy:** `x += 3` is a label that says "whatever is in this box, add three and put it back". It saves you from writing the variable name twice.

---

### 1.5 Relational (comparison) operators

Relational operators compare two values and always return `bool` (`true` or `false`). They are the conditions used by `if`, `while` and `for`.

| Operator | Name | Example | Result |
| --- | --- | --- | --- |
| `==` | Equal to | `5 == 5` | `true` |
| `!=` | Not equal to | `5 != 3` | `true` |
| `>` | Greater than | `10 > 5` | `true` |
| `<` | Less than | `3 < 8` | `true` |
| `>=` | Greater than or equal to | `7 >= 7` | `true` |
| `<=` | Less than or equal to | `4 <= 9` | `true` |

```csharp
int age = 20;
bool isAdult = age >= 18;          // evaluates to true
Console.WriteLine(isAdult);        // output: True
```

Remember that `bool` prints as `True`/`False` with capital letters in C#, while the literals in code are lowercase `true`/`false`.

---

### 1.6 Logical operators

Logical operators combine boolean expressions.

| Operator | Name | Description | Example | Result |
| --- | --- | --- | --- | --- |
| `&&` | Logical AND | `true` only if **both** sides are `true` | `(5 > 3) && (8 > 6)` | `true` |
| `\|\|` | Logical OR | `true` if **at least one** side is `true` | `(5 > 3) \|\| (8 < 6)` | `true` |
| `!` | Logical NOT | Reverses the boolean | `!(5 > 3)` | `false` |

`&&` and `||` **short-circuit**:

- With `&&`, if the left side is `false`, the right side is not evaluated.
- With `||`, if the left side is `true`, the right side is not evaluated.

This matters when the right side could fail. In the condition below, `number` is never divided by zero when it is zero, because the left side is already `false`:

```csharp
int number = 0;
if (number != 0 && 10 / number > 1)
{
    Console.WriteLine("Safe division");
}
// output: (nothing) — the right side is skipped, so no DivideByZeroException
```

```csharp
bool hasTicket = true;
int age = 18;
bool canEnterMovie = hasTicket && (age >= 18); // true && true → true
Console.WriteLine(canEnterMovie);              // output: True
```

> **Analogy:** `&&` is a two-lock door — both keys must work. `||` is a door with two buttons — either one opens it. Short-circuiting means you do not bother trying the second key once the first one has already failed.

---

### 1.7 Conditional (ternary) operator `?:`

The conditional operator is a shorthand for a simple `if-else` that **returns a value**, so you can assign it directly to a variable.

```csharp
condition ? value_if_true : value_if_false
```

```csharp
int userScore = 85;
string result = userScore > 70 ? "Pass" : "Fail"; // result is "Pass"
Console.WriteLine(result);                        // output: Pass
```

**Type compatibility rule:** both result expressions must have a common type. The compiler does not guess.

```csharp
int a = 10;
int b = 5;
var result = (a > b) ? "Yes" : 0; // ERROR CS0173
```

The exact compiler message is:

```text
CS0173: Type of conditional expression cannot be determined because there is no
implicit conversion between 'string' and 'int'
```

**Fix:** make both branches the same type, for example `string result = (a > b) ? "Yes" : "0";`, or convert explicitly: `string result = (a > b) ? "Yes" : 0.ToString();`.

#### Quiz — lecture slide 23

What is the output of this program?

```csharp
int x = 10;
int y = 20;

string result = (x > y) ? "X is greater"
               : (x == y) ? "Equal"
               : "Y is greater";
Console.WriteLine(result);
```

a) `X is greater`
b) `Equal`
c) Compile-time error
d) `Y is greater`

**Answer: d) `Y is greater`.** `x > y` is `10 > 20`, which is `false`, so the second ternary is evaluated. `x == y` is also `false`, so the final branch `"Y is greater"` is chosen. The nested ternary is read right-to-left because `?:` is right-associative. For three or more branches, prefer an `if-else-if` ladder or `switch` expression for readability.

---

### 1.8 Null coalescing operators `??` and `??=`

These operators handle nullable values safely and provide defaults without a long `if` statement.

| Operator | Name | Description |
| --- | --- | --- |
| `??` | Null coalescing | Returns the left operand if it is not `null`; otherwise returns the right operand |
| `??=` | Null coalescing assignment | Assigns the right-hand value to the left-hand variable **only** if that variable is `null` |

**`??` example (from the lecture):**

```csharp
string? studentName = null;                 // ? allows null without a CS8600 warning
string showStudentName = studentName ?? "Student";
Console.WriteLine($"Student Name: {showStudentName}");
// output: Student Name: Student
```

If `studentName` had been `"Anita"`, the output would be `Student Name: Anita` — the left side is used whenever it is not `null`.

**`??=` example (from the lecture):**

```csharp
string? teacherName = null;
teacherName ??= "Teacher";                  // assigns because teacherName is null
Console.WriteLine($"Teacher Name: {teacherName}");
// output: Teacher Name: Teacher
```

If `teacherName` had already held `"Mr. Shah"`, `??=` would leave it unchanged.

> **Analogy:** `??` is a spare pen you use only when your own pen is missing. `??=` is the act of putting that spare pen into the empty slot so it is there next time.

---

### 1.9 Operator reference and precedence

When an expression has several operators, precedence decides which one runs first. Parentheses override precedence.

| Precedence (high → low) | Operators | Associativity |
| --- | --- | --- |
| 1 | `++` `--` (postfix) | left → right |
| 2 | `++` `--` (prefix), `!`, unary `+` `-` | right → left |
| 3 | `*` `/` `%` | left → right |
| 4 | `+` `-` | left → right |
| 5 | `<` `>` `<=` `>=` | left → right |
| 6 | `==` `!=` | left → right |
| 7 | `&&` | left → right |
| 8 | `\|\|` | left → right |
| 9 | `??` | right → left |
| 10 | `?:` | right → left |
| 11 | `=` and compound assignments | right → left |

```csharp
int value = 2 + 3 * 4;         // 14: * runs before +
int grouped = (2 + 3) * 4;     // 20: parentheses change the order
Console.WriteLine($"{value}, {grouped}"); // output: 14, 20
```

> **Rule:** if you have to pause to think about precedence, add parentheses. They cost nothing and make the code unambiguous to the next reader.

---

### 1.10 Traps worth knowing

| Trap | Wrong code | What happens | Correct code |
| --- | --- | --- | --- |
| `=` instead of `==` | `if (x = 5)` | `CS0029`: assignment cannot be a condition | `if (x == 5)` |
| Mixed ternary types | `flag ? "Yes" : 0` | `CS0173` | `flag ? "Yes" : "0"` |
| `null` in a non-nullable string | `string name = null;` | Warning `CS8600` | `string? name = null;` |
| Text plus number | `"5" + 3` | Gives `"53"`, not `8` | `5 + int.Parse("3")` |
| Prefix vs postfix | `int y = x++;` | `y` gets the old value | `int y = ++x;` if you want the new value |

---

## 2. Control Flow

### 2.1 What control flow is

> **Analogy:** code normally runs top to bottom like a recipe. Control-flow statements are the instructions that say "only do this step if…" and "repeat that step until…".

Control flow is the order in which statements execute. Without it, a program can only run every line once, in order. With it, programs can:

- **Make decisions:** run different blocks based on a condition, for example show a profile only when a user is logged in.
- **Repeat actions:** process every item in a list without writing the same code five times.

### 2.2 The `if` statement

An `if` statement runs its block **only** when its boolean expression is `true`. If the condition is `false`, nothing else happens.

```csharp
int batteryLevel = 15;
if (batteryLevel <= 15)
{
    Console.WriteLine("Battery low: Please charge your device.");
}
// output: Battery low: Please charge your device.
```

The condition must be a `bool`. `if (batteryLevel)` does not compile, because an `int` is not a `bool`.

### 2.3 The `if-else` statement

Use `if-else` when you need an alternative action for the `false` case.

```csharp
string enteredPassword = "P@ssw0rd";
string correctPassword = "P@ssw0rd";

if (enteredPassword == correctPassword)
{
    Console.WriteLine("Access Granted");
}
else
{
    Console.WriteLine("Invalid Password");
}
// output: Access Granted
```

> **Real-world use:** a login system grants access on a correct password and shows an error message otherwise.

### 2.4 The `if-else-if` ladder

Use a ladder when there are several mutually exclusive conditions. C# tests them from top to bottom and runs **only the first matching block**.

```csharp
int age = 70;
bool isStudent = false;

if (age < 12)
{
    Console.WriteLine("Child discount applied");
}
else if (age >= 60)
{
    Console.WriteLine("Senior citizen discount applied");
}
else if (isStudent)
{
    Console.WriteLine("Student discount applied");
}
else
{
    Console.WriteLine("No discount applied");
}
// output: Senior citizen discount applied
```

Order matters. If `age < 12` came after `age >= 60`, it would still work here because the ranges do not overlap, but overlapping conditions must be ordered from most specific to least specific.

> **Real-world use:** movie ticket pricing — child (under 12), senior (60+), student, otherwise regular price.

### 2.5 Best practice: braces and the stray semicolon

Always use braces, even for a single statement. Always indent the body of both `if` and `else`.

```csharp
if (x > 10)
{
    Console.WriteLine("x is greater than 10");
}
```

The following is a **logical error**. The semicolon after the condition makes the body empty, so the message prints regardless of `x`:

```csharp
int x = 5;
if (x > 10);                      // <-- stray semicolon: empty statement
{
    Console.WriteLine("x is greater than 10");
}
// output: x is greater than 10   (wrong! x is 5)
```

The compiler accepts this because `;` is a valid empty statement. It is one of the most frequent logic errors in `if` statements, and braces alone would not have caught it.

### 2.6 The `switch` statement

`switch` is a multiway branch: it selects one block based on the value of an expression. The `default` block is optional; it runs when no `case` matches.

```csharp
string action = "Play";

switch (action)
{
    case "Play":
        Console.WriteLine("Playing the game!");
        break;
    case "Pause":
        Console.WriteLine("Music paused.");
        break;
    case "Next":
        Console.WriteLine("Next track.");
        break;
    default:
        Console.WriteLine("Continue music");
        break;
}
// output: Playing the game!
```

Rules to remember:

- Each `case` that contains statements must end with `break;` (or another jump statement) so execution does not fall through to the next case.
- `default` is the `else` of a switch. Put it last by convention.
- C# also has a compact **switch expression** (`action switch { "Play" => "...", _ => "..." }`) for returning a value; the statement form above is the one used in the workshop.

> **Real-world use:** a media player responding to Play, Pause, Stop or Rewind.

### 2.7 The `for` loop

Use `for` when you know **exactly how many times** to loop. The loop variable is declared, tested and updated in one line.

```csharp
for (int i = 1; i <= 6; i++)
{
    Console.WriteLine("Checking motion sensor...");
    // wait for 10 seconds
}
// output: "Checking motion sensor..." six times
```

| Part | Example | Role |
| --- | --- | --- |
| Initialiser | `int i = 1` | Runs once before the loop |
| Condition | `i <= 6` | Checked before each iteration; loop stops when `false` |
| Iterator | `i++` | Runs after each iteration |

> **Real-world use:** a security sensor checked every 10 seconds for one minute — six checks, known in advance.

### 2.8 The `foreach` loop

Use `foreach` to visit every item in a collection, such as an array or list. You do not manage an index.

```csharp
string[] studentEmails =
{
    "manoj@gmail.com",
    "shree@gmail.com",
    "prakriti@gmail.com",
    "ayush@gmail.com"
};

foreach (string email in studentEmails)
{
    Console.WriteLine($"Sending reminder to {email}");
}
```

> **Real-world use:** send a reminder to every address in a mailing list. Use `for` instead when you need the position, and `foreach` when you only need the items.

### 2.9 Nested loops

A loop inside a loop runs the inner loop once for every iteration of the outer loop.

```csharp
for (int i = 1; i <= 3; i++)
{
    for (int j = 1; j <= 2; j++)
    {
        Console.WriteLine("Loop");
    }
}
```

#### Quiz — lecture slide 42

How many times is `Loop` printed? a) 3  b) 6  c) 5  d) 9

**Answer: b) 6.** The outer loop runs 3 times; each of those runs the inner loop 2 times: `3 × 2 = 6`. The general rule for independent nested loops is to multiply the iteration counts.

### 2.10 The `while` loop

Use `while` when the number of iterations is **not known in advance**. The condition is checked **before** each iteration, so the body may run zero times.

```csharp
string userInput = "";

while (userInput != "quit")
{
    Console.WriteLine("Type 'quit' to exit.");
    userInput = Console.ReadLine() ?? "";
}
```

> **Real-world use:** a game keeps accepting input until the player types "quit". Remember to change the variable used in the condition inside the loop, or you create an infinite loop.

### 2.11 The `do-while` loop

A `do-while` loop is exit-controlled: the body runs first, then the condition is checked. The body therefore runs **at least once**.

```csharp
string correctPin = "1234";
string? enteredPin;

do
{
    Console.Write("Enter your PIN: ");
    enteredPin = Console.ReadLine();
}
while (enteredPin != correctPin);

Console.WriteLine("PIN accepted. Access granted!");
```

Notice the **semicolon after the closing parenthesis** of the `while` clause — it is required for `do-while`, unlike a normal `while` loop.

> **Real-world use:** an ATM prompts for a PIN at least once and keeps asking until the correct PIN is entered.

### 2.12 Choosing the right loop

| Loop | Condition checked | Use when |
| --- | --- | --- |
| `for` | Before each iteration | You know the exact count, or need an index |
| `foreach` | Implicit (items remaining) | You need every element of a collection |
| `while` | Before each iteration | The count is unknown and zero iterations are possible |
| `do-while` | After each iteration | The body must run at least once |

### 2.13 Jump statements: `break` and `continue`

Jump statements alter the normal flow of a loop.

**`break` leaves the loop immediately:**

```csharp
for (int i = 1; i <= 5; i++)
{
    if (i == 3)
    {
        Console.WriteLine("Stopping at " + i);
        break;                     // exits the loop
    }
    Console.WriteLine("Number: " + i);
}
```

```text
Number: 1
Number: 2
Stopping at 3
```

**`continue` skips the rest of the current iteration:**

```csharp
for (int i = 1; i <= 5; i++)
{
    if (i == 3)
    {
        continue;                  // skip when i is 3
    }
    Console.WriteLine("Number: " + i);
}
```

```text
Number: 1
Number: 2
Number: 4
Number: 5
```

> **Analogy:** `break` is leaving the cinema; `continue` is walking out of one screening and going straight into the next one without watching the rest of the current film.

---

## 3. Exception Handling

### 3.1 Errors, exceptions and why they matter

An **exception** is an event during execution that disrupts the normal flow of instructions — for example dividing by zero, reading a missing file or indexing past the end of an array.

- A **compile-time error** (such as `CS1002`) stops the program from building.
- A **runtime exception** builds fine but happens while the program is running.

Why handling matters in C#:

- **Prevent crashes:** an unhandled exception terminates the program.
- **Build robust software:** unexpected situations can be handled gracefully.
- **Meet professional standards:** production code does not let raw stack traces reach users.

### 3.2 An unhandled exception

```csharp
int[] numbers = { 1, 2, 3, 4, 5 };
Console.WriteLine(numbers[5]);     // trying to print the 6th element of a 5-element array
```

The array has valid indexes `0` to `4`. Index `5` is outside the bounds, so the program stops with:

```text
System.IndexOutOfRangeException: 'Index was outside the bounds of the array.'
```

### 3.3 The `try-catch` block

The `try` block holds code that might throw. The `catch` block runs when a matching exception is thrown.

```csharp
try
{
    int[] numbers = { 1, 2, 3, 4, 5 };
    Console.WriteLine(numbers[5]);
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}
```

Output instead of a crash:

```text
An error occurred: Index was outside the bounds of the array.
```

The program then continues to the next statement and exits normally. `ex.Message` is the human-readable description supplied by the exception.

### 3.4 Multiple `catch` blocks

C# tests `catch` blocks **in order**, so put the most specific exception types first. Here is the division calculator from the lecture, adapted with `?? ""` so nullable warnings do not distract from the exception handling:

```csharp
Console.Write("Enter a number: ");
string input = Console.ReadLine() ?? "";

try
{
    int number = int.Parse(input);
    int result = 10 / number;      // throws DivideByZeroException when number is 0
    Console.WriteLine($"Result: {result}");
}
catch (FormatException)
{
    Console.WriteLine("Error: That's not a valid number!");
}
catch (DivideByZeroException)
{
    Console.WriteLine("Error: Cannot divide by zero!");
}
```

| Input | Output |
| --- | --- |
| `2` | `Result: 5` |
| `abc` | `Error: That's not a valid number!` |
| `0` | `Error: Cannot divide by zero!` |

`int.Parse("abc")` throws `FormatException`; `10 / 0` throws `DivideByZeroException`. Each is caught by its own block.

### 3.5 The `finally` block

`finally` runs whether or not an exception occurred. It is the right place for cleanup such as closing a file or a connection.

```csharp
StreamReader? reader = null;

try
{
    reader = new StreamReader("file.txt");
    string content = reader.ReadToEnd();
    Console.WriteLine(content);
}
catch (FileNotFoundException)
{
    Console.WriteLine("File was not found.");
}
finally
{
    reader?.Close();               // null-conditional: safe even if opening failed
    Console.WriteLine("Cleanup completed");
}
```

If `file.txt` exists, its content then `Cleanup completed` are printed. If it does not exist, `File was not found.` then `Cleanup completed` are printed. The `?.` operator calls `Close()` only when `reader` is not `null`.

A `try` statement can be `try-catch`, `try-finally`, or `try-catch-finally`. A `finally` block without a `catch` still runs, but the exception continues upward afterwards.

### 3.6 `throw` and rethrow patterns

You can create an exception yourself with `throw`, and you can pass an exception on after adding context.

**Throw a new exception with an inner exception:**

```csharp
try
{
    int age = int.Parse("abc");
}
catch (FormatException ex)
{
    throw new ArgumentException("Age must be a whole number.", "age", ex);
}
```

**Rethrow the same exception with a bare `throw;`:**

```csharp
try
{
    int[] values = { 1, 2, 3 };
    Console.WriteLine(values[9]);
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine("Logging: an index was out of range.");
    throw;                         // preserves the original stack trace
}
```

Use `throw;` when the caller should handle the same exception. Use `throw new ...(..., ex);` when you want to change the exception type while keeping the original cause. Avoid `catch (Exception)` as a catch-all in normal code: catch the specific exceptions you expect.

### 3.7 Common exception types

| Exception | Typical cause |
| --- | --- |
| `FormatException` | `int.Parse("abc")` — text is not in the expected format |
| `DivideByZeroException` | Integer division by zero |
| `IndexOutOfRangeException` | Array index outside `0 … Length - 1` |
| `NullReferenceException` | Calling a member on a `null` reference |
| `FileNotFoundException` | Opening a file that does not exist |
| `InvalidOperationException` | An operation is not valid in the object's current state |
| `ArgumentException` | A method received an invalid argument |

`TryParse` (from the Week 1 cheatsheet) avoids `FormatException` altogether when invalid input is expected: `int.TryParse(input, out int number)` returns `false` instead of throwing.

---

## 4. If you know Java

| Java | C# | Note |
| --- | --- | --- |
| `++i`, `i++`, `--i`, `i--` | Same | Same prefix/postfix behaviour |
| `+=`, `-=`, `*=`, `/=`, `%=` | Same | Same compound assignment operators |
| `==`, `!=`, `>`, `<`, `>=`, `<=` | Same | C# strings also compare with `==` by value |
| `&&`, `\|\|`, `!` | Same | Both short-circuit in the same way |
| `condition ? a : b` | Same | Both branches must share a type |
| No built-in equivalent | `??`, `??=` | Java uses `Optional.orElse` for similar defaults |
| `if`, `else if`, `else` | Same | C# requires `bool`, not an integer |
| `switch` (with `break`) | Same | C# 8+ also has switch expressions |
| Enhanced `for (T item : items)` | `foreach (T item in items)` | C# needs the `in` keyword |
| `Integer.parseInt(text)` | `int.Parse(text)` | `int.TryParse` is the non-throwing version |
| `try`, `catch`, `finally` | Same | C# rarely catches `Exception` broadly |
| `throw new IOException(...)` | `throw new IOException(...)` | Same syntax; `throw;` also rethrows |
| `System.out.println` | `Console.WriteLine` | Same idea, different class |
| `list.size()` | `list.Count` | Property, not a method |

> **One thing to stop assuming:** Java lets you write `if (someInt)` only when the type is `boolean`; C# enforces this even more strictly with a real `bool` type, and its nullable annotations (`string?`) make "might be null" explicit in the type itself.

---

## 5. Common build errors and runtime exceptions

| Message | Cause | Fix |
| --- | --- | --- |
| `CS0029` | `if (x = 5)` — assignment used as a condition | Use `==` |
| `CS0173` | Ternary branches have incompatible types, e.g. `string` and `int` | Make both branches the same type |
| `CS8600` | Assigning `null` to a non-nullable `string` | Declare `string?` |
| `CS8602` | Dereferencing a possibly null value | Check for `null` or use `?.` / `??` |
| `CS1002` | `;` expected, often a missing semicolon after a statement | Add the semicolon |
| `CS0165` | Use of an unassigned local variable | Give the variable an initial value before reading it |
| `CS0131` | Assignment to a constant, e.g. `Circle.PI = 3.15;` | Do not assign to `const` |
| `CS0246` | Type or namespace not found | Check the spelling and the namespace |
| `CS1503` | Argument type does not match parameter type | Parse or convert the value first |
| `IndexOutOfRangeException` (runtime) | Array index outside its bounds | Check `index >= 0 && index < array.Length` |
| `FormatException` (runtime) | `int.Parse` on non-numeric text | Use `TryParse` or catch `FormatException` |
| `DivideByZeroException` (runtime) | Integer division by zero | Check the divisor or catch the exception |
| `NullReferenceException` (runtime) | Member access on `null` | Initialise the object or use `?.` |
| Infinite loop (no compiler error) | `while` condition never changes | Update the condition variable inside the loop |
| Wrong `if` result (no compiler error) | Stray semicolon after `if (...)` | Remove the semicolon and use braces |

A **warning** (such as `CS8600`) does not stop the build; an **error** does. Treat warnings as signals to make your intent explicit.

---

## 6. Summary

- Operators are classified by operands (unary, binary, ternary) and by function (assignment, arithmetic, relational, logical, conditional, null coalescing).
- `++x` changes first then returns; `x++` returns first then changes. Keep them on their own lines in expressions.
- Compound assignment (`+=`, `*=`, …) stores the result back in the same variable.
- Relational operators return `bool`; `&&` and `||` short-circuit.
- The ternary operator returns a value, but both branches must have a compatible type.
- `??` supplies a default for `null`; `??=` assigns that default into the variable.
- Use `if-else-if` for a decision ladder and `switch` for a multiway branch on one value; always use braces and watch for stray semicolons.
- Choose `for` for a known count, `foreach` for collections, `while` for unknown counts and `do-while` for "at least once".
- `break` exits a loop; `continue` skips to the next iteration.
- An exception is a runtime disruption. `try` wraps risky code, `catch` handles specific exception types and `finally` always cleans up.
- See [the workshop](Week%203%20Workshop%20-%20Operators,%20Control%20Flow%20and%20Exception%20Handling.md) for six tasks that use every one of these ideas.

---

## References

- [Previous week: Variables and Datatypes](../Week%202/Week%202%20Lecture%20Notes.md)
- [Previous week: Workshop 2](../Week%202/Week%202%20Workshop%20-%20Variables%20and%20Datatypes.md)
- [Week 1: C# / Java syntax cheatsheet](../Week%201/CSharp-Java-Syntax-Cheatsheet.md)
- [C# operators (Microsoft Learn)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/)
- [Selection statements: if and switch (Microsoft Learn)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements)
- [Iteration statements: loops (Microsoft Learn)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements)
- [Exceptions and exception handling (Microsoft Learn)](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/)
- [try, catch and finally (Microsoft Learn)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch)
- [Null coalescing operators (Microsoft Learn)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator)
- [Conditional operator ?: (Microsoft Learn)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator)
