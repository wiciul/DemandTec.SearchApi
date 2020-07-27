namespace DataAccess
{
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using Models;
    using System.Collections.Generic;
    using CsvHelper;
    using SeedHelpers;

    public static class StationsContextSeed
    {
        public static async Task SeedFromCsvAsync(this StationsContext context)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("DataAccess.stations.csv");
            if (stream != null)
            {
                using var reader = new StreamReader(stream);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Configuration.RegisterClassMap<CsvStationMapper>();
                var stations = new List<Station>();
                await foreach (var stationRecord in csv.GetRecordsAsync<CsvRecord>())
                {
                    stations.Add(new Station(stationRecord.Name, stationRecord.Code));
                }
                await context.Cities.AddRangeAsync(stations);
                await context.SaveChangesAsync();
            }

        }
    }
}