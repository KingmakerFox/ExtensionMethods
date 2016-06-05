nuget.exe install FAKE -OutputDirectory packages -ExcludeVersion
nuget install OpenCover -OutputDirectory packages -ExcludeVersion
nuget install ReportGenerator -OutputDirectory packages -ExcludeVersion

packages\FAKE\tools\Fake.exe build.fsx %*