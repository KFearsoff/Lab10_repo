using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Journal
    {
        private List<JournalEntry> list = new List<JournalEntry>();

        public void CountChanged(object source, CHEventArgs args)
        {
            list.Add(new JournalEntry(args));
        }

        public void ReferenceChanged(object source, CHEventArgs args)
        {
            list.Add(new JournalEntry(args));
        }

        public override string ToString()
        {
            string temp = "";
            foreach (var c in list) temp += c.ToString();
            return temp;
        }
    }
}
