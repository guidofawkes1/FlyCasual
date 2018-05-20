﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SubPhases;

namespace MainPhases
{

    public class SetupPhase : GenericPhase
    {

        public override void StartPhase()
        {
            Name = "Setup Phase";

            StartGameStartSubPhase();
        }

        private void StartGameStartSubPhase()
        {
            Phases.CurrentSubPhase = new GameStartSubPhase();
            Phases.CurrentSubPhase.Start();
            Phases.CurrentSubPhase.Prepare();
            Phases.CurrentSubPhase.Initialize();
        }

        public override void NextPhase()
        {
            Selection.DeselectAllShips();

            GenericSubPhase subphase = Phases.StartTemporarySubPhaseNew("Notification", typeof(NotificationSubPhase), StartPlanningPhase);
            (subphase as NotificationSubPhase).TextToShow = "Planning";
            subphase.Start();
        }

        private void StartPlanningPhase()
        {
            Phases.CurrentPhase = new PlanningPhase();
            Phases.CurrentPhase.StartPhase();
        }

    }

}