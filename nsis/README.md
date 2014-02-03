Compile the lawapp_installer.nsi script with NSIS to build the Longaccess windows client installer.

The installer script uses the open source NSIS [NsisDotNetChecker][] plugin.

You need to build the source from that repo before you include it in your NSIS installation.

The header DotNetChecker.nsh goes in the Include folder and the library DotNetChecker.dll
goes in the Plugins folder. These folders can be found in your local NSIS installation.

Caution 1: If you use NSIS v3.0 and above, the dll goes in the "Plugins\x86-ansi" folder 
of your local installation.

Caution 2: You can try using the already built dll found in that repo, but it may not work.
		   To be safe, just compile the source from the NsisDotNetChecker repo.
		   You need at least Visual Studio 2010. Newer versions can import the solution with no problems.

[NsisDotNetChecker]: https://github.com/ProjectHuman/NsisDotNetChecker "NsisDotNetChecker"

