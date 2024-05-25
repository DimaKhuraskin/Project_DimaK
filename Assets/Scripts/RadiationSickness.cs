using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationSickness : MonoBehaviour
{
    public float RadSick = 0;
    private float increaseRate = 3;
    public float _count1;
    public float _count2;
    public float _count3;

    void OnTriggerEnter(Collider other)
       {
           if (other.gameObject.CompareTag("Player"))
           {
               switch (other.gameObject.tag)
               {
                   case "1":
                       increaseRate = _count1;
                       break;
                   case "2":
                       increaseRate = _count2;
                       break;
                   case "3":
                       increaseRate = _count3;
                       break;
               }

               StartCoroutine(IncreaseRadSick());
           }
       }

       void OnTriggerExit(Collider other)
       {
           if (other.gameObject.CompareTag("Player"))
           {
               StopCoroutine(IncreaseRadSick());
           }
       }

       IEnumerator IncreaseRadSick()
       {
           while (true)
           {
               RadSick += increaseRate;
               yield return new WaitForSeconds(1);
           }
       } 
    
    void Update()
    {
        Debug.Log(RadSick);
    }

}
