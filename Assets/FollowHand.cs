using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHand : MonoBehaviour {

    private SteamVR_TrackedController Controller { get { return (isRightHand ? controllerManager.right : controllerManager.left).GetComponent<SteamVR_TrackedController>(); } }

    public SteamVR_TrackedObject hand;
    public bool isRightHand;

    private SteamVR_ControllerManager controllerManager;

	// Use this for initialization
	void Start () {
        controllerManager = GetComponentInParent<SteamVR_ControllerManager>();
        //SteamVR_Controller.Device controllerDevice = SteamVR_Controller.Input((int)Controller.controllerIndex);
        //hand.transform.parent = controllerDevice.transform;
    }

    // Update is called once per frame
    void Update () {
        var newPos = new Vector3(Controller.transform.position.x, Controller.transform.position.y, Controller.transform.position.z);
        var newRot = new Quaternion(Controller.transform.rotation.x, Controller.transform.rotation.y, Controller.transform.rotation.z, Controller.transform.rotation.w);
        SteamVR_Controller.Device controllerDevice = SteamVR_Controller.Input((int)Controller.controllerIndex);
        var controllerPose = controllerDevice.GetPose();

        //Controller.Get
        //hand.transform.SetPositionAndRotation(newPos, newRot);
        //hand.transform.SetPositionAndRotation(new Vector3(controllerPose.vVelocity.v0, controllerPose.vVelocity.v1, controllerPose.vVelocity.v2), newRot);
        var rot = Quaternion.LookRotation(Controller.transform.forward, Controller.transform.up);
        hand.transform.SetPositionAndRotation(controllerDevice.transform.pos, rot);
    }
}
