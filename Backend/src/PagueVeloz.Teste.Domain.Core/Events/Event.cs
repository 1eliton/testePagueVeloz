﻿using System;
using MediatR;

namespace PagueVeloz.Teste.Domain.Core
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}