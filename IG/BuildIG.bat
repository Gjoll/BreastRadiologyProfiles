@SET JAVA_TOOL_OPTIONS=-Dfile.encoding=UTF-8
pushd guide
JAVA -jar org.hl7.fhir.publisher.jar -ig ig.json
popd

@PAUSE