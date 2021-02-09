using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EntityController
{
    Waypoint targetWaypoint;

    void Start()
    {
        setRandomWaypoint();
        target = GameObject.FindObjectOfType<PlayerController>().gameObject;
    }

   
    void Update()
    {
        combat.UpdateCooldownTimer(Time.deltaTime);
        if(target) {
            if(isTargetInVision()) {
                moveToPoint(target.transform.position);
                if(isTargetInRange()) {
                    if(combat.TryAttack(target)) {
                        Debug.Log($"{this.name} attacked {target.name}");
                    }
                }
            } else {
                if(moveToPoint(targetWaypoint.transform.position)) {
                    setRandomWaypoint();
                }
            }
        } else {
            if(moveToPoint(targetWaypoint.transform.position)) {
                setRandomWaypoint();
            }
        }
    }

    void setRandomWaypoint() {
        Waypoint[] waypoints = GameObject.FindObjectsOfType<Waypoint>();
        targetWaypoint = waypoints[Random.Range(0, waypoints.Length)];
    }
}
