================================================================================
Milestone 2 - Team Fantastic!
================================================================================
Authors:
Matthew Moldavan - mmoldavan@gatech.edu - mmoldavan3
Hannah Glazebrook - hannah.glazebrook@gatech.edu
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

Game Feel - Complete
 - We were aiming for a "dreamy" feel. You are experiencing dreams in the form 
 of deja vu moments of your past. You are discovering who you once were.

================================================================================
Individual Requirements: Matthew Moldavan (Yuk Mountain Scene)
================================================================================
Five Unique Physical Actors - Complete
 - Carts, barrels, crates, signs, and the origami paper cranes are all rigid
 bodies nd are interactable with the player.

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

Assets used in the creation of the scene:

The font used for the Story Points is Daniel Black
* http://www.1001freefonts.com/handwriting-fonts-3.php

The 3DText shader was developed using this guide
* http://wiki.unity3d.com/index.php?title=3DText

To figure out what object was under the mouse, I used this
* http://answers.unity3d.com/questions/229778/how-to-find-out-which-object-is-under-a-specific-p.html

The model for the door is door_2_1
*

The background music is The Night Sky
*

The buzzing sound for the teleporter is idle_power_fist_1
*

The explosion sound when running into the Repulsor is explosion_bazooka
* 

The Barricade, Well, Nightstand, and Lamp models are taken from their
appropriate scenes.

The footstep and glass tinkling are from the same asset set
- Normal: Water_A_1
- Home Sweet Home: Wood_A_1
- Yuk Mountain: Forest_B_1
- City Madness: Pavement_A_1
- Glass tinkling: Glass_A_1
* 

The capsule collision is lrg_rock_softland_concrete_01
* 

The skybox is Skybox_BlueNebula
* https://www.assetstore.unity3d.com/en/#!/content/25142 

The grid texture is grid.png
* http://code.tutsplus.com/tutorials/unity3d-third-person-cameras--mobile-11230

The hand icon is a shrunken, inverted version of Gloves
* 



================================================================================
Individual Requirements: Hannah Glazebrook (Home Sweet Home Scene)
================================================================================
Five Unique Physical Actors - Complete

At Least Two Compound Objects Consisting of Joints - Complete
 
Varied Height Terrain - Complete

Three Material Sounds - Complete

Game Feel - Complete

Assets used in the creation of the scene:

================================================================================
Individual Requirements: Gina Nguyen (City Scene)
================================================================================
Five Unique Physical Actors - Complete

At Least Two Compound Objects Consisting of Joints - Complete
 
Varied Height Terrain - Complete

Three Material Sounds - Complete

Game Feel - Complete

Assets used in the creation of the scene:


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
http://projects.mattmoldavan.com/cs6457/m2/