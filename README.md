﻿Blender to Unity 3D importer
============================

An advanced Blender model importer for Unity 3D

By Angel García "Edy"
http://www.edy.es

### Setting up

Create a folder in your project's Assets folder to hold the assets of this project. It can be named anything you'd like, but I'd recommend something like "EdysBlenderImporter".

Copy all the folders and files in this repository, except for the "Gizmos" folder, into the folder created above.

Copy the "Gizmos" folder to your project's Assets folder. This step is optional, but, if followed, will provide a nice icon for any importer options assets created in your project.

No Blender files will be touched by the Importer unless they are explictly configured to.

### How to import models with the Importer

There are now two ways to configure a Blender file to be imported:

1. Use the Assets->Create->EdysBlenderImporter Options menu item in the Unity editor.

 This will create a new options asset. Move the asset to the same folder containing your imported Blender model and rename the asset to the same name as your Blender model (no extension). Select the options asset and change options in the Inspector as necessary (but the defaults should work for most cases). Right-click the Blender file, then choose Reimport to apply the new settings.

2. Rename the model to include the string [importer] in the name or path (case insensitive). Example:

    Assets/Models/Scenery/Big House [importer].blend

 The [importer] string can be used in a path. All contained 3D files are processed:

    Assets/Models/Player Vehicles [IMPORTER]/Car1.blend

 Right-click the file or folder, then choose Reimport to apply new settings after renaming.

### How to use the advanced parameters

The [importer] string allows additional parameters as keywords separated by a dot (.):

	[importer]					(use default settings)
	[importer.opt.zreverse]		(optional parameters are applied)

**Parameters:**

	IMPORTER		Use importer. Otherwise bypass the file and let Unity import without changes.
					This must be the first parameter. All others are optional.
	
	OPT				Optimize mesh usage. Ensure that the identical meshes are instanced instead of 
					duplicated.	This optimization can also be applied later scene-wide (menu 
					GameObject > "Optimize mesh instances in this scene").
	SKIPFIX			Do not fix the Blender file. This is automatically applied with any 3D format
					other than Blender. OPT and NOMODS can still be used separately in other 3D formats.
	FORCEFIX		Forces to apply the fix even in non-Blender files. This is useful with FBX files
					exported from Blender.
	ZREVERSE		Turn the model around 180º when importing so the Z axis points the opposite 
					direction. Use when the "forward" direction of the model points	backwards (-Z).
					"Forward" should be +Z in Unity (-Y in Blender).
	
	NOMODS			Do not apply selective commands to meshes (see below).	
	NOANIMFIX		Do not fix animation clips in .blend files when imported.
	NOFLOATFIX		Do not fix floating point precision errors (i.e. rounding 0.9999998 to 1)
	FORCEFIXROOT	Fixes an specific case of Blender file consisting on a single Empty object
					as root of all other objects. See Known Issues below for details.

#### Selective commands to meshes

Some keywords can be specified in the name of the objects in the hierarchy. They will trigger
specific commands unless the NOMODS parameter is specified above.

Example object name:

	collider_hull --norend--coll
	
All commands must be grouped together at the end of the name, starting by -- each, without
any other character or separator.

**Mesh commands:**

	NOREND			Remove the Mesh Renderer
	COLL			Add a Mesh Collider
	COLLCONV		Add a Mesh Collider and mark it as Convex

### Hints & Tips

#### Parenting in Blender

Always use **Ctrl-Shift-P** for parenting objects instead of Ctrl-P. Parenting with Ctrl-P 
makes Blender to store two transforms per parenthood relationship, direct and inverse. 
Only the direct transform is imported by Unity.

Alt-P clears the parent's inverse transform in a children when the parenthood was established with Ctrl-P.

Please contact me if you have experience developing Blender Add-ons. I'd like add a function
(maybe triggered by Shift-Alt-P?) for parenting objects like Unity does, without inverse transform.

#### Rotations and transforms

Unity applies Euler rotations in this order: ZXY

In Blender, the euler rotation mode that matches Unity is: "YXZ Euler" (Z and Y axis are exchanged). 
Still, you can use any rotation mode in Blender. The result of the rotation will be preserved, with 
the Euler angles in Unity adjusted accordingly.

All transformations (position, rotation, scale) will look in Unity exactly as seen in Blender, 
provided the parenthood relationships have been established as speficied above. Only the specific 
values will be different as result of the coordinate change (axis exchanged, etc).

### Known issues

Rotations are incorrectly imported when the Blender file contains a single Empty object as root for 
all other objects. Use the FORCEFIXROOT option in this case.

Animation clips are processed when imported in "Legacy - Store in Root" mode.
