using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("MusicTracks")]
    public AudioSource musicA;
    public AudioSource musicB;
    public AudioSource musicC;
    public AudioSource musicD;

    [Header("Start/Stop Snapshots")]
    public AudioMixerSnapshot StartMus;
    public AudioMixerSnapshot StopMus;

    [Header("DebugControls")]
    public bool DebugPlayAll;
    public bool DebugStopAll;
    public bool PhaseIntro, Phase1, Phase2, Transition, PhaseFinal;
    public float TransitionTime = 1f;

    [Header("Metronome")]
    public Metronome GameMetronome;

    [Header("TestAudioClass")]//TO remove when applied to game
    public BossMusicA _testMusic;

    [HideInInspector]
    public double globalTick;

    public static AudioManager audioManag;

    private void Awake()
    {
        audioManag = this;
    }

    private void Update()
    {
        if (DebugPlayAll)
        {
            PlayAll();
        }

        if (DebugStopAll)
        {
            StopAll();
        }

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

    private void PlayAll()
    {
        StartMus.TransitionTo(TransitionTime);

        musicA.PlayScheduled(globalTick);
        musicB.PlayScheduled(globalTick);
        musicC.PlayScheduled(globalTick);
        musicD.PlayScheduled(globalTick);

        DebugPlayAll = false;
    }

    private void StopAll()
    {
        StartCoroutine(StopAllMusic());
        DebugStopAll = false;
    }

    IEnumerator StopAllMusic()
    {
        StopMus.TransitionTo(TransitionTime);
        yield return new WaitForSeconds(TransitionTime);

        musicA.Stop();
        musicB.Stop();
        musicC.Stop();
        musicD.Stop();

        yield break;
    }

    #region Metronome
    private void OnEnable()
    {
        if (GameMetronome != null)
        {
            GameMetronome.Ticked += HandleTicked;
        }
    }

    private void OnDisable()
    {
        if (GameMetronome != null)
        {
            GameMetronome.Ticked -= HandleTicked;
        }
    }

    private void HandleTicked(double tickTime)
    {
        globalTick = tickTime;
    }
    #endregion

}
