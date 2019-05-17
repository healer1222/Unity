using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    //configuration params

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    
    [SerializeField] Sprite[] hitSprites;

    //cached reference

    Level level;
    GameSession gameSession;
    Paddle myPaddle;

    //state variables

    [SerializeField] int timesHit; //TODO only serialized for debug purposes

    private void Start()
    {
        CountBreakableBlocks();

        gameSession = FindObjectOfType<GameSession>();
        myPaddle = FindObjectOfType<Paddle>();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        if (tag == "Breakable" || tag == "DoublethePaddle")
        {

            level.CountBlocks();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        TriggerSparklesVFX();

        if(tag == "Breakable")
        {
            HandleHit();

        }
        else if(tag == "DoublethePaddle")
        {

            myPaddle.transform.localScale = new Vector2(2f,1f) ;
            HandleHit();

        }
            



    }

    private void HandleHit()
    {
        timesHit++;

        int maxHits = hitSprites.Length + 1;
        

        if (timesHit >= maxHits)
        {

            DestroyBlock();

        }
        else
        {

            ShowNextHitSprite();

        }

    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {

            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];

        }
        else
        {

            Debug.LogError("Block sprite is missing from array!" + gameObject.name);

        }
        

    }

    private void DestroyBlock()
    {

        gameSession.addPointsToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        
    }
    
    private void TriggerSparklesVFX()
    {

        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }

}
