# Pub-Sub_Ecommerce
Implementation of an enterprise pub-sub communication pattern in an e-commerce scenario.
The scenario is referring to an order event placed by a client that will be published to a Topic
and later be consumed by several services in order to process billing, order, and delivery logic.

![Pub-Sub Communication Pattern](https://github.com/yahiaalioua/Pub-Sub_Ecommerce/blob/main/PubSub.drawio.png)

The Pub-Sub pattern has been implemented following these enterprise rules:

First of all when a message is being processed from the topic by a consumer, we should make sure that the message is locked and can`t be processed by other consumers. Once the message is processed there should be 2 outcomes:

1)The message couldn´t be processed and therfore will fall into the dead letter topic or be deferred for a later retry.

2)The message is processed succesfully and will be removed from the topic.

![Processing of a message workflow](https://github.com/yahiaalioua/Pub-Sub_Ecommerce/blob/main/QueueDiagram2.drawio%20(1).png)

Implementation with Azure Service Bus Topics and .Net
