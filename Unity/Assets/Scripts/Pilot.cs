using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : SteeringBehaviour
{
    public PilotNodePositioning node;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public override Vector3 Calculate()
    {
        if(node.isControlled)
        {
            return new Vector3(0, Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        }
        else
        {
            return Vector3.zero;
        }
    }
}
