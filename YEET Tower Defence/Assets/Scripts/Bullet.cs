using UnityEngine;

public class Bullet : MonoBehaviour {

    public Turret owner;
    private Transform target;

    public float speed = 70f;

    public int damage = 50;

    public GameObject impactEffect;

    public void Seek (Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Damage(target);
        Destroy(gameObject);
    }

    void Damage (Transform enemyGO)
    {
        Enemy enemy =  enemyGO.GetComponent<Enemy>();

        if (enemy != null)
        {
            bool die = enemy.TakeDamage(damage);
            if (die)
            {
                enemy.AddGold(this);
            }

        }
    }
}
