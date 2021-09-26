# DotSpatial-2.0 For SmartLas by Li G.Q., 2021

For documentation and code samples see
https://dotspatial.codeplex.com/documentation
For discussions, questions and suggestions use
https://dotspatial.codeplex.com/discussions

Some sample projects there are at Examples folder.
Use DemoMap.exe to see basic functionality of DotSpatial library.

## Development agreement
* Main namespace for core dlls - DotSpatial.*
* Main namespace for plugins - DotSpatial.Plugins.*
* Use AnyCPU target for projects always when it's possible.
* Plugins which works only in Windows, should have output folder "..\Windows Extensions\PluginFolder".
* Plugins which works in Windows and Mono, should have output folder "..\Plugins\PluginFolder".
* Every release must be tagged in GIT.
* Use branches when adding a lot of changes.
* Write unit-tests, when it is possible.
* Use resources for message strings. Use language-specific .resx files when needed to localize GUI.
