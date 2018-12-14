
## Tutorial 04 Inter Application Bus 

This tutorial shows how to use the inter-application bus within the .NET adapter.  Here we will run through a simple example of subscribing to a topic and sending a message out to another application.

**1st Step**

By now you should be familiar with some of the calls within the .NET Adapter.  Specifically here we can use `runtime.Connect` to subscribe to a Topic, and print out any messages sent to this topic within the console.

Below shows how to use the Inter-Application Bus to subscribe a Topic named `OpenFinTopic`, any message that is published to this topic will be displayed in the console.

```
    runtime.Connect(() =>
            {
                InterApplicationBus.Subscription<string>(runtime, "OpenFinTopic").MessageReceived += (s, e) =>
                {
                    Console.WriteLine(e.Message);
                };
```

**2nd Step**

To publish a message to the topic `OpenFinTopic` we can create another application to publish a message.

>Task: Create a new application that will publish a test message to the `OpenFinTopic`.

**3rd Step**

Once you have created an application you can publish a message to the given topic, the code within your application could look something like this:

`fin.desktop.InterApplicationBus.publish("OpenFinTopic","My Message");`

> Tips: Try [creating an application](http://cdn.openfin.co/jsdocs/beta/tutorial-application.constructor.html) programmaticaly through the dev console. 

After you have published the message to the topic, you should be able to see the message within your console application.