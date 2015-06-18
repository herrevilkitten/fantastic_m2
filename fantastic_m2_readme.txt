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
 various objects in our scene.

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
Different sounds play based on the texture under the feet. 

Game Feel - Complete
Need I really explain?

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
Five Unique Physical Actors - Complete

At Least Two Compound Objects Consisting of Joints - Complete
 
Varied Height Terrain - Complete

Three Material Sounds - Complete

Game Feel - Complete

Assets used in the creation of the scene:

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