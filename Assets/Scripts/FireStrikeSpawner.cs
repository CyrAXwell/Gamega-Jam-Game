using System.Collections;
using UnityEngine;

public class FireStrikeSpawner : MonoBehaviour
{
   [SerializeField] private float _leftBorder = -8.5f;
   [SerializeField] private float _rightBorder = 8.5f;
   [SerializeField] private float _upBorder = 4.5f;
   [SerializeField] private float _downBorder = -4.5f;
   [SerializeField] private float _delta = 3;
   [SerializeField] private GameObject _fireStrikePref;

   private Vector3 _spawnPosition;
   private int _numOfFireStrike = 1;
   private GameObject _player;

   private void Start()
   {
        StartCoroutine(SpawnFireStrike(3f));
        _player = GameObject.FindWithTag("Player");
   }

    private IEnumerator SpawnFireStrike(float interval)
    {
        yield return new WaitForSeconds(interval);
        
        for(int i = 0;i < _numOfFireStrike;i++)
        {
            GetPosition();
            Instantiate(_fireStrikePref,_spawnPosition, Quaternion.identity);
        }
        
        StartCoroutine(SpawnFireStrike(3f));
    }

    private void GetPosition()
    {
        float border;

        border = _player.transform.position.x - _delta;
        float leftSide = border < _leftBorder ? _leftBorder : border;

        border = _player.transform.position.x + _delta;
        float rightSide = border > _rightBorder ? _rightBorder : border;

        border = _player.transform.position.y - _delta;
        float downSide = border < _downBorder ? _downBorder : border;

        border = _player.transform.position.y + _delta;
        float upSide = border > _upBorder ? _upBorder : border;

        float xPosition = Random.Range(leftSide, rightSide);
        float yPosition = Random.Range(downSide, upSide);
        
        _spawnPosition = new Vector3(xPosition, yPosition, 0f);
    }
}
