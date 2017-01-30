#Read Me
This solution has three projects.

##XMLJSONConvertor:
One a DLL that handles the actual work of the checking the file then converting. It also has a helper class that handles the create files and streams, and extension class for string, that checks the string to see if it is actually JSON. The file helper class doesn't actually need to be in this DLL, there could be a class in each of the two applications that house those too file, however I decided to have one class because in theory if this DLL was to be used in multiple applications a lot of that functionality would have to be repeat across those applications.

##JSONXMLConsoleApp:
There is a console app, that requires you to pass two command line arguements. One for the source file and one for the target file, it first reads the target file to string, passes it to the DLL and then writes the convert text to a file. To run it you would need to from the command line you would need to navigate to the application directory and enter `JSONXMLConsoleApp.exe [sourcefile] [targetfile]`.

##JSONXMLWebservice:
This is a RESTful web service that requires you to POST one file either XML or JSON to `api/process` and then returns a response with the converted file. If that file isn't XML or JSON it will return a 405 HTTP error. This api call only supports one file at a time.
