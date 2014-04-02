## Top News for Windows Phone (Sample App)
#### Gage Ames (gage@gageames.com)

Top News for Windows Phone is a sample Windows Phone 8 app that aims to demonstrate the core concepts of Windows Phone development and REST API incorporation.  This app uses the [USA TODAY Articles API](http://developer.usatoday.com/docs/read/articles) to obtain today's top news articles in JSON format.  The JSON is then parsed using [Json.NET](http://json.codeplex.com) and displayed in the app.  The article names can be tapped to open the full article in the web browser.

### Getting Started
The only setup required to run this app is a USA TODAY Articles API key.  You can request one at the [USA TODAY Developer Network website](http://developer.usatoday.com/apps).  Once you have your API key, replace the following line within `UsaTodayTopNews\UsaTodayApi.cs`:
```C#
private static string ApiKey = "YOUR_API_KEY";
```

### NuGet Packages Required
* [The Window Phone Toolkit](http://phone.codeplex.com)
* [Json.NET](http://json.codeplex.com)
* [Microsoft HTTP Client Libraries](https://www.nuget.org/packages/Microsoft.Net.Http)

### License
This software is distributed free of charge and licensed under the MIT License. For more information about this license and the terms of use of this software, please review the LICENSE file.
