using UnityEngine;

public class Gift : MonoBehaviour
{
    [SerializeField] private GameObject _floatingText;

    private GiftSpawner _giftSpawner;

    public void Initialize(GiftSpawner giftSpawner)
    {
        _giftSpawner = giftSpawner;
    }

    private void OnTriggerEnter2D(Collider2D colloder)
    {
        if(colloder.CompareTag(GameController.PLAYER_GAME_OBJECT_TAG))
        {
            _giftSpawner.TakeGift();
            
            GameObject effect = Instantiate(_floatingText, gameObject.transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);

            Destroy(gameObject);
        }
    }
}
