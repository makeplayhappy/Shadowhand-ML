using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhysicsErrorTest : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    void Update() {
        for (int i = 0; i < 3; i++){
            if( float.IsNaN( transform.position[i] ) || float.IsInfinity( transform.position[i] ) ){
                Debug.Log("transform has gone out of bounds " + i);
                SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ;
            }
        }

    }
}
