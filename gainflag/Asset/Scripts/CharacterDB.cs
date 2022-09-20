using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CharacterDB",menuName ="Scriptable Object/Character DB")]
public class CharacterDB : ScriptableObject
{
    [SerializeField] CharacterInfo[] character;

    public int CharacterCount { get { return character.Length; } }
    public CharacterInfo GetCharacterInfo(int idx)
    {
        return character[idx];
    }

    /*public void SetName(int idx,string str)
    {
        character[idx].SetName(str);
    }*/
}
