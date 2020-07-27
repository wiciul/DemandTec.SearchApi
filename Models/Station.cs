namespace Models
{
    public class Station
    {
        public Station(string name, string code)
        {
            Name = name;
            Code = code;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Code { get; private set; }
    }
}