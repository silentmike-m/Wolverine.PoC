namespace Wolverine.PoC.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController, Route("[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private IMessageBus? bus;
    public IMessageBus Bus => this.bus ??= this.HttpContext.RequestServices.GetRequiredService<IMessageBus>();
}
