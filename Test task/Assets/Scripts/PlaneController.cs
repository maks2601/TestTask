using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlaneController : MonoBehaviour
{
    [SerializeField] private Joystick joystick;

    [SerializeField, Range(0f, 100f)] float rotationSpeed;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.MoveRotation(rb.rotation * GetQuaternion());
    }

    private Quaternion GetQuaternion()
    {
        float verticalRotation = joystick.Vertical * -1;
        float horizontalRotation = joystick.Horizontal;

        Vector3 eulerAngleVelocity = new Vector3(verticalRotation, 0f, horizontalRotation);
        return Quaternion.Euler(rotationSpeed * Time.fixedDeltaTime * eulerAngleVelocity);
    }
}
