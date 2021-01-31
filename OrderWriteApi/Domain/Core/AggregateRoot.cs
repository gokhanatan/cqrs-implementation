using System;
using System.Collections.Generic;

namespace OrderWriteApi.Domain.Core
{
    public abstract class AggregateRoot
    {
        private readonly List<object> _changes = new List<object>();

        public abstract Guid Id { get; }

        protected abstract void When(object @event);

        public IEnumerable<object> GetUncommittedChanges()
        {
            return _changes;
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        protected void ApplyChange(object @event)
        {
            When(@event);
            _changes.Add(@event);
        }
    }
}