# Build & Run

- **Primary build**: Visual Studio 2017 (v15), .NET Framework 4.7.1.
- **Command line**:
  "C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\MSBuild.exe" "MMS Design_2017.sln" /m /p:Configuration=Debug

- **Editing only**: Visual Studio 2022 (v17).
  - Separate bin/obj outputs via Directory.Build.props.
  - Do not build release from VS2022.

- **Testing**:
  - Run app from VS2017 Debug.
  - Exercise core workflows: client load, transaction entry, report generation.
