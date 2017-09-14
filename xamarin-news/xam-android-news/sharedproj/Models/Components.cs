using System;
using System.Collections.Generic;
using System.Text;

namespace sharedproj.Models
{
    public abstract class Component
    {
        public string type;
        public string subtype;
    }

    public class Text : Component
    { 
    }
}
