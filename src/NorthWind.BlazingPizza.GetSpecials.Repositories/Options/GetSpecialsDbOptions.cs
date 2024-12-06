namespace NorthWind.BlazingPizza.GetSpecials.Repositories.Options
{
    public class GetSpecialsDbOptions
    {
        public const string SectionKey = nameof(GetSpecialsDbOptions);
        public string ConnectionString { get; set; }
    }
}
