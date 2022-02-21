using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Core.Entities
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
