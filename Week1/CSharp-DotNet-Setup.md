# C# and .NET Setup Guide for macOS and Windows

**Course:** C# and .NET  
**Target:** .NET 10 LTS  
**Editor:** Visual Studio Code with the Microsoft C# Dev Kit extension

This guide explains how to install and verify the tools needed to begin C# and .NET development on macOS or Windows. The same C# and .NET workflow is available on both operating systems.

> **Version note:** .NET 10 is the long-term-support (LTS) release used in this guide. Patch numbers such as `10.0.xxx` change regularly. Install the latest .NET 10 SDK shown on the official download page.

## What will be installed?

| Tool | Purpose |
| --- | --- |
| C# | The programming language used in this course. |
| .NET | A cross-platform platform for building and running applications. |
| .NET SDK | The development tools, compiler, templates, command-line tools, and runtime needed to create applications. |
| .NET Runtime | The component that runs compiled .NET applications. The SDK includes the matching runtime. |
| Visual Studio Code | A lightweight source-code editor available on macOS and Windows. |
| C# Dev Kit | Microsoft's C# and .NET support for Visual Studio Code, including project templates, IntelliSense, and debugging. |

For this course, install the **.NET SDK**, not only the Runtime. The SDK already includes the runtime needed to run the programs created in class.

## Recommended installation order

1. Install the .NET 10 SDK.
2. Install Visual Studio Code.
3. Install the Microsoft C# Dev Kit extension in Visual Studio Code.
4. Verify the installation from a terminal.
5. Run one small verification project.

> **Before you start:** The current official Visual Studio Code documentation states that a Visual Studio subscription is required to use C# Dev Kit. Students who cannot sign in should contact the college laboratory administrator before class. The command-line .NET SDK can still be installed and verified independently, so the CLI exercises in the Week 1 notes work either way.

## macOS setup

### 1. Check the Mac processor

Before downloading .NET, check whether the Mac uses an Apple Silicon processor or an Intel processor:

1. Open **Terminal**.
2. Run:

```bash
uname -m
```

Use the following result to choose the installer:

| Result | Mac type | .NET installer |
| --- | --- | --- |
| `arm64` | Apple Silicon, such as M1, M2, M3, or M4 | **Arm64** |
| `x86_64` | Intel | **x64** |

You can also check this from **Apple menu > About This Mac**.

### 2. Download and install the .NET SDK

1. Open the official [.NET 10 download page](https://dotnet.microsoft.com/en-us/download/dotnet/10.0).
2. Find the **Build apps - SDK** section.
3. In the **macOS** row, select **Installers**.
4. Select **Arm64** for an Apple Silicon Mac or **x64** for an Intel Mac.
5. Open the downloaded `.pkg` file.
6. Follow the installer instructions and wait for the installation to finish.

The .NET SDK includes the runtime, so a separate Runtime installation is not required for normal development.

### 3. Verify the macOS installation

Close and reopen Terminal after installing the SDK, then run:

```bash
dotnet --version
dotnet --list-sdks
dotnet --info
```

A successful installation should show a version beginning with `10.`, for example:

```text
10.0.401
```

`dotnet --info` displays the installed SDK, runtimes, operating-system information, and the path to the .NET installation.

### 4. Install Visual Studio Code

1. Download Visual Studio Code from the [official VS Code download page](https://code.visualstudio.com/Download).
2. Open the downloaded application and install it.
3. Launch Visual Studio Code.

### 5. Install C# Dev Kit in Visual Studio Code

1. In Visual Studio Code, open the **Extensions** view.
   - macOS: `Command+Shift+X`
   - Windows: `Ctrl+Shift+X`
2. Search for **C# Dev Kit**.
3. Select the extension published by **Microsoft**.
4. Click **Install**.
5. If the extension requests sign-in, complete the Microsoft sign-in and activation steps.

## Windows setup

### 1. Check the Windows processor architecture

For most classroom computers, the correct installer is **x64**. To check:

1. Open **Settings**.
2. Select **System > About**.
3. Look for **System type**.

| System type | .NET installer |
| --- | --- |
| 64-bit x64-based PC | **x64** |
| 64-bit ARM-based PC | **Arm64** |

Avoid the x86 installer unless the computer is specifically a 32-bit system.

### 2. Download and install the .NET SDK

1. Open the official [.NET 10 download page](https://dotnet.microsoft.com/en-us/download/dotnet/10.0).
2. Find the **Build apps - SDK** section.
3. In the **Windows** row, select **Installers**.
4. Select **x64** for a standard 64-bit PC or **Arm64** for an ARM-based PC.
5. Open the downloaded installer.
6. If Windows displays a User Account Control prompt, approve the installation.
7. Follow the installer instructions and wait for the installation to finish.

The .NET SDK includes the matching runtime. Do not install a separate Runtime unless a later lesson specifically requires it.

### 3. Optional Windows Package Manager installation

If Windows Package Manager (`winget`) is available, the SDK can be installed from PowerShell or Command Prompt instead:

```powershell
winget install Microsoft.DotNet.SDK.10
```

Use the graphical installer when `winget` is unavailable or when the college requires a specific installation method.

### 4. Verify the Windows installation

Close and reopen PowerShell, Command Prompt, or the terminal in Visual Studio Code, then run:

```powershell
dotnet --version
dotnet --list-sdks
dotnet --info
```

A successful installation should show a version beginning with `10.`, for example:

```text
10.0.401
```

### 5. Install Visual Studio Code

1. Download Visual Studio Code from the [official VS Code download page](https://code.visualstudio.com/Download).
2. Open the downloaded installer.
3. Follow the installation instructions.
4. Launch Visual Studio Code.

### 6. Install C# Dev Kit in Visual Studio Code

1. Open the **Extensions** view with `Ctrl+Shift+X`.
2. Search for **C# Dev Kit**.
3. Select the extension published by **Microsoft**.
4. Click **Install**.
5. If the extension requests sign-in, complete the Microsoft sign-in and activation steps.

## Setup verification checklist

Run the verification commands for your platform, then confirm every row below.

| Check | macOS | Windows |
| --- | --- | --- |
| Processor architecture identified | `arm64` or `x86_64` from `uname -m` | x64 or Arm64 from **Settings > System > About** |
| .NET 10 SDK installer completed | Arm64 or x64 `.pkg` | x64 or Arm64 installer |
| `dotnet --version` starts with `10.` | Yes | Yes |
| At least one .NET 10 SDK listed by `dotnet --list-sdks` | Yes | Yes |
| .NET runtime shown in `dotnet --info` | Yes | Yes |
| Visual Studio Code installed and opens | Yes | Yes |
| Microsoft C# Dev Kit installed and enabled | Yes | Yes |
| `dotnet run` displays `Hello, World!` | Yes | Yes |

If `dotnet` is not recognised after installation, close and reopen the terminal — the terminal reads the updated `PATH` only when it starts.

## Create a verification project

A small console project confirms that the SDK, C# compiler, runtime, terminal, and editor are working together.

### From the terminal

On macOS:

```bash
mkdir -p ~/csharp-dotnet
cd ~/csharp-dotnet
dotnet new console -n FirstApp
cd FirstApp
code .
```

On Windows PowerShell:

```powershell
New-Item -ItemType Directory -Force -Path "$HOME\csharp-dotnet"
Set-Location "$HOME\csharp-dotnet"
dotnet new console -n FirstApp
Set-Location FirstApp
code .
```

If `code` is not recognized, open the `FirstApp` folder from Visual Studio Code using **File > Open Folder**.

Run the project:

```text
dotnet run
```

The default project should display:

```text
Hello, World!
```

### From Visual Studio Code

1. Open the folder where you want to keep your course projects.
2. Open the Command Palette:
   - macOS: `Command+Shift+P`
   - Windows: `Ctrl+Shift+P`
3. Type **.NET** and select **.NET: New Project**.
4. Select **Console app**.
5. Enter a project name and choose a location.
6. Select **Run > Run without Debugging**, or press `Ctrl` + `F5`. Press `F5` instead when you want to run with the debugger and step through the code.

The project should run and display `Hello, World!`.

## What to install for later lessons?

Most C# and .NET lessons require only:

- The .NET SDK
- Visual Studio Code
- C# Dev Kit

Additional extensions and workloads should be installed only when a lesson introduces a specific technology, such as ASP.NET Core, databases, GitHub authentication, or deployment.

## Official references

- [.NET 10 downloads](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- [Install .NET on macOS](https://learn.microsoft.com/en-us/dotnet/core/install/macos)
- [Install .NET on Windows](https://learn.microsoft.com/en-us/dotnet/core/install/windows)
- [Download Visual Studio Code](https://code.visualstudio.com/Download)
- [C# Dev Kit in Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- [Getting started with C# in VS Code](https://code.visualstudio.com/docs/csharp/get-started)
- [C# Dev Kit sign-in requirements](https://code.visualstudio.com/docs/csharp/signing-in)
