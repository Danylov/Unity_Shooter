using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    [SerializeField] private float rocketSpeed = 5.0f;
    [SerializeField] private float rocketMaxRotationSpeed = 5.0f; // Degrees / second
    private Transform target; 
    private Vector3 moveDirection, OldMoveDirection = Vector3.one;
    private bool homing;
    private float rocketStrength = 15.0f;
    private float aliveTimer = 20.0f;

    public void Fire(Transform homingTarget)
    {
        target = homingTarget;
        homing = true;
        Destroy(gameObject, aliveTimer);
    }

    void Update()
    {
        if (homing && target)
        {
            moveDirection = (target.transform.position - transform.position).normalized;
            float currAngle = Vector3.Angle(moveDirection, OldMoveDirection);
            float rocketMaxRotationSpeedPerFrame = rocketMaxRotationSpeed * Time.deltaTime;
            if ((OldMoveDirection != Vector3.one) && (rocketMaxRotationSpeedPerFrame < currAngle))
                moveDirection = Vector3.Slerp(OldMoveDirection, moveDirection, rocketMaxRotationSpeedPerFrame);
            transform.position += Time.deltaTime * rocketSpeed * moveDirection;
            transform.LookAt(target);
            OldMoveDirection = moveDirection;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (target != null)
        {
            if (col.gameObject.CompareTag(target.tag))
            {
                Rigidbody targetRigidbody = col.gameObject.GetComponent<Rigidbody>();
                Vector3 away = -col.contacts[0].normal;
                targetRigidbody.AddForce(away * rocketStrength, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
    }
}