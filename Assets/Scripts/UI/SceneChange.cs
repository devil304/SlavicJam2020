using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string nextScene;
    public void loadScene()
    {
        StartCoroutine(Loading());
    }
    IEnumerator Loading()
    {
        var scene = SceneManager.LoadSceneAsync(nextScene);
        scene.allowSceneActivation = false;
        yield return new WaitUntil(() => scene.progress >= 0.9f);
        scene.allowSceneActivation = true;
    }
}
