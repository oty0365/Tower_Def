using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : Enemy.Enemy
{
    private void Start()
    {
        SetUpEnemy();
    }

    private void Update()
    {
        MoveToWay();
    }
}
