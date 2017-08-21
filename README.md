# AGL_CodeTest
Project created as part of the Coding test for AGL Energy
Set the Pet.Web project as the Start up project
Pet.Services project access the service end point http://agl-developer-test.azurewebsites.net/people.json to get the List of pets
Common project does the generic functions 
Pet.Model project defines the object models which are referred in other projects
Pet.ServiceTests has a unit test that checks if the service call retunrs results 
Autofac is used for the Dependancy injection
