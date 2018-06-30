using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchpadMovementInput : MonoBehaviour {

    public SteamVR_TrackedController Controller { get { return GetComponent<SteamVR_TrackedController>(); } }

    // Use this for initialization
    void Start () {
	}
    

    // Update is called once per frame
    void Update () {
        if (Controller.padPressed)
        {
            var _Parent = GetComponentInParent<MeshRenderer>();
            var camera = _Parent.GetComponentInChildren<SteamVR_Camera>();
            var directionToMove = camera.GetRay().direction;
            directionToMove.Scale(new Vector3(.016F, 0, .016F));
            _Parent.transform.Translate(directionToMove);
        }
    }
}
