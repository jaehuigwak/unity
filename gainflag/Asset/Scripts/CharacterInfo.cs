using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterInfo
{
    [SerializeField] string name;
    [SerializeField] GameObject character;

    public GameObject GetObject()
    {
        character.SetActive(true);
        return character;
    }
    public void SetName(string str)
    {
        if(str!=null||str=="")
            name = str;
    }
    public string GetName()
    {
        return name;
    }

}
