using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    void OnCollisionEnter(Collision collisionInfo) {
        if (collisionInfo.gameObject.tag.Equals("Player")) {
            collisionInfo.gameObject.GetComponent<Rigidbody>().AddForce(collisionInfo.contacts[0].normal * 3000);
        }
    }
}
