using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float Speed = 30f;
    public int targetScore;
    public UnityEvent<int> UpdateScore;
    public delegate void TargetEvents();
    public static event TargetEvents OnTargetTouched;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(Input.GetAxis("Horizontal")*Speed, 0.0f, Input.GetAxis("Vertical")*Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            targetScore = other.gameObject.GetComponent<Target>().score;
            UpdateScore?.Invoke(targetScore);
            OnTargetTouched?.Invoke();
            Destroy(other.gameObject);
        }
    }
}