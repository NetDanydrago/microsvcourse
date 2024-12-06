


namespace NorthWind.BlazingPizza.RazorViews.Components;

public partial class Specials
{
    [Inject]
    public GetSpecialsViewModel ViewModel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await ViewModel.GetSpecialsAsync();
    }

}
