﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PatrykKonior

public class Floor : MonoBehaviour
{

    public ParticleSystem fxPrefab;

    ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnCollisionEnter(Collision col)
    {
        var fx = Instantiate(fxPrefab, col.transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(fx.gameObject, 1f);
        Destroy(col.gameObject);
        scoreManager.LoseLife();
    }
}
