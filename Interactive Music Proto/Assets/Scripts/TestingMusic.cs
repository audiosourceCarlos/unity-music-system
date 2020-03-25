using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingMusic : MonoBehaviour
{
    [Header("TestAudioClass")]//TO remove when applied to game
    public BossMusicA _testMusic;

    [Header("DebugControls")]//To remove when applied to game, this goes in the triggering logic
    public bool PhaseIntro;
    public bool Phase1, Phase2, Transition, PhaseFinal;


    void Update()
    {
        if (PhaseIntro)
        {
            if (_testMusic != null)
                _testMusic.PlayIntro();

            PhaseIntro = false;
        }

        if (Phase1)
        {
            if (_testMusic != null)
                _testMusic.PlayPhaseOne();

            Phase1 = false;
        }

        if (Phase2)
        {
            if (_testMusic != null)
                _testMusic.PlayPhaseTwo();

            Phase2 = false;
        }

        if (Transition)
        {
            if (_testMusic != null)
                _testMusic.PlayTransition();

            Transition = false;
        }

        if (PhaseFinal)
        {
            if (_testMusic != null)
                _testMusic.PlayFinalPunch();

            PhaseFinal = false;
        }
    }

}

