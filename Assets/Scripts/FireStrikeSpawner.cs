using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStrikeSpawner : MonoBehaviour
{
   [SerializeField] private float leftBorder;
   [SerializeField] private float rightBorder;
   [SerializeField] private float upBorder;
   [SerializeField] private float downBorder;
   [SerializeField] private float delta;

   [SerializeField] private GameObject fireStrikePref;
   private Vector3 spawnPosition;
   private int numOfFireStrike = 1;
   private GameObject player;

   void Start()
   {
        StartCoroutine(SpawnFireStrike(3f));
        //Instantiate(fireStrikePref,new Vector3(0f,4.5f,0f), Quaternion.identity);
        player = GameObject.FindWithTag("Player");
   }

    private IEnumerator SpawnFireStrike(float interval)
    {
        yield return new WaitForSeconds(interval);
        
        for(int i = 0;i < numOfFireStrike;i++)
        {
            GetPosition();
            Instantiate(fireStrikePref,spawnPosition, Quaternion.identity);
        }
        
        StartCoroutine(SpawnFireStrike(3f));

    }

    private void GetPosition()
    {
        float leftSide = player.transform.position.x - delta;
        if(leftSide < leftBorder)
        {
            leftSide = leftBorder;
        }
        float rightSide = player.transform.position.x + delta;
        if(rightSide > rightBorder)
        {
            rightSide = rightBorder;
        }
        float downSide = player.transform.position.y - delta;
        if(downSide < downBorder)
        {
            downSide = downBorder;
        }
        float upSide = player.transform.position.y + delta;
        if(upSide > upBorder)
        {
            upSide = upBorder;
        }
        

        float xPosition = Random.Range(leftSide, rightSide);
        float yPosition = Random.Range(downSide, upSide);
        
        spawnPosition = new Vector3(xPosition, yPosition, 0f);
    }
}
