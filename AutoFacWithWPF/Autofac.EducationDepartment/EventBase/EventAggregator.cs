using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace AutofacExample.EducationDepartment.EventBase
{
    public class EventAggregator : IEventAggregator, IDisposable
    {
        private readonly Subject<object> _aggregator = new Subject<object>();

        public IObservable<object> AllEvents
        {
            get { return this._aggregator; }
        }

        public IObservable<T> GetEvents<T>()
        {
            return this._aggregator.OfType<T>();
        }

        public void Publish<T>(T @event)
        {
            this._aggregator.OnNext(@event);
        }

        public void Dispose()
        {
            this._aggregator.Dispose();
        }
    }
}
