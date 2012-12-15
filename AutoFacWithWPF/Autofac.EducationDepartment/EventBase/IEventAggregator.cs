using System;

namespace AutofacExample.EducationDepartment.EventBase
{
    public interface IEventAggregator
    {
        IObservable<object> AllEvents { get; }
        IObservable<T> GetEvents<T>();
        void Publish<T>(T @event);
    }
}
