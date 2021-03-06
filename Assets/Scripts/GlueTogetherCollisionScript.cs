﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueTogetherCollisionScript : MonoBehaviour
{
    public bool isClicked = false;
    public GameObject[] MergeObjects;
    public float CollisionCooldown = 5.0f;
    public bool notCollided = true;



    void OnCollisionEnter(Collision collision)
    {
        if (CollisionCooldown <= 0.0f)
            if (notCollided && (this.tag == "Calcium" && collision.gameObject.tag == "Natrium") || (this.tag == "Natrium" && collision.gameObject.tag == "Calcium"))
            {
                if (collision.gameObject.GetComponent<GlueTogetherCollisionScript>().CollisionCooldown > 0.0f)
                    return;
                notCollided = false;
                if (collision.gameObject.GetComponent<GlueTogetherCollisionScript>().notCollided)
                {
                    Vector3 force = this.GetComponent<Rigidbody>().velocity * 20 /*+ collision.gameObject.GetComponent<Rigidbody>().velocity*/;
                    Destroy(collision.gameObject);
                    Destroy(this.gameObject);
                    GameObject newObject = Instantiate(MergeObjects[0], transform.position, new Quaternion());
                    newObject.GetComponent<Rigidbody>().AddForce(force);
                }
            }

        if (notCollided && (this.tag == "Kalium" && collision.gameObject.tag == "Natrium") || (this.tag == "Natrium" && collision.gameObject.tag == "Kalium"))
        {
            if (collision.gameObject.GetComponent<GlueTogetherCollisionScript>().CollisionCooldown > 0.0f)
                return;
            notCollided = false;
            if (collision.gameObject.GetComponent<GlueTogetherCollisionScript>().notCollided)
            {
                Vector3 force = this.GetComponent<Rigidbody>().velocity * 20 /*+ collision.gameObject.GetComponent<Rigidbody>().velocity*/;
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                GameObject newObject = Instantiate(MergeObjects[1], transform.position, new Quaternion());
                newObject.GetComponent<Rigidbody>().AddForce(force);
            }
        }

        if (notCollided && (this.tag == "Kalium" && collision.gameObject.tag == "Calcium") || (this.tag == "Calcium" && collision.gameObject.tag == "Kalium"))
        {
            if (collision.gameObject.GetComponent<GlueTogetherCollisionScript>().CollisionCooldown > 0.0f)
                return;
            notCollided = false;
            if (collision.gameObject.GetComponent<GlueTogetherCollisionScript>().notCollided)
            {
                Vector3 force = this.GetComponent<Rigidbody>().velocity * 20 /*+ collision.gameObject.GetComponent<Rigidbody>().velocity*/;
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                GameObject newObject = Instantiate(MergeObjects[2], transform.position, new Quaternion());
                newObject.GetComponent<Rigidbody>().AddForce(force);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CollisionCooldown > 0.0f)
            CollisionCooldown -= Time.deltaTime;
        if (this.transform.position.z > 0.7 || this.transform.position.z < -0.7)
            this.transform.position.Set(this.transform.position.x, this.transform.position.y, 0.0f);
    }
}
