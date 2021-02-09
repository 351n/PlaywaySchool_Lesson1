using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject target;

    private float speed = 5f;

    void Start()
    {
        target = GameObject.FindObjectOfType<EnemyController>().gameObject;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(horizontal != 0 || vertical != 0) {
            transform.Translate(new Vector3(horizontal,0,vertical)*Time.deltaTime*speed,Space.Self);
        }

        if(target) {
            Debug.Log(getAngleToTarget());
        }
    }

    float getAngleToTarget() {
        Vector3 toTarget = new Vector3(target.transform.position.x - transform.position.x,0, target.transform.position.z - transform.position.z);

        float dot = Vector3.Dot(transform.forward.normalized, toTarget.normalized);

        float angle = Mathf.Acos(dot);

        return angle*180/Mathf.PI;
    }

    bool isTargetOnRightSide() {
        bool result = false;



        return result;
    }

    bool isTargetInFront() {
        bool result = false;



        return result;
    }
}
