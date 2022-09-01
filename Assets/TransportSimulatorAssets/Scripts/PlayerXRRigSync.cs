using UnityEngine;
using Unity.Netcode;


public class PlayerXRRigSync : NetworkBehaviour
{
    void Update()
    {
        if(!IsOwner) return;

        var XRRig = GameObject.Find("XRRig Mouse Keyboard");

        if(!XRRig) return;

        var cameraTransform = XRRig.transform.GetChild(0).GetChild(0);

        transform.position = XRRig.transform.position;
        transform.eulerAngles = new Vector3(0, cameraTransform.eulerAngles.y, 0);

        // deactivate renderer on owner, to prevent seeing it on own screen
        var meshRenders = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach(var meshRenderer in meshRenders){
            meshRenderer.enabled = false;
        }
    }
}