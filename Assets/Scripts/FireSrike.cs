using System.Collections;
using UnityEngine;

public class FireSrike : MonoBehaviour
{
    [SerializeField] private float _splashRange = 1.25f;
    [SerializeField] private float _speed = 2.3f;
    [SerializeField] AudioSource _hitSound;

    private GameObject _player;
    private bool _canMove = true;
    private bool _canDamage = false;
    private bool _isPlayerHit = false;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag(GameController.PLAYER_GAME_OBJECT_TAG);
        StartCoroutine(StopMove(1.3f));
        StartCoroutine(ExplosionDamage(1.8f));
        StartCoroutine(StopDamage(2.1f));
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        if(_canMove)
        {
            transform.position = Vector2.MoveTowards(gameObject.transform.position, _player.transform.position, _speed * Time.deltaTime);
        }

        if(_canDamage)
        {
            var hitColliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), _splashRange);
            foreach(var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag(GameController.BLOCK_GAME_OBJECT_TAG)) 
                {
                    hitCollider.GetComponent<Block>().DestroyBlock();
                }

                if (hitCollider.CompareTag(GameController.PLAYER_GAME_OBJECT_TAG)) 
                {
                    if(!_isPlayerHit)
                    {
                        _isPlayerHit = true;
                        GameObject.Find("Game Controller").GetComponent<GameController>().GameOver();
                    }
                }
            }
        }
    }

    private IEnumerator ExplosionDamage(float interval)
    {
        yield return new WaitForSeconds(interval);
        _hitSound.Play();
        _canDamage = true;
    }

    private IEnumerator StopDamage(float interval)
    {
        yield return new WaitForSeconds(interval);
        _canDamage = false;
    }

    private IEnumerator StopMove(float interval)
    {
        yield return new WaitForSeconds(interval);
        _canMove = false;
    }

    public void DontMove()
    {
        _canMove = false;
    }
}
