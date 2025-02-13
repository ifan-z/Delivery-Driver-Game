using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColour = new Color32(255, 255, 255, 255);
    [SerializeField] Color32 noPackageColour = new Color32(255, 255, 255, 255);

    bool hasPackage = false;
    [SerializeField] float deleteDelay = 0.2f;

    [SerializeField] GameObject car;
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = car.GetComponent<SpriteRenderer>();
    }
    
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ouch! Bumped into " + other.gameObject.name);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package") {
            if (!hasPackage) {
                Debug.Log("Picked up a package!");
                hasPackage = true;
                Destroy(other.gameObject, deleteDelay);
                hasPackageColour = other.gameObject.GetComponent<SpriteRenderer>().color;
                spriteRenderer.color = hasPackageColour;
            }
        } else if (other.tag == "Customer") {
            if (hasPackage) {
                Debug.Log("Package delivered!");
                hasPackage = false;
                spriteRenderer.color = noPackageColour;
            }
        } else {
            Debug.Log("What was that? Triggered " + other.gameObject.name);
        }
    }
}
