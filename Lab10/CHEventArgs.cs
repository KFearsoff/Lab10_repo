using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class CHEventArgs : EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public object ChangedObject { get; set; }

        public CHEventArgs(string CollectionName, string ChangeType, object ChangedObject)
        {
            this.CollectionName = CollectionName;
            this.ChangeType = ChangeType;
            this.ChangedObject = ChangedObject;
        }

        public override string ToString()
        {
            return $"{CollectionName}\n{ChangeType}\n{ChangedObject.ToString()}";
        }
    }
}
