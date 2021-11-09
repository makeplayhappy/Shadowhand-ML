#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// this displays additional information to aid setting up articulation joints
// keeping the values within "realistic" lmitis helps stabalise the simualtion

[CustomEditor( typeof( ArticulationExtraInfo ) )]
public class ArticulationExtraInfoEditor : Editor{

    public override void OnInspectorGUI(){

        DrawDefaultInspector ();

        ArticulationExtraInfo extraInfo = (ArticulationExtraInfo) target;

        GameObject go = extraInfo.gameObject;
        ArticulationBody body = go.GetComponent<ArticulationBody>();

/*
k - be the stiffness of the spring,  
c - be the damping,  
m - the mass of the body connected by this spring,  
n - natural frequency of the spring,  
d - damping ratio. Then, it’s possible to prove that: 

n = sqrt(k / m)  
d = c / (2 * sqrt(k * m))  
*/        
        GUIStyle IssueStyle = new GUIStyle();
        IssueStyle.normal.textColor = Color.red;

        GUIStyle OkayStyle = new GUIStyle();
        OkayStyle.normal.textColor = Color.green;

        float stiffness = body.xDrive.stiffness;
        float naturalFreq = 0f;

        GUIStyle FreqStyle = OkayStyle;
        if(stiffness > 0){
            naturalFreq = Mathf.Sqrt( body.xDrive.stiffness / body.mass );
            if( naturalFreq < 0 || naturalFreq > 20 ){
                FreqStyle = IssueStyle;

            }
        }

        float dampingRatio = 0f;
        GUIStyle DampStyle = OkayStyle;
        dampingRatio = body.xDrive.damping / (2 * Mathf.Sqrt( body.xDrive.stiffness * body.mass )  ) ;
        if( dampingRatio < 0 || dampingRatio > 1){
            DampStyle  = IssueStyle;
        }

        
        GUILayout.Space(10f);


        GUILayout.BeginHorizontal();
        GUILayout.Label("Natural Frequency, should be in the range 1 .. 20 ");
        GUILayout.Label(naturalFreq.ToString("F2") , FreqStyle );

        GUILayout.Space(10f);

        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();

        GUILayout.Label("Damping Ratio, should be in the range 0 .. 1 ");
        GUILayout.Label(dampingRatio.ToString("F2") , DampStyle );

        GUILayout.EndHorizontal();

        GUILayout.Space(10f);
        

    }


}

#endif