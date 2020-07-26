using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class MapMapper : MonoBehaviour
{
    [HideInInspector] public TileInfo[,] map { get; private set; }
    [HideInInspector] public Player play;
    [HideInInspector] public List<vinyl> pros = new List<vinyl>();
    [HideInInspector] public int enemylist = 0;
    [SerializeField] SceneChange sc;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject LosePanel;


    public void die()
    {
        play.MI.Disable();
        Destroy(play);
        FindObjectOfType<counter>().trig = false;
        StartCoroutine(Die());
    }
    public IEnumerator Die()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        LosePanel.SetActive(true);
        sc.nextScene = gameObject.scene.name;
    }
    public void WIn()
    {
        FindObjectOfType<counter>().trig = false;
        StartCoroutine(win());
    }
    public IEnumerator win()
    {
        yield return new WaitForSecondsRealtime(3f);
        winPanel.SetActive(true);
    }
    public void mapTheMap()
    {
       List<Transform> tiles = new List<Transform>();

        foreach(Transform child in transform)
        {
            if(child.GetComponent<TileInfo>())
                tiles.Add(child);
        }

        int maxX = (int)Math.Round(tiles.Max(go => go.position.x), 0);
        int maxY = (int)Math.Round(tiles.Max(go => go.position.y), 0);

        map = new TileInfo[maxX+1, maxY+1];

        foreach (Transform go in tiles)
        {
            map[(int)Math.Round(go.position.x,0), (int)Math.Round(go.position.y,0)] = go.GetComponent<TileInfo>();
        }
    }

    private void Awake()
    {
        play = FindObjectOfType<Player>();
        mapTheMap();
    }
}
