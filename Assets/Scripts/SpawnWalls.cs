using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    private int numero;
    [SerializeField] private GameObject preMiniWall;
    [SerializeField] private List<TransformDatas> posMiniWalls;
    [SerializeField] private bool[] posAlreadyUsed;
    [SerializeField] private AppDatas choice;

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
        posAlreadyUsed = new bool[choice.actualDifficulty.posMiniWalls.Count];
        posMiniWalls = choice.actualDifficulty.posMiniWalls;
    }

    private void SpawnWall()
    {
        StartCoroutine(DelayBeforeSpawn());
    }

    private IEnumerator DelayBeforeSpawn()
    {
        yield return new WaitForSeconds(1f);
        numero = Random.Range(0, posMiniWalls.Count);
        foreach (bool _bool in posAlreadyUsed)
        {
            if (_bool == false)
            {
                while (posAlreadyUsed[numero])
                {
                    numero = Random.Range(0, posMiniWalls.Count);
                }
            }
        }
        SpawnMiniWall(numero);
        posAlreadyUsed[numero] = true;
    }
    
    private void SpawnMiniWall(int i)
    {
        Instantiate(preMiniWall, posMiniWalls[i].Position,Quaternion.Euler(posMiniWalls[i].Rotation));
    }
}