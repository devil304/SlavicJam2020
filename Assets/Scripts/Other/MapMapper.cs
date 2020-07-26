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


    public void die()
    {

    }
    public void WIn()
    {
        StartCoroutine(win());
    }
    public IEnumerator win()
    {
        yield return new WaitForSecondsRealtime(3f);
        winPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        sc.loadScene();
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
