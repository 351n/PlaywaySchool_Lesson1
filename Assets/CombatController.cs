using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController
{
    protected float health = 100f;
    protected float attack = 15f;
    protected float cooldown = 5f;
    public float range = 3f;

    private float cooldownTimer =0f;

    public void UpdateCooldownTimer(float value) {
        if(cooldownTimer>0) cooldownTimer -= value;
    }

    public bool TryAttack(GameObject target) {
        if(!target) return false;
        if(!CanAttack()) return false;
        CombatController targetCombat = target.GetComponent<EntityController>().combat;
        if(targetCombat == null) return false;
        if(!targetCombat.IsAlive()) return false;

        targetCombat.GetAttacked(attack);
        cooldownTimer = cooldown;
        return true;
    }

    public bool IsAlive() {
        return health > 0;
    }

    public void GetAttacked(float dmg) {
        health -= attack;
    }

    public bool CanAttack() {
        return cooldownTimer <= 0f;
    }
}
