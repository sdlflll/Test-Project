using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeleteFirst : MonoBehaviour
{
   

    
   public void DeleteFirstLocation (GameObject First)
    {
        First.SetActive (false);
        
    }
}
