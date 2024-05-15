using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float hitDamage;
    [SerializeField] private Wood wood;

    [SerializeField] private ParticleSystem woodFx;

    private ParticleSystem.EmissionModule woodFxEmission;

    private Vector3 offset;
    private float zCoordinate;
    private bool isDragging = false;

    public Vector3 initialPosition;


    private void Start()
    {
        woodFxEmission = woodFx.emission;
        transform.position = initialPosition;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (Physics.Raycast(ray, out hit) && hit.transform == transform)
                    {
                        isDragging = true;
                        zCoordinate = Camera.main.WorldToScreenPoint(transform.position).z;
                        offset = transform.position - GetWorldPosition(touch.position);
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        // Update the position of the object
                        transform.position = GetWorldPosition(touch.position) + offset;

                        float newXPosition = Mathf.Clamp(transform.position.x, -2.60f, 2.60f);
                        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

                        float newYPosition = Mathf.Clamp(transform.position.y, -3.00f, 1.45f);
                        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    break;
            }
        }
    }

    private Vector3 GetWorldPosition(Vector3 screenPosition)
    {
        screenPosition.z = zCoordinate;
        return Camera.main.ScreenToWorldPoint(screenPosition);
    }

    private void OnCollisionExit(Collision collision)
    {
        woodFxEmission.enabled = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (isDragging)
        {
            Coll coll = collision.collider.GetComponent<Coll>();
            if (coll != null)
            {
                woodFxEmission.enabled = true;
                woodFx.transform.position = collision.contacts[0].point;

                coll.HitCollider(hitDamage);
                wood.Hit(coll.index, hitDamage);
            }
        }
    }
}