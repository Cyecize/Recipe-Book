# Recipe Book
Simple demo application for testing the capabilities of Microsoft WPF platform.

The app is strategically split into 3 sub projects - Front end, Business Logic and Database Communication.

Interesting things to get from this repo:
* Navigation management - Check out logic behind INavigator and switching between pages and the creation of new view models.
* Generic Database Communication - Check out logic behind  **IDataService<T, I>** . It implements all commonly used **CRUD** operations and allows us to abstract from communication with DbContext.

Some of the technologies used:
* .NET Core 3.1
* .NET Framework 3.1 With MySql
* WPF .NET
* Microsoft Dependency Injection

App was done by me for a colleague of mine for educational purpose.
If you have questions, feel free to contact me.

Prior to making this app I hadn't really used WPF so I have watched a really great tutorial/series on youtube that you can watch [here](https://www.youtube.com/watch?v=V9UdD96iTbk&list=PLA8ZIAm2I03jSfo18F7Y65XusYzDusYu5).

