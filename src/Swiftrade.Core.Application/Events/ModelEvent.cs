﻿using Swiftrade.Common.Messaging;
using Swiftrade.Core.Application.Messages;

namespace Swiftrade.Core.Application.Events
{
    public class ModelEvent<TModel> : IEvent
    {
        public TModel Model { get; set; }
        public ModelAction Action { get; set; }

        public ModelEvent(TModel model, ModelAction action)
        {
            Model = model;
            Action = action;
        }
    }

    public enum ModelAction
    {
        Unknown = 0,
        Created = 1,
        Updated = 2,
        Deleted = 3,
        Sync = 4
    }
}
