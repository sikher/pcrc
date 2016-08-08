using System;
using System.Collections.Generic;
using System.Text;

namespace Metamorph.Classes
{
    class Pair
    {
        private Object _key;
        private Object _value;

        private bool showValue = true;

        public Pair(Object key, Object value)
        {
            _key = key;
            _value = value;
        }

        public Object Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public Object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public bool ShowValue
        {
            get { return showValue; }
            set { showValue = value; }
        }

        // Override the standard 'tostring' function
        public override string ToString()
        {
            if (showValue)
                return _value.ToString();
            else
                return _key.ToString();
        }
    }
}
