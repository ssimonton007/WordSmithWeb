# WordSmithWeb
Book Word Counting application
This application was created for <a href="https://www.sourceallies.com/" target="_blank">Source Allies</a>. It is intended to show the thought process, problem solving and coding skills of Steven Simonton.

It was created using Visual Studio 2022.
Project Type: Blazor WebAssembly App

Additional Nuget Packages Include:

Serilog.AspNetCore(6.0.1) - For server-side logging

Swashbuckle.AspNetCore(6.4.0) - For the swagger UI

It has a Blazor UI and a REST API for the processing of the uploaded books.

The API was architected with a simple CQRS pattern. This increases development time, but it provides a very maintainable code base for future extensibility and bug fixes.

All the processing functionality is implemented through a Service based approach. This service is accessed by the controller through dependency injection
