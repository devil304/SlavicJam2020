using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class inGameSettings : MonoBehaviour
{
    AudioSource[] SFXsources;
    AudioSource[] MUSICsources;
    [SerializeField] public float SFXValue;
    [SerializeField] public float MUSICValue;
    bool isTouchScreen;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (Application.platform == RuntimePlatform.Android)
        {
            isTouchScreen = true;
            GameObject.FindGameObjectWithTag("Touchscreen").SetActive(true);
        }
        else
        {
            isTouchScreen = false;
            GameObject.FindGameObjectWithTag("Touchscreen").SetActive(false);
        }

        SFXsources = GameObject.FindGameObjectsWithTag("SFX").Select(AS => AS.GetComponent<AudioSource>()).ToArray();
        MUSICsources = GameObject.FindGameObjectsWithTag("MUSIC").Select(AS => AS.GetComponent<AudioSource>()).ToArray();

        SceneManager.activeSceneChanged += (Old, New) =>
        {
            if (isTouchScreen == true)
            {
                GameObject.FindGameObjectWithTag("Touchscreen").SetActive(true);
            }
            else
            {
                GameObject.FindGameObjectWithTag("Touchscreen").SetActive(false);
            }

            SFXsources = GameObject.FindGameObjectsWithTag("SFX").Select(AS => AS.GetComponent<AudioSource>()).ToArray();
            MUSICsources = GameObject.FindGameObjectsWithTag("MUSIC").Select(AS => AS.GetComponent<AudioSource>()).ToArray();

            foreach (AudioSource SFXsource in SFXsources)
            {
                SFXsource.volume = SFXValue;
            }
            foreach (AudioSource MUSICsource in MUSICsources)
            {
                MUSICsource.volume = MUSICValue;
            }
        };
    }

    public void SFXChange(float Value)
    {
        foreach(AudioSource SFXsource in SFXsources)
        {
            SFXsource.volume = Value;
        }
        SFXValue = Value;
    }

    public void MusicChange(float Value)
    {
        foreach (AudioSource MUSICsource in MUSICsources)
        {
            MUSICsource.volume = Value;
        }
        MUSICValue = Value;
    }
}
