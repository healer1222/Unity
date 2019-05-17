using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] float hp = 500f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathVolume = 0.75f;

    [Header("Projectile")]
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileFiringPeriod = 0.1f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;

   

    Coroutine firingCoroutine;

    float minX;
    float maxX;
    float minY;
    float maxY;



    // Use this for initialization
    void Start () {

        SetUpMoveBoundaries();
      

    }

    
    // Update is called once per frame
    void Update () {

        Move();
        Fire();

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
        FindObjectOfType<Level>().LoadGameOver();
        Destroy(gameObject);

        GameObject explosion = Instantiate(deathVFX,
           transform.position,
           transform.rotation);

        Destroy(explosion, durationOfExplosion);
        
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathVolume);

        FindObjectOfType<SceneManagement>().SetPrevScene(SceneManager.GetActiveScene().buildIndex);  

       
        
    }

    public float GetHP()
    {
        return hp;
    }

    private void Fire()
    {


        if (Input.GetButtonDown("Fire1"))
        {


            firingCoroutine = StartCoroutine(FireContinously());

        }
        if (Input.GetButtonUp("Fire1"))
        {

            StopCoroutine(firingCoroutine);

        }

        
    }

    IEnumerator FireContinously()
    {

        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;

            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);

            yield return new WaitForSeconds(projectileFiringPeriod);
        }
       


    }

    private void SetUpMoveBoundaries()
    {

        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }

    private void Move()
    {

        
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(newXPos, newYPos);

        

    }
}
