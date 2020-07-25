using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(Enemy_Walker))]
public class EW1Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        Enemy_Walker myScript = (Enemy_Walker)target;

        if (GUILayout.Button("Waypoint edit"))
        {
            myScript.waypointsEditor = new WaypointEdit[myScript.waypoints.Length];
            for (int i = 0; i < myScript.waypoints.Length; i++)
            {
                var tmp = Instantiate(myScript.waypoints[i].shoot ? myScript.prefs[1] : myScript.prefs[0], (Vector3Int)myScript.waypoints[i].pos, Quaternion.identity, null).GetComponent<WaypointEdit>();
                tmp.shoot = myScript.waypoints[i].shoot;
                if (tmp.shoot)
                {
                    switch (myScript.waypoints[i].dir.x)
                    {
                        case 1:
                            tmp.transform.Rotate(0f,0f,-90f);
                            break;
                        case -1:
                            tmp.transform.Rotate(0f, 0f, 90f);
                            break;
                    }
                    switch (myScript.waypoints[i].dir.y)
                    {
                        case -1:
                            tmp.transform.Rotate(0f, 0f, 180f);
                            break;
                    }
                }
                tmp.transform.parent = myScript.WaypointsContainerEditor;
                myScript.waypointsEditor[i] = tmp;
            }
            myScript.waypoints = null;

        }
        if (GUILayout.Button("Waypoint save"))
        {
            myScript.waypoints = new WaypointData[myScript.waypointsEditor.Length];
            for (int i = 0; i < myScript.waypointsEditor.Length; i++) {
                Vector2Int tmp = Vector2Int.zero;
                switch(myScript.waypointsEditor[i].transform.rotation.eulerAngles.z)
                {
                    case 90f:
                        tmp = Vector2Int.left;
                        break;
                    case 270f:
                        tmp = Vector2Int.right;
                        break;
                    case 180f:
                        tmp = Vector2Int.down;
                        break;
                    case 0f:
                        tmp = Vector2Int.up;
                        break;

                }
                myScript.waypoints[i] = new WaypointData(Vector2Int.RoundToInt(myScript.waypointsEditor[i].transform.position), myScript.waypointsEditor[i].shoot, tmp);
            }
            foreach (WaypointEdit we in myScript.waypointsEditor)
                DestroyImmediate(we.gameObject);
            myScript.waypointsEditor = null;
        }
        if (GUI.changed)
        {
            EditorUtility.SetDirty(myScript);
            EditorSceneManager.MarkSceneDirty(myScript.gameObject.scene);
        }
    }
}
