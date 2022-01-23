# AutoGraphBinding

Xamarin (.Net 6) Binding Project for iOS (T1 Autograph Objective C Library).

## Steps to reproduce this project state

1. Install the .Net ios workload if it has not been done before
2. Create two projects (a binding project for the native objective-C lib, a sample which uses the binding project, Framework: .net6.0-ios)
3. Download the Autograph library (in this case version 2.0.6, you can download the library for testing purposes [here](https://tenonedesign.com/t1autograph.php))
4. Download the latest sharpie toolkit ([here](https://docs.microsoft.com/de-de/xamarin/cross-platform/macios/binding/objective-sharpie/get-started)) to create a C#/.Net API file (one or multiple C# classes) to communicate with the Objective-C lib
5. Create the API definition class with the following console command (in a new target directory "sharpie")
    ```sh
    sharpie bind --output=sharpie --namespace=AutographBinding --sdk=iphoneos15.2 -scope T1Autograph.xcframework/ios-arm64_armv7/T1Autograph.framework/Headers T1Autograph.xcframework/ios-arm64_armv7/T1Autograph.framework/Headers/*.h
    ```
6. Copy the created `ApiDefinitions.cs` file and the downloaded Autograph objective-C lib (T1Autograph.xcframework) to the root directory of your binding project
7. Make sure your binding project is a real binding project. Take a look at your csproj file and make sure you made the following changes.
   ```xml
   [...]
   <RootNamespace>AutographBinding</RootNamespace>
   <AssemblyName>AutographBinding</AssemblyName>
   <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
   <IsBindingProject>true</IsBindingProject>
   <NoBindingEmbedding>true</NoBindingEmbedding>
   [...]
   <ItemGroup>
       <ObjcBindingApiDefinition Include="ApiDefinitions.cs">
           <Link>ApiDefinitions.cs</Link>
       </ObjcBindingApiDefinition>
       <NativeReference Include="T1Autograph.xcframework" Kind="Framework" />
   </ItemGroup>
   [...]
   ```
8. Add the Autograph Binding project to the example project