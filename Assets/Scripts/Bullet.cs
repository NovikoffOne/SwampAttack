using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private float _lifeTime = 5f;
    private float _currentTime;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
        _currentTime += Time.deltaTime;
        
        if(_currentTime >= _lifeTime)
        {
            Destroy(this.gameObject);
            _currentTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);

            Destroy(this.gameObject);
        }
    }
}
