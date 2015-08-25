using System;

namespace lostsocks.Entities
{
    public class Sock
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateOfBirth { get; set; }

        public byte[] Image { get; set; }

      //  public long ApplicationUser_Id { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        // http://stackoverflow.com/questions/25400555/save-and-retrieve-image-binary-from-sql-server-using-entity-framework-6
    }
}