﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Model
{
    public class DomainEventPublisher
    {
        [ThreadStatic]
        static DomainEventPublisher _instance;

        public static DomainEventPublisher Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DomainEventPublisher();
                }
                return _instance;
            }
        }

        DomainEventPublisher()
        {
            this.publishing = false;
        }

        bool publishing;
        List<IDomainEventSubscriber<IDomainEvent>> _subscribers;

        List<IDomainEventSubscriber<IDomainEvent>> Subscribers
        {
            get
            {
                if (this._subscribers == null)
                {
                    this._subscribers = new List<IDomainEventSubscriber<IDomainEvent>>();
                }

                return this._subscribers;
            }
            set
            {
                this._subscribers = value;
            }
        }

        bool HasSubscribers()
        {
            return this._subscribers != null && this.Subscribers.Count != 0;
        }

        public void Reset()
        {
            if (!this.publishing)
            {
                this.Subscribers = null;
            }
        }

        public void Subscribe(IDomainEventSubscriber<IDomainEvent> subscriber)
        {
            if (!this.publishing)
            {
                this.Subscribers.Add(subscriber);
            }
        }

        public void Subscribe(Action<IDomainEvent> handle)
        {
            Subscribe(new DomainEventSubscriber<IDomainEvent>(handle));
        }

        public void Publish<T>(T domainEvent) where T : IDomainEvent
        {
            if (!this.publishing && this.HasSubscribers())
            {
                try
                {
                    this.publishing = true;

                    var eventType = domainEvent.GetType();

                    foreach (var subscriber in this.Subscribers)
                    {
                        var subscribedToType = subscriber.SubscribedToEventType();
                        if (eventType == subscribedToType || subscribedToType == typeof(IDomainEvent))
                        {
                            subscriber.HandleEvent(domainEvent);
                        }
                    }
                }
                finally
                {
                    this.publishing = false;
                }
            }
        }

        public void PublishAll(ICollection<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                this.Publish(domainEvent);
            }
        }

        class DomainEventSubscriber<TEvent> : IDomainEventSubscriber<TEvent>
            where TEvent : IDomainEvent
        {
            public DomainEventSubscriber(Action<TEvent> handle)
            {
                this.handle = handle;
            }

            readonly Action<TEvent> handle;

            public void HandleEvent(TEvent domainEvent)
            {
                this.handle(domainEvent);
            }

            public Type SubscribedToEventType()
            {
                return typeof(TEvent);
            }
        }
    }
}
