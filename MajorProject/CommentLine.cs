using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MajorProject
{
    class CommentLine : Line
    {
        String content;

        public CommentLine(String _content)
        {
            content = _content;
        }
        public String Content()
        {
            return content;
        }
        override public string ToString()
        {
            return content;
        }
    }

}