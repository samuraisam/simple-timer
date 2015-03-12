![http://simple-timer.googlecode.com/files/screenshot5.png](http://simple-timer.googlecode.com/files/screenshot5.png)

This is an activity timer written in C# .NET. It features the global key commands, alt+spc to start/stop the timer and crtl+alt+spc to reset the time, allowing for unobtrusive and simple time tracking.

[![](http://author.brothersoft.com/softimg/pick_100.gif)](http://www.brothersoft.com/simple-timer-300415.html)

## Explanation ##

I wrote this timer because there were no simple timers out there on the 'net worth using. The total size of the EXE is less than 36kb. It utilizes the [UserActivityHook](http://www.codeproject.com/csharp/globalhook.asp) class introduced on codeproject.com for the global key commands. Everything else is stock .NET. This would work great as an example of using the `UserActivityHook` class (everything from `KeyDown`, `KeyPress` and `KeyUp` usage to canceling the bubbling of events).

As of 1.1, users are able to run multiple instances and give them names. I also added the ability to control the timer from a context menu on the taskbar. While the timer is running, right-click on the taskbar item to use this functionality. When more than one timer is opened, global key commands work only for the first-opened timer (this is why I added the taskbar functionality).

As of 1.2, users can keep track of their start and stopping times using the new built-in logger. The triangle-button on the bottom slides out a log window which displays a log of starting, stopping and total times. This data can be selected using the top-left button and pasted into an Excel document for printing or reporting.

As of 1.3 a ton of functionality has been added while simplifying the interface. The main interface buttons all now use images in addition to text for both recognizability and accessibility. Users now can right-click anywhere on the form to access a contextual menu with preferences and new modes of operation. Timer now provides a **countdown** timer as well as the regular **stopwatch**. Switch between them using the contextual menu. Users can now also change the transparency of their timers and set them to always stay on top, as well as tell the timer to alert them at preset intervals of time. All of this new functionality and imagery has come at a small cost--the executable is now just over 110kb.

As of 1.4 Beta 1 I've added the ability to save and open timers, the ability to print the timer log, the option to shrink the interface to a 120x40 box (mini-interface), a few bugs fixed and the right-click menu (the main entry point to the extended functionality of Timer) will now work on the entire surface of Timer.

## Use ##

Key Commands:
  * **Start Timer/Stop Timer** `Alt + Space` (from anywhere in the system while the app is running)
  * **Reset Timer** `Crtl + Alt + Space` (from anywhere in the system while the app is running)
  * **Quit** `Escape` (while the app is in focus)

To use, open Timer from your Start Menu; enter a name for the timer; and start using! You can do this with as many Timers as you need, simply rinse-lather-repeat!

## Contributing ##
Please feel free to contribute to this project. Just email me to get commit access. If you want to contribute monetarily, do so via Paypal; my Paypal address is [samuraiblog@gmail.com](mailto:samuraiblog@gmail.com). This is my first C#/.NET project. If there is anything you'd like to recommend but don't have time to write code for, I'd greatly appreciate the advise via email. :)