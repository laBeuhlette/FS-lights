using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "objectTemplate", menuName = "monPatrimoine/objectTemplate", order = 0)]
public class testSO : ScriptableObject
{
    public string objectName;
    public MeshRenderer objectMesh;
    public saut saut;
    public test test;

    public Material material;
    
    
}
