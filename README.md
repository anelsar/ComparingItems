# ComparingItems

-----> IMPORTANT <-----
If it fails to run due to an "Could not find a part of the path \roslyn\csc.exe" error, the solution is </br>
to open Package manager console (Tools -> NuGet Package Manager -> Package Manager Console) and to update nugget packages with </br>
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r </br>
command.
-----------------------

This app was built using ASP.NET MVC in Visual Studio 2019 <br/>
For page styling Bootstrap 4.1.2 was used <br/>
For dependency injection Unity.mvc 5 was used <br/>
The item values are stored in a .json file

-----App description-----

The user sees a list of 6 items, their names, scores and current positions.
After clicking on the 'Show pairs' button a new random 'match' between two items gets generated and the user has the option to enter the score values
After entering the values and clicking the 'Generate new pair' button, a newly generated pair is presented to the user, and for the previous pair, if one of the score values was
greater then the other, the score of the item with the greater value is increased by one, and the user has the option to generate a new match pair. A user can generate pairs until 
every item has played a match against every other. After that a link button will be presented to the user for showing the item updated item rankings.

