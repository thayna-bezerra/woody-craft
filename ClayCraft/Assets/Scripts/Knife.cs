using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private Rigidbody knifeRb;
    private Vector3 movementVector;
    private bool isMoving = false;

    private void Start()
    {
        knifeRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isMoving = Input.GetMouseButton(0);

        if (isMoving)
            movementVector = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f) * movementSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (isMoving)
            knifeRb.position += movementVector;
    }
}
