﻿using System;
using Agatha.DVDRental.Fulfillment.Infrastructure;

namespace Agatha.DVDRental.Fulfillment.Model.Fulfilment
{
    public class FulfilmentRequest
    {
        public FulfilmentRequest(int filmId, int subscriptionId)
        {
            this.FilmId = filmId;
            this.SubscriptionId = subscriptionId;
            Requested = DateTime.Now;
        }

        public int Id { get; set; }
        public int FilmId { get; private set; }
        public int SubscriptionId { get; private set; }
        public DateTime Requested { get; private set; }
        public bool IsDispatched { get; private set; }

        public string AssignedTo { get; private set; }

        public bool IsAssigned()
        {
            return !String.IsNullOrEmpty(AssignedTo);
        }

        public void AssignForPickingTo(string picker)
        {
            if (String.IsNullOrEmpty(AssignedTo))
            {
                AssignedTo = picker;

                DomainEvents.Raise(new FulfilmentRequestAssignedForPicking() { FilmId = FilmId, SubscriptionId = SubscriptionId });
            }           
        }

        public void Dispatched()
        {
            if (!IsDispatched)
            {
                IsDispatched = true;

                DomainEvents.Raise(new FulfilmentRequestDispatched() { FilmId = FilmId, SubscriptionId = SubscriptionId });
            }           
        }
    }
}
