using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveStateFog : State
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxCoolDownTime = 2;
    [SerializeField] private float _minCoolDownTime = 0;
    [SerializeField] private float _maxJerkRange = 5;
    [SerializeField] private float _minJerkRange = 1;

    private Vector2 _attackPosition;
    private float _coolDown;
    private float _jerkRange;
    private float _curentTime;

    private void Start()
    {
        _coolDown = Random.Range(_minCoolDownTime, _maxCoolDownTime);
        _attackPosition = new Vector2(Target.transform.position.x - 1, transform.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        _curentTime += Time.deltaTime;

        if(_curentTime >= _coolDown)
        {
            Jerk();
            _curentTime = 0;
        }
    }

    private void Jerk()
    {
        _jerkRange = Random.Range(_minJerkRange, _maxJerkRange);

        transform.position = new Vector2(transform.position.x + _jerkRange, transform.position.y);

        if(transform.position.x >= Target.transform.position.x)
        {
            transform.position = _attackPosition;
        }
    }
}
