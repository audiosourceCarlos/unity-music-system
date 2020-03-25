using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public bool SceneOne;
    public bool SceneTwo;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    
    void Update()
    {
        if (SceneOne)
        {
            MusicManager.musicManag.StopAll();
            SceneManager.LoadScene(0);
            SceneOne = false;
        }

        if (SceneTwo)
        {
            MusicManager.musicManag.StopAll();
            SceneManager.LoadScene(1);
            SceneTwo = false;
        }

    }
}
