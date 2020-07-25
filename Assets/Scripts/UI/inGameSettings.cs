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
    [SerializeField] public GameObject Counter;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        SFXsources = GameObject.FindGameObjectsWithTag("SFX")?.Select(AS => AS.GetComponent<AudioSource>()).ToArray();
        MUSICsources = GameObject.FindGameObjectsWithTag("MUSIC")?.Select(AS => AS.GetComponent<AudioSource>()).ToArray();

        SceneManager.activeSceneChanged += (Old, New) =>
        {
#if UNITY_ANDROID
            GameObject.FindGameObjectWithTag("Touchscreen")?.SetActive(true);
#endif
#if UNITY_STANDALONE
                GameObject.FindGameObjectWithTag("Touchscreen")?.SetActive(false);
#endif

            SFXsources = GameObject.FindGameObjectsWithTag("SFX")?.Select(AS => AS.GetComponent<AudioSource>()).ToArray();
            MUSICsources = GameObject.FindGameObjectsWithTag("MUSIC")?.Select(AS => AS.GetComponent<AudioSource>()).ToArray();

            foreach (AudioSource SFXsource in SFXsources)
            {
                SFXsource.volume = SFXValue;
            }
            foreach (AudioSource MUSICsource in MUSICsources)
            {
                MUSICsource.volume = MUSICValue;
            }
            if(New.name!="Menu"&& Old.name != "Menu")
            {
                transform.GetChild(0).gameObject.SetActive(true);
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
