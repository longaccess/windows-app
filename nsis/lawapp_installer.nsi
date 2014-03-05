;NSIS LongAccess Windows Application Installer
;Languages Supported: English, Greek

;----------------------------------------------
;Include Modern UI 2
!include x64.nsh
!include MUI2.nsh
!include FileFunc.nsh
!include DotNetChecker.nsh
!include Sections.nsh

;----------------------------------------------
;General

	;Name and file
	Name "Longaccess"
	
	;Default Installation Folder
	InstallDir "$LOCALAPPDATA\Longaccess Client"
	
	;Get installation folder from registry if available
	InstallDirRegKey HKCU "Software\Longaccess" ""

	;Request application privileges for Windows Vista+
	RequestExecutionLevel user
	
	BrandingText "The Longaccess Company"

	; the filename of the uninstaller
	!define UNINSTALLER_NAME "Uninstall.exe"
	
	; the platform description (appears in installer filename)
	!ifndef PLATFORM
	!define PLATFORM Windows
	!endif

    ; if this is a 64 bit only release
    
	!searchparse /noerrors ${PLATFORM} "32-bit" THIRTYTWO
	!ifndef THIRTYTWO
		!define SIXTYFOUR 1
	!else
		!define SIXTYFOUR 0
	!endif

	; the application name that appears in files (like the installer)
	!define NAME Longaccess

	; the location of the backend files	
	!ifndef LACLI
	!define LACLI lacli
	!endif

	; the location of the release files	
	!ifndef RELEASE
	!define RELEASE Release
	!endif

;----------------------------------------------
;Some Functions
Var Extension
Var ExtCmd

Function setExtensionVars

	StrCpy $Extension ".longaccess"
	StrCpy $ExtCmd '"$INSTDIR\GuiClient.exe" '
	
FunctionEnd

Var Version

Function setVersion
	
	nsExec::ExecToStack '"$INSTDIR\lacli\lacli.exe" --version'
	Pop $0 ; exit status
	Pop $1 ; output
	StrCpy $Version $1 "" 6

FunctionEnd

Function LaunchLink

    ExecShell "" "$DESKTOP\Longaccess.lnk"

FunctionEnd

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
	!insertmacro MUI_PAGE_COMPONENTS
	;!insertmacro MUI_PAGE_DIRECTORY
	!insertmacro MUI_PAGE_INSTFILES
	
	# These indented statements modify settings for MUI_PAGE_FINISH
    !define MUI_FINISHPAGE_NOAUTOCLOSE
	
	
	!define MUI_FINISHPAGE_LINK $(LINK_INFO)
	!define MUI_FINISHPAGE_LINK_LOCATION "http://longaccess.com"
    !define MUI_FINISHPAGE_RUN
    !define MUI_FINISHPAGE_RUN_FUNCTION "LaunchLink"
	!insertmacro MUI_PAGE_FINISH

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
  !ifdef SIGN
	!ifdef INNER
 
	  ; If INNER is defined and signing is happening, then we aren't supposed 
	  ; to do anything except write out the installer.  This is better than 
	  ; processing a command line option as it means this entire code path
	  ; is not present in the final (real) installer.
 
      !echo "Inner invocation writing uninstaller"                  ; just to see what's going on
	  WriteUninstaller "$%TEMP%\${UNINSTALLER_NAME}"
	  Abort  ; just bail out quickly when running the "inner" installer
	  !echo "Inner invocation quitting"                  ; just to see what's going on
	!endif
  !endif
  !ifndef INNER	 
    !if ${SIXTYFOUR}	
	${If} ${RunningX64}
	${Else}
		MessageBox MB_OK "This installation of the Longaccess Client only works on 64-bit Windows."
		Abort
	${EndIf}
    !endif
	
	!insertmacro MUI_LANGDLL_DISPLAY
	
	ReadRegStr $R0 HKCU \
		"Software\Microsoft\Windows\CurrentVersion\Uninstall\Longaccess" \
		"UninstallString"
	StrCmp $R0 "" done
 
	MessageBox MB_OKCANCEL|MB_ICONEXCLAMATION \
	"Longaccess is already installed. $\n$\nClick `OK` to remove the \
	previous version or `Cancel` to cancel this installation." \
	IDOK uninst
	Abort
	
	;Run the uninstaller
	uninst:
		ClearErrors
		ExecWait '$R0 _?=$INSTDIR' $R1 ;Do not copy the uninstaller to a temp file. Also need this so the executed installers waits for the exec of the uninstaller
		
		StrCmp $R1 1 0 no_uninst_cancel
		Abort
		
		no_uninst_cancel:
			IfErrors no_remove_uninstaller

			IfFileExists "$INSTDIR\${UNINSTALLER_NAME}" 0 no_remove_uninstaller
				Delete "$INSTDIR\${UNINSTALLER_NAME}"
				RMDir $INSTDIR

			no_remove_uninstaller:
		
	done:
  !endif	
FunctionEnd

!ifdef INNER
  !echo "Inner invocation"                  ; just to see what's going on
  OutFile "$%TEMP%\tempinstaller.exe"       ; not really important where this is
  SetCompress off                           ; for speed
!else
  !ifdef SIGN
    ; we are signing the installer and need to sign the uninstaller as well.

    !echo "Outer invocation"
 
    ; Call makensis again, defining INNER.  This writes an installer for us which, when
    ; it is invoked, will just write the uninstaller to some location, and then exit.
    ; Be sure to substitute the name of this script here.
 
    !system "$\"${NSISDIR}\makensis$\" $\"/DSIGN=${SIGN}$\" /DINNER /V4 lawapp_installer.nsi" = 0
 
    ; So now run that installer we just created as %TEMP%\tempinstaller.exe.  Since it
    ; calls quit the return value isn't zero.
 
    !system "$%TEMP%\tempinstaller.exe" = 2
 
    ; That will have written an uninstaller binary for us.  Now we sign it with your
    ; favourite code signing tool.
  
    !ifdef TIMESTAMP
      !define EXTRASIGNARG "/tr ${TIMESTAMP}"
    !else
      !define EXTRASIGNARG ""
    !endif
    !system "SIGNTOOL sign /a /n $\"${SIGN}$\" ${EXTRASIGNARG} $%TEMP%\${UNINSTALLER_NAME}" = 0 
  !endif

  ; Good.  Now we can carry on writing the real installer.

  !ifdef VERSION
    OutFile "${NAME}-${VERSION}-${PLATFORM}.exe"
  !else
    OutFile "${NAME}-unknown-${PLATFORM}.exe"
  !endif

!endif

;----------------------------------------------
;Installer Section

Section "Core Installation" SecInstall
  !ifndef INNER
	!if ${SIXTYFOUR}
	SetRegView 64
	!endif
	;Make this component section mandatory in the components selection page.
	SectionIn RO
	
	;define the output path for the files
	SetOutPath "$INSTDIR"
	
	;Check if .NET 4 Full is installed. This uses the macro writtin in the included DotNetChecker.nsh.
	;DotNetChecker.nsh needs to be placed in the "Include" folder of your nsis installation.
	;The macro makes the call DotNetChecker::IsDotNet${FrameworkVersion}Installed from the DotNetChecker.dll,
	;which has to be in the plugins folder of your nsis installation.
	!insertmacro CheckNetFramework 40Full

	;specify files to go in output path
	File /r "${LACLI}"
	File /oname=GuiClient.exe ${RELEASE}\GuiClient.exe
	File /oname=GuiClient.exe.config ${RELEASE}\GuiClient.exe.config
	File /oname=Thrift.dll ${RELEASE}\Thrift.dll
	
	Call setVersion
	Call setExtensionVars
	
	;Get total installation size in KB
	${GetSize} "$INSTDIR" "/S=0K" $0 $1 $2
	IntFmt $0 "0x%08X" $0
	
	;Set variable for uninstaller executable name and its registry entry key
	!define REG_UNINSTALL "Software\Microsoft\Windows\CurrentVersion\Uninstall\Longaccess"
	!define WEBSITE_LINK "http://longaccess.com"

	;Write Registry keys for uninstaller information in Windows Control Panel
	WriteRegStr HKCU "${REG_UNINSTALL}" "DisplayName" "Longaccess"
	WriteRegStr HKCU "${REG_UNINSTALL}" "DisplayIcon" "$\"$INSTDIR\GuiClient.exe$\""
	WriteRegStr HKCU "${REG_UNINSTALL}" "Publisher" "The Longaccess Company"
	WriteRegStr HKCU "${REG_UNINSTALL}" "DisplayVersion" "$Version"
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
	
	;Store keys to handle the file association and the shell commands
	WriteRegStr HKCU "Software\Classes\longaccess\DefaultIcon" "" "$INSTDIR\GuiClient.exe"
	WriteRegStr HKCU "Software\Classes\longaccess\shell\open" "" "Open with Longaccess"
	WriteRegStr HKCU "Software\Classes\longaccess\shell\open\command" "" '$ExtCmd "%1"'

	;Set application capabilities settings
	WriteRegStr HKCU "Software\Longaccess\Capabilities" "ApplicationDescription" "The Longaccess Windows Client"
	WriteRegStr HKCU "Software\Longaccess\Capabilities" "ApplicationName" "longaccess"
	WriteRegStr HKCU "Software\Longaccess\Capabilities\FileAssociations" $Extension "longaccess"

	;Set longaccess as a registered applicaition
	WriteRegStr HKCU "Software\RegisteredApplications" "longaccess" "Software\LongaccessCLI\Capabilities"

	;Set .longaccess to longaccess class as defined above
	WriteRegStr HKCU "Software\Classes\.longaccess\OpenWithProgids" "longaccess" ""
	
	;Notify the system that there is a change in file assosiations, so the windows explorer updates accordingly.
	System::Call 'shell32.dll::SHChangeNotify(i, i, i, i) v (0x08000000, 0, 0, 0)'
	
	;Create uninstaller
	!ifdef SIGN
		; this packages the signed uninstaller
		File $%TEMP%\${UNINSTALLER_NAME}
	!else
		WriteUninstaller "$INSTDIR\${UNINSTALLER_NAME}"
	!endif

	;Create shortcuts
	CreateDirectory $SMPROGRAMS\Longaccess
	CreateShortCut "$DESKTOP\Longaccess.lnk" "$INSTDIR\GuiClient.exe" ;"-i" ; use defaults for parameters, icon, etc.
	CreateShortCut "$SMPROGRAMS\Longaccess\Longaccess.lnk" "$INSTDIR\GuiClient.exe" ;"-i" ; use defaults for parameters, icon, etc.
	CreateShortCut "$SMPROGRAMS\Longaccess\Uninstall Longaccess.lnk" "$INSTDIR\${UNINSTALLER_NAME}" ; use defaults for parameters, icon, etc.
  !endif	
SectionEnd

;----------------------------------------------
;Descriptions

	;USE A LANGUAGE STRING IF YOU WANT YOUR DESCRIPTIONS TO BE LANGAUGE SPECIFIC
	
	LangString LINK_INFO ${LANG_ENGLISH} "Visit the Longaccess site."
	LangString LINK_INFO ${LANG_GREEK} "Επισκεφθείτε τον ιστότοπο της Longaccess."
	
	;Define language strings for showing the right description in the components page.
	LangString DESC_SecInstall ${LANG_ENGLISH} "Installs all required components. This action also includes checking for the minimum required .NET Framework version (v4 Full) that needs to be installed in your system."
	LangString DESC_SecInstall ${LANG_GREEK} "Εγκατάσταση των απαραίτητων αρχείων. Η ενέργεια αυτή συμπεριλαμβάνει και τον έλεγχο της ελάχιστης απαιτούμενης έκδοσης του .NET Framework (v4 Full) που είναι εγκατεστημένο στο σύστημά σας."
	
	;Assign descriptions to sections
	!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
		!insertmacro MUI_DESCRIPTION_TEXT ${SecInstall} $(DESC_SecInstall)
	!insertmacro MUI_FUNCTION_DESCRIPTION_END

;----------------------------------------------
;Uninstaller Section
; only included in the inner invocation that calls WriteUninstaller
!ifdef INNER
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
	DeleteRegKey HKCU "Software\Classes\longaccess"
	DeleteRegValue HKCU "Software\RegisteredApplications" "longaccess"
	;DeleteRegValue HKCU "Software\Classes\.longaccess\OpenWithProgids" "longaccess"
	DeleteRegKey HKCU "Software\Classes\.longaccess"
	
	;Notify the system that there is a change in file assosiations, so the windows explorer updates accordingly.
	System::Call 'shell32.dll::SHChangeNotify(i, i, i, i) v (0x08000000, 0, 0, 0)'
	
	DeleteRegKey HKCU "Software\Longaccess"
	DeleteRegKey HKCU "Software\Longaccess\Longaccess Installer Language"
	DeleteRegKey HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\Longaccess"
 
SectionEnd
!endif

;----------------------------------------------
;Uninstaller Functions

Function un.onInit

	!insertmacro MUI_UNGETLANGUAGE
	
FunctionEnd
