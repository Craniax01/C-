# Workshop 1 — Personal Details and Motivational Quote

**Module:** CS6004NP Application Development
**Duration:** 20 minutes

Two tasks. Create a console app that prints your personal details, then add a second class that stores and prints a motivational quote.

---

## Task A — Print your personal details

**Goal:** a console app that prints your name, address, contact number, college, and anything else you want to add.

### Step 1 — Create the project

```bash
dotnet new console -n PersonalDetails
cd PersonalDetails
```

This creates two files: `PersonalDetails.csproj` and `Program.cs`.

### Step 2 — Write the code

Open `Program.cs` and replace everything in it with the skeleton below. The first variable and the first print line are done for you as a model — copy that pattern for the rest.

```csharp
namespace PersonalDetails
{
    class Program
    {
        public static void Main(string[] args)
        {
            // TODO 1: declare one variable per detail.
            //         Text uses string, a whole number uses int.
            //         The first one is done for you.
            string name = "Your Full Name";

            // TODO 2: declare a variable for the address, contact number,
            //         email, college, course, and year of study.

            // TODO 3: print a heading line, then one labelled line per detail.
            //         The first two are done for you as a model.
            Console.WriteLine("========== Personal Details ==========");
            Console.WriteLine($"Name          : {name}");

            // TODO 4: print a line for every remaining detail.
        }
    }
}
```

<details>
<summary>Hint</summary>

- A variable is declared as `type name = value;` — the type comes first, then the name.
- Text needs `string`. The year of study is a whole number, so it needs `int`.
- The `{name}` inside the string is what inserts the value. Change the word inside the braces to print a different variable.
- The spaces before the `:` line the labels up. Match them if you want the output to look tidy.

</details>

### Step 3 — Understand each part

| Part | What it does |
| --- | --- |
| `namespace PersonalDetails` | Groups the code. The name matches the project. |
| `class Program` | Holds the code for this program. |
| `public static void Main(string[] args)` | The starting point. The runtime calls this first. |
| `string name = "Your Full Name";` | A **variable** that stores one value for the duration of `Main`. |
| `$"Name : {name}"` | String interpolation. `$"` before the text, `{name}` inserts the variable's value. |
| `Console.WriteLine(...)` | Prints one line, then moves to the next line. |

### Step 4 — Build and run

```bash
dotnet build
dotnet run
```

Your output should look like this, with your own values:

```text
========== Personal Details ==========
Name          : Your Full Name
Address       : Your Address
Contact Number: +977 98XXXXXXXX
Email         : you@icp.edu.np
College       : Your College Name
Course        : Your Course
Year of Study : 1
```

### Check your work

- ☐ The build reports **0 errors, 0 warnings**.
- ☐ Changing one variable changes exactly one output line.
- ☐ No value is typed directly inside a `WriteLine` — it always comes from a variable.
- ☐ You have at least six details, including name, address, contact number, and college.

---

## Task B — Add the `MotivationalQuote` class

**Goal:** move the quote out of `Main` and into its own class, so the quote is stored in a **field** instead of a local variable.

### Step 1 — Create the class file

In VS Code, right-click the project folder and choose **New File**. Name it exactly `MotivationalQuote.cs`. It must be saved inside the project folder.

### Step 2 — Write the class

Put this skeleton in `MotivationalQuote.cs` and fill in the three TODOs. The `namespace` and the `PrintQuote` signature are given — keep them exactly as they are, because `Program` will call that method.

```csharp
namespace PersonalDetails
{
    public class MotivationalQuote
    {
        // TODO 1: declare a field to hold the quote.
        //         The type is string, only this class should be able to use it,
        //         and it is never changed after it is set.

        // TODO 2: write a constructor. It takes one string parameter and
        //         stores that value in the field from TODO 1.
        //         The constructor's name is identical to the class name.

        public void PrintQuote()
        {
            // TODO 3: print the heading exactly as
            //         "========== Quote of the Day ==========",
            //         then print the stored quote surrounded by
            //         double-quote characters.
        }
    }
}
```

<details>
<summary>Hint</summary>

- **TODO 1 — the field.** A field looks like a variable but sits directly inside the class, above any method. It needs three things: the type `string`, the access modifier `private` (only this class may use it), and the word `readonly` (it is set once and never changes). C# prefixes private fields with an underscore, so pick a name like `_quote`.
- **TODO 2 — the constructor.** A constructor has no return type — not `void`, not `string`. It is written as `public` then the class name, then a parameter list in brackets, then braces. Inside the braces, assign the parameter to the field with a single `=`.
- **TODO 3 — the print.** Use `Console.WriteLine` twice, as in Task A. To add literal double-quote characters inside a string, write `\"`.
- **Do you need `this`?** No. C# does not require it, so `_quote = quote;` is correct on its own. You *may* write `this._quote = quote;` — it compiles and means the same thing. Java needs `this` because `name = name;` would be ambiguous there; C# scopes variables inside the braces, so the field is already unambiguous. Keeping the field named `_quote` and the parameter named `quote` removes the question entirely.

</details>

### Step 3 — Understand the difference

| Piece | Kind | Why it is there |
| --- | --- | --- |
| The `_quote` field | Field | Holds the quote for as long as the object exists. Task A's variables were local — they vanished when `Main` finished. A field belongs to the object, so it survives. |
| The constructor | Constructor | Runs automatically the moment the object is created. Its job is to make sure the field is filled in. |
| `public void PrintQuote()` | Method | Prints the stored quote. `public` so that `Program` is allowed to call it, `void` because it returns nothing. |
| The `_` prefix | Naming convention | C# marks private fields with it. `name` is a local variable, `_quote` is a field. |

### Step 4 — Call it from `Program`

Add these two lines at the end of `Main`, after the details have been printed:

```csharp
MotivationalQuote quote = new MotivationalQuote("Your motivational quote goes here.");
quote.PrintQuote();
```

`new MotivationalQuote(...)` creates the object. The text in the brackets is passed to the constructor, which stores it. The second line calls the method that prints it.

### Step 5 — Build and run

```bash
dotnet run
```

Expected output:

```text
========== Personal Details ==========
Name          : Your Full Name
Address       : Your Address
Contact Number: +977 98XXXXXXXX
Email         : you@icp.edu.np
College       : Your College Name
Course        : Your Course
Year of Study : 1
========== Quote of the Day ==========
"Your motivational quote goes here."
```

### Check your work

- ☐ The quote is stored in a **field**, not a local variable.
- ☐ The class is in its own file, outside the `class Program` braces.
- ☐ The quote text is passed into the constructor, not hard-coded inside `PrintQuote`.
- ☐ Calling `PrintQuote()` twice prints the quote twice.
- ☐ The build reports **0 errors, 0 warnings**.

---

## If you know Java

| Java | C# |
| --- | --- |
| `String s = "text";` | `string s = "text";` — use lowercase `string` |
| `public static void main(String[] args)` | `public static void Main(string[] args)` — capital `M` |
| `System.out.println("text")` | `Console.WriteLine("text")` |
| `'x'` for text | `"x"` for text. Single quotes are only for a single character. |
| String concatenation with `+` | String interpolation, `$"Name: {name}"` |
| Fields default to package-private | Always write `public`, `private`, or `protected` |

---

## If the program does not build

| Error | Fix |
| --- | --- |
| `CS5001: Program does not contain a static 'Main' method` | Check the `Main` line reads exactly `public static void Main(string[] args)`. |
| `CS1002: ; expected` | A statement is missing its semicolon at the line shown. |
| `CS0116: A namespace cannot directly contain members` | The method was written directly inside `namespace { }`. Put it inside a class. |
| `CS0246: The type or namespace name 'MotivationalQuote' could not be found` | The file name is misspelled, the file is outside the project folder, or the two files use different `namespace` names. |
| `dotnet : command not found` | Close the terminal fully and open a new one, then try again. |
