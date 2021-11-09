using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a "dummy class just to make the component available in the inspector
[RequireComponent(typeof(ArticulationBody))]
public class ArticulationExtraInfo : MonoBehaviour {
    [Header("Spring freq and damping")]   
    private bool isOkay = true;


}
