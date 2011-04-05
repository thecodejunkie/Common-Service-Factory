properties {
    $buildDir = ".\build"
    $outputDir = $buildDir + "\lib\" + $framework
    $nunitDir = (gci -fi NUnit* .\source\packages).FullName
    $nunit = (gci $nunitDir\Tools\nunit-console.exe)
}

task default -depends Compile, Clean

task Init -depends Clean {
    mkdir $outputDir | out-null
}

task Compile -depends Init { 
    msbuild /p:Configuration=Release .\source\CommonServiceFactory.sln 
}

task Test -depends Compile {
    . $nunit .\source\CommonServiceFactory.Tests\bin\Release\CommonServiceFactory.Tests.dll
}

task Package -depends Test {
    copy .\source\CommonServiceFactory\bin\Release\CommonServiceFactory.dll $outputDir
    .\Tools\nuget\NuGet.exe pack .\CommonServiceFactory.nuspec -b .\build -o .\build
}

task Clean { 
    if (test-path $buildDir) { ri -r -fo $buildDir }
    msbuild /t:Clean /p:Configuration=Release .\source\CommonServiceFactory.sln 
}
