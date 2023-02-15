using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _curruntWeapon;
    private int _curruntHealth;
    private Animator _animator;
    private int _currentWeaponNumber;

    public event UnityAction<int, int> HelthChanger;
    public event UnityAction<int> MoneyChanger;

    public int Money { get; private set; }

    private void Start()
    {
        _curruntWeapon = _weapons[0];
        _curruntHealth = _health;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _curruntWeapon.Shoot(_shootPoint);
        }
    }

    public void ApplyDamage(int damage)
    {
        _curruntHealth -= damage;

        HelthChanger?.Invoke(_curruntHealth, _health);

        if(_curruntHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;

        MoneyChanger?.Invoke(money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
        MoneyChanger?.Invoke(weapon.Price);
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count - 1)
        {
            _currentWeaponNumber = 0;
        }
        else
        {
            _currentWeaponNumber++;
        }

        WeaponChenger(_weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if(_currentWeaponNumber == 0)
        {
            _currentWeaponNumber = _weapons.Count - 1;
        }
        else
        {
            _currentWeaponNumber--;
        }

        WeaponChenger(_weapons[_currentWeaponNumber]);
    }

    private void WeaponChenger(Weapon weapon)
    {
        _curruntWeapon = weapon;
    }
}
