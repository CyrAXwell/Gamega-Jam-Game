using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private GameObject brokenBlock;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject brokenEffect;

    void Start()
    {
        brokenBlock.SetActive(false);
        
        //brokenBlock.GetComponent<SpriteRenderer>().enabled = false;
        //gameObject.transform.GetChild(0);
    }

    public void DestroyBlock()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        brokenBlock.SetActive(true);

        GameObject effect = Instantiate(brokenEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        StartCoroutine(StartRestoreAnimation(2f));
        StartCoroutine(RestoreBlock(3f));
        //Debug.Log(gameObject.name);
        
        
    }

    private IEnumerator StartRestoreAnimation(float interval)
    {
        yield return new WaitForSeconds(interval);
        brokenBlock.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        anim.SetTrigger("Restore");

    }

    private IEnumerator RestoreBlock(float interval)
    {
        yield return new WaitForSeconds(interval);
        anim.SetTrigger("Stop Restore");
        //gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }
}
