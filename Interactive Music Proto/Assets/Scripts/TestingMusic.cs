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



    private void OnEnable()
    {
        if (MusicManager.musicManag.GameMetronome != null)
        {
            MusicManager.musicManag.GameMetronome.Ticked += GameMetronome_Ticked;
        }
    }

    private void OnDisable()
    {
        if (MusicManager.musicManag.GameMetronome != null)
        {
            MusicManager.musicManag.GameMetronome.Ticked -= GameMetronome_Ticked;
        }
    }

    //METRONOME TIME
    private void GameMetronome_Ticked(double obj)
    {
        if (PhaseIntro)
        {
            if (_testMusic != null)
                _testMusic.PlayIntro(obj);

            PhaseIntro = false;
        }

        if (Phase1)
        {
            if (_testMusic != null)
                _testMusic.PlayPhaseOne(obj);

            Phase1 = false;
        }

        if (Phase2)
        {
            if (_testMusic != null)
                _testMusic.PlayPhaseTwo(obj);

            Phase2 = false;
        }

        if (Transition)
        {
            if (_testMusic != null)
                _testMusic.PlayTransition(obj);

            Transition = false;
        }

        if (PhaseFinal)
        {
            if (_testMusic != null)
                _testMusic.PlayFinalPunch(obj);

            PhaseFinal = false;
        }

    }

}

