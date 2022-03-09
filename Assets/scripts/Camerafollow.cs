using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{

    public Transform PlayerTransform;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y, this.transform.position.z);

    }
}
