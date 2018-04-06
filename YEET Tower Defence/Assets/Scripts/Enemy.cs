using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    public int health = 100;

    public int value = 50;

    public GameObject deathEffect;

    private Transform target;
    private int wavepointIndex = 0;


    void Start()
    {
        if (transform.position.x > 40)
        {
            target = wayPointP2.wayPointsP2[0];

        }
        else
        {
            target = wayPoint.wayPoints[0];
        }
    }

    public bool TakeDamage (int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
            return true;
        }

        return false;
    }

    void Die()
    { 
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.6f)
            {
                if (transform.position.x > 38)
                {
                    GetNextWaypointP2();

                }
                else
                {
                    GetNextWaypointP1();
                }

            }
    }

    void GetNextWaypointP1()
    {
        if (wavepointIndex  >= wayPoint.wayPoints.Length - 1)
        {
            GameManager.players[0].Lives--;
            EndPath();
            return;
        }
        wavepointIndex++;
        target = wayPoint.wayPoints[wavepointIndex];
    }

    void GetNextWaypointP2()
    {
        if (wavepointIndex >= wayPointP2.wayPointsP2.Length - 1)
        {
            GameManager.players[1].Lives--;
            EndPath();
            return;
        }
        wavepointIndex++;
        target = wayPointP2.wayPointsP2[wavepointIndex];
    }


    void EndPath ()
    {
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
    
    public void AddGold(Bullet bullet)
    {
        bullet.owner.owner.Money += value;  
    }
}
