using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityController
{        
    void Start() {
        speed *= 1.5f;
        target = GameObject.FindObjectOfType<EnemyController>().gameObject;
    }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(horizontal != 0 || vertical != 0) {
            transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime * speed, Space.Self);
        }

        combat.UpdateCooldownTimer(Time.deltaTime);
        if(Input.GetButtonUp("Jump") && target) {
            if(isTargetInRange() && combat.CanAttack()) {
                Debug.Log("Player can try to attack");
                if(combat.TryAttack(target)) {
                    Debug.Log($"{this.name} attacked {target.name}");
                }
            }
        }
        
    }

}
