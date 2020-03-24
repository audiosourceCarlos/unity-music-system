using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BossMusicA : MonoBehaviour
{
    [Header("Music Clips")]
    public AudioClip Intro;
    public AudioClip Phase1;
    public AudioClip Phase2;
    public AudioClip Transition;
    public AudioClip FinalPunch;

    [Header("Snapshots")]
    public AudioMixerSnapshot IntroState;
    public AudioMixerSnapshot Phase1State;
    public AudioMixerSnapshot Phase2State;
    public AudioMixerSnapshot TransitionState;
    public AudioMixerSnapshot FinalState;

    [Header("TransitionTime")]
    public float TransIntro;
    public float TransP1;
    public float TransP2;
    public float TransTran;
    public float TransFin;

    [Header("SongMetrics")]
    public double _gametempo = 120.0;
    public int _subdivision = 4;

    private AudioSource _trackA, _trackB, _trackC, _trackD;
    private Metronome _metronome;
    private double _tick;


    private void Awake()
    {
        _metronome = GameObject.Find("MusicManager").GetComponent<Metronome>();
        _metronome.TempoChange(_gametempo, _subdivision);

        _trackA = GameObject.Find("TrackA").GetComponent<AudioSource>();
        _trackB = GameObject.Find("TrackB").GetComponent<AudioSource>();
        _trackC = GameObject.Find("TrackC").GetComponent<AudioSource>();
        _trackD = GameObject.Find("TrackD").GetComponent<AudioSource>();

        // track A is assigned below as it shares clip
        _trackB.clip = Phase1;
        _trackC.clip = Phase2;
        _trackD.clip = Transition;
    }

    private void Start()
    {
        _tick = AudioManager.audioManag.globalTick;
    }

    public void PlayIntro()
    {
        _trackA.clip = Intro; //shares track with FinalPunch
        IntroState.TransitionTo(TransIntro);

        _trackA.PlayScheduled(_tick);
    }

    public void PlayPhaseOne()
    {
        Phase1State.TransitionTo(TransP1);

        _trackB.PlayScheduled(_tick);
    }

    public void PlayPhaseTwo()
    {
        Phase2State.TransitionTo(TransP2);

        _trackC.PlayScheduled(_tick);
    }

    public void PlayTransition()
    {
        TransitionState.TransitionTo(TransTran);

        _trackD.PlayScheduled(_tick);
    }

    public void PlayFinalPunch()
    {
        _trackA.clip = FinalPunch; //shares track with FinalPunch
        FinalState.TransitionTo(TransFin);

        _trackA.PlayScheduled(_tick);

    }


}
