using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : CollectableBase
{
    [Header("Animation")]
    public float idleAnimationLoopTime = 0.5f;
    public Ease idleAnimatonEase = Ease.OutBack;
    public float collectAnimationDuration = 0.5f;
    public Ease collectAnimationEase = Ease.OutElastic;

    private bool _collected = false;

    private void Awake()
    {
        IdleAnimation();
    }

    protected override void OnCollect()
    {
        if (!_collected)
        {
            _collected = true;
            base.OnCollect();
            ItemManager.Instance.AddCoins();
            StartCoroutine(CollectAnimation());
        }
    }

    IEnumerator CollectAnimation()
    {
        DOTween.Kill(transform);
        transform.DOScale(0, collectAnimationDuration).SetEase(collectAnimationEase);
        yield return new WaitForSeconds(1.5f*collectAnimationDuration);
        Destroy(gameObject);
    }

    private void IdleAnimation()
    {
        transform.DOScaleX(-1, idleAnimationLoopTime).SetLoops(-1, LoopType.Yoyo).SetEase(idleAnimatonEase);
    }
}
