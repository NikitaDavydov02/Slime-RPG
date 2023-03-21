using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 offcet = Vector3.zero;
    private Transform target;
    void Start()
    {
    }
    public void SetTarget(Transform target)
    {
        //Screen.SetResolution((int)Screen.width, (int)Screen.height, true);
        this.target = target;
        if (target != null)
            offcet = target.position - transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = target.position - offcet;
            //transform.LookAt(target);
        }
    }
}
