using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FlashColor : MonoBehaviour
{
    public Color damageColor = Color.red;
    public float flashDuration = 0.3f;

    private List<SpriteRenderer> _spriteRenderers;
    private Tween _currentTween;

    private void OnValidate()
    {
        _spriteRenderers = new List<SpriteRenderer>();
        foreach (var sr in GetComponentsInChildren<SpriteRenderer>())
        {
            _spriteRenderers.Add(sr);
        }
    }

    public void Flash()
    {
        if (_currentTween != null)
        {
            _currentTween.Kill();
            _spriteRenderers.ForEach(i => i.color = Color.white);
        }

            foreach (var sr in _spriteRenderers)
        {
            _currentTween = sr.DOColor(damageColor, flashDuration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
