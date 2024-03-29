﻿using System.Collections.Generic;
using Robust.Shared.ViewVariables;

namespace Content.Server.Atmos
{
    public class ExcitedGroup
    {
        [ViewVariables] public bool Disposed = false;

        [ViewVariables] public readonly List<TileAtmosphere> Tiles = new(100);

        [ViewVariables] public int DismantleCooldown { get; set; } = 0;

        [ViewVariables] public int BreakdownCooldown { get; set; } = 0;
    }
}
