using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionScript : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public string Element = "";

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        if (numCollisionEvents != 0)
        {
            if (other.CompareTag("Enemy"))
            {
                TakeDamage(other);
            }
        }
    }

    void TakeDamage(GameObject obj)
    {
        bool isCritical = obj.transform.parent.gameObject.CompareTag(Element);
        EnemyHealth enemyHealth = obj.transform.parent.GetComponent<EnemyHealth> ();
        if (enemyHealth != null)
        {
            if (isCritical)
            {
                enemyHealth.TakeDamage(3);
                StateManager.Instance.Score += 200;          
            }
            else
            {
                enemyHealth.TakeDamage(1);
            }
        }
    }
}
