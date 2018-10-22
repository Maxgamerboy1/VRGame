using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    SteamVR_Camera Camera { get { return GetComponentInParent<MeshRenderer>().GetComponentInChildren<SteamVR_Camera>(); } }
    public GameObject fullBodyMesh;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var newPos = new Vector3(Camera.head.position.x, Camera.head.position.y, Camera.head.position.z);
        newPos.Set(newPos.x, newPos.y, newPos.z);
        fullBodyMesh.transform.SetPositionAndRotation(newPos, Camera.head.rotation);
    }
}
