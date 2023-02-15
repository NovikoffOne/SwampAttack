using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] Spawner _spawner;

    private void OnEnable()
    {
        _spawner.EnemyCountChanger += OnValueChanger;

        Slider.value = 0;
    }

    private void OnDisable()
    {
        _spawner.EnemyCountChanger -= OnValueChanger;
    }
}
