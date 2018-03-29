using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHand : MonoBehaviour {

    public Transform Object;
    public Vector3 offset;

    void Update()
    {
        transform.position = Object.position + offset;
    }
}
