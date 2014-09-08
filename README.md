OWIN-Katana
===========
These are the code samples I've demonstrated on the [DevFM #10 : OWIN & Katana](http://www.eventbrite.com/e/devfm-10-owin-katana-tickets-12380830397) event at the [Microsoft Innovation Center](http://www.mic-belgique.be) in Mons, Belgium.

This repository contains 5 samples with different iterations.

1. HelloWorld
	- [Raw](https://github.com/fvilers/OWIN-Katana/releases/tag/hello-world-raw): an inline delegate that returns the well-known **Hello, world!** message;
	- [HTML](https://github.com/fvilers/OWIN-Katana/releases/tag/hello-world-html): the same sample but now returning a whole HTML document;
	- [Strongly typed](https://github.com/fvilers/OWIN-Katana/releases/tag/hello-world-strongly-typed): the same sample but using the OwinContext instead of a weakly typed dictionary;
2. Chaining
	- [Short-circuit](https://github.com/fvilers/OWIN-Katana/releases/tag/chaining-short-circuit): an example of how to **not** chain middlewares;
	- [The right way](https://github.com/fvilers/OWIN-Katana/releases/tag/chaining-right-way): an example of how to chain middlewares;
	- [Both ways](https://github.com/fvilers/OWIN-Katana/releases/tag/chaining-both-ways): an example of how the request and response navigates in the OWIN pipeline;
3. Conditionals
	- [Nested app](https://github.com/fvilers/OWIN-Katana/releases/tag/conditionals-nested-app): a nested app that responds to a specific path;
	- [More nested app](https://github.com/fvilers/OWIN-Katana/releases/tag/conditionals-nested-app-more): a nested app with two level of depth;
	- [When condition](https://github.com/fvilers/OWIN-Katana/releases/tag/conditionals-nested-app-when-condition): a nested app that responds to a specific path **and** when a condition is met;
4. Middlewares
	- [Custom classes](https://github.com/fvilers/OWIN-Katana/releases/tag/middlewares-custom-class): an example of how to create custom middleware classes;
	- [Reading request](https://github.com/fvilers/OWIN-Katana/releases/tag/middlewares-reading-request): demoing how to read the request body stream multipe times;
	- [WebAPI](https://github.com/fvilers/OWIN-Katana/releases/tag/middlewares-webapi): an example of how to integrate ASP.NET Web API into an OWIN pipeline;
5. CompleteSample
	- [CompleteSample](https://github.com/fvilers/OWIN-Katana/releases/tag/complete-sample): a complete sample of a pipleine with 3 actual middlewares (loggin, authentication and Web API)