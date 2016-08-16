# Building AutoRest

## Build Prerequisites
AutoRest is developed primarily in C# but generates code for multiple languages. To build and test AutoRest requires a few things be installed locally.

### Initialize Settings
To set up a machine with the necessary tools for building AutoRest, run `.\Tools\initialize-settings.ps1`; this script will determine which tools are missing on your machine and installs them. **After all installations are complete, the script will restart your machine.**

`initialize-settings.ps1` will look for the following tools on your machine:
- .NET 4.5+
- Java
- Node.js
- Ruby
- Gradle
- Python
- tox
- Visual Studio 2015
- .NET CoreCLR

After your machine restarts, run the following commands to complete the Android SDK installation:
>`(echo y | android update sdk -u -a -t build-tools-23.0.1) && (echo y | android update sdk -u -a -t android-23) && (echo y | android update sdk -u -a -t extra-android-m2repository)`
>`Copy-Item "$($env:LOCALAPPDATA)\Android" "C:\Program Files (x86)\Android" -recurse`

You will also want to run the following command from the project root:
>`gem install bundler && npm install && npm install gulp && npm install gulp -g && npm update`

### .Net
#### on Windows 
Install the [Microsoft Build Tools](http://go.microsoft.com/?linkid=9832060) or get them with [Visual Studio](https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx).
Ensure that msbuild is in your path by running vcvarsall.bat
>C:\Program Files (x86)\Microsoft Visual Studio 14.0\VC\vcvarsall.bat

To compile the code in Visual Studio IDE,
 
- Ensure you are using Visual Studio 2015 (Update 3)
- Ensure "Nuget Package Manager For Visual Studio" is updated to a newest version, like "2.8.60723.765", which is needed to install xunit.
- Install [Task Runner Explorer](https://visualstudiogallery.msdn.microsoft.com/8e1b4368-4afb-467a-bc13-9650572db708) to run gulp tasks such as synchonize nuget version, assembly info, etc.

Install .Net CoreCLR RTM using [these steps](https://www.microsoft.com/net/core#windows).

#### on Mac or Linux
Install Mono 4.3.0 (MonoFramework-MDK-4.3.0.372.macos10.xamarin.x86.pkg)

Install DNVM using [these steps](https://docs.asp.net/en/latest/getting-started/installing-on-mac.html).

### Node.js
Install the latest from [nodejs.org](https://nodejs.org/). Then from the project root run `npm install`.

### Java / Android
Install the latest Java SE Development Kit from [Java SE Downloads](http://www.oracle.com/technetwork/java/javase/downloads/index.html).
Ensure that the JDK binaries are in your `PATH`.
>set PATH=PATH;C:\Program Files\java\jdk1.8.0_45\bin

Ensure that your environment includes the `JAVA_HOME`.
>set JAVA_HOME=C:\Program Files\java\jdk1.8.0_45

Install the latest Android environment from http://developer.android.com/sdk/index.html. You can either install Android Studio if you want to do actual development work in Android, or simply install the [SDK tools](http://developer.android.com/sdk/index.html#Other) that is minimally requried to build the Android code. 

In SDK Manager, make sure that build tools 23.0.1, Android Support Repository, and Google Repository are installed. Make sure ANDROID_HOME is in your environment variable. If you installed Android Studio, you can find it out from Android Studio settings. If you installed SDK tools, its default location is `C:\Program Files (x86)\Android\android-sdk` on Windows. If it is not there, it may be in your hidden `AppData\Local` directory.

#### Gradle
Install the `Gradle build system` from [Gradle downloads](http://gradle.org/gradle-download/).
Ensure Gradle is in your `PATH`.
>set PATH=PATH;C:\gradle-2.6\bin

Ensure that your environment includes the `GRADLE_HOME`.
>set GRADLE_HOME=C:\gradle-2.6

#### Java IDE
You may want a Java IDE.
- Install Jetbrains IntelliJ IDEA from [JetBrains downloads](https://www.jetbrains.com/idea/download/.)
 OR
- Install `Eclipse IDE for Java EE Developer` from [Eclipse downloads](http://eclipse.org/downloads/) 

### Ruby
[RubyInstaller](http://rubyinstaller.org/downloads/) version 2+ - 32-bit version.
By default, Ruby installs to C:\Ruby21 or Ruby22, etc. Ensure that C:\Ruby21\bin is in your `PATH`.
>set PATH=PATH;C:\Ruby21\bin

[RubyDevKit](http://rubyinstaller.org/downloads/) 32-bit version for use with Ruby 2.0 and above
The DevKit installer just unpacks files. Navigate to the directory and run the following:
```bash
ruby dk.rb init
ruby dk.rb install
gem install bundler
```

### Python
Install [Python 2.7 and Python 3.5](https://www.python.org/downloads/), and add one of them to your PATH (we recommend 3.5).
>set PATH=PATH;C:\Python35

### Testing Your Environment
To make sure you've set up all the prerequisites correctly, run `.\Tools\Verify-Settings.ps1` before you attempt to build.

## Build

### Visual Studio Build
There are 2 solutions used to build C# ClientRuntime and AutoRest code generator. AutoRest.sln is used to build AutoRest code generator. ClientRuntime.sln is used to build C# ClientRuntime.

###Command Line
We use [gulp](http://gulpjs.com) and msbuild / xbuild to handle the builds. Install for global use with

>npm install gulp -g

>gulp

If you would like to see what commands are available to you, run `gulp -T`. That will list all of the gulp tasks you can run. By default, just running `gulp` will run a build that will execute clean, build, code analysis, package and test.

### Output from gulp -T
```bash
[13:54:21] Using gulpfile ./autorest/gulpfile.js
[13:54:21] Tasks for ./autorest/gulpfile.js
[13:54:21] ├── regenerate:expected
[13:54:21] ├── regenerate:delete
[13:54:21] ├── regenerate:expected:csazure
[13:54:21] ├── regenerate:expected:cs
[13:54:21] ├── clean:build
[13:54:21] ├── clean:templates
[13:54:21] ├── clean:generatedTest
[13:54:21] ├─┬ clean
[13:54:21] │ ├── clean:build
[13:54:21] │ ├── clean:templates
[13:54:21] │ └── clean:generatedTest
[13:54:21] ├── syncNugetProjs
[13:54:21] ├── syncNuspecs
[13:54:21] ├─┬ syncDotNetDependencies
[13:54:21] │ ├── syncNugetProjs
[13:54:21] │ └── syncNuspecs
[13:54:21] ├── build
[13:54:21] ├── package
[13:54:21] ├── test
[13:54:21] ├── analysis
[13:54:21] └── default
```

### Running the tests
Prior to executing `gulp` to build and then test the code, make sure that the latest tools are setup for your build environment.

 >gulp test

### Troubleshooting
#### Strong Name Validation Errors

If you're running Windows and get errors like this while building:

> Unhandled Exception: System.IO.FileLoadException: Could not load file or assembly 'AutoRest, Version=0.17.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35' or one of its dependencies. Strong name validation failed. (Exception from HRESULT: 0x8013141A) ---> System.Security.SecurityException: Strong name validation failed. (Exception from HRESULT: 0x8013141A)

It means you need to disable strong name validation on your dev box:

`"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools\sn.exe" -Vr *`
`"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools\x64\sn.exe" -Vr *`


### Running AutoRest
#### Command Line
After building, the `AutoRest.exe` executable will be output to the `/binaries/net45/` folder. You can run it with the command line options specified in the [Command Line Interface](./cli.md) documentation.

#### Visual Studio
You can run (and debug) AutoRest by providing the command line parameters in the properties for the AutoRest project. To set these:
1. Open the properties for the AutoRest project.  
2. Select the `Debug` tab.  
3. Set the `Command line arguments` field in the `Start Options` section.  
4. Build the entire solution to make sure the generators and modelers are built.  
5. F5 the project.  

#### Troubleshooting

#####If the task runner window in Visual Studio does not show any tasks
Make sure that you have run `npm install` in the root folder.

#####If `AutoRest.exe` complains about not having generators for each language
Make sure that you have built the entire `AutoRest.sln` solution.

#####If you see the error `gulp is not recognized as an internal or external command`
`gulp` is located at `C:\Users\[user]\AppData\Roaming\npm\gulp` in Windows after you install it globally.

# Releasing AutoRest and ClientRuntimes

 - [ ] Merge pending PRs into the master branch
 - [ ] Create a release branch from master
 - [ ] Update Changelog.md
 - [ ] Publish .NET Runtimes (increment versions as appropriate) using [automated build](http://azuresdkci.cloudapp.net/view/3-AutoRest/job/autorest-publish/)
 - [ ] Publish Node Runtimes (increment versions as appropriate)
 - [ ] Publish Java Runtimes (increment versions as appropriate)
 - [ ] Publish Ruby Runtimes (increment versions as appropriate)
 - [ ] Publish Python Runtimes (increment versions as appropriate)
 - [ ] Create a signed package using [automated build](http://azuresdkci.cloudapp.net/view/3-AutoRest/job/autorest-sign/) with build parameters: sha1: release branch name, scope: CodeGenerator
 - [ ] Smoke Test the signed package (Run Autorest.exe to check help and generate a sample spec for any language)
 - [ ] Publish Choco package {upload autorest.0.15.0.symbols.nupkg from the downloaded archive of the successful signing job}(Please look at the secure notebook for creds)
 - [ ] Publish nuget package [using automated build](http://azuresdkci.cloudapp.net/view/3-AutoRest/job/autorest-publish/)
 - [ ] Create a github release from the release branch including a tag
 - [ ] Add -SNAPSHOT to Java Runtime versions
 - [ ] Update [Docker file](https://github.com/Azure/autorest/blob/master/Tools/dockerfiles/Dockerfile) in the release branch
 - [ ] Add zip packages as a binary to the release
 - [ ] Copy over the changelog as release notes for github release
 - [ ] Publish the github release
 - [ ] Login to [dockerhub] (https://hub.docker.com/r/azuresdk/autorest/~/settings/automated-builds/) and trigger the build using the release tag (look at the secure notebook for creds)
 - [ ] Smoke test the nuget and npm packages
 - [ ] Merge release -> master
 - [ ] Bump up the version of autorest.exe
   - [ ] Update Assembly Info in AutoRest.Core
   - [ ] Update AutoRest.nuget.proj to build nightly using the next version
   - [ ] Run `gulp syncDependencies` from the root of the cloned AutoRest repository
