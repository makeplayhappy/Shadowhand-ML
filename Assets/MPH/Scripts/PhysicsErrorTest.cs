using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is to catch wild glitches in the simulation that completely break the articulations

public class PhysicsErrorTest : MonoBehaviour
{

    void Update() {
        for (int i = 0; i < 3; i++){
            if( float.IsNaN( transform.position[i] ) || float.IsInfinity( transform.position[i] ) ){
                #if UNITY_EDITOR
                    Debug.Log("transform has gone out of bounds " + i);
                    Debug.Break();
                #else
                    SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ; 
                #endif
                
                 
            }
        }

    }
}
