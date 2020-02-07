pushd Content
rmdir /s /q Merged
rmdir /s /q Fragments
rmdir /s /q Graphics
rmdir /s /q Page
rmdir /s /q Resources
popd

pushd Guide
pushd input
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