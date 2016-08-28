﻿using UnityEngine;
using System.Collections;
using MandarineStudio.AncientTreaseures;

[RequireComponent(typeof(BoxCollider2D))]
public class GemController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.GemCollected();
            Destroy(gameObject);
        }
    }
}