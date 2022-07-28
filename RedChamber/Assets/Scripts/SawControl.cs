using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
# endif
public class SawControl : MonoBehaviour
{
    GameObject []goPoints;
    bool tookDistances = true;
    Vector3 bwDistance;
    int distTemp;
    bool nextorBack = true;
    // Start is called before the first frame update
    void Start()
    {
        goPoints = new GameObject[transform.childCount];
        for (int i = 0; i < goPoints.Length; i++)
        {
            goPoints[i] = transform.GetChild(0).gameObject;
            goPoints[i].transform.SetParent(transform.parent);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, 5);
        goToPoint();
    }
    void goToPoint()
    {
        if (tookDistances)
        {
            bwDistance = (goPoints[distTemp].transform.position - transform.position).normalized;
            tookDistances = false;
        }
        float dist = Vector3.Distance(transform.position, goPoints[distTemp].transform.position);
        transform.position += bwDistance * Time.deltaTime * 10;
        if (dist<0.5f)
        {
            tookDistances = true;
            if (distTemp==goPoints.Length-1)
            {
                nextorBack = false;
            }
            else if (distTemp==0)
            {
                nextorBack = true;
            }
            if (nextorBack)
            {
                distTemp++;
                
            }
            else {
                distTemp--;
                
            }

            }
      


    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.GetChild(i).transform.position, 1);
        }
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i + 1).transform.position);
        }
    }
#endif
}
#if UNITY_EDITOR
[CustomEditor(typeof(SawControl))]
[System.Serializable]
class sawEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SawControl script = (SawControl)target;
        if (GUILayout.Button("Create", GUILayout.MinWidth(100), GUILayout.MinHeight(100)))
        {
            GameObject newObj = new GameObject();
            newObj.transform.parent = script.transform;
            newObj.transform.position = script.transform.position;
            newObj.name = script.transform.childCount.ToString();

        }
    }

}
# endif
