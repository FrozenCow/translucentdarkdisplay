Translucent Dark v1.8
by FrozenCow
http://www.softwarebakery.com/frozencow/

This package contains the Translucent Dark display for Growl for Windows.

Requirements
============
- Growl for Windows
- .NET Framework 3.5 SP1

Installation
============
Create the folder:
XP: "C:\Documents and Settings\{USER}\Local Settings\Application Data\Growl\2.0.0.0\Displays\Translucent Dark Display"
Vista or higher: "C:\Users\{USER}\AppData\Local\Growl\2.0.0.0\Displays\Translucent Dark Display"
and copy the files from this package there (assumed {USER} is your username).

Changelog
=========
v1.8
- Added option to prevent closing of notifications if mouse is hovering them.
- Fixed bug that faded notifications too soon.
- Fixed reversed items bug when docked in top.

v1.7
- Added option to fade in and out (instead of slide in and out).

v1.6
- Added ability to change fonts and font-sizes.
- Added option to 'pause' notifications when an fullscreen application is running.
- Fixed settings file being created in GfW's executable folder.
- Separated Growl.Displays.Wpf.dll from Growl.Displays.TranslucentDark.dll.
- Several other fixes.

v1.5
- Fixed keyboard-shortcuts crashing the display.
- Several code cleanups.

v1.4
- Added ability to use package with Growl's one-click install feature.

v1.3
- Added ability to change transparency of the container.
- Fixed ablity to click notifications.
- Removed references to SP1's versions of Dispatcher.Invoke, that will make it more likely to work under .NET Framework 3.5 without SP1.

v1.2
- Added configuration options:
	- Notification size.
	- Icon size.
	- Horizontal placement (left, center, right and stretch).
	- Vertical placement (top, center, bottom and stretch).
	- Notification and text coloring.
	- Visibility of icons and text.

v1.1
- Added support for sticky notifications.
- Added sliding animation when popping up or out.
- Fixed crashes for invalid notification icons.
- Fixed popups getting focus when popping up.
- Fixed several potential crashes.
