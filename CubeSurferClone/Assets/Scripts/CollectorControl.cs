using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorControl : MonoBehaviour
{
     GameObject mainCube;
    int high;
    void Start()
    {
        mainCube = GameObject.Find("MainCube");
    }

    // Update is called once per frame
    void Update()
    {
        mainCube.transform.position = new Vector3(transform.position.x,high+1,transform.position.z);
        this.transform.localPosition = new Vector3(0,-high,0);
    }
    public void highLess() {

        high--;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "collect"&&other.gameObject.GetComponent<CollectableCubeControl>().GetisItCollect() == false)
        {
            high += 1;
            other.gameObject.GetComponent<CollectableCubeControl>().Collected();
            other.gameObject.GetComponent<CollectableCubeControl>().setHigh(high);
            other.gameObject.transform.parent = mainCube.transform;
        }
    }
}
