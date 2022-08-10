using UnityEngine;

public class Track : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(target, Vector3.up);
    }
}
