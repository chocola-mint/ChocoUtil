# ChocoUtil
 A personal library of Unity utilities.

This library has three goals:
1. To serve as a public repository that can represent my programming capabilities.
2. To serve as a minimal-dependency library that can be plugged to any Unity project.
    * Which means only built-in packages.
3. To improve code reuse across my personal projects.

## .NET version
.NET Standard 2.1

## Dependencies
* Unity 2021.3.6f1 (DLLs come with your Unity installation)

## Build Process

1. Open the Visual Studio solution in the Source folder w/ Visual Studio.
2. Set to build mode to "Release", and build the solution.
3. The solution is set up so that the DLL (ChocoUtil.dll) inside the release folder is cloned to Assets/Plugins/ChocoUtil.
4. Run tests inside Unity as necessary. They're put under the Tests folder and can be run using the Test Runner window.
