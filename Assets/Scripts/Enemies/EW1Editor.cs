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
                tmp.pos = myScript.waypoints[i].pos;
                tmp.shoot = myScript.waypoints[i].shoot;
                tmp.dir = myScript.waypoints[i].dir;
                if (tmp.shoot)
                {
                    switch (tmp.dir.x)
                    {
                        case 1:
                            tmp.transform.Rotate(0f,0f,-90f);
                            break;
                        case -1:
                            tmp.transform.Rotate(0f, 0f, 90f);
                            break;
                    }
                    switch (tmp.dir.y)
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
            for (int i = 0; i < myScript.waypointsEditor.Length; i++)
                myScript.waypoints[i] = new WaypointData(myScript.waypointsEditor[i].pos, myScript.waypointsEditor[i].shoot, myScript.waypointsEditor[i].dir);
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
