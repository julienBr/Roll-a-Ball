using UnityEngine;

public class Target : MonoBehaviour
{
    private float _rotationSpeed = 0.2f;
    [SerializeField] public int score = 1;
    
    private void Update()
    {
        transform.Rotate(Vector3.up*_rotationSpeed,Space.World);
    }
}