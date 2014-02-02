;NSIS LongAccess Windows Application Installer
;Languages Supported: English, Greek

;----------------------------------------------
;Include Modern UI 2
!include x64.nsh
!include MUI2.nsh
!include FileFunc.nsh
!include DotNetChecker.nsh

;----------------------------------------------
;General

	;Name and file
	Name "Longaccess"
	OutFile "Longaccess-0.2.1-Windows7-64-bit.exe"
	
	;Default Installation Folder
	InstallDir "$LOCALAPPDATA\Longaccess Client"
	
	;Get installation folder from registry if available
	InstallDirRegKey HKCU "Software\Longaccess" ""

	;Request application privileges for Windows Vista+
	RequestExecutionLevel admin

;----------------------------------------------
;Interface Settings

	!define MUI_ABORTWARNING

	;Show all languages, despite user's codepage
	!define MUI_LANGDLL_ALLLANGUAGES
	
;----------------------------------------------
;Language Selection Dialog Settings

	;Remember the installer language
	!define MUI_LANGDLL_REGISTRY_ROOT "HKCU"
	!define MUI_LANGDLL_REGISTRY_KEY "Software\Longaccess"
	!define MUI_LANGDLL_REGISTRY_VALUENAME "Longaccess Installer Language"

;----------------------------------------------
;Pages

	!insertmacro MUI_PAGE_WELCOME
	!insertmacro MUI_PAGE_LICENSE "License.txt"
	;!insertmacro MUI_PAGE_COMPONENTS
	;!insertmacro MUI_PAGE_DIRECTORY
	!insertmacro MUI_PAGE_INSTFILES

	!insertmacro MUI_UNPAGE_CONFIRM
	!insertmacro MUI_UNPAGE_INSTFILES

;----------------------------------------------
;Languages

	!insertmacro MUI_LANGUAGE "English" ;first language is the default language
	!insertmacro MUI_LANGUAGE "Greek"
	;!insertmacro MUI_LANGUAGE "French"
	;!insertmacro MUI_LANGUAGE "German"
	;!insertmacro MUI_LANGUAGE "Spanish"
	;!insertmacro MUI_LANGUAGE "SpanishInternational"
	;!insertmacro MUI_LANGUAGE "SimpChinese"
	;!insertmacro MUI_LANGUAGE "TradChinese"
	;!insertmacro MUI_LANGUAGE "Japanese"
	;!insertmacro MUI_LANGUAGE "Korean"
	;!insertmacro MUI_LANGUAGE "Italian"
	;!insertmacro MUI_LANGUAGE "Dutch"
	;!insertmacro MUI_LANGUAGE "Danish"
	;!insertmacro MUI_LANGUAGE "Swedish"
	;!insertmacro MUI_LANGUAGE "Norwegian"
	;!insertmacro MUI_LANGUAGE "NorwegianNynorsk"
	;!insertmacro MUI_LANGUAGE "Finnish"
	;!insertmacro MUI_LANGUAGE "Russian"
	;!insertmacro MUI_LANGUAGE "Portuguese"
	;!insertmacro MUI_LANGUAGE "PortugueseBR"
	;!insertmacro MUI_LANGUAGE "Polish"
	;!insertmacro MUI_LANGUAGE "Ukrainian"
	;!insertmacro MUI_LANGUAGE "Czech"
	;!insertmacro MUI_LANGUAGE "Slovak"
	;!insertmacro MUI_LANGUAGE "Croatian"
	;!insertmacro MUI_LANGUAGE "Bulgarian"
	;!insertmacro MUI_LANGUAGE "Hungarian"
	;!insertmacro MUI_LANGUAGE "Thai"
	;!insertmacro MUI_LANGUAGE "Romanian"
	;!insertmacro MUI_LANGUAGE "Latvian"
	;!insertmacro MUI_LANGUAGE "Macedonian"
	;!insertmacro MUI_LANGUAGE "Estonian"
	;!insertmacro MUI_LANGUAGE "Turkish"
	;!insertmacro MUI_LANGUAGE "Lithuanian"
	;!insertmacro MUI_LANGUAGE "Slovenian"
	;!insertmacro MUI_LANGUAGE "Serbian"
	;!insertmacro MUI_LANGUAGE "SerbianLatin"
	;!insertmacro MUI_LANGUAGE "Arabic"
	;!insertmacro MUI_LANGUAGE "Farsi"
	;!insertmacro MUI_LANGUAGE "Hebrew"
	;!insertmacro MUI_LANGUAGE "Indonesian"
	;!insertmacro MUI_LANGUAGE "Mongolian"
	;!insertmacro MUI_LANGUAGE "Luxembourgish"
	;!insertmacro MUI_LANGUAGE "Albanian"
	;!insertmacro MUI_LANGUAGE "Breton"
	;!insertmacro MUI_LANGUAGE "Belarusian"
	;!insertmacro MUI_LANGUAGE "Icelandic"
	;!insertmacro MUI_LANGUAGE "Malay"
	;!insertmacro MUI_LANGUAGE "Bosnian"
	;!insertmacro MUI_LANGUAGE "Kurdish"
	;!insertmacro MUI_LANGUAGE "Irish"
	;!insertmacro MUI_LANGUAGE "Uzbek"
	;!insertmacro MUI_LANGUAGE "Galician"
	;!insertmacro MUI_LANGUAGE "Afrikaans"
	;!insertmacro MUI_LANGUAGE "Catalan"
	;!insertmacro MUI_LANGUAGE "Esperanto"
	;!insertmacro MUI_LANGUAGE "Asturian" */

;----------------------------------------------
;Reserve Files

	;If you are using solid compression, files that are required before
	;the actual installation should be stored first in the data block,
	;because this will make your installer start faster.

	!insertmacro MUI_RESERVEFILE_LANGDLL

;----------------------------------------------
;Installer Functions

Function .onInit

	!insertmacro MUI_LANGDLL_DISPLAY
	
FunctionEnd

;----------------------------------------------
;Installer Section

Section "Install" SecInstall
	SetRegView 64
	
	;define the output path for the files
	SetOutPath "$INSTDIR"
	
	;Check if .NET 4 Full is installed
	!insertmacro CheckNetFramework 40Full
	
	;specify files to go in output path
	File /r "lacli"
	File "GuiClient.exe"
	File "GuiClient.exe.config"
	File "Thrift.dll"
	
	;Get total installation size in KB
	${GetSize} "$INSTDIR" "/S=0K" $0 $1 $2
	IntFmt $0 "0x%08X" $0
	
	;Set variable for uninstaller executable name and its registry entry key
	!define UNINSTALLER_NAME "Uninstall.exe"
	!define REG_UNINSTALL "Software\Microsoft\Windows\CurrentVersion\Uninstall\Longaccess"
	!define WEBSITE_LINK "http://longaccess.com"

	;Write Registry keys for uninstaller information in Windows Control Panel
	WriteRegStr HKCU "${REG_UNINSTALL}" "DisplayName" "Longaccess"
	WriteRegStr HKCU "${REG_UNINSTALL}" "DisplayIcon" "$\"$INSTDIR\GuiClient.exe$\""
	WriteRegStr HKCU "${REG_UNINSTALL}" "Publisher" "The Longaccess Company"
	WriteRegStr HKCU "${REG_UNINSTALL}" "DisplayVersion" "0.2.1"
	WriteRegDWord HKCU "${REG_UNINSTALL}" "EstimatedSize" "$0"
	WriteRegStr HKCU "${REG_UNINSTALL}" "HelpLink" "${WEBSITE_LINK}"
	WriteRegStr HKCU "${REG_UNINSTALL}" "URLInfoAbout" "${WEBSITE_LINK}"
	WriteRegStr HKCU "${REG_UNINSTALL}" "InstallLocation" "$\"$INSTDIR$\""
	WriteRegStr HKCU "${REG_UNINSTALL}" "InstallSource" "$\"$EXEDIR$\""
	WriteRegDWord HKCU "${REG_UNINSTALL}" "NoModify" 1
	WriteRegDWord HKCU "${REG_UNINSTALL}" "NoRepair" 1
	WriteRegStr HKCU "${REG_UNINSTALL}" "UninstallString" "$\"$INSTDIR\${UNINSTALLER_NAME}$\""
	WriteRegStr HKCU "${REG_UNINSTALL}" "Comments" "Uninstalls Longaccess from your computer."
	
	;Store installation folder
	WriteRegStr HKCU "Software\Longaccess" "" $INSTDIR
	
	;Create uninstaller
	WriteUninstaller "$INSTDIR\${UNINSTALLER_NAME}"

	;Create shortcuts
	CreateDirectory $SMPROGRAMS\Longaccess
	CreateShortCut "$DESKTOP\Longaccess.lnk" "$INSTDIR\GuiClient.exe" "-i" ; use defaults for parameters, icon, etc.
	CreateShortCut "$SMPROGRAMS\Longaccess\Longaccess.lnk" "$INSTDIR\GuiClient.exe" "-i" ; use defaults for parameters, icon, etc.
	CreateShortCut "$SMPROGRAMS\Longaccess\Uninstall Longaccess.lnk" "$INSTDIR\${UNINSTALLER_NAME}" ; use defaults for parameters, icon, etc.
	
SectionEnd

;----------------------------------------------
;Descriptions

	;USE A LANGUAGE STRING IF YOU WANT YOUR DESCRIPTIONS TO BE LANGAUGE SPECIFIC

	;Assign descriptions to sections
	;!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
		;!insertmacro MUI_DESCRIPTION_TEXT ${SecDummy} "A test section."
	;!insertmacro MUI_FUNCTION_DESCRIPTION_END

;----------------------------------------------
;Uninstaller Section
Section "Uninstall"

	;SetOutPath "$INSTDIR"
	
	;Always delete uninstaller first
	Delete "$INSTDIR\${UNINSTALLER_NAME}"

	;Delete Start Menu entries
	Delete "$DESKTOP\Longaccess.lnk"
	Delete "$SMPROGRAMS\Longaccess\Longaccess.lnk"
	Delete "$SMPROGRAMS\Longaccess\Uninstall Longaccess.lnk"
	;RMDir "$SMPROGRAMS\Longaccess"
	
	;Delete installed files and directories
	Delete "$INSTDIR\GuiClient.exe"
	Delete "$INSTDIR\GuiClient.exe.config"
	Delete "$INSTDIR\Thrift.dll"
	RMDir /r "$INSTDIR\lacli"
	RMDir "$INSTDIR"
	
	;Delete registry entries
	DeleteRegKey HKCU "Software\Longaccess"
	DeleteRegKey HKCU "Software\Longaccess\Longaccess Installer Language"
	DeleteRegKey HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\Longaccess"
 
SectionEnd

;----------------------------------------------
;Uninstaller Functions

Function un.onInit

	!insertmacro MUI_UNGETLANGUAGE
	
FunctionEnd
