using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCubeControl : MonoBehaviour
{
    bool isItCollect;
    int index;
    public CollectorControl coll;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isItCollect==true)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="obstacle")
        {
            coll.highLess();
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        
    }
    public bool GetisItCollect() {

        return isItCollect;
    }
    public void Collected() {
        isItCollect = true;
    
    }
    public void setHigh(int index) {
        this.index = index;
    
    }
}
