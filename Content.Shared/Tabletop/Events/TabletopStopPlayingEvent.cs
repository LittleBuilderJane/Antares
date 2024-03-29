﻿using System;
using Robust.Shared.GameObjects;
using Robust.Shared.Serialization;

namespace Content.Shared.Tabletop.Events
{
    /// <summary>
    /// An event ot tell the server that we have stopped playing this tabletop game.
    /// </summary>
    [Serializable, NetSerializable]
    public class TabletopStopPlayingEvent : EntityEventArgs
    {
        /// <summary>
        /// The entity UID of the table associated with this tabletop game.
        /// </summary>
        public EntityUid TableUid;

        public TabletopStopPlayingEvent(EntityUid tableUid)
        {
            TableUid = tableUid;
        }
    }
}
