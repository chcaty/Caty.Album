using System;
using System.Collections.Generic;
using System.Text;

namespace Caty.Album.Model
{
    public class Face
    {
        public int FaceId { get; set; }
        public byte[] FaceData { get; set; }
        public string FaceName { get; set; }
        public int PeopleId { get; set; }

    }
}
