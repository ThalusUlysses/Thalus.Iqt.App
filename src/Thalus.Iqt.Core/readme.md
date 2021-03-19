# Overview
Installation Qualification Text (IQT) mainly means that a set of binaries and directores are qualified at a specific location. The qualification creates a snapshot of the folderstructure, files and file versions.
With this qualification system changes can easily be identified. Most common use case is to proof that a system is still as delivered and nothing has been changed. 

# How does it work?
Basically a qualified name is created by a set of criterias such like size, timestamp and version identifiers.
The IQT creates identities for files and directories, where each items can be identified uniquely
## Files
There are two types of files. Those with version information and those without. Depending the type the qualified name is beeing created
### With Version
For examples *.dll's come with a version ```FileVersionInfo``` that can be picked up for qualification.

```C#
FileVersionInfo k;
FileInfo fi;

 $"{k.FileName}_{k.ProductName}_{k.ProductVersion}_{k.FileVersion}_{fi.Length}";
 ```
 ### Without Version
 For example *.txt files. Those do not have a ```FileVersionInfo``` that can be picked up by the qualification
 ```C#
FileInfo fi;

$"{fi.FullName}_{fi.LastWriteTimeUtc.ToString(CultureInfo.InvariantCulture)}_{fi.Length}";
 ```
 ## Directories
 There are two types of creation methods for the qualified name regarding directories. Those including the creation time stamp and those without.
 ### With Creation Time Stamp
```C#
$"{di.FullName}_{di.CreationTimeUtc.ToString(CultureInfo.InvariantCulture)}"
```
### Without Creation Time Stamp
```C#
$"{di.FullName}"
```
# Using the Functionality
The IQT comes up with two major functions.
- Creation of identities
- Comparison of identites
## Creation Example
```C#
IIqtExclude exclude;
string[] diectories;

IPoorMansIoC ioc = new IqtIoc();

IResult<IIqtIdentityCreator>  resultCreator =  ioc.Get<IIqtIdentityCreator>().ThrowIfException();
IIqtIdentityCreator creator = result.ResultSet;

IIqtIdentity[] identities = creator.CreateFrom(exclude,directories);
```
## Comparison Example
```C#
IIqtExclude exclude;
string[] diectories;
IIqtIdentity[] identities;

IPoorMansIoC ioc = new IqtIoc();

IResult<IIqtIdentityCreator> resultCreator =  ioc.Get<IIqtIdentityCreator>().ThrowIfException();
IIqtIdentityCompare creator = resultCreator.ResultSet;

IResult<IIqtIdentityCompare> resultComparer =  ioc.Get<IIqtIdentityCompare>().ThrowIfException();
IIqtIdentityCompare creator = resultComparer.ResultSet;

IIqtIdentity[] current = creator.CreateFrom(exclude,directories);

IqtIdentityResultSet result = comparer.CompareIdentities(identities, current);
```