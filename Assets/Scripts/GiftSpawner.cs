using UnityEngine;
using TMPro;

public class GiftSpawner : MonoBehaviour
{
    [SerializeField] private Sprite[] _giftIcons;
    [SerializeField] private GameObject _gift;
    [SerializeField] private GameObject[] _tiles;
    [SerializeField] private TMP_Text _scoreDisplay;
    [SerializeField] private AudioSource _takeGiftSound;

    private int _activeTile = 62;
    private float _score = 0;

    private void Start()
    {
        _scoreDisplay.text = "—чет:0";
        SpawnGift();
    }

    public void TakeGift()
    {
        _takeGiftSound.Play();
        _score++;
        _scoreDisplay.text = "—чет:" + _score;
        SpawnGift();
    }

    public void SpawnGift()
    {
        int i = Random.Range(0,(int)_tiles.Length);
        if(i == _activeTile)
        {
            i = i < _tiles.Length - 1 ? i++ : i--;
        }

        _activeTile = i;
        Vector3 spawnPosition = _tiles[_activeTile].transform.position + new Vector3(0f,0.1f,0f);

        GameObject newGift = Instantiate(_gift, spawnPosition, Quaternion.identity);
        newGift.GetComponent<Gift>().Initialize(this);
        newGift.GetComponent<SpriteRenderer>().sprite = _giftIcons[Random.Range(0,3)];
    }
}
