using Microsoft.AspNetCore.Components;

namespace WebUIBlazor.Components.Pages;

public class CarDetailsBase : ComponentBase
{
    [Parameter]
    public Guid Id { get; set; }

    //[Inject]
    //public ICar
}
