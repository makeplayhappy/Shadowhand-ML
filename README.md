# Shadowhand Unity ML Proof Concept
This is a repository for building machine learning environments using a robot arm connected to a Shadowhand in Unity3d.

Re authored shadowhand Blender file in the Docs folder, includes fingertip mesh colliders (2021)
Shadowhand attached to a UR3 arm.

# Blender files
These are used to generate fbx files imported into Unity. FBX export in Blender can break multi level articulation style setups. My prefered method is to use this Blender export plugin [https://github.com/EdyJ/blender-to-unity-fbx-exporter](https://github.com/EdyJ/blender-to-unity-fbx-exporter) .
This helps prevent scaling and rotation import issues.


# ArticulationBody Notes

I have added an editor component to display the damping ratio and the natural frequency of each articulation joint. Values that are widely outside the normal / realistic values create unstable simulations. I found that having colliders attached to the end of articulation chains (eg. on the last element protruding "outside" of the ArticulationBody) seemed to create instabilties, to mitigate I've added fixed joints to the tip of the articulation, this has helped prevent some of the wilder instabilities.

Add the "ArticulatuionExtraInfo" component in the inspector to an articulation joint to display the extra data. There is also a "PhysicsErrorTest" component which can be added to any link to catch wild instabilities that break the simulation; the whole articulation gets placed outside of the world co-ordinates (position vectors end up as NaN or infinity).
## ArticulationBody Component (documentation from Unity forum link)
To control an articulation indirectly, we have drives. A drive is a mechanism that applies force or torque (whatever is applicable according to the joint type). Internally it uses an implicit spring, so it’s useful to understand this simple formula:

F = (currentPosition - target) * stiffness - (currentVelocity - targetVelocity) * damping

Where:
Target, stiffness, targetVelocity and damping are parameters of the drive   
currentPosition is the current value of the drive (=current translation, or current angle)  
currentVelocity is the current velocity of the body (=linear speed, or angular speed)  

Obviously, Force Limit is to limit the maximum force (or torque) applied. You can also set the range within which the drive should operate by changing Lower Limit and Upper Limit. 

Like with any spring, it may be useful to understand harmonic oscillator. Here is a super brief intro.

Let   
k - be the stiffness of the spring,  
c - be the damping,  
m - the mass of the body connected by this spring,  
n - natural frequency of the spring,  
d - damping ratio. Then, it’s possible to prove that: 

n = sqrt(k / m)  
d = c / (2 * sqrt(k * m))  


For a physically realistic simulation - n should be in the range 1..20, d should be 0..1. 

### Scene Setups
####Layers
6 : Shadowhand articulation



####Tags