﻿using System;
using Robust.Shared.GameObjects;
using Robust.Shared.Serialization;

namespace Content.Shared.Alert;

/// <summary>
/// A message that calls the click interaction on a alert
/// </summary>
[Serializable, NetSerializable]
public class ClickAlertEvent : EntityEventArgs
{
    public readonly AlertType Type;

    public ClickAlertEvent(AlertType alertType)
    {
        Type = alertType;
    }
}