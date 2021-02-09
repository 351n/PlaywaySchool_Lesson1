using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    const float piRad = 180 / Mathf.PI;
    const float halfFov = 60;
    const float fovDist = 5;

    protected GameObject target;
    protected float speed = 5f;

    public CombatController combat = new CombatController();

    void Start() {
        target = GameObject.FindObjectOfType<EnemyController>().gameObject;
    }

    void Update() {
        combat.UpdateCooldownTimer(Time.deltaTime);
    }

    float getAngleToTarget() {
        Vector3 toTarget = new Vector3(target.transform.position.x - transform.position.x, 0, target.transform.position.z - transform.position.z);

        float dot = Vector3.Dot(transform.forward.normalized, toTarget.normalized);

        float angle = Mathf.Acos(dot);

        return angle * piRad;
    }

    bool isTargetOnRightSide() {
        bool result = false;



        return result;
    }

    bool isTargetInFront() {
        bool result = false;



        return result;
    }

    protected bool isTargetInVision() {
        if(Vector3.Distance(transform.position, target.transform.position) > fovDist) return false;
        if(getAngleToTarget() > halfFov) return false;


        //Debug.Log(this.name + " sees its target");
        return true;
    }

    protected bool isTargetInRange() {
        if(Vector3.Distance(transform.position, target.transform.position) > combat.range) return false;

        return true;
    }

    protected bool moveToPoint(Vector3 destination) {
        //Debug.Log("Moving to: " + destination);
        transform.LookAt(destination);

        if(Vector3.Distance(transform.position, destination) > 0.1f) {
            Vector3 toTarget = destination - transform.position;
            transform.position = Vector3.MoveTowards(transform.position,target.transform.position, Time.deltaTime * speed);
            return false;
        } else {
            return true;
        }
    }
}
