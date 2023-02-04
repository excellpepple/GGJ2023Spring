using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootInputVisualizer : MonoBehaviour
{
    private rootPoint currentRootPoint;

    public void setRootPoint(rootPoint rp)
    {
        transform.position = rp.position;
    }
}
