using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mud.Core.Entities
{
    public class DungeonStory
    {
        public Guid Id { get; set; }
        public string Story { get; set; } = string.Empty;
        public Guid DungeonId { get; set; }
        public Dungeon Dungeon { get; set; } = null!;
    }
}
