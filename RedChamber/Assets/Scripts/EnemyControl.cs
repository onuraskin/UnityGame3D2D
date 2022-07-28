using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
# endif

public class EnemyControl : MonoBehaviour
{
    GameObject[] goPoints;
    bool tookDistances = true;
    Vector3 bwDistance;
    int distTemp;
    bool nextorBack = true;
    GameObject character;
    RaycastHit2D dir;
    public LayerMask layer;
    int hiz = 5;
    public Sprite face;
    public Sprite back;
    SpriteRenderer spriteRenderer;
    public GameObject ammo;
    float gunTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        goPoints = new GameObject[transform.childCount];
        character = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        for (int i = 0; i < goPoints.Length; i++)
        {
            goPoints[i] = transform.GetChild(0).gameObject;
            goPoints[i].transform.SetParent(transform.parent);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isitSee();
        if (dir.collider.tag == "Player") {
            hiz = 10;
            spriteRenderer.sprite = face;
            fire();
        }
        else
        {
            hiz = 4;
            spriteRenderer.sprite = back;
        }



        goToPoint();
    }
    void fire()
    {
        gunTime += Time.deltaTime;
        if (gunTime > Random.Range(0.2f, 1f))
        {
            Instantiate(ammo, transform.position, Quaternion.identity);
            gunTime = 0;
        }


    }
    void isitSee()
    {

        Vector3 direction = character.transform.position - transform.position;
        dir = Physics2D.Raycast(transform.position, direction, 1000, layer);
        Debug.DrawLine(transform.position, dir.point, Color.magenta);


    }

    void goToPoint()
    {
        if (tookDistances)
        {
            bwDistance = (goPoints[distTemp].transform.position - transform.position).normalized;
            tookDistances = false;
        }
        float dist = Vector3.Distance(transform.position, goPoints[distTemp].transform.position);
        transform.position += bwDistance * Time.deltaTime * hiz;
        if (dist < 0.5f)
        {
            tookDistances = true;
            if (distTemp == goPoints.Length - 1)
            {
                nextorBack = false;
            }
            else if (distTemp == 0)
            {
                nextorBack = true;
            }
            if (nextorBack)
            {
                distTemp++;

            }
            else
            {
                distTemp--;

            }

        }



    }
    public Vector2 getWay()
    {

        return (character.transform.position - transform.position).normalized;


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
[CustomEditor(typeof(EnemyControl))]
[System.Serializable]
class EnemyContEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EnemyControl script = (EnemyControl)target;
        EditorGUILayout.Space();
        if (GUILayout.Button("Create", GUILayout.MinWidth(100), GUILayout.MinHeight(100)))
        {
            GameObject newObj = new GameObject();
            newObj.transform.parent = script.transform;
            newObj.transform.position = script.transform.position;
            newObj.name = script.transform.childCount.ToString();

        }
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("layer"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("face"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("back"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ammo"));
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
    }

}
# endif
