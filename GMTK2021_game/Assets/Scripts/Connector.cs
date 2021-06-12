using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<Rigidbody2D>())
            {
                HingeJoint2D newhinge = transform.parent.gameObject.AddComponent<HingeJoint2D>();
                newhinge.autoConfigureConnectedAnchor = false;
                newhinge.connectedBody = collision.GetComponent<Rigidbody2D>();
                newhinge.anchor = transform.localPosition;
                newhinge.connectedAnchor = collision.transform.InverseTransformPoint(GetComponent<Collider2D>().ClosestPoint(collision.transform.position));
                newhinge.enableCollision = true;
                GetComponentInParent<Grabbable>().Touch();
                this.enabled = false;
            }
        }
    }
}
