using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gift : MonoBehaviour
{
    [SerializeField] private GameObject floatingText;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            GameObject effect = Instantiate(floatingText, gameObject.transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            GameObject.Find("Gift Spawner").GetComponent<GiftSpawner>().TakeGift();
            Destroy(gameObject);
        }
    }
}
