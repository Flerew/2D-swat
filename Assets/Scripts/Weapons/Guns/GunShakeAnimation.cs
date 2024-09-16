using UnityEngine;
using DG.Tweening;
using System;
using System.Collections;

public class GunShakeAnimation : MonoBehaviour 
{
    [SerializeField] private float _shakeLenght;
    [SerializeField] private float _randomShakeX = 0.01f;
    [SerializeField, Range(0, 0.2f)] private float _shakeXDuration;

    private IGun _gun;
    private float _shakeDuration;

    public void Initialize(IGun gun, float shakeDuration)
    {
        _gun = gun;
        _shakeDuration = shakeDuration;

        _gun.OnShoot += OnShoot;
    }

    private void OnShoot()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        float animDuration = _shakeDuration / 2;

        LocalShake(_shakeLenght, animDuration);

        yield return new WaitForSeconds(animDuration);

        LocalShake(-_shakeLenght, animDuration);
    }

    private void LocalShake(float lenght, float duration)
    {
        float randomShakeX = UnityEngine.Random.Range(-_randomShakeX, _randomShakeX);

        transform.DOLocalMoveY(-lenght, duration);
        transform.DOLocalMoveX(randomShakeX, duration);
    }
}
