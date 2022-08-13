using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using TMPro;

public class Placement : MonoBehaviour
{
    public List<GameObject> furniture = new List<GameObject>();
    public List<Material> materials = new List<Material>();
    private Dictionary<string,Material> m_dic = new Dictionary<string,Material>();

    public ARRaycastManager raymanager;
    private List<ARRaycastHit> hits=new List<ARRaycastHit>();

    public Transform pool;

    private Vector2 vCenter;
    private GameObject select;

    //public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Material mat in materials)
        {
            m_dic.Add(mat.name, mat);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(select!=null)
        {
            vCenter=new Vector2(Screen.width*.5f, Screen.height*.5f);
        }

        if(raymanager.Raycast(vCenter,hits,TrackableType.PlaneWithinPolygon))
        {
            ARPlane plane=hits[0].trackable.GetComponent<ARPlane>();

            if(plane!=null) // plane을 놓을 수 있는 경우
            {
                select.transform.position = hits[0].pose.position;
                select.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                select.transform.localScale = new Vector3(0, 0, 0);
            }
        }

    }

    public void Select(int type)
    {
        if(select!=null) // 이전에 생성된 오브젝트 소멸.
        {
            Destroy(select);
            select = null;
        }
        select=Instantiate(furniture[type]); //scale = 0인 오브젝트 생성
    }

    public void Put()
    {
        //select.transform.localScale = new Vector3(1, 1, 1); //오브젝트 활성화
        select.transform.SetParent(pool);
        select = null;
    }

    public void ChangeMaterial()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(name);
        Material mat = m_dic[name];
        Material[] obj_mat = select.transform.GetChild(0).GetComponent<MeshRenderer>().materials;

        /*if(obj_mat==null)
        {
            obj_mat = select.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
        }*/

        obj_mat[0] = mat;
        select.transform.GetChild(0).GetComponent<MeshRenderer>().materials = obj_mat;

        //text.text = name+obj_mat[0].name;
    }
}
