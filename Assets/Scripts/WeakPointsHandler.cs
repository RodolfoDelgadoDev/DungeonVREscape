using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPointsHandler : MonoBehaviour
{
    public GameObject[] hearths;
    private int count = 0;

    // Update is called once per frame
    void Update()
    {
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            foreach(var h in hearths)
            {
                if (h.activeInHierarchy == true)
                {
                    h.SetActive(false);
                    break;
                }
                else
                    count++;
            }
            if (count == 3)
            {
                ///Play animation of death
            }
        }
    }
}
