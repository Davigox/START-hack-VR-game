﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWeaponBullet : MonoBehaviour {
    [SerializeField]
    float damage = 5f;
    [SerializeField]
    float initalForce = 75;

    Rigidbody myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        myRigidbody.AddForce(transform.right * -1 * initalForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision == null)
        {
            return;
        }
        GameObject collisionObject = collision.gameObject;

        if(collisionObject.tag == "Enemy")
        {
            collisionObject.SendMessage("ApplyDamage", damage, 
                SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }

    }
}
