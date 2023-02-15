using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(Transform _shootPoint)
    {
        Instantiate(Bullet, _shootPoint.position, Quaternion.identity);
    }
}
