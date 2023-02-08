using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public struct TransformDatas
{
    public Vector3 Position;
    public Vector3 Rotation;
    public Vector3 Scale;
}

[CreateAssetMenu(fileName = "Difficulty")]

public class Difficulty : ScriptableObject
{
    [SerializeField] public List<TransformDatas> posMiniWalls;
}