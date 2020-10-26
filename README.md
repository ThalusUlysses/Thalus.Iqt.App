# Overview
Installation Qualification Test (IQT) is a tool to create reference files of directory and
file structures and adds comparison functions on it.
The tool was written to create identities from directories, directory structure and files
and save them to a *.json file.

# CMD Line

Thalus.Iqt.App uses the *commandLineParser* from https://github.com/commandlineparser/commandline, GIT like with verbs

**Example:**
```
app create --all
```

## Help
```
Thalus.Iqt.App.exe --help

  create       Creates an Installation Qualification Test file from existing folders

  compare      Compares an Installation Qualification Test file with the current installation (IQT)

  exitcodes    List of exit codes

  help         Display more information on a specific command.

  version      Display version information.
  ```
## Create
Creates a reference file form directory and file structure. Depening on the passed arguments. Items can be excluded by *--exclude-* either by specific name, regex or file endings
```
Thalus.Iqt.App.exe create --help

  -o, --output                    Installation Qualification Test reference output file *.json

  -f, --force                     Enables overwriting existing reference files *.json

  -d, --directory                 Directories that are associated with the IQT reference file. List of directories
                                  to include

  --exclude-files                 Exclude specific list of files from IQT creation with full qualified name

  --exclude-file-endings          Exclude a list of files with specific file endings

  --exclude-file-regex            Exclude files by list of regular expressions

  --exclude-directories           Exclude list of directoreis by full qualified name

  --exclude-directory regex       Exclude list of directoreis by regular expression

  --use-directory-creationdate    Include createion time stamp utc to directory identity

  -v, --verbose                   Set output to verbose messages.

  --help                          Display this help screen.

  --version                       Display version information.
```
**Example:**
```
thalus.iqt.app create --directory dirA dirB dirC --output  c:/temp/IqtOutfile.json
Created IQT file sucessfully at: c:/temp/IqtOutfile.json
Iqt exited with exitcode:0
```
**Result:**
```
{
  "Identities": [
    {
      "QualifiedName": "{
  "Identities": [
    {
      "QualifiedName": "<yourPath>Thalus.Iqt.App\\src\\Thalus.Iqt.App\\bin\\Release\\netcoreapp3.1\\win-x64\\publish",
      "Name": "publish",
      "FullName": "<yourPath>Thalus.Iqt.App\\src\\Thalus.Iqt.App\\bin\\Release\\netcoreapp3.1\\win-x64\\publish",
      "Hash": "09-AC-40-6D-52-BE-A6-FA-2A-21-E2-2A-4D-7C-D5-9B-B2-B1-4A-79",
      "Excluded": false
    },
    {
      "QualifiedName": "<yourPath>\\Thalus.Iqt.App.exe_Thalus Ulysses Installation Qualification Test_1.0.0_1.0.0.0_70061700",
      "Name": "Thalus.Iqt.App.exe",
      "FullName": "<yourPath>\\Thalus.Iqt.App.exe",
      "Hash": "85-AF-8C-F7-50-2D-CC-28-59-80-7C-9A-95-26-26-AB-40-DE-7C-E8",
      "Excluded": false
    },
    {
      "QualifiedName": "<yourPath>\\Thalus.Iqt.App.pdb_26.10.2020 08:57:34_3656",
      "Name": "Thalus.Iqt.App.pdb",
      "FullName": "<yourPath>\\Thalus.Iqt.App.pdb",
      "Hash": "B4-F2-88-CF-40-DD-AE-4E-8C-C8-F9-21-D5-CA-D7-CF-47-4D-CE-27",
      "Excluded": false
    }
  ],
  "Excludes": {
    "Files": [
    ],
    "FileNamePatterns": [
    ],
    "FileEndings": [
    ],
    "UseDirectoryTimeStamp": false,
    "Direcories": [
    ],
    "DirectoryNamePatterns": [
    ]
  }
}
```
## Compare
Compares an IQT reference file with the existing directory and file structure using the *create* functionality.

```
Thalus.Iqt.App.exe compare --help

  -r, --reference    Installation qualification Test reference file *.json

  -d, --directory    Directories that are associated with the IQT reference file. List of directories to test

  -o, --output       Installation Qualification Test result output file *.json

  -f, --force        Enables overwriting existin result files *.json

  -v, --verbose      Set output to verbose messages.

  --help             Display this help screen.

  --version          Display version information.
```
**Example positve:**
```
thalus.iqt.app compare --directory dirA dirB dirC --reference C:\\temp\\IqtOutfile.json --output C:\\temp\\Thalus.Iqt.App\\IqtResultOutfile.json
Iqt exited with exitcode:0
```
**Result:**
```
{
  "ExpectedButNotThere": [
  ],
  "ExcludedButNotThere": [
  ],
  "ThereButExcluded": [
  ],
  "ThereButNotExpected": [
  ],
  "ThereButWrongHash": [
  ]
}
```
Or in case that for example the *.pdb file is missing
**Example negative:**
```
thalus.iqt.app compare --directory dirA dirB dirC --reference C:\\temp\\IqtOutfile.json --output C:\\temp\\Thalus.Iqt.App\\IqtResultOutfile.json
Iqt exited with exitcode:402
```
**Result:**
```
{
  "ExpectedButNotThere": [
    {
      "Expected": {
        "QualifiedName": "<yourPath>\\Thalus.Iqt.App.pdb_26.10.2020 08:57:34_3656",
        "Name": "Thalus.Iqt.App.pdb",
        "FullName": "<yourPath>\\Thalus.Iqt.App.pdb",
        "Hash": "B4-F2-88-CF-40-DD-AE-4E-8C-C8-F9-21-D5-CA-D7-CF-47-4D-CE-27",
        "Excluded": false
      },
      "Current": null,
      "Text": "Identity was expected but was not found"
    }
  ],
  "ExcludedButNotThere": [
  ],
  "ThereButExcluded": [
  ],
  "ThereButNotExpected": [
  ],
  "ThereButWrongHash": [
  ]
}
```


