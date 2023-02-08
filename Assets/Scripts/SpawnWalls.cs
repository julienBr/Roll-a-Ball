using System.Collections;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    private int numero;
    [SerializeField] private GameObject preMiniWall;
    [SerializeField] private Transform[] posMiniWalls;
    private bool[] posAlreadyUsed;

    private void OnEnable()
    {
        Player.OnTargetTouched += SpawnWall;
    }

    private void OnDisable()
    {
        Player.OnTargetTouched -= SpawnWall;
    }

    private void Start()
    {
        posAlreadyUsed = new bool[posMiniWalls.Length];
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
}