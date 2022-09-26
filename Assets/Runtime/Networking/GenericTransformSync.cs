using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ubiq.XR;
using UnityEngine;
using Ubiq;
using Ubiq.Messaging;
using System;


[ExecuteAlways]
public class GenericTransformSync : NetworkBehaviour
{
    [SerializeField]
    public Rigidbody body;
    public bool hasBody;
    public bool syncBody;


    bool owner;
    public struct Message
    {

        public TransformMessage transform;

        public Nullable<RigidBodyMessage> body;

        public Message(Transform transform, Rigidbody body)
        {
            this.transform = new TransformMessage(transform);
            this.body = new RigidBodyMessage(body);
        }

        public Message(Transform transform)
        {
            this.transform = new TransformMessage(transform);
            this.body = null;
        }

        public void Deserialize(Transform transform, Rigidbody body)
        {
            Deserialize(transform);
            if (this.body.HasValue)
            {
                var messageBody = this.body.GetValueOrDefault();
                body.velocity = messageBody.velocity;
                body.isKinematic = messageBody.kinematic;
            }
        }

        public void Deserialize(Transform transform)
        {
            transform.localPosition = this.transform.position;
            transform.localRotation = this.transform.rotation;
        }
    }

    void Update()
    {
        if (!Application.IsPlaying(gameObject)) {
            body = GetComponent<Rigidbody>();
            this.hasBody = body != null;
        }
    }

    private void FixedUpdate()
    {
        if (owner)
        {
            if (body && syncBody)
                SendJson(new Message(transform, body));
            else
                SendJson(new Message(transform));
        }

    }

    protected override void ProcessMessage(ReferenceCountedSceneGraphMessage message)
    {
        var msg = message.FromJson<Message>();
        msg.Deserialize(transform, body);
    }
}