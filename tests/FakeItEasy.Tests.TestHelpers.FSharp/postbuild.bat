@REM Due to dotnet/fsharp#14863, FakeItEasy.Tests.TestHelper.FSharp is delay signed.
@REM This prevents FakeItEasy.Tests from loading the assembly.
@REM Workaround until the tooling is fixed is to resign the assembly.
@REM The path to sn.exe seems impossible to find with any certainty, so
@REM for now we'll try to hardcode it and hope we can remove this postbuild step
@REM before it becomes an issue.

set assembly="%1"
"%ProgramFiles(x86)%\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\sn.exe" -q -R %assembly% ../../src/FakeItEasy.snk
