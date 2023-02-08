using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float Speed = 30f;
    [SerializeField] private GameObject preMiniWall;
    [SerializeField] private Transform[] posMiniWalls;
    private bool[] posAlreadyUsed;
    private int numero;
    public int targetScore;
    public UnityEvent<int> UpdateScore;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        posAlreadyUsed = new bool[posMiniWalls.Length];
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(Input.GetAxis("Horizontal")*Speed, 0.0f, Input.GetAxis("Vertical")*Speed);
    }

    private void SpawnWall()
    {
        StartCoroutine(DelayBeforeSpawn());
    }

    private IEnumerator DelayBeforeSpawn()
    {
        yield return new WaitForSeconds(2f);
        numero = Random.Range(0, posMiniWalls.Length);
        while (posAlreadyUsed[numero])
        {
            numero = Random.Range(0, posMiniWalls.Length);
        }
        SpawnMiniWall(numero);
        posAlreadyUsed[numero] = true;
    }
    
    private void SpawnMiniWall(int i)
    {
        Instantiate(preMiniWall, posMiniWalls[i].transform.position, posMiniWalls[i].transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            targetScore = other.gameObject.GetComponent<Target>().score;
            UpdateScore?.Invoke(targetScore);
            Destroy(other.gameObject);
            SpawnWall();
        }
    }
}