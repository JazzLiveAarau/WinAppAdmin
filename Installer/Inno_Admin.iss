; Installation of JAZZ live AARAU Admin

[Setup]
AppPublisher=JAZZ live AARAU
AppPublisherURL=https://jazzliveaarau.ch/
VersionInfoCompany=JAZZ live AARAU
AppName=JAZZ live AARAU Admin
AppVerName=JAZZ live AARAU Admin version 1.98
DefaultDirName={sd}\Apps\JazzLiveAarau\Admin
DefaultGroupName=JAZZ live AARAU Admin
UninstallDisplayIcon={app}\JazzAppAdmin.exe
Uninstallable=yes
Compression=lzma
SolidCompression=yes
OutputDir= NeueVersion
OutputBaseFilename= SetupJazzLiveAarauAdmin-version-1-98

[Dirs]
Name: "{app}\appdata"; Permissions: users-modify
Name: "{app}\Help"; Permissions: users-modify
Name: "{app}\XmlVorlagen"; Permissions: users-modify
Name: "{app}\LatestVersionInfo"; Permissions: users-modify
Name: "{app}\Dokumente"; Permissions: users-modify
; Fix of problem for Peter H????  Name: "{app}\NeueVersion"; Permissions: users-modify

[Files]
Source: "JazzAppAdmin.exe"; DestDir: "{app}"
Source: "JazzLoginLogout.dll"; DestDir: "{app}"
Source: "Ftp.dll"; DestDir: "{app}"
Source: "JazzFtp.dll"; DestDir: "{app}"
Source: "JazzApp.dll"; DestDir: "{app}"
Source: "JazzVersion.dll"; DestDir: "{app}"
Source: "zxing.dll"; DestDir: "{app}"
Source: "zxing.presentation.dll"; DestDir: "{app}"
Source: "Help\JAZZ_live_AARAU_Admin.rtf"; DestDir: "{app}\Help"; Flags: isreadme; Permissions: users-modify

[Icons]
Name: "{group}\JAZZ live AARAU Admin"; Filename: "{app}\JazzAppAdmin.exe"

[InstallDelete]
Type: files; Name: "{app}\JazzAppAdmin.exe"
Type: files; Name: "{app}\JazzAppAdminSettings.config"
Type: files; Name: "{app}\Ftp.dll"
Type: files; Name: "{app}\JazzFtp.dll"
Type: files; Name: "{app}\JazzApp.dll"
Type: files; Name: "{app}\JazzLoginLogout.dll"
Type: files; Name: "{app}\JazzVersion.dll"
Type: files; Name: "{app}\zxing.dll"
Type: files; Name: "{app}\zxing.presentation.dll"

[UninstallDelete]
Type: files; Name: "{app}\JazzAppAdminSettings.config"
