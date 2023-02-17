using Unity.VisualScripting;
using UnityEngine;

public class M16 : Weapon
{
    [SerializeField] private float _delayShot = 0.01f;
    [SerializeField] private float _coolDownShot = 0.3f;

    private int _maxCountBullet = 3;
    private int _bulletCount;
    private Transform _shootPoint;
    
    public override void Shoot(Transform shootPoint)
    {
        _shootPoint = shootPoint;

        InvokeRepeating(nameof(InstantiateBullet), _delayShot, _coolDownShot);
    }

    private void InstantiateBullet()
    {
        Instantiate(Bullet, _shootPoint.position, Quaternion.identity);
        _bulletCount++;

        if (_bulletCount >= _maxCountBullet)
        {
            CancelInvoke();
            _bulletCount = 0;
        }
    }
}
