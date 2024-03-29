﻿using System;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;

namespace Content.Shared.Light.Component
{
    [NetworkedComponent]
    public abstract class SharedEmergencyLightComponent : Robust.Shared.GameObjects.Component
    {
        public override string Name => "EmergencyLight";

        public bool Enabled { get; set; } = false;
    }

    [Serializable, NetSerializable]
    public sealed class EmergencyLightComponentState : ComponentState
    {
        public bool Enabled;

        public EmergencyLightComponentState(bool enabled)
        {
            Enabled = enabled;
        }
    }

    [Serializable, NetSerializable]
    public enum EmergencyLightVisuals
    {
        On,
    }
}
