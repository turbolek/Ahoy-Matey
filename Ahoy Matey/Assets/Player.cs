using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{

    public float speed = 5f;
    Vector3 shift;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            shift.x = CrossPlatformInputManager.GetAxis("Horizontal");
            shift.z = CrossPlatformInputManager.GetAxis("Vertical");

            transform.position += Time.deltaTime * speed * shift;
        }

    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        if (isLocalPlayer)
        {
            Camera myCamera = GetComponentInChildren<Camera>();
            myCamera.enabled = true;
        }

    }
}
