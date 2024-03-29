﻿using Robust.Shared.GameObjects;

namespace Content.Shared.Interaction.Events
{
    public class ChangeDirectionAttemptEvent : CancellableEntityEventArgs
    {
        public ChangeDirectionAttemptEvent(EntityUid uid)
        {
            Uid = uid;
        }

        public EntityUid Uid { get; }
    }
}
