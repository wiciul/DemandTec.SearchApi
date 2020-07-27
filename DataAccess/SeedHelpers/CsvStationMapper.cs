namespace DataAccess.SeedHelpers
{
    using CsvHelper.Configuration;

    internal sealed class CsvStationMapper : ClassMap<CsvRecord>
    {
        public CsvStationMapper()
        {
            Map(s => s.Name).Name("Station Name");
            Map(s => s.Code).Name("Station Code");
        }
    }
}