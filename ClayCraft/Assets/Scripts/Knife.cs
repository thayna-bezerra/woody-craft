using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float hitDamage;
    [SerializeField] private Wood wood;

    [SerializeField] private ParticleSystem woodFx;

    private ParticleSystem.EmissionModule woodFxEmission;

    private Vector2 lastTouchPosition;
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
            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                isDragging = true;
                Vector2 touchDeltaPosition = touch.position - lastTouchPosition; // Usando Vector2 para a posição do toque
                Vector3 movementVector = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 0f) * movementSpeed * Time.deltaTime;
                transform.position += movementVector;
                lastTouchPosition = touch.position;

                float newXPosition = Mathf.Clamp(transform.position.x, -2.60f, 2.60f);
                transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

                float newYPosition = Mathf.Clamp(transform.position.y, -3.00f, 1.61f);
                transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
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
