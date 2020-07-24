using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inGameSettings : MonoBehaviour
{
    AudioSource[] SFXsources;
    AudioSource[] MUSICsources;
    [SerializeField] float SFXValue;
    [SerializeField] float MUSICValue;

    private void Awake()
    {
        SFXsources = GameObject.FindGameObjectsWithTag("SFX").Select(AS => AS.GetComponent<AudioSource>()).ToArray();
        MUSICsources = GameObject.FindGameObjectsWithTag("MUSIC").Select(AS => AS.GetComponent<AudioSource>()).ToArray();

        SceneManager.activeSceneChanged += (Old,New) =>
        {
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
