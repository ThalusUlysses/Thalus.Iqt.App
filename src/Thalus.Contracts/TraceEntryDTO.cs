using System;
using Thalus.Contracts;

namespace Thalus.Contracts
{
    public class TraceEntryDTO : ITraceEntry
    {
       public  string WriterId { get; set; }

        public TraceCategories Category { get; set; }

        public TextDTO Text { get; set; }

        public object Data { get; set; }

        public DateTime Utc { get; set; }

        public DateTime Local { get; set; }

        public int Line { get; set; }

        public string Scope { get; set; }

        public string FileName { get; set; }

        public string CallerMember { get; set; }

        public string[] Attributes { get; set; }
        public int ThreadId { get; set; }

        IText ITraceEntry.Text => Text;
    }
}
