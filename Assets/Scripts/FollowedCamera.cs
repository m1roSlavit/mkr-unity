using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowedCamera : MonoBehaviour
{

    [SerializeField] private Transform _folowingObject;

    void Update()
    {
        transform.position = new Vector3(_folowingObject.position.x, transform.position.y, _folowingObject.position.z);
    }
}
