﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Model
{
    public interface IDomainEventSubscriber<T> where T: IDomainEvent
    {
        void HandleEvent(T domainEvent);
        Type SubscribedToEventType();
    }
}
