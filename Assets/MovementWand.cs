using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class MovementWand : MonoBehaviour {

    SteamVR_TrackedObject trackedObject;

    SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObject.index); } }

	// Use this for initialization
	void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (controller != null)
        {
            if (controller.GetPress(EVRButtonId.k_EButton_SteamVR_Touchpad))
            {
                Debug.Log("UpPad Pressed");
                //var camera = GetComponent<Camera>();
                var _Parent = GetComponentInParent<MeshRenderer>();
                var camera = _Parent.GetComponentInChildren<SteamVR_Camera>();
                var directionToMove = camera.GetRay().direction;
                directionToMove.Scale(new Vector3(.16F, .16F, .16F));
                _Parent.transform.Translate(directionToMove);
                //Player _Player = GetComponent<Player>();
                //_Player.transform.Translate(5, 0, 5);
                //transform.Translate(5, 0, 5);
                //Player.transform.Translate(new Vector3(3, 3));
            }
        }
	}
}
