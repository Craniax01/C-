# Workshop 3 — Operators, Control Flow and Exception Handling

**Module:** CS6004NI Application Development
**Duration:** 90 minutes of student tasks (20-minute teacher debrief + 10-minute review = 120-minute session)

In this workshop you will write and run one console program that uses operators, control flow and exception handling. Complete all six tasks **individually** inside a single project, in the order given. Every task adds code to the same `Program.cs`; do not create a new project for each task.

> The concepts are explained in [Week 3 Lecture Notes.md](Week%203%20Lecture%20Notes.md). The finished project is at `OperatorsAndControlFlow/Program.cs` and the full solution is reproduced at the end of this document for checking.

---

## Task overview

| Task | Topic | Time |
| --- | --- | --- |
| 1 | College Reward Points — compound assignment, comparison, `++` | 10 min |
| 2 | Student Exam Result — `if` / `else if` / `else`, `&&` | 15 min |
| 3 | Library Menu — `switch`, `??`, `??=` | 15 min |
| 4 | Weekly Attendance — `foreach`, `for`, `while`, `do-while` | 15 min |
| 5 | Exam Hall Seat Labels — nested `for`, `continue`, `break` | 15 min |
| 6 | Simple Division Calculator — `try`, `catch`, `finally` | 20 min |

---

## Before you start

1. Open a terminal in the `Week 3` folder (`/Users/rocco/Documents/C#/Week 3` on this machine).
2. Run exactly this command:

   ```bash
   dotnet new console -n OperatorsAndControlFlow --framework net10.0
   ```

3. Open `OperatorsAndControlFlow/Program.cs`. The template contains one line, `Console.WriteLine("Hello, World!");`. **Replace that line** with the structure below; do not leave the template line in place.

```csharp
namespace OperatorsAndControlFlow
{
    class Program
    {
        static void Main()
        {
            // Add Task 1 to Task 6 here, in this order.
        }
    }
}
```

4. Keep the namespace, class and method names exactly as shown. Add each new task **below** the previous one, inside `Main`.
5. Build after each task with `dotnet build` from the `OperatorsAndControlFlow` folder, or run everything at the end with:

   ```bash
   dotnet run --project OperatorsAndControlFlow/OperatorsAndControlFlow.csproj
   ```

---

## Task 1 — College Reward Points

**Goal:** update a score with compound assignment, compare it, and demonstrate the difference between post-increment and pre-increment.

A student begins a competition with **10** reward points. The student earns **5** extra points, then **doubles** the total after completing a challenge.

### Step 1 — Write the code

Add this block inside `Main`:

```csharp
// ---- Task 1 ----
int points = 10;                 // TODO 1: start with 10 points
// TODO 2: add 5 using +=, then double using *=
// TODO 3: compare final points with 25 using >= and print the bool
// TODO 4: use points++ and ++points in two separate expressions
```

### Step 2 — Fill in the TODOs

<details>
<summary>Hint — exact code for TODO 2 to TODO 4</summary>

```csharp
points += 5;
points *= 2;
Console.WriteLine($"Final points: {points}");

bool atLeast25 = points >= 25;
Console.WriteLine($"At least 25 points: {atLeast25}");

int afterPost = points++;        // returns 30, then stores 31
Console.WriteLine($"points++ returned {afterPost}; points is now {points}");

int afterPre = ++points;         // stores 32, then returns 32
Console.WriteLine($"++points returned {afterPre}; points is now {points}");
```

`points++` returns the **old** value before increasing; `++points` increases first and then returns the **new** value. Both end up increasing `points` by one.

</details>

### Step 3 — Build and run

```bash
dotnet run --project OperatorsAndControlFlow/OperatorsAndControlFlow.csproj
```

Expected output for Task 1 (the remaining tasks are not added yet):

```text
Final points: 30
At least 25 points: True
points++ returned 30; points is now 31
++points returned 32; points is now 32
```

### Check your work

- ☐ `points` is `30` after `+= 5` and `*= 2`.
- ☐ The comparison used `>=`, and the printed value is `True`.
- ☐ `points++` returned `30` and left `points` as `31`.
- ☐ `++points` returned `32` and left `points` as `32`.

---

## Task 2 — Student Exam Result

**Goal:** choose one grade with an `if` / `else if` / `else` ladder, and combine two conditions with `&&`.

A lecturer needs a console program that displays a student's grade and pass eligibility. Use `int marks = 72;` and `int attendance = 80;` for the first run.

### Step 1 — Write the code

```csharp
// ---- Task 2 ----
int marks = 72;                  // TODO 1: change these two values to test
int attendance = 80;

// TODO 2: grade A for 80+, B for 65–79, C for 50–64, otherwise Fail
string grade = "";

// TODO 3: eligible when marks >= 50 AND attendance >= 75
bool isEligible = false;

Console.WriteLine($"Marks: {marks}, Attendance: {attendance}");
Console.WriteLine($"Grade: {grade}");
Console.WriteLine($"Pass eligible: {isEligible}");
```

### Step 2 — Fill in the TODOs

<details>
<summary>Hint — exact ladder and logical expression</summary>

```csharp
if (marks >= 80)
{
    grade = "A";
}
else if (marks >= 65)
{
    grade = "B";
}
else if (marks >= 50)
{
    grade = "C";
}
else
{
    grade = "Fail";
}

isEligible = marks >= 50 && attendance >= 75;
```

`&&` is `true` only when **both** comparisons are `true`. The ladder tests from the highest band down, so only one `grade` value is assigned.

</details>

### Step 3 — Build and run

Expected output for Task 2 with the starting values:

```text
Marks: 72, Attendance: 80
Grade: B
Pass eligible: True
```

Then change the two values and record what happens:

| `marks` | `attendance` | Expected grade | Expected eligibility |
| --- | --- | --- | --- |
| `85` | `90` | `A` | `True` |
| `72` | `70` | `B` | `False` |
| `55` | `80` | `C` | `True` |
| `40` | `90` | `Fail` | `False` |

Restore `marks = 72` and `attendance = 80` before continuing to Task 3.

### Check your work

- ☐ The ladder uses `if`, two `else if` branches and one `else`.
- ☐ Every grade boundary produces the value in the table above.
- ☐ Eligibility uses `&&`, not `||`.

---

## Task 3 — Library Menu

**Goal:** use `switch` with a `default` case, and use `??` and `??=` with a nullable string.

A library console menu offers three services: `1. Borrow`, `2. Return`, `3. Renew`.

### Step 1 — Write the code

```csharp
// ---- Task 3 ----
int choice = 2;                  // TODO 1: test with 1, 3 and 9
Console.WriteLine("Library Menu");
Console.WriteLine("1. Borrow   2. Return   3. Renew");
Console.WriteLine($"Selected choice: {choice}");

// TODO 2: switch on choice with cases 1, 2, 3 and a default

string? userName = null;         // TODO 3: ?? displays "Guest"
// TODO 4: ??= assigns "Guest" only when userName is null
```

### Step 2 — Fill in the TODOs

<details>
<summary>Hint — exact switch and null-coalescing code</summary>

```csharp
switch (choice)
{
    case 1:
        Console.WriteLine("You selected Borrow.");
        break;
    case 2:
        Console.WriteLine("You selected Return.");
        break;
    case 3:
        Console.WriteLine("You selected Renew.");
        break;
    default:
        Console.WriteLine("Invalid choice.");
        break;
}

string displayName = userName ?? "Guest";
Console.WriteLine($"Display name: {displayName}");

userName ??= "Guest";
Console.WriteLine($"userName after ??=: {userName}");
```

Each case with statements ends in `break;`. `??` returns `"Guest"` for this run without changing `userName`; `??=` then stores `"Guest"` in `userName` because it was `null`.

</details>

### Step 3 — Build and run

Expected output for Task 3 with `choice = 2`:

```text
Library Menu
1. Borrow   2. Return   3. Renew
Selected choice: 2
You selected Return.
Display name: Guest
userName after ??=: Guest
```

Now change only `choice` and confirm:

| `choice` | Expected message |
| --- | --- |
| `1` | `You selected Borrow.` |
| `3` | `You selected Renew.` |
| `9` | `Invalid choice.` |

Restore `choice = 2` before continuing.

### Check your work

- ☐ The switch has exactly four branches, including `default`.
- ☐ Every branch ends with `break;`.
- ☐ `??` printed `Guest`; `??=` stored `Guest` in `userName`.

---

## Task 4 — Weekly Attendance

**Goal:** use all four loop forms and accumulate a total.

A class representative records attendance from Monday to Friday: `int[] attendance = {20, 22, 21, 24, 23};`.

### Step 1 — Write the code

Use `dailyAttendance` as the variable name, because `attendance` is already used in Task 2 in the same `Main` method.

```csharp
// ---- Task 4 ----
int[] dailyAttendance = { 20, 22, 21, 24, 23 }; // TODO 1: Monday to Friday
int total = 0;

// TODO 2: foreach — print each value and add it to total
// TODO 3: for — print "Day 1: 20" through "Day 5: 23"
// TODO 4: while — count down from 3 to 1
// TODO 5: do-while — print "Attendance recorded" once with runAgain = false
```

### Step 2 — Fill in the TODOs

<details>
<summary>Hint — exact loop code</summary>

```csharp
Console.WriteLine("Daily attendance:");
foreach (int present in dailyAttendance)
{
    Console.WriteLine($"  {present}");
    total += present;
}
Console.WriteLine($"Total attendance: {total}");

for (int i = 0; i < dailyAttendance.Length; i++)
{
    Console.WriteLine($"Day {i + 1}: {dailyAttendance[i]}");
}

int countdown = 3;
while (countdown >= 1)
{
    Console.WriteLine(countdown);
    countdown--;
}

bool runAgain = false;
do
{
    Console.WriteLine("Attendance recorded");
}
while (runAgain);
```

`foreach` needs no index. The `for` loop uses `i + 1` for the day number because array indexes start at `0`. The `while` loop changes `countdown` on every iteration, so it terminates. The `do-while` body runs once **before** `runAgain` is checked, which is why `false` still produces one line. The semicolon after `while (runAgain);` is required for `do-while`.

</details>

### Step 3 — Build and run

Expected output for Task 4:

```text
Daily attendance:
  20
  22
  21
  24
  23
Total attendance: 110
Day 1: 20
Day 2: 22
Day 3: 21
Day 4: 24
Day 5: 23
3
2
1
Attendance recorded
```

### Check your work

- ☐ The total is `110`.
- ☐ `foreach` printed five values; `for` printed five labelled days.
- ☐ `while` printed `3`, `2`, `1` and then stopped.
- ☐ `do-while` printed `Attendance recorded` exactly once with `runAgain = false`.

---

## Task 5 — Exam Hall Seat Labels

**Goal:** use nested `for` loops, then control a loop with `continue` and `break`.

An exam hall has **3 rows** with **4 seats** in each row.

### Step 1 — Write the code

```csharp
// ---- Task 5 ----
// TODO 1: nested for loops printing "Row 1 - Seat 1" to "Row 3 - Seat 4"
// TODO 1: count and print the total number of seats
// TODO 2: for 1 to 10, continue at 5 and break at 8
Console.Write("Loop values: ");
```

### Step 2 — Fill in the TODOs

<details>
<summary>Hint — exact nested loop and jump statements</summary>

```csharp
int seatCount = 0;

for (int row = 1; row <= 3; row++)
{
    for (int seat = 1; seat <= 4; seat++)
    {
        Console.WriteLine($"Row {row} - Seat {seat}");
        seatCount++;
    }
}
Console.WriteLine($"Total seats: {seatCount}");

for (int i = 1; i <= 10; i++)
{
    if (i == 5)
    {
        continue;                // skip printing 5
    }
    if (i == 8)
    {
        break;                   // leave the loop before printing 8
    }
    Console.Write($"{i} ");
}
Console.WriteLine();
```

The inner loop completes all four seats for each row. `continue` jumps to the next iteration, so `5` is never printed. `break` exits the loop entirely, so `8`, `9` and `10` are never printed.

</details>

### Step 3 — Build and run

Expected output for Task 5:

```text
Row 1 - Seat 1
Row 1 - Seat 2
Row 1 - Seat 3
Row 1 - Seat 4
Row 2 - Seat 1
Row 2 - Seat 2
Row 2 - Seat 3
Row 2 - Seat 4
Row 3 - Seat 1
Row 3 - Seat 2
Row 3 - Seat 3
Row 3 - Seat 4
Total seats: 12
Loop values: 1 2 3 4 6 7
```

### Check your work

- ☐ Twelve seat labels were printed, from `Row 1 - Seat 1` to `Row 3 - Seat 4`.
- ☐ `Total seats: 12` is printed once.
- ☐ `Loop values:` contains `5`, no `8`, no `9` and no `10`.

---

## Task 6 — Simple Division Calculator

**Goal:** parse console input, catch two specific exceptions and always run cleanup code.

### Step 1 — Write the code

```csharp
// ---- Task 6 ----
// TODO 1: ask for two integers with Console.ReadLine()
// TODO 2: inside try, int.Parse both inputs and divide first by second
// TODO 3: catch FormatException and DivideByZeroException separately
// TODO 4: finally prints "Calculation complete"
```

### Step 2 — Fill in the TODOs

<details>
<summary>Hint — exact exception-handling code</summary>

```csharp
Console.Write("Enter the first integer: ");
string firstInput = Console.ReadLine() ?? "";
Console.Write("Enter the second integer: ");
string secondInput = Console.ReadLine() ?? "";

try
{
    int first = int.Parse(firstInput);
    int second = int.Parse(secondInput);
    int result = first / second;
    Console.WriteLine($"Result: {result}");
}
catch (FormatException)
{
    Console.WriteLine("Error: please enter whole numbers only.");
}
catch (DivideByZeroException)
{
    Console.WriteLine("Error: cannot divide by zero.");
}
finally
{
    Console.WriteLine("Calculation complete");
}
```

`Console.ReadLine()` returns `string?`, so `?? ""` avoids a nullable warning and gives `int.Parse` a non-null string. `int.Parse("text")` throws `FormatException`; division by zero throws `DivideByZeroException`. The `finally` block runs in **all three** test cases.

</details>

### Step 3 — Build and run

Run the program three times, typing the two inputs shown. The prompts stay on the same line as the typed input.

**Test A — `20` then `4`:**

```text
Enter the first integer: Enter the second integer: Result: 5
Calculation complete
```

**Test B — `text` then `4`:**

```text
Enter the first integer: Enter the second integer: Error: please enter whole numbers only.
Calculation complete
```

**Test C — `20` then `0`:**

```text
Enter the first integer: Enter the second integer: Error: cannot divide by zero.
Calculation complete
```

The lines above are the last lines of the full program output; Tasks 1 to 5 still print before them. To pipe the tests non-interactively in a terminal:

```bash
printf '20\n4\n' | dotnet run --project OperatorsAndControlFlow/OperatorsAndControlFlow.csproj
```

### Check your work

- ☐ Both inputs are read with `Console.ReadLine() ?? ""`.
- ☐ There are two separate `catch` blocks with the exact exception types shown.
- ☐ `Calculation complete` appears in all three tests.
- ☐ The messages in Tests B and C match the expected output exactly.

---

## If you know Java

| Java | C# in this workshop |
| --- | --- |
| `i++`, `++i` | Same behaviour |
| `+=`, `*=` | Same |
| `&&` | Same short-circuit behaviour |
| `condition ? a : b` | Same, but both branches must share a type |
| `switch` with `break` | Same keywords, including `default`; switch expressions use `_` |
| Enhanced `for (int x : array)` | `foreach (int x in array)` |
| `Integer.parseInt(text)` | `int.Parse(text)` |
| `try` / `catch` / `finally` | Same keywords |
| `catch (Exception e)` | Prefer specific types: `FormatException`, `DivideByZeroException` |
| No direct `??` / `??=` | Use `??` and `??=` for defaults on nullable values |

---

## If the program does not build

| Message | Cause | Fix |
| --- | --- | --- |
| `CS1002` | Missing `;` | Add the semicolon at the end of the statement |
| `CS1513` | Missing `}` | Check that each block has a matching closing brace |
| `CS0136` | Two variables with the same name in `Main` | Use `dailyAttendance` in Task 4, not `attendance` |
| `CS0029` | `if (marks = 72)` | Use `==` for comparison |
| `CS0173` | Ternary branches have different types | Use the same type in both branches |
| `CS8600` | `string userName = null;` | Write `string? userName = null;` |
| `CS0246` | `FormatException` or `DivideByZeroException` not found | Keep `ImplicitUsings=enable` in the `.csproj`, or add `using System;` |
| `CS0165` | `grade` read before all branches assign it | Use `if` / `else if` / `else` so every path assigns `grade` |
| Wrong `if` result | Semicolon after `if (...)` | Remove the semicolon |
| Wrong total | `total` reset inside the `foreach` | Initialise `total = 0` once, before the loop |
| `dotnet : command not found` | .NET SDK not on `PATH` | Install the SDK from [CSharp-DotNet-Setup.md](../Week%201/CSharp-DotNet-Setup.md) and reopen the terminal |

---

## Reference solution

This is the complete, verified `OperatorsAndControlFlow/Program.cs`. Use it to compare your work after you have attempted the tasks. It builds with **0 warnings and 0 errors** on .NET 10.

```csharp
namespace OperatorsAndControlFlow
{
    class Program
    {
        static void Main()
        {
            // ---- Task 1: College Reward Points ----
            int points = 10;                 // TODO 1: start with 10 reward points
            points += 5;                     // TODO 2: add 5 with +=
            points *= 2;                     // TODO 2: double the total with *=
            Console.WriteLine($"Final points: {points}");

            bool atLeast25 = points >= 25;   // TODO 3: comparison operator
            Console.WriteLine($"At least 25 points: {atLeast25}");

            int afterPost = points++;        // TODO 4: use 30 first, then store 31
            Console.WriteLine($"points++ returned {afterPost}; points is now {points}");

            int afterPre = ++points;         // TODO 4: store 32 first, then return 32
            Console.WriteLine($"++points returned {afterPre}; points is now {points}");

            Console.WriteLine();

            // ---- Task 2: Student Exam Result ----
            int marks = 72;                  // TODO 1: change these values to test
            int attendance = 80;

            string grade;                    // TODO 2: if / else if / else grade ladder
            if (marks >= 80)
            {
                grade = "A";
            }
            else if (marks >= 65)
            {
                grade = "B";
            }
            else if (marks >= 50)
            {
                grade = "C";
            }
            else
            {
                grade = "Fail";
            }

            bool isEligible = marks >= 50 && attendance >= 75; // TODO 3: logical AND
            Console.WriteLine($"Marks: {marks}, Attendance: {attendance}");
            Console.WriteLine($"Grade: {grade}");
            Console.WriteLine($"Pass eligible: {isEligible}");

            Console.WriteLine();

            // ---- Task 3: Library Menu ----
            int choice = 2;                  // TODO 1: test with 1, 3 and 9
            Console.WriteLine("Library Menu");
            Console.WriteLine("1. Borrow   2. Return   3. Renew");
            Console.WriteLine($"Selected choice: {choice}");

            switch (choice)                  // TODO 2: switch with a default case
            {
                case 1:
                    Console.WriteLine("You selected Borrow.");
                    break;
                case 2:
                    Console.WriteLine("You selected Return.");
                    break;
                case 3:
                    Console.WriteLine("You selected Renew.");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            string? userName = null;         // TODO 3: nullable string with no value
            string displayName = userName ?? "Guest"; // TODO 3: ?? supplies a default
            Console.WriteLine($"Display name: {displayName}");

            userName ??= "Guest";            // TODO 4: ??= assigns only when null
            Console.WriteLine($"userName after ??=: {userName}");

            Console.WriteLine();

            // ---- Task 4: Weekly Attendance ----
            int[] dailyAttendance = { 20, 22, 21, 24, 23 }; // TODO 1: Monday to Friday
            int total = 0;

            Console.WriteLine("Daily attendance:");          // TODO 2: foreach
            foreach (int present in dailyAttendance)
            {
                Console.WriteLine($"  {present}");
                total += present;
            }
            Console.WriteLine($"Total attendance: {total}");

            for (int i = 0; i < dailyAttendance.Length; i++) // TODO 3: for with an index
            {
                Console.WriteLine($"Day {i + 1}: {dailyAttendance[i]}");
            }

            int countdown = 3;                               // TODO 4: while
            while (countdown >= 1)
            {
                Console.WriteLine(countdown);
                countdown--;
            }

            bool runAgain = false;                           // TODO 5: do-while runs once
            do
            {
                Console.WriteLine("Attendance recorded");
            }
            while (runAgain);

            Console.WriteLine();

            // ---- Task 5: Exam Hall Seat Labels ----
            int seatCount = 0;
            for (int row = 1; row <= 3; row++)               // TODO 1: nested for loops
            {
                for (int seat = 1; seat <= 4; seat++)
                {
                    Console.WriteLine($"Row {row} - Seat {seat}");
                    seatCount++;
                }
            }
            Console.WriteLine($"Total seats: {seatCount}");

            Console.Write("Loop values: ");                  // TODO 2: continue skips 5, break stops at 8
            for (int i = 1; i <= 10; i++)
            {
                if (i == 5)
                {
                    continue;
                }
                if (i == 8)
                {
                    break;
                }
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            Console.WriteLine();

            // ---- Task 6: Simple Division Calculator ----
            Console.Write("Enter the first integer: ");       // TODO 1: read two strings
            string firstInput = Console.ReadLine() ?? "";
            Console.Write("Enter the second integer: ");
            string secondInput = Console.ReadLine() ?? "";

            try                                             // TODO 2: parse and divide
            {
                int first = int.Parse(firstInput);
                int second = int.Parse(secondInput);
                int result = first / second;
                Console.WriteLine($"Result: {result}");
            }
            catch (FormatException)                          // TODO 3: bad number text
            {
                Console.WriteLine("Error: please enter whole numbers only.");
            }
            catch (DivideByZeroException)                     // TODO 3: division by zero
            {
                Console.WriteLine("Error: cannot divide by zero.");
            }
            finally                                           // TODO 4: always runs
            {
                Console.WriteLine("Calculation complete");
            }
        }
    }
}
```
