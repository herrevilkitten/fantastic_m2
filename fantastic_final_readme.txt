================================================================================
Milestone 4 - Team Fantastic!
================================================================================
Authors:
Matthew Moldavan - mmoldavan@gatech.edu - mmoldavan3
Hannah Glazebrook - hannah.glazebrook@gatech.edu - hjahant3
Eric Kidder - ekidder3@gatech.edu
Gina Nguyen - gnguyen37@gatech.edu


================================================================================
Team Requirements
================================================================================
1) The introduction starts off with a number of fades before displaying the 
game title and buttons.

2) The title screen background is a camera flyby of the level.  The red color
and background music are used to heighten the dramatic tension of the level.

3) The menu buttons are placed at the bottom of the screen.  All of the menu
buttons should be in the same locations for the Title, Settings, and Credits
screens.  The size, color, and font were chosen to indicate the modern feel
of the game.  Selected buttons are darker in color and have a pair of crosshairs
(from the game's logo) in them.

4) Menu is navigable with both mouse and keyboard (arrow keys).  Settings
controls currently do not support keyboard.

5) Credits are present.

6) Credits are split up into sections.  Each section fades in, scrolls to the
bottom, and then fades out.

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
Run to the fountain (left side of the lake from the spawn point) to see the
fountain particle effect. To the right of spawn is the smoke effect coming from
a pipe on the edge of the lake. If you run through the water, you will see
splashes from the feet. The leaf falling effect is present next to the fountain
and on the island.

================================================================================
Scene:
================================================================================
Scenes/Yuk City Park/Yuk City Market.unity

================================================================================
Game Url:
================================================================================
http://projects.mattmoldavan.com/cs6457/alpha/

================================================================================
Assets Used
================================================================================
NPCs without AI made by Matt with Fuse. Animations from Mixamo.

Assets used in title sequence:
Typeface: Soul Mission
http://www.dafont.com/soulmission.font?text=The+Target

Texture: Crosshairs
http://cdn-5.freeclipartnow.com/d/41645-1/Crosshairs.jpg

Background Music: Corridor
http://www.purple-planet.com/mysterious-backgrounds/4588158576

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
