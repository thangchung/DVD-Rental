﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agatha.DVDRental.Fulfillment.Model.Fulfilment
{
    public class FulfilmentRequestAssignedForPicking
    {
        public int FilmId { get; set; }

        public int SubscriptionId { get; set; }
    }
}
