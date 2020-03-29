pushd Content
rem rmdir /s /q Examples
rmdir /s /q Fragments
rmdir /s /q Graphics
rmdir /s /q Page
rmdir /s /q Merged
rmdir /s /q Resources

pushd ACR
rmdir /s /q Fragments
rmdir /s /q Graphics
rmdir /s /q Page
rmdir /s /q Resources
popd

popd

pushd Guide
pushd input
rmdir /s /q examples
rmdir /s /q images
rmdir /s /q resources

pushd pagecontent
del /s /q StructureDefinition*.xml
del /s /q ValueSet*.xml
popd

popd

rmdir /s /q output
rmdir /s /q temp
popd



pause