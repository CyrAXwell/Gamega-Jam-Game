using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSrike : MonoBehaviour
{
    [SerializeField] private float splashRange;
    [SerializeField] private float speed;
    private GameObject player;
    private GameObject gift;
    private bool canMove = true;
    private bool canDamage = false;
    [SerializeField] AudioSource hitSound;
    private bool isPlayerHit = false;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(StopMove(1.3f));
        StartCoroutine(ExplosionDamage(1.8f));
        StartCoroutine(StopDamage(2.1f));
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        if(canMove)
        {
            //gift = GameObject.FindGameObjectWithTag("Gift");
            transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if(canDamage)
        {
            var hitColliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), splashRange);
            foreach(var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Block")) {
                    hitCollider.GetComponent<Block>().DestroyBlock();
                }
                if (hitCollider.CompareTag("Player")) {
                    if(!isPlayerHit)
                    {
                        isPlayerHit = true;
                        GameObject.Find("Game Controller").GetComponent<GameController>().GameOver();
                    }
                    
                }
            }
        }
    }

    private IEnumerator ExplosionDamage(float interval)
    {
        yield return new WaitForSeconds(interval);
        hitSound.Play();
        canDamage = true;
    }
    private IEnumerator StopDamage(float interval)
    {
        yield return new WaitForSeconds(interval);
        canDamage = false;
    }

    private IEnumerator StopMove(float interval)
    {
        yield return new WaitForSeconds(interval);
        canMove = false;
    }

    public void DontMove()
    {
        canMove = false;
    }


}
