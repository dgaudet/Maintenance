Maintenance
This is a simple sample Web Api 2 example of an automobile maintenance api, which is fully unit tested.

## How To run:
* Open the sln file in Visual Studio 2015 (You can use the community edition for free)
* Do you have to do something to get all of the NuGet packages?
* On the top menu click Tests -> All Tests
* Right click on the Maintenance Project in the solution explorer and select �Set as Startup Project�
* Then you can run the app Debug -> Start Debugging
* The data is stored in memory and there is some data for you to play around with, but when you shut down the app, you will lose all of your new data
* Visual Studio will spin up an IISExpress web server, mine started on port 52970, yours may or may not. If not you will need to modify the port in the Angular -> Services.js file
* You should be able to access the gui at http://localhost:52970/angular/index.html