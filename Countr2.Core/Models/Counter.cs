using SQLite;

namespace Countr2.Core.Models
{
    public class Counter
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

    }
}
