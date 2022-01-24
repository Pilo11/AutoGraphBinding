find . -iname "bin" | xargs rm -rf
find . -iname "obj" | xargs rm -rf
cd AutographBindingExample
dotnet restore
cd ..
