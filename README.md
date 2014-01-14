The Longaccess App for Windows
==============================

This is an app for interacting with the [Longaccess service][la]. It is is a graphical application, written for the .NET framework. It also contains [a CLI backend][cli] which is written in [Python][py]. Using the app requires having registered for an account on the service. If you are unfamiliar with other aspects of the Longaccess service a good place to start is "[What is Longaccess?][]"

Installation
------------

Currently the binaries are built using Visual Studio 2012 on 64-bit Windows. Other platforms may work as well. For access to precompiled packages and installers check the [Longaccess downloads page][lad].

Dependencies
------------

The app requires .NET framework 3.5, and the user will be prompted to install it if it isn't available on the system.

Secure removal
--------------

When removing archives and certificates from the disk the app supports [secure deletion][sd] through an external program. In case a suitable removal program cannot be found the client will fallback on insecure deletion. Currently on windows we support support the following tools, if they are available on the system path:

* [sdelete][] (Windows, proprietary)
* [Eraser][] (Windows, open-source)

[la]: https://www.longaccess.com "the Longaccess website"
[lad]: https://downloads.longaccess.com "the Longaccess downloads page"
[py]: http://www.python.org "the python website"
[What is Longaccess?]: https://github.com/longaccess/longaccess-docs/blob/master/what_is_longaccess.md "what is Longaccess?"
[sd]: https://ssd.eff.org/tech/deletion "Secure deletion - EFF"
[sdelete]: http://technet.microsoft.com/en-us/sysinternals/bb897443.aspx "SDelete - Windows sysinternals"
[Eraser]: http://eraser.heidi.ie/ "Eraser"
