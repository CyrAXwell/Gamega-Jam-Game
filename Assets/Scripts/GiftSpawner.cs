using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GiftSpawner : MonoBehaviour
{
    [SerializeField] private Sprite[] giftIcons;
    [SerializeField] private GameObject gift;
    [SerializeField] private GameObject[] tiles;
    private int activeTile = 62;
    private Vector3 spawnPosition;

    [SerializeField] private TMP_Text scoreDisplay;
    private float score = 0;
    [SerializeField] AudioSource takeGiftSound;

    void Start()
    {

        scoreDisplay.text = "—чет:0";
        SpawnGift();
        // GameObject newGift = Instantiate(gift,new Vector3(0.5f, 0.5f, 0f), Quaternion.identity);
        // newGift.transform.GetComponent<SpriteRenderer>().sprite = giftIcons[Random.Range(0,3)];
    }


    void Update()
    {
        
    }

    public void TakeGift()
    {
        takeGiftSound.Play();
        score++;
        scoreDisplay.text = "—чет:" + score;
        SpawnGift();
    }

    public void SpawnGift()
    {
        int i = Random.Range(0,(int)tiles.Length);
        if(i == activeTile && i < tiles.Length-1)
        {
            i++;
        }
        if(i == activeTile && i >= tiles.Length-1)
        {
            i--;
        }

        activeTile = i;
        spawnPosition = tiles[activeTile].transform.position + new Vector3(0f,0.1f,0f);
        GameObject newGift = Instantiate(gift,spawnPosition, Quaternion.identity);
        newGift.transform.GetComponent<SpriteRenderer>().sprite = giftIcons[Random.Range(0,3)];

        // for(int i=0;i<tiles.Length;i++)
        // {
        //     spawnPosition = tiles[i].transform.position + new Vector3(0f,-0.1f,0f); 
        //     GameObject newGift = Instantiate(gift,spawnPosition, Quaternion.identity);
        //     newGift.transform.GetComponent<SpriteRenderer>().sprite = giftIcons[Random.Range(0,3)];
        // }
    }
}
