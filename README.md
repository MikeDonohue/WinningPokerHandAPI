# WinningPokerHandAPI

What is this?

A ASP.NET CORE Restful API that accepts requests containing poker hands, compares their hand strength and returns the winner.


What makes this API Restful?

Use of a uniform interface (UI):
All Https verb work as expected in reguards to their related resource. All resources have their own endpoints. Currently this API only implements GET, and POST but could easily be expanded to intereact with other http verys as the project grows. 

Client-server based:
Seperation of concers is important. This is strictly a server.

Stateless operations:
This API is stateless and no request is effected by prior requests. This doesn't mean there arn't on follow on request as a result of generating a resourse. The consumer of this API will be informed what they can do with a response since I employ HATEOAS. This means when you get a response back you also get all of the uris you can interact with using that data. 

Layered system:
My api is seperated into three layers. 
- Controllers that accept the HTTP requests.
- Servies that perform business logic.
- Repositories that interact with the database.

Code on Demand:
My API only acts when it is prompted to. 

Caching:
Basic caching implemented. Can be improved via use of etags.

Testing this API for yourself? Please see my included postman test suite. 

I used GitHub's built in ticketing system when working on this project to track my commits against. Feel free to look at the projects tab to see for yourself. 
