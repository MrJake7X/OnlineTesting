using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorBehaviour : Bolt.EntityBehaviour<ICustomCubeState>
{
    public float speed;

    Vector2 axis;

    // Same as Start
    public override void Attached()
    {
        state.SetTransforms(state.CubeTransform, transform);
    }

    // Same as Update, but only in owner computer
    public override void SimulateOwner()
    {
        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");

        transform.position += new Vector3(axis.x, transform.position.y, axis.y) * speed * BoltNetwork.FrameDeltaTime;
    }
}
