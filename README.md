# Usage

Package Link https://www.nuget.org/packages/ServiceBus.MessageSender
 ## 1- Startup.cs

```c#
services.AddServiceBusMessageSender();
```

## Controller - Action

```c#

       using ServiceBus.MessageSender.Lib;
       
       
       [HttpGet]
        public async Task<IActionResult> Get([ServiceBus("Queue_Or_Topic_Name", "ServiceBusConnection")] IServiceBusMessageSender messageSender)
        {

            await messageSender.SendAsync(new
            {
                Test = "Test"
            });

            return Ok();
        }
```
