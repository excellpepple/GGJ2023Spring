using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity: MonoBehaviour
{
    public int hitPoints;
    public float attackDamage;
    public float hp;
    
    public void AttackObject(Entity target)
    {
        target.TakeDamage(attackDamage);
    }

    public virtual void TakeDamage(float damage)
    {
        
    }

    /*public void AttackObject(GameObject collisionGameObject)
    {
        if (collisionGameObject.GetType() == typeof(Entity) )
        {
            collisionGameObject.TakeDamage(attackDamage);
        }
    }*/
}
