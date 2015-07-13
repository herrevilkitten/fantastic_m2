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
Our Waypoint Network is called RandomLakeNetwork. It goes around the whole lake 
and has several branches off of the main network. 

4) Waypoint Route Rig with at least 4 waypoints - Complete
Our Waypoint Route is called Lake Patrol Route. It goes around the peripheral of 
the lake and sidewalks. 

5) NPC Characters with a Mechanim motor - Complete
We each have an NPC Character using the mechanim motor (more details in the 
individual section)
1. Matt = Mystery Girl
2. Gina = AJ
3. Hannah = Dark Cat
4. Eric = **?**

6) NPC character with mechanim animator - complete
We each have an NPC Character using the mechanim animator (more details in the 
individual section)
1. Matt = Mystery Girl
2. Gina = AJ
3. Hannah = Dark Cat
4. Eric = **?**

7) Custom RAIN AI Element for a NPC to predict player position - Complete
We have 2 versions of DetectPlayer. 
1) DetectPlayerPosition is custom RAIN Actions and RAIN AI memory. It's used 
with the Mystery Girl and Dark Cat. 
2) DetectPlayerPositionAIElement is a custom RAIN AI element. It's attached to 
the AJ character

Both versions use a simple algorithm to calculate player's velocity and use that 
to set a headoff position. If velocity is 0, then we set the NPC to go directly
to the player. If velocity is not 0, then we set the NPC to go to a position 
based on the current velocity of the player. 

================================================================================
Individual Requirements: Matthew Moldavan
================================================================================
I made a ghost (semi-transparent) myserious girl roam around the park trail. She
floats through the air flailing her arms as she roams. When the player gets in
range, she starts dancing.

It modifies our base SimpleBehaviorTree to make the ghost stop aproaching if
less than 5m

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
A. 
I used the SimpleBehaviorTree and used my own version of the DetectPlayerTree 
to do my own behavior when seeing the player. 
a) Using a Long Range Visual Aspect, AJ starts waving when the player is 
within that range. 
b) When player is close enough, AJ starts running after the player using the
predictive headoff algorithm. 
c) When player is within a configurable range, AJ will start whispering a secret 
the player. 
d) Also has different speed settings for patrolling and wandering

B/C
Uses the following waypoints in the wander tree:
a. WaterFountainWaypoint
b. Sidewalk Target
c. InitialPlayerWaypointTarget
d. PianoWaypointTarget

- Uses the default mesh, routes, and networks. 

D
See A (ABOVE). I use 2 different Visual Aspects to locate the NPC player to have 
different actions. 

Other:
1) The headoff position sometimes causes AJ to jump on top of other characters. 
I've tried to set the NPC position to be further from the player; however, AJ 
will still jump onto other characters. 
2) AJ doesn't always face the player properly. 


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
Keyboard numbers 1-4 switch between scenes. Scenes can also be access by
entering the doors found in the Mental Nexus (first scene that loads, also key 1)

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