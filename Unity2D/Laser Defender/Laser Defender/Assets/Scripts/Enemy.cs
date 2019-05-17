using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    [Header("Enemy")]
    [SerializeField] float hp = 100;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathVolume = 0.75f;
    [SerializeField] int diePoint = 100;
    [Header("EnemyProjectile")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 5;   
    [SerializeField] AudioClip enemyShootSound;
    [SerializeField] [Range(0, 1)] float enemyShootVolume = 0.25f;

    // Use this for initialization
    void Start () {

        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
		
	}
	
	// Update is called once per frame
	void Update () {

        CountDownAndShoot();

	}

    private void CountDownAndShoot()
    {

        shotCounter -= Time.deltaTime;

        if(shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }

    }

    private void Fire()
    {

        GameObject laser = Instantiate(
            projectile,
            transform.position,
            Quaternion.identity
            ) as GameObject;

        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);

        AudioSource.PlayClipAtPoint(enemyShootSound,Camera.main.transform.position,enemyShootVolume);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {      

        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        if (!damageDealer) { return; }

        ProcessHit(damageDealer);       

    }

    private void ProcessHit(DamageDealer damageDealer)
    {

        hp -= damageDealer.getDamage();
        damageDealer.Hit();

        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, 
            transform.position, 
            transform.rotation);

        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathVolume);

        FindObjectOfType<SceneManagement>().AddPoints(diePoint);

    }
}
