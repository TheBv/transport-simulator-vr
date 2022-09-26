using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ubiq.Messaging
{
    [Serializable]
    public struct TransformMessage
    {
        public Vector3 position;
        public Quaternion rotation;

        public TransformMessage(Transform transform)
        {
            this.position = transform.localPosition;
            this.rotation = transform.localRotation;
        }
    }
    [Serializable]
    public struct RigidBodyMessage
    {
        public bool kinematic;

        public Vector3 velocity;

        public RigidBodyMessage(Rigidbody body) {
            this.kinematic = body.isKinematic;
            this.velocity = body.velocity;
        }
        
    } 


}