================================================================================
Milestone 2 - Team Fantastic!
================================================================================
Authors:
Matthew Moldavan - mmoldavan@gatech.edu - mmoldavan3
Hannah Glazebrook - hannah.glazebrook@gatech.edu - hjahant3
Eric Kidder - ekidder3@gatech.edu
Gina Nguyen - gnguyen37@gatech.edu


================================================================================
Team Requirements
================================================================================
Basic Physics Interaction - Complete
 - We have created a PlayerCollision script that applies physics forces to
 various objects in our scene.  There is a default force (PlayerPushHandler) and
 scripts can be used to customize the actions for different objects.  For
 instance, the glass cubes in the Nexus use PlayerGlassPushHandler, which uses
 a different force formula and emits a particle effect.

Collider Animation - Complete
 - The jump animation uses an animation curve to set character controller height
 and disable gravity during the jump. This curve is utilized inside of
 Scripts/Player/PlayerMovement.cs

Ragdoll Simulation - Complete
 - You can press Z at any time in any scene to instantly become a ragdoll. 
 Eric's Nexus scene also has an area where the player will get thrown back 
 as a ragdoll.
 Gina's City Madness scene also has an area where the player has a flashback and 
 becomes a ragdoll. Player must run towards the accident scene (at the edge of the scene) 
 and collide into the car. 

Game Feel - Complete
 - We were aiming for a "dreamy" feel. You are experiencing dreams in the form 
 of deja vu moments of your past. You are discovering who you once were.

================================================================================
Individual Requirements: Matthew Moldavan (Yuk Mountain Scene)
================================================================================
Five Unique Physical Actors - Complete
 - Carts, barrels, crates, signs, and the origami paper cranes are all rigid
 bodies and are interactable with the player.

At Least Two Compound Objects Consisting of Joints - Complete
 - There are three compound objects in my scene:
   1. Axe Signs (there are three attached to posts of the bridge): Uses a hinge
      joint between the chains and the sign to swing back and forth.
   2. Origami Paper Crane Stand (also attached to a post on the bridge): Uses
      a fixed joint on the top with spring joints between each paper crane.
   3. Wood Carts (one moving around in a circle near the piano, and another
      stationary by the barrels): Uses Wheel Colliders and a physics script
      to form car axles. The wheels spin as they are pushed. Bug: They flip
      randomly.

Varied Height Terrain - Complete
Terrain & multi level bridges that can be jumped between.

Three Material Sounds - Complete
Different sounds play based on the primary texture under the feet. Grass, Sand,
Stone, and the path all have separate footstep sounds. The footstep loudness
increases with speed.

Game Feel - Complete
Fog, rain, dark lighting, and a nebulous sky box add to the "dreamyness" 
state of the character. This dream scene features a romantic proposal, a past 
event in the character's life. Warm lighting adds to the "happy moment" feel.

Assets used in the creation of the scene:
Valentines Chocolates and Roses (TurkCheeps)
 https://kharma.unity3d.com/en/#!/content/14187
Traditional water well (3DMondra)
 https://kharma.unity3d.com/en/#!/content/4477
Piano (Miroslav Uhlir)
 https://kharma.unity3d.com/en/#!/content/154
Origami Paper Crane (Longitude Unknown)
 https://kharma.unity3d.com/en/#!/content/16630
Medieval Buildings (Lukas Bobor) - Bridge and Sign model only
 https://kharma.unity3d.com/en/#!/content/34770
Large Cart (Unity Technologies)
 https://kharma.unity3d.com/en/#!/content/19232
Barrels (Gabro Media)
 https://kharma.unity3d.com/en/#!/content/32975
Crate (Armanda3D)
 https://kharma.unity3d.com/en/#!/content/31462
Terrain Assets (Unity Technologies)
 https://kharma.unity3d.com/en/#!/content/6

MysteryGirl and MysteryGuy (Piano player) models were made by me in Mixamo Fuse
Sitting and piano playing animations from Mixamo

The background soundtrack is "Chronos - Achronon" by Nikita Klimenko
(https://soundcloud.com/chronosproject)
Downloaded from http://www.ektoplazm.com/free-music/chronos-spiritus
It was free and licensed under the Creative Commons for noncommercial usage.

The piano soundtrack is a wedding march from some random free mp3 website.

================================================================================
Individual Requirements: Eric Kidder (Mental Nexus Scene)
================================================================================
The Mental Nexus is a representation of the Player Character's (PC)
subconsciousness.  This is a place where physics doesn't quite work as before 
and familiar objects are mixed up in a strange landscape.  The Nexus is divided
up into four quarters.  Three of the quarters have portals to the other scenes
and are decorated in the fashion of that scene, with terrain textures, models,
and sounds from that scene.

Enter the Nexus - this is the area that the PC starts in.  It is a walled 
maze/hallway with confusing messages and pillars that seem out of place.

Home Sweet Home - this is a grassy area with nightstands and lamps, dangling
capsules, and the door to Home Sweet Home.

Yuk Mountain - climbing up the ramp to the hill/volcano brings you to the
Yuk Mountain door.  Nearby is a well and a place where the PC can watch the
"ball volcano" launch balls into the air.

City Madness - in this area are barricades from the city, the door to City
Madness, and glass cubes and tinkle and sparkle when they collide.  Physics
are changed slightly for the cubes and they will be kicked up into the air
based on the PC's velocity.

Between Yuk Mountain and City Madness is the Barrier.  This is an area with
white particles that are launched into the air, slowly turning black.
Entering the air can be hazardous.

Five Unique Physical Actors - Complete

There are a number of physical actors in the scene.  A lot of them can be
interacted with.  Immediately in front of the PC in Entering the Nexus
is the Sphere.  This is a proof-of-concept that the player can interact
with.

- Hoving the mouse over the Sphere will add a hand icon to the cursor.
This indicates that the object can be interacted with.

- Getting close enough to the Sphere will give it a yellow particle effect.
Moving away will remove the effect.

- While close enough to the Sphere and hovering over it, the player can
hit the "Use" key (E) to push the Sphere slightly.

This is a demonstration of how to highlight and interact with 3D objects
using Unity.  It doesn't do a lot, but it's neat.  There is one other use of
it in the region, as the Box (described below).

The Story Points are combination Point Light/Text frames that hover in the
air.  They provide story information in the Mental Nexus.  A collider around
the Story Points detects when the player gets close.  When that happens, the
light is turned off and the text is removed.

In the Home Sweet Home area are a series of dangling capsules.  These are
hanging from Spring Joints and have Point Lights on the end.  The player can
run or jump into them and knock them into each other.

In the Yuk Mountain region is the "ball volcano".  This consists of 5 balls
with attached Point Lights.  When the balls reach a collider near the bottom
of the volcano, they get knocked back into the air.  Another capsult collider
that surrounds the volcano is supposed to keep them inside by inverting their
velocity as part of OnTriggerExit.  However, sometime this doesn't work and a
ball escapes.

In the City Madness region are a number of glass cubes.  They make a tinkling
sound when they collide with anything.  In addition, when the player runs into
them, a particle effect is emitted and the cube can be knocked into the air.
This only happens if the Y component of the moveDirection is >= 0.  Otherwise,
it indicates that the player is pushing down on the cube, so knocking it up
wouldn't make as much sense.

In each area is a Door to another scene.  These doors are made up of an
invisible door post and the door model.  Standing within the door frame (after
opening it by walking into it) will cause a glow and buzzing noise to grow
in intensity.  After a couple of seconds of this, the player will be
teleported to the scene associated with the door.

At Least Two Compound Objects Consisting of Joints - Complete

There are three different jointed objects.  Two of them are used multiple
times.  The Doors that act as teleporters are used three times each and the
capsules in Home Sweet Home are used three times each.  These are both based
on Prefabs that I made.

The Box is another hinged object, but uses our Interaction effects like the
Sphere.  Opening it (by Using it) applies force to the box lid.  It cannot be
closed again and sometimes if it slams shut, it gets stuck.

Varied Height Terrain - Complete

The terrain is a mixture of flats and hills.  The ball volcano has a ramp-like
feature that goes up along the outside.  High, steep terrain are used to
create hallways and obstacles, such as the walls and columns in Enter the Nexus

Three Material Sounds - Complete

The default footstep for the Mental Nexus is a Water footstep sound.  The
different terrains that are used near each of the Doors are representative of
that scene and try to use a sound from it.

- Home Sweet Home uses a Wood sound, but it is very soft.

- Yuk Mountain uses a Forest sound.

- City Madness uses a Pavement sound.

Game Feel - Complete

The Mental Nexus is supposed to represent someone's subconscious.  As such,
things are both familiar and strange.  The watery sound of the footsteps
demonstrates some of this, along with the terrain and object mixure.  Most
physics works as a person would expect, but some of it seems off.  The doors
stand by themselves but they do lead to other places.

I think the Story Points are probably the most important part of showing off
the meaning of the game.  I believe they /imply/ a story and the player's mind
will naturally fill in the perceived gaps.  I've had different reactions from
different observers on just what the story is.

The model itself is very pale and somewhat ghastly.  I think that works well
in Mental Nexus, although I am not so sure about more brightly lit scenes.

Bugs and Weirdness:

Sometimes one of the balls will escape the BallBarrier collider.  I feel that
it is because the shape of the volcano does not completely match the shape of
the collider.

When the player runs into the Repulsor and gets knocked back, the "stand up"
routine is ... really bad.  We don't have any animations for going from ragdoll
to standing, although I did find some scripts we can look at in the future.

Trying to jump into/through the Repulsor is pretty hilarious.

The Sphere seems to roll on and on forever, even with drag.

The snapping of the MouseLook needs work.  I would like to change it to stay
looked until the player moves and then maybe Lerp/Slerp to the FollowCamera
position.  We've also considered adding a first person mode, hence the
EyeCamera.

The particle effects are kinda lame.  They would work better if I used a
different particle texture, I think.

The collider for the teleporter is a bit finicky and I wish we had better
level transitions.  If we stay with this model, I'll look at LoadLevelAsync

Interactions are really cool, but need polish.  Also, maybe use Mouse2 for
MouseLook and Mouse1 for Interact instead of pressing E.

Setting the cursor seems to be somewhat hit-and-miss.  When running in
Unity, it works great.  Otherwise, it seems to be OS (and maybe browser)
dependent.

Assets used in the creation of the scene:

The font used for the Story Points is Daniel Black
* http://www.1001freefonts.com/handwriting-fonts-3.php

The 3DText shader was developed using this guide
* http://wiki.unity3d.com/index.php?title=3DText

To figure out what object was under the mouse, I used this
* http://answers.unity3d.com/questions/229778/how-to-find-out-which-object-is-under-a-specific-p.html

The model for the door is door_2_1
* https://www.assetstore.unity3d.com/en/#!/content/860

The background music is The Night Sky
* https://www.assetstore.unity3d.com/en/#!/content/35720

The buzzing sound for the teleporter is idle_power_fist_1
* https://www.assetstore.unity3d.com/en/#!/content/15644

The explosion sound when running into the Repulsor is explosion_bazooka
* https://www.assetstore.unity3d.com/en/#!/content/15644

The Barricade, Well, Nightstand, and Lamp models are taken from their
appropriate scenes.

The footstep and glass tinkling are from the same asset set
- Normal: Water_A_1
- Home Sweet Home: Wood_A_1
- Yuk Mountain: Forest_B_1
- City Madness: Pavement_A_1
- Glass tinkling: Glass_A_1
* https://www.assetstore.unity3d.com/en/#!/content/25410

The capsule collision is lrg_rock_softland_concrete_01
* https://www.assetstore.unity3d.com/en/#!/content/21405

The skybox is Skybox_BlueNebula
* https://www.assetstore.unity3d.com/en/#!/content/25142 

The grid texture is grid.png
* http://code.tutsplus.com/tutorials/unity3d-third-person-cameras--mobile-11230

The hand icon is a shrunken, inverted version of Gloves
* https://www.assetstore.unity3d.com/en/#!/content/36440

================================================================================
Individual Requirements: Gina Nguyen (City Scene)
================================================================================
Five Unique Physical Actors - Complete
1. Bouncing Red Ball and Bouncing White Ball
2. Hinge Joint Door on first house on the right. Opens based on physics force
3. Square boxes - moves on collision
4. Hinge Joint on Sign near first house on the right. Swings a little bit when physics force applied by character
5. Spring Joint on Left Post. Structures bounce a little bit on start up.

At Least Two Compound Objects Consisting of Joints - Complete
1. Hinge joint door (on tiny house)
2. Hinge joint on sign (on sign)
3. Spring joint on left post (Balls hanging from post)
 
Varied Height Terrain - Complete
1. Side walk borders
2. Ramp
3. Bridge with stairs

Three Material Sounds - Complete
1. Metal boxes make noise upon collision
2. Doors make noise when opening
3. Character has unique footsteps: pavement, wood, gravel, and grass
4. If player hits the wall on his home hard enough, he makes an oomph sound
5. When player goes into flashback mode, he screams

Game Feel - Complete
This scene is supposed to feel eerie and dreamy. Character is having an unpleasant nightmare / flashback of the accident that took away his family. 
1. Added the character's son. The son runs away from the character when character approaches him. The son leads him to the accident scene (where character can have painful flashback)
2. Fog added to give the dreamy effect. Shadows are soft. 
3. Character runs faster or slower depending on surface (example: forest/grass = slower; stairs = slower). 
-- Grass is the left side of the field. 
-- Gravel is on the other side and does not impact speed. 
-- stairs will slow down the player. 
4. Eerie background music
5. Footstep sounds and speed change based on surface that the player is on

Known Issues:
1. Character can walk on top of the barrier and does not move the barrier. 
2. Camera can behave oddly when stuck in a collider
3. Use own playermovement and terrainsound script (should merge back into the team's prefab, but did not have time to regression test all scenes)
4. Mesh Colliders on some of the objects are causing warnings
5. Missing one prefab tree

Assets used in the creation of the scene:
1. All environment models (except for the ramp, terrain, and the first house on the right) were attained via the asset store. 
Sources:
1. Sevn-Interactive - Atlas Buildings 00 (office buildings)
2. Universal Image - Barricade
3. msgvevo - Classic skybox (skybox for camera)
4. VIS Games - Damaged Old Car (flashback scene)
5. Play fuel studio - Dark Wood Texture (on sign)
6. Webcadabra - Door collection (for custom house door)
7. Juggernaut Realm - Door Sounds Collection (for door open soundwave)
8. mataii - Fire Hydrant
9. no9 Game Sounds - Footsteps pack 1
10. Ryuno - Free Dark Ambient Loop
11. Vigilante Audio - Screams Pain Agony (for flashback sound)
12. Unity - Shanty Town: Brush Vegetation
13. Unity - Shanty Town: Building Eight
14. Unity - Shanty Town: Building Six
15. Unity - Shanty Town: Trees
16. Jacek Jankowski - Simple Modular Street Kit (streets)
17. Side Effects Software - Staircase
18. quirogalabs - The Ultimate Footsteps Sounds FX Pack
19. Xenosmash Games - White Smoke Particle System (smoke from the flashback accident)
20. Nobiax / Yughues - Yughues Free Wooden Floor Materials  

================================================================================
Individual Requirements: Hannah Glazebrook (Home Sweet Home scene)
================================================================================
Hannah Glazebrook   hannah.glazebrook@gatech.edu    hjahant3  
(Home Sweet Home scene)

External Assets: 
House and Furnishings from Unity Asset Store: Smith’s Home by Wensk (http://www.wensk.com)
TerrainSounds script: from Unity Standard Assets
home_sweet_home Sounds: from FreeSound.org

Requirements

-5 unique actors with dynamic physical properties:
	Moves on contact: bouncing ball on roof, box that slides on ramp, capsule chain in 	courtyard, knife on hinge in kitchen, room doors on hinges, chairs in dining room.
        Moves on click: drawers and doors on cabinets and nightstands can be opened and		closed with a click. Refrigerator and oven also open upon click. 
	Physics materials: Sand box in back yard has high friction material. Ramps in 		courtyard have slippery material. Balls in bedroom and on roof have bouncy 		material.
Issues: character can step on bouncy ball, and seems to jump with it?, a couple of spots in the game force the character to lift up into the air as if stepping on an invisible collider, but I cannot seem to find it anywhere. Bouncy balls seem to gain momentum rather than slowing down with each bounce.

-At least 2 compound objects consisting of joints:
	Bedroom, front and bathroom doors have hinge joint
	Blue ball in courtyard has spring joint
	Knife in kitchen has hinge joint
	Capsule chain in yard has 2 hinge joints (connected hinge joints)
Issues: doors on hinges seem to almost break upon impact sometimes, even though the settings for break force, etc are set to infinity. From what I found on the internet, this may be a bug in Unity 5. The bedroom door to the master bedroom snaps to the wall when the game begins to run. This also appears to be a bug in Unity. I tried changing the mass and drag of the door, making sure it wasn’t at an angle that forced gravity to pull it to the wall, and re-setting the axis and anchor of the door to no avail.

-Variable height terrain:
	Ramps leading up to roof, sandbox (jump into), patio (jump into), can climb on 		beds, chairs, sofas in bedroom, table
Issues: the character controller’s jump animation is more of a “leap forward” animation than one that blends with movement allowing for more smooth transitions to handle elevation.

-3 material sounds that play while character interacts with the ground surface
	Sounds are mapped to each of 5 tagged surface types: a distinct sound for the sand 	in the 	courtyard, the grass in the courtyard, the floor inside the house, the 		cement roof, and the 	metal ramps up to the ceiling.
Issues: sometimes there is a lag in transition where an extra sound will play from the previous surface.

-Game feel and polish
	Eerie background music to convey the oddness and confusion, dark skybox to match 	the main level to convey that this is still a dreamlike state, odd things in the 	environment such as the knife in the kitchen and the odd floating objects outside 	convey a sense of darkness and suspense. Fog to convey a sense of confusion and 	fuzziness. Lighting mapped to the skybox to convey a sense of mystery, darkness 	and occlusion.

Level movement/instructions: use WASD or arrow keys to move around. spacebar to jump. shift + WASD to run, click to snap camera, click on cabinets and drawers to open and close, doors, objects in the courtyard (capsule chain, blue ball on spring, ball on ceiling, cube on ramp) move when you walk/run into them using WASD (and shift if you want to run) keys. Objects to test to meet requirements are listed above under requirements. 

Game feel is intended to be eerie, confusing, and mysterious, as though the player is lost in his or her own mind, or a strange world with bizarre memories with missing pieces.


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
Scenes/Mental Nexus/Mental Nexus.unity

================================================================================
Game Url:
================================================================================
http://www.redcoatmedia.com/cs6475/milestone2/index.html