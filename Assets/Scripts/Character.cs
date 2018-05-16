using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Character : ScriptableObject
{
    [SerializeField]
    private string name;

    public string Name
    {
        get { return Name; }
        set { this.name = Name; }
    }
}
