﻿using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Demo.Events
{
    public class UpdateEvent : PubSubEvent<Models.UpdateModel>
    {
    }
}
