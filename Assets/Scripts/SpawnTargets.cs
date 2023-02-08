using UnityEngine;

public class SpawnTargets : MonoBehaviour
{
    [SerializeField] private GameObject[] preTarget;
    [SerializeField] private Transform[] posTargets;
    private int numTarget;

    private void SpawnTarget(int numTarget, Transform posTarget)
    { 
        Instantiate(preTarget[numTarget], posTarget.position, posTarget.rotation);
        preTarget[numTarget].tag = "Target";
    }

    private void Start()
    {
        numTarget = Random.Range(0, preTarget.Length-1);
        foreach (Transform _transform in posTargets)
        {
            SpawnTarget(numTarget,_transform);
            numTarget = Random.Range(0, preTarget.Length-1);
        }
    }
}