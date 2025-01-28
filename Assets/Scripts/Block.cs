using System.Collections;
using UnityEngine;

public class Block : MonoBehaviour
{
    private const string RESTORE_ANIM_TRIGGER = "Restore";
    private const string STOP_RESTORE_ANIM_TRIGGER = "Stop Restore";

    [SerializeField] private GameObject _brokenBlock;
    [SerializeField] private GameObject _brokenEffect;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _brokenBlock.SetActive(false);
    }

    public void DestroyBlock()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        _brokenBlock.SetActive(true);

        GameObject effect = Instantiate(_brokenEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        StartCoroutine(StartRestoreAnimation(2f));
        StartCoroutine(RestoreBlock(3f));
    }

    private IEnumerator StartRestoreAnimation(float interval)
    {
        yield return new WaitForSeconds(interval);
        _brokenBlock.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        _animator.SetTrigger(RESTORE_ANIM_TRIGGER);
    }

    private IEnumerator RestoreBlock(float interval)
    {
        yield return new WaitForSeconds(interval);
        _animator.SetTrigger(STOP_RESTORE_ANIM_TRIGGER);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
