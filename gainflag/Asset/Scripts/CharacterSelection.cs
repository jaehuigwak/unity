using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSelection : MonoBehaviour
{
    [Header("Character Prefabs")]
    [SerializeField] CharacterDB characterData;
    private GameObject player;

    private GameObject[] characters;
    private string[] names;

    [SerializeField] int sel = 0;
    //RotationLoop rotate;
    private void Awake()
    {
        characters = new GameObject[characterData.CharacterCount];
        names=new string[characterData.CharacterCount];

        for(int i=0;i<characterData.CharacterCount;i++)
        {
            CharacterInfo playerInfo = characterData.GetCharacterInfo(i);
            characters[i] = Instantiate(playerInfo.GetObject(),transform.position,playerInfo.GetObject().transform.rotation);
            names[i]=playerInfo.GetName();
            //characters[i].SetActive(false);
        }
    }
    private void Start()
    {
        sel = 0;
        UpdateCharacter(sel);
        //rotate = GetComponent<RotationLoop>();
    }

    public void NextSelection()
    {
        sel = (sel + 1) % characterData.CharacterCount;
        UpdateCharacter(sel);

        //rotate.enabled = false;
        //rotate.enabled = true;
    }

    public void PreviousSelection()
    {
        sel--;
        if(sel< 0)
        {
            sel = characterData.CharacterCount - 1;
        }
        UpdateCharacter(sel);

        //rotate.enabled = false;
        //rotate.enabled = true;
    }

    private void UpdateCharacter(int selIdx)
    {
       /* Debug.Log(selIdx);
        if (player != null)
        {
            Destroy(player);
        }*/

        /*CharacterInfo playerInfo = characterData.GetCharacterInfo(selIdx);
        player = Instantiate(playerInfo.GetObject()); //오브젝트 화면 표시 필요...
        name.text = playerInfo.GetName();*/

        for(int i=0;i<characters.Length;i++)
        {
            if(i == selIdx)
            {
                characters[i].SetActive(true);
            }
            else
            {
                characters[i].SetActive(false);
            }
        }
                
    }

    public void SelectChar()
    {
        PlayerPrefs.SetInt("sel", sel);
    }

    public void SetName(TMP_InputField input)
    {
        if(input.text!=null||input.text!="") //입력이 있을 경우
        {
            //PlayerPrefs.SetString("name", input.text);
            characterData.GetCharacterInfo(sel).SetName(input.text);

        }
    }
}
