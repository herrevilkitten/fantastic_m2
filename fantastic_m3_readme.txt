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
1) At least 1 RAIN AI Navigation Mesh Rig - Complete
Mesh is called Navigation Mesh. 

2) At least 2 Navigation Targets in 1 Behavior Tree - Complete
We have multiple Navigation Targets:
a. WaterFountainWaypoint
b. Sidewalk Target
c. InitialPlayerWaypointTarget
d. PianoWaypointTarget
e. CatTarget1
f. CatTarget2
g. CatTarget3
h. CatTarget4
i. CatTarget5

3) Waypoint Network Rig with at least 6 waypoints and a branch - Complete
Our Waypoint Network is called RandomLakeNetwork. It goes around the whole lake and has several branches off of the main network. 

4) Waypoint Route Rig with at least 4 waypoints - Complete
Our Waypoint Route is called Lake Patrol Route. It goes around the peripheral of the lake and sidewalks. 

5) NPC Characters with a Mechanim motor - Complete
We each have an NPC Character using the mechanim motor (more details in the individual section)
1. Matt = Mystery Girl
2. Gina = AJ
3. Hannah = Dark Cat
4. Eric = **?**

6) NPC character with mechanim animator - complete
We each have an NPC Character using the mechanim animator (more details in the individual section)
1. Matt = Mystery Girl
2. Gina = AJ
3. Hannah = Dark Cat
4. Eric = **?**

7) Custom RAIN AI Element for a NPC to predict player position - Complete




================================================================================
Individual Requirements: Matthew Moldavan
================================================================================
I made a ghost (semi-transparent) myserious girl roam around the park trail. She
floats through the air flailing her arms as she wonders. When the player gets in
range, she starts dancing.

a. I modified our base SimpleBehaviorTree to modify the interaction with the
player. It sets a IsDancing boolean when nearby the player and doesn't need
to get as close (only 5m) to begin interacting as the origina ltree.

b. It avoids obstacles using our nav mesh in the scene and wonders between set
points on the navigation network.

c. the NPC utilizes the waypoint network around the lake.

d. the NPC detects player movment near them using a visual sense and a visual
asepct attached to the player. When the girl is near the player, it will dance.

================================================================================
Individual Requirement: Eric Kidder
================================================================================
a.  I forked an earlier version of our behavior tree and heavily modified it.
The patrol and detection behavior is different, but it uses our standard
wandering behavior.  Patrol now makes a decision at each waypoint to either smoke,
pause, or start wandering.  Each thing it detects will get a unique message --
and it will only say the message once every 30 seconds because of a timer.

b. Everything is integrated with the navigation mesh and waypoint system.

c. Fulfilled by a and b

d. The NPC will detect different Visual Aspects and react to them differently.
This can be seen by the floating words that appear over the NPC when it sees
different things.

Other:
The dialog system reads its state machine from text files.
The dialog system can support different state trees depending on code.  For
exampe, my NPC will have different text if he's in the smoking animation or
not.
RAIN AI's "Wait for Mecanim State" feature is really hard to use and wouldn't
work for me at all.  I had to use a timer to get the character to NOT move and
smoke.
The turning is really bad.  I honestly could not figure out what the various
values meant and just tweaked things until they looked less bad.
My NPC is using the PC's animation controller and it mostly works, but RAIN
seems to have some preconceptions on variable names.

================================================================================
Individual Requirement: Gina Nguyen
================================================================================

================================================================================
Individual Requirement: Hannah Glazebrook
================================================================================


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