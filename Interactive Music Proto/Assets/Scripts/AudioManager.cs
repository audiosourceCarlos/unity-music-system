﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("MusicTracks")]
    public AudioSource musicA;
    public AudioSource musicB;
    public AudioSource musicC;

    [Header("Start/Stop Snapshots")]
    public AudioMixerSnapshot StartMus;
    public AudioMixerSnapshot StopMus;

    [Header("TransitionSnapshots")]
    public AudioMixerSnapshot Intro;
    public AudioMixerSnapshot MusPhase1;
    public AudioMixerSnapshot MusPhase2;
    [Header("DebugControls")]
    public bool DebugPlay;
    public bool DebugStop;
    public bool PhaseIntro, Phase1, Phase2;
    public float TransitionTime = 1f;

    public static AudioManager audioManag;

    private void Awake()
    {
        audioManag = this;
    }

    private void Update()
    {
        if (DebugPlay)
        {
            Play();
        }

        if (DebugStop)
        {
            Stop();
        }

       if (PhaseIntro)
        {
            Intro.TransitionTo(TransitionTime);
            PhaseIntro = false;
        }

       if (Phase1)
        {
            MusPhase1.TransitionTo(TransitionTime);
            Phase1 = false;
        }

       if (Phase2)
        {
            MusPhase2.TransitionTo(TransitionTime);
            Phase2 = false;
        }
    }

    private void Play()
    {
        musicA.Play();
        musicB.Play();
        musicC.Play();

        StartMus.TransitionTo(TransitionTime);

        DebugPlay = false;
    }

    private void Stop()
    {
        StartCoroutine(StopMusic());
        DebugStop = false;
    }

    IEnumerator StopMusic()
    {
        StopMus.TransitionTo(TransitionTime);
        yield return new WaitForSeconds(TransitionTime);

        musicA.Stop();
        musicB.Stop();
        musicC.Stop();

        yield break;
    }


}
