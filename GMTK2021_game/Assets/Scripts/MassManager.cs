using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassManager : MonoBehaviour
{
    public float strength;
    public float attachmentscaler;
    List<GameObject> attachedObjects;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void AddObject(GameObject recruit)
    {
        float objectmass = recruit.GetComponent<Rigidbody2D>().mass;
        strength += objectmass * attachmentscaler;
        attachedObjects.Add(recruit);
        UpdateStrength();
    }

    public void RemoveObject(GameObject fired)
    {
        float objectmass = fired.GetComponent<Rigidbody2D>().mass;
        if(attachedObjects.Contains(fired))
        {
            attachedObjects.Remove(fired);
        }
        UpdateStrength();
    }

    void UpdateStrength()
    {
        this.transform.parent.GetComponentInChildren<Arm>().grabstrength = strength;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
