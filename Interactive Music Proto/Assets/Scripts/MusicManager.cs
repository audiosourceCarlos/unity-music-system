using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    [Header("MusicTracks")]
    public AudioSource musicA;
    public AudioSource musicB;
    public AudioSource musicC;
    public AudioSource musicD;

    [Header("Start/Stop Snapshots")]
    public AudioMixerSnapshot StartMus;
    public AudioMixerSnapshot StopMus;

    [Header("Metronome")]
    public Metronome GameMetronome;

    [HideInInspector]
    public double globalTick;

    [Header("DebugControls")]
    public bool DebugPlayAll;
    public bool DebugStopAll, DebugPauseAll, DebugUnpauseAll;
    public float TransitionTime = 1f;

    public static MusicManager musicManag;

    private void Awake()
    {
        musicManag = this;
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

        if (DebugPauseAll)
        {
            PauseAll();
        }

        if (DebugUnpauseAll)
        {
            UnPauseAll();
        }
    }

    public void PlayAll()
    {
        StartMus.TransitionTo(TransitionTime);

        musicA.PlayScheduled(globalTick);
        musicB.PlayScheduled(globalTick);
        musicC.PlayScheduled(globalTick);
        musicD.PlayScheduled(globalTick);

        DebugPlayAll = false;
    }

    public void StopAll()
    {
        StartCoroutine(StopAllMusic());
        DebugStopAll = false;
    }

    public void PauseAll()
    {
        musicA.Pause();
        musicB.Pause();
        musicC.Pause();
        musicD.Pause();

        DebugPauseAll = false;
    }

    public void UnPauseAll()
    {
        musicA.UnPause();
        musicB.UnPause();
        musicC.UnPause();
        musicD.UnPause();

        DebugUnpauseAll = false;
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
