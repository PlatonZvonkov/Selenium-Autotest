# Veeam
The first task is a console app monitors targeted process in windows by name. Arguments of name, process lifetime, and check frequency are passed through creating shortcuts and adding 3 lines after "monitor.exe" in "Target" field. Application logs information in /logs folder about the activity of the targeted process.

The second task is data-driven NUnit Project with Selenium NuGet Package, parameterized data incoming via JSON array (file in folder but it can be a remote connection). Test checks if there is an expected amount of vacancies on the targeted page.

My code convention was according to Microsoft guidelines.
