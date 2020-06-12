using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class JournalEntry
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public string ChangedObject { get; set; }

        public JournalEntry(CHEventArgs args)
        {
            CollectionName = args.CollectionName;
            ChangeType = args.ChangeType;
            ChangedObject = args.ChangedObject.ToString();
        }
        public JournalEntry(string CollectionName, string ChangeType, object ChangedObject)
        {
            this.CollectionName = CollectionName;
            this.ChangeType = ChangeType;
            this.ChangedObject = ChangedObject.ToString();
        }

        public override string ToString()
        {
            return $"{CollectionName}\n{ChangeType}\n{ChangedObject}";
        }
    }
}
