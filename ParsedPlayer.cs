using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParserVoorbeeld
{
    class ParsedPlayer
    {
        public int StartRoomId { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int Lives { get; set; }

        public override string ToString()
        {
            return $"StartRoomId: {StartRoomId}, StartX: {StartX}, StartY: {StartY}, Lives: {Lives}";
        }
    }
}
