﻿using System;
using Content.Client.Atmos.EntitySystems;
using Content.Shared.Atmos;
using Content.Shared.Atmos.Piping.Binary.Components;
using Content.Shared.Atmos.Piping.Trinary.Components;
using JetBrains.Annotations;
using Robust.Client.GameObjects;
using Robust.Shared.GameObjects;

namespace Content.Client.Atmos.UI
{
    /// <summary>
    /// Initializes a <see cref="GasPressurePumpWindow"/> and updates it when new server messages are received.
    /// </summary>
    [UsedImplicitly]
    public class GasPressurePumpBoundUserInterface : BoundUserInterface
    {

        private GasPressurePumpWindow? _window;
        private const float MaxPressure = Atmospherics.MaxOutputPressure;

        public GasPressurePumpBoundUserInterface(ClientUserInterfaceComponent owner, object uiKey) : base(owner, uiKey)
        {
        }

        protected override void Open()
        {
            base.Open();

            _window = new GasPressurePumpWindow();

            if(State != null)
                UpdateState(State);

            _window.OpenCentered();

            _window.OnClose += Close;

            _window.ToggleStatusButtonPressed += OnToggleStatusButtonPressed;
            _window.PumpOutputPressureChanged += OnPumpOutputPressurePressed;
        }

        private void OnToggleStatusButtonPressed()
        {
            if (_window is null) return;
            SendMessage(new GasPressurePumpToggleStatusMessage(_window.PumpStatus));
        }

        private void OnPumpOutputPressurePressed(string value)
        {
            float pressure = float.TryParse(value, out var parsed) ? parsed : 0f;
            if (pressure > MaxPressure) pressure = MaxPressure;

            SendMessage(new GasPressurePumpChangeOutputPressureMessage(pressure));
        }

        /// <summary>
        /// Update the UI state based on server-sent info
        /// </summary>
        /// <param name="state"></param>
        protected override void UpdateState(BoundUserInterfaceState state)
        {
            base.UpdateState(state);
            if (_window == null || state is not GasPressurePumpBoundUserInterfaceState cast)
                return;

            _window.Title = (cast.PumpLabel);
            _window.SetPumpStatus(cast.Enabled);
            _window.SetOutputPressure(cast.OutputPressure);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing) return;
            _window?.Dispose();
        }
    }
}
