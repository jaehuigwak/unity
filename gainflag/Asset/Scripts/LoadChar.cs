using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Cinemachine;

public class LoadChar : MonoBehaviour
{
    [Header("Characters Info")]
    [SerializeField] CharacterDB characterData;
    //[SerializeField] CinemachineVirtualCamera followCam;
    private GameObject player;
    private int sel;
    private string name;


    // Start is called before the first frame update

    private void Awake()
    {
        if(!PlayerPrefs.HasKey("sel"))
        {
            sel = 0;
        }
        else
        {
            sel = PlayerPrefs.GetInt("sel");
        }

        CreatePlayer();
    }

    void CreatePlayer()
    {
        //Debug.Log("sel:"+sel);
        
        player=characterData.GetCharacterInfo(sel).GetObject();
        /*if(PlayerPrefs.HasKey("name")) //입력된 이름이 있을 경우
        {
            name= PlayerPrefs.GetString("name");
        }*/
        GameObject clone=Instantiate(player,transform.position,Quaternion.identity);
        clone.SetActive(true);

        clone.GetComponent<PlayerInput>().enabled = true;
        clone.GetComponent<PlayerMovement>().enabled = true;

        clone.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = characterData.GetCharacterInfo(sel).GetName();
        clone.transform.GetChild(2).gameObject.SetActive(true);

        //followCam.Follow = clone.transform;
        //followCam.LookAt = clone.transform;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
