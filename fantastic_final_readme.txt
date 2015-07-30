================================================================================
Final Product - Team Fantastic!
================================================================================
Authors:
Matthew Moldavan - mmoldavan@gatech.edu - mmoldavan3
Hannah Glazebrook - hannah.glazebrook@gatech.edu - hjahant3
Eric Kidder - ekidder3@gatech.edu
Gina Nguyen - gnguyen37@gatech.edu


================================================================================
Team Requirements
================================================================================
It must be a 3D game! (20 pts)
- 3D Game

Yes

- Achievable objective? (e.g. player can complete a level. NOT a sandbox)

Yes.  When all of the evidence is cleaned, the PC will dance.

- Communication of success or failure to player!

Yes.

- Able to reset and replay on success or failure (e.g. Minecraft when “You died”, there is a “respawn” button)

The game automatically resets after a short delay.

Skeletal-Animated 3D Mesh Character Controller with Real-Time Control (20 pts)
- Mecanim Controlled and Blendtree enabled character

Yes

- Player has direct control of character majority of time?

Yes

- Choice of controls is intuitive and appropriate (e.g. shouldn’t make difficult keyboard mappings or controls where its hard to pick up objects)

Tank controls can be annoying, but yes.

- Fluid? Continuity of motion?

Yes

- Offer a dynamic range of control (e.g. Mario’s variable jump height, “analog” control of speeds, etc.)

Yes

3D World with Physics and Spatial Simulation (20 pts)
- Both graphically and auditory represented

Yes

- Aligned with physics representation (e.g. minimal clipping through objects)

Yes

- Interactive

Some objects, like the trash cans and barrels, will react to the player running into them.  Other items, like the paper cranes, user the game's interaction system.

- Consistent spatial simulation throughout (e.g. Running speed remains same regardless of framerate. Gravity constrains maximum jump to x distance in all cases; shouldn’t be able to jump more or less in different cases unless obvious input control or environmental changes are presented to the user.).

Yes

Real-time NPC Steering Behaviors / Artificial Intelligence (20 pts)
- Reasonably effective and believable AI?
- Fluid? Continuity of motion?
- Sensory feedback of AI state? (e.g. animation and sounds identify passive or aggressive AI)
Yes - We have 3 trees for AI behavior:
1. Patrolling Cops
-- Patrol
-- Observe player for suspicious activities
-- Report back suspicious activities
-- React to distractions (like the ball)
-- Arrest the player
-- Get angry when the player wins!
-- Dynamic obstruction... it detects obstructions and will after a period of time move around the obstruction
-- (not used, but implemented) - used custom objects to allow for cops to communicate with each other. This was intended to be used for backup

2. Cops on guard
-- Observe player for suspicious activities
-- Report back suspicious activities
-- Arrest the player
-- React to distractions (like the ball)
-- Get angry when the player wins!

3. Conversation NPCs
-- Have two types of conversation
--- Gossiping when they don't sense the player nearby
--- Have a fake conversation when the player gets too close

Polish (20 pts)
- Overall UI
o Your software should feel like a game from start of execution to the end
o There should be no debug output visible (you can remove your team name from the GUI as well for final project)
o GUI elements should be styled appropriately (e.g. replacing plain printed health text number with stylized health text [e.g. HL2] or health bar [e.g. Halo])
o Transitions between scenes should be done aesthetically (e.g. fade in, fade out, panning cameras, etc.)
- Environment Acknowledges Player
o Should include many of the following:
§ Physically simulated movement
§ Scripted animation
§ Surface effects, such as texture changes or decals
§ Particle effects
§ Auditory events & effects
- Cohesiveness / Unified Aesthetic o Artistic style (extremely simple is fine!)
o Color palette
o Sound theme, including consonance
o Lighting Style
- Appeal
o No glitches
o No easily escaping the confines of the game world (make proper barriers)
o Stable (e.g. should play consistently the same on variety of hardware)

================================================================================
Special Instructions for building and running code
================================================================================

In the game:
W/S move the player forward and back
A/D turn the character (tank control)
SPACE jumps
Mouse1 interacts with items in the world
Holding Mouse2 turns on mouse look.  Releasing it snaps back to the follow
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
http://projects.mattmoldavan.com/cs6457/final/

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
