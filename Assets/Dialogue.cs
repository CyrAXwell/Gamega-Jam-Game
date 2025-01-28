using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private TextMeshProUGUI nextButtonText;

    [SerializeField] private GameObject fireStrikePref;

    private int index;


    void Start()
    {
        textBox.text = string.Empty; 
        StartDialogue();
        nextButton.SetActive(false);
        //nextButtonText.text = "Пропустить>>";
    }

    void Update()
    {
        
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {   
            if(textBox.text == "С неба падают огненные лучи выжигающие все на своем пути. Ученые говорят, что это вызвано сильными вспышками на солнце. Они называют это явление ")
            {
                textBox.text += "<i><color=#7d0005>";
            }
            if(textBox.text == "С неба падают огненные лучи выжигающие все на своем пути. Ученые говорят, что это вызвано сильными вспышками на солнце. Они называют это явление <i><color=#7d0005>красной жарой")
            {
                textBox.text += "</color></i>";
            }
            textBox.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        
        if(index >= lines.Length-1)
        {
            nextButtonText.text = "Начать>>";
        }
        nextButton.SetActive(true);
        //nextButtonText.text = "Далее>>";
    }

    void NextLine()
    {
        if(index < lines.Length -1)
        {
            nextButton.SetActive(false);
            index++;
            textBox.text = string.Empty; 
            StartCoroutine(TypeLine());
        }else
        {
            NextScene();
        }
        if(index == 1)
        {
            StartFireStrike();
        }
    }

    public void NextButton()
    {
        NextLine();
        // if(textBox.text == lines[index])
        // {
        //     NextLine();
        // }else
        // {
        //     StopAllCoroutines();
        //     textBox.text = lines[index];
        // }

    }

    private void StartFireStrike()
    {
        // StartCoroutine(FireStrike(new Vector3(Random.Range(-8f,-3f), Random.Range(-4f,4f), 0f), Random.Range(0.1f,1f)));
        // StartCoroutine(FireStrike(new Vector3(Random.Range(-8f,-3f), Random.Range(-4f,4f), 0f), Random.Range(0.1f,1f)));
        // StartCoroutine(FireStrike(new Vector3(Random.Range(-8f,-3f), Random.Range(-4f,4f), 0f), Random.Range(0.1f,1f)));

        // StartCoroutine(FireStrike(new Vector3(Random.Range(3f,8f), Random.Range(-4f,4f), 0f), Random.Range(0.1f,1f)));
        // StartCoroutine(FireStrike(new Vector3(Random.Range(3f,8f), Random.Range(-4f,4f), 0f), Random.Range(0.1f,1f)));
        // StartCoroutine(FireStrike(new Vector3(Random.Range(3f,8f), Random.Range(-4f,4f), 0f), Random.Range(0.1f,1f)));
        // StartCoroutine(FireStrike(new Vector3(Random.Range(3f,8f), Random.Range(-4f,4f), 0f), Random.Range(0.1f,1f)));
        StartCoroutine(FireStrike(new Vector3(-7f, 3f, 0f), 0.1f));
        StartCoroutine(FireStrike(new Vector3(6f, 1f, 0f), 1f));
        StartCoroutine(FireStrike(new Vector3(-6f, -2f, 0f), 1.5f));

        StartCoroutine(FireStrike(new Vector3(-4.5f, 0f, 0f), 2.5f));
        StartCoroutine(FireStrike(new Vector3(4f, 3f, 0f), 3f));
        StartCoroutine(FireStrike(new Vector3(7f, -3.5f, 0f), 3.5f));

        StartCoroutine(FireStrike(new Vector3(-6f, 2.5f, 0f), 4.5f));
        StartCoroutine(FireStrike(new Vector3(5f, 3f, 0f), 5.5f));
        StartCoroutine(FireStrike(new Vector3(-7f, -3f, 0f), 6.5f));
        StartCoroutine(FireStrike(new Vector3(4f, -1f, 0f), 7.5f));
    }

    private IEnumerator FireStrike(Vector3 spawnPosition, float interval)
    {
        yield return new WaitForSeconds(interval);
        GameObject firestrike = Instantiate(fireStrikePref,spawnPosition, Quaternion.identity);
        firestrike.GetComponent<FireSrike>().DontMove();
    }

    public void NextScene()
    {
        SceneManager.LoadScene(2);
        
    }
    

    


}
