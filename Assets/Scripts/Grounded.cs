﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour {
    GameObject Mushmom;
    // Start is called before the first frame update
    void Start() {
        Mushmom = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Ground") {
            Mushmom.GetComponent<Movement2D>().isGrounded = true;
        }
    }


    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.tag == "Ground") {
            Mushmom.GetComponent<Movement2D>().isGrounded = false;
        }
    }
}


