﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Vector2Int explosionPos;
    public BoardManager bm;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        bm.GetTile(explosionPos.x, explosionPos.y).WarnTile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tile"))
        {
            GameObject newExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
            newExplosion.GetComponent<Explosion>().explosionPos = explosionPos;
            newExplosion.GetComponent<Explosion>().bm = bm;
            Destroy(gameObject);
        }
    }
}
