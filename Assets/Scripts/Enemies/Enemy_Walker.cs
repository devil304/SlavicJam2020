using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walker : Enemy_Base
{
    [SerializeField] private GameObject BulletPrefab;
    int waypointIndex = 0;
    bool isMovementFinished = false;
    bool isMovementReversed = false;
    bool isStandingOnWaypoint = false;
    bool isShootFinished = false;
#if UNITY_EDITOR
    public Transform WaypointsContainerEditor;
    public WaypointEdit[] waypointsEditor;
    public GameObject[] prefs;
#endif
    public WaypointData[] waypoints;

    private new void Start()
    {
        base.Start();
        Player.PlayerTurnEnd += Action;
    }

    void Action()
    {
        CheckIfHit();
        if(waypointIndex < waypoints.Length)
        {
            if (waypoints[waypointIndex].shoot && !isShootFinished && isStandingOnWaypoint)
            {
                isShootFinished = true;
                StartCoroutine(Shoot());
            }
            else
            {
                isShootFinished = false;
                Move();
            }
        }
    }
    
    IEnumerator Shoot()
    {
        if(waypoints[waypointIndex].dir.x > 0)
        {
            SpriteRenderer.flipX = false;
        }
        else
        {
            SpriteRenderer.flipX = true;
        }

        Animator.SetBool("Shoot", true);
        yield return new WaitForSecondsRealtime(0.5f);
        Animator.SetBool("Shoot", false);

        var spawnPos = waypoints[waypointIndex].pos + waypoints[waypointIndex].dir;
        var bullet = Instantiate(BulletPrefab, new Vector3(spawnPos.x, spawnPos.y), Quaternion.identity);
        var bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.Direction = waypoints[waypointIndex].dir;
    }

    void Move() 
    {
        if(!isMovementFinished)
        {           
            if (isStandingOnWaypoint)
            {
                if(isMovementReversed)
                {
                    waypointIndex--;
                }
                else
                {
                    waypointIndex++;
                }
                
                if (waypointIndex == waypoints.Length)
                {
                    isMovementReversed = true;
                    waypointIndex -= 2;
                }

                if(waypointIndex == -1)
                {
                    isMovementReversed = false;
                    waypointIndex += 2;
                }
            }
            var direction = (Vector3Int)waypoints[waypointIndex].pos - transform.position;
            StartCoroutine(MoveToDirection(direction.normalized, StepFinished));
        }
    }

    void StepFinished()
    {
        if(waypointIndex < waypoints.Length)
        {
            var dist = Vector2.Distance(transform.position, waypoints[waypointIndex].pos);
            
            if (dist < 0.1)
            {
                isStandingOnWaypoint = true;
            }
            else
            {
                isStandingOnWaypoint = false;
            }
        }
        CheckIfHit();
    }

    private void OnDestroy()
    {
        Player.PlayerTurnEnd -= Move;
    }
}
