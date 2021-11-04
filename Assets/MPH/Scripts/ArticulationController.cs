using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArticulationController : MonoBehaviour{

    public ArticulationBody[] articulations;
    public int[] frameUpdate; //this array stores Time.frameCount + random_int for when the next change to joint should happen
    public int articulation_index = 0;
    public bool randomMotion = true;

    public int minFrames = 60;
    public int maxFrames = 300;



    void Awake() {
        articulations = GetComponentsInChildren<ArticulationBody>(); 
        frameUpdate = new int[articulations.Length];
    }

    void Start(){

    }

    void Update(){
        if( randomMotion ){
            if( articulation_index >= articulations.Length ){
                articulation_index = 0;
            }

            if( Time.frameCount > frameUpdate[articulation_index] ){
                //do motion and set next update

                

                switch( articulations[articulation_index].jointType ){
                    case ArticulationJointType.RevoluteJoint:

                        // clone the drive component, update the target and then set it back, this just how you have to do it for now!
                        // https://forum.unity.com/threads/featherstones-solver-for-articulations.792294/page-6
                        ArticulationDrive drive = articulations[articulation_index].xDrive;
                        ArticulationDofLock xlock = articulations[articulation_index].linearLockX;
                        switch(xlock){
                            case ArticulationDofLock.FreeMotion:
                                drive.target = Random.Range(-180f, 180f);
                            break;
                            default:
                                drive.target = Random.Range(drive.lowerLimit, drive.upperLimit);
                            break;
                        }
                        
                        articulations[articulation_index].xDrive = drive;

                    break;
                }



                int nextUpdateFrame = Time.frameCount + Random.Range(minFrames, maxFrames);
                frameUpdate[articulation_index] = nextUpdateFrame;
            }

            articulation_index++;
        }
        
    }
}
