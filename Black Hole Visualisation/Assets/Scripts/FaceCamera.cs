using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public Transform cam;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(cam);
        transform.Rotate(new Vector3(1, 0, 0), 90);
    }
}
