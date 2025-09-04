**SuperHero Project - C# Version**<br />

I've decided to follow Clean Architecture to do so, and I think that it's worth mentioning some points here:<br /> 
<img width="277" height="463" alt="image" src="https://github.com/user-attachments/assets/83047498-d662-495b-9a40-cbcd0dc9b568" />
<br />

The Application layer, as intended, will have everything related to the communication with the external world. <br /> 
This also applies to the Event Producer, which in this case is a RabbitMQ, but could be Kafka. <br /> In this project, it communicates with internal routines, but could be a third-party Service.<br /> 
That's why I've decided to put it into the Application Layer.<br /> 
<img width="254" height="473" alt="image" src="https://github.com/user-attachments/assets/f3059a4f-55f8-4f9b-94e3-910c0326d53a" />

The Domain is responsible for guarding all the System's ways to be.<br /> 
What does that mean?<br /> 
Means that, if I want to rewrite this in another tech stack, this Domain definition must be respected and implemented accordingly<br /> 
<img width="278" height="570" alt="image" src="https://github.com/user-attachments/assets/90490912-f143-476b-9e2a-b7b1c6ff9b51" />

Inside the Infra, I've put everything I've considered to make sense as the foundation for the Service.<br /> 
Which means the not usual IoC csproj, where I've done all the implementations for DI to be used inside the Api Bootstrapper.<br /> 
<img width="329" height="780" alt="image" src="https://github.com/user-attachments/assets/d4f58840-6d74-40c6-a47e-9855bed4daa0" />
