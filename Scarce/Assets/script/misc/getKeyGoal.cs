﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getKeyGoal : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        getTheKey gameManager;
        gameManager = GetComponentInParent<getTheKey>();
        gameManager.EndGame();
    }
}
