using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textBox;
    [SerializeField] private string[] _lines;
    [SerializeField] private float _textSpeed = 0.04f;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private TextMeshProUGUI _nextButtonText;
    [SerializeField] private GameObject _fireStrikePref;

    private int _index;

    private void Start()
    {
        _textBox.text = string.Empty; 
        StartDialogue();
        _nextButton.SetActive(false);
    }

    public void NextButton()
    {
        NextLine();
    }

    public void NextScene()
    {
        SceneManager.LoadScene(2);
    }

    private void StartDialogue()
    {
        _index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach(char c in _lines[_index].ToCharArray())
        {   
            if(_textBox.text == "С неба падают огненные лучи выжигающие все на своем пути. Ученые говорят, что это вызвано сильными вспышками на солнце. Они называют это явление ")
            {
                _textBox.text += "<i><color=#7d0005>";
            }
            if(_textBox.text == "С неба падают огненные лучи выжигающие все на своем пути. Ученые говорят, что это вызвано сильными вспышками на солнце. Они называют это явление <i><color=#7d0005>красной жарой")
            {
                _textBox.text += "</color></i>";
            }
            _textBox.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
        
        if(_index >= _lines.Length-1)
        {
            _nextButtonText.text = "Начать>>";
        }
        _nextButton.SetActive(true);
    }

    private void NextLine()
    {
        if(_index < _lines.Length -1)
        {
            _nextButton.SetActive(false);
            _index++;
            _textBox.text = string.Empty; 
            StartCoroutine(TypeLine());
        }
        else
        {
            NextScene();
        }
        if(_index == 1)
        {
            StartFireStrike();
        }
    }

    private void StartFireStrike()
    {
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
        GameObject firestrike = Instantiate(_fireStrikePref,spawnPosition, Quaternion.identity);
        firestrike.GetComponent<FireSrike>().DontMove();
    }
}
