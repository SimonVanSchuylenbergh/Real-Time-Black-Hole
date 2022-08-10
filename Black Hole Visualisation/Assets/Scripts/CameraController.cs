using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 5;
    public float center_repulsion_start = 1;
    public float center_repulsion_strength = 1f;

    public bool cap_to_60_fps = false;

    private Rigidbody rigidBody;
    private SimpleCameraControl playerInputActions;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        playerInputActions = new SimpleCameraControl();
        playerInputActions.Camera.Enable();

        if (cap_to_60_fps)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 inputVector = playerInputActions.Camera.Movement.ReadValue<Vector3>();
        rigidBody.AddForce(transform.localToWorldMatrix * inputVector * speed, ForceMode.Force);

        // Center repulsion
        if (transform.position.magnitude < center_repulsion_start)
        {
            float strength = (1 / transform.position.magnitude - 1 / center_repulsion_start) * center_repulsion_strength;
            rigidBody.AddForce(transform.position.normalized * strength, ForceMode.Force);
        }
    }
}
