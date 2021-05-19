# Usage

Package Link https://www.nuget.org/packages/ServiceBus.MessageSender
 ## 1- Startup.cs

```c#
services.AddServiceBusMessageSender();
```

## Controller - Action

```c#

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceBus.MessageSender.Lib;

namespace ServiceBus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AzureController : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> Get([ServiceBus("Queue_Or_Topic_Name", "ServiceBusConnection")] IServiceBusMessageSender messageSender)
        {

            await messageSender.SendAsync(new
            {
                Test = "Test"
            });

            return Ok();
        }

    }
}

```
