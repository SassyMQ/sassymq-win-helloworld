# SassyMQ Windows Hello World Test Apps

This repo contains two test apps.  One is "the world" which is a console app and listens for 
messages from the programmer.

The other is a Programmer Win App which lets you send messages to the world.

Both connect to `amqps://smqPublic:smqPublic@explore.ssot.me/DEMO

If you run other isntances of this lexicon (such as Golang, PHP, Python, etc) these apps
can be used to test either the Programmer or the World side of the call.