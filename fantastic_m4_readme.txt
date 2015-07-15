================================================================================
Milestone 3 - Team Fantastic!
================================================================================
Authors:
Matthew Moldavan - mmoldavan@gatech.edu - mmoldavan3
Hannah Glazebrook - hannah.glazebrook@gatech.edu - hjahant3
Eric Kidder - ekidder3@gatech.edu
Gina Nguyen - gnguyen37@gatech.edu


================================================================================
Team Requirements
================================================================================
1)

2)

3)

4)

5)

6)

7) At least two different particle effects with two particle systems - Complete
a. The stone fountain has a water fountain particle system. It has three 
particle components: the water drops originating from the jet of the fountain, 
the mist around the fountain, and the splash of the drops into the water.
It spawns the drops in a cone fashion and uses velocity over time curves to
randomize the drop effect for more realism.

b. the player's footsteps through the water/lake create water splashes. This
splash is attached to the feet of the player rig, and contains two particle
systems, one to generate a mist, and one to create some water drops.

8) Change size of particles - Complete
This is satisfied by the smoke coming out of the pipe next to the lake. The
smoke particle size grows using the size over lifetime module.

9) Change speed of particles - Complete
This is satisified by the stone fountain water particle system. The water drops
originating from the top of the fountain use Velocity over Lifetime curves to
control and randomize the direction of the water drops

10) Use a 2d custom material for a particle - Complete
On the Island in the middle of the lake, the trees have a particle system
generating falling leafs that land on the ground. The leafs are using a leaf
material we created in photoshop. The leaf material adds some realism to the
scene.

11) Complicated Effect using a Sub-Emitter - Complete
The stone fountain's water effect leverages a sub-emitter to create splashes
and mist on the water when water drops collide with the water plane.

12) Triggered Particle Effect - Complete
There is a particle system attached to the player's feet of a water splash. The
splash is triggered when the player walks across water using animation events
attached to the Player's run and walk animations, which call an OnStep()
function in code. 

The code can be viewed in Scripts/Player/PlayerParticles.cs OnStep() and is
attached to the Player object.

================================================================================
Special Instructions for building and running code
================================================================================

In the game:
W/S move the player forward and back
A/D turn the character (tank control)
SPACE jumps
E uses interactive objects
Z ragdolls the player
1-4 load the appropriate level
ESC reloads the current level
Holding Mouse1 turns on mouse look.  Releasing it snaps back to the follow
camera.

================================================================================
Steps to show game requirements:
================================================================================
All AI characters begin near the player's spawn area and on the left side of the
lake. They are generally easy to find. AJ (Gina's AI) begins on the hill to the
left. The Mysterious Girl (red and black, transparent ghost) is Matt's AI and 
also on the hill to the left. Eric's ghost begins near the girl. The gray cat
near where the player spawns is Hannah's

================================================================================
Scene:
================================================================================
Scenes/Yuk City Park/Yuk City Market.unity

================================================================================
Game Url:
================================================================================
http://www.redcoatmedia.com/cs6475/milestone3/index.html

================================================================================
Assets Used
================================================================================
NPCs without AI made by Matt with Fuse. Animations from Mixamo.

Assets used in the creation of the scene:
Piano (Miroslav Uhlir)
 https://kharma.unity3d.com/en/#!/content/154
Origami Paper Crane (Longitude Unknown)
 https://kharma.unity3d.com/en/#!/content/16630
Medieval Buildings (Lukas Bobor) - Bridge and Sign model only
 https://kharma.unity3d.com/en/#!/content/34770
Park Bench (Universal Image)
 https://kharma.unity3d.com/en/#!/content/850
Terrain Assets (Unity Technologies)
 https://kharma.unity3d.com/en/#!/content/
Cinema Themes (Cinema Suite Inc) - For the camera filter
 https://kharma.unity3d.com/en/#!/content/20394
Bird churping and water fountain sounds from
 http://www.pacdv.com/sounds/ambience_sounds.html
