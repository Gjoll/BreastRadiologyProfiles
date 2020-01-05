msbuild
VSTest.Console.exe Projects\BreastRadiology.XUnitTests\bin\Debug\netcoreapp3.1\BreastRadiology.XUnitTests.dll /Tests:FullBuild
pushd IG\Guide
JAVA -jar input-cache\org.hl7.fhir.publisher.jar -ig ig.ini
popd
