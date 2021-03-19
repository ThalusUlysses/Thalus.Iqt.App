# Overview
Installation Qualification Text (IQT) mainly means that a set of binaries and directores are qualified at a specific location. The qualification creates a snapshot of the folderstructure, files and file versions.
With this qualification system changes can easily be identified. Most common use case is to proof that a system is still as delivered and nothing has been changed. 

# How does it work?
Basically a qualified name is created by a set of criterias such like size, timestamp and version identifiers.
The IQT creates identities for files and directories, where each items can be identified uniquely.
## Create an IQT file
```C
  -o, --output                    Installation Qualification Test reference output file *.json

  -f, --force                     Enables overwriting existing reference files *.json

  -d, --directory                 Directories that are associated with the IQT reference file. List of directories to include

  --exclude-files                 Exclude specific list of files from IQT creation with full qualified name

  --exclude-file-endings          Exclude a list of files with specific file endings

  --exclude-file-regex            Exclude files by list of regular expressions

  --exclude-directories           Exclude list of directoreis by full qualified name

  --exclude-directory regex       Exclude list of directoreis by regular expression

  --use-directory-creationdate    Include createion time stamp utc to directory identity

  -v, --verbose                   Set output to verbose messages.

  --help                          Display this help screen.

  --version                       Display version information.

Thalus.Iqt.App create --output <myOutputFilePath> --directory <myDirA> <myDirB>
// or
Thalus.Iqt.App create --output <myOutputFilePath>  --directory <myDirA> <myDirB> --force
```
## Compare an IQT file
```C
  -r, --reference    Installation qualification Test reference file *.json

  -d, --directory    Directories that are associated with the IQT reference file. List of directories to test

  -o, --output       Installation Qualification Test result output file *.json

  -f, --force        Enables overwriting existin result files *.json

  -v, --verbose      Set output to verbose messages.

  --help             Display this help screen.

  --version          Display version information.

Thalus.Iqt.App compare --reference <myReferenceFilePath> --directory <myDirA> <myDirB> --output <myOutputResultFilePath> 
// or
Thalus.Iqt.App compare --output <myReferenceFilePath>  --directory <myDirA> <myDirB> --output <myOutputResultFilePath> --force
```