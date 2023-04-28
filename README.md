# RosaDealVR
##                                        VR tour of Rosa Deal School of Arts
-We currently have 2 versions available. A normal PCBuild  that offers the tour with basic Keyboard and mouse controls.
The second build is for VR. This version offers the Tour for the Meta Quest 2. 
--For both builds all you would need to do is run the .exe file and it should work, we have not implemented a stop or exit program button so you will need to tab out 
and close it or use the funtion alt + F4 to froce close the program.

-We created the virtual environment using Blender. 
--We began by making our models with the standard .blender file format, but we later learned that itss better to export as a .FBX file/

-When dealing with the user movement we had to make sure that the user would not feel nauseous when moving. This took some testing with multiple different people before we settled on the movement. 
--Apart from this, we also had to add collisions. This was to prevent useres from walking through the walls of the virtual environment. By adding mesh colliders to the walls, which is a component provided by Unity, allowed us to fix this problem.

-For object interactions, we were able to use the built in grabbable.cs in Unity. Since we needed to add physics to objects which would be affected by grabbable, we used the rigidbody component for this.

-In the tour, you cannot move between floors using the stairs, instead we added teleport features that allows user to move to any floor they wish to see from any floor. 
--Every frame we check to see if any of the teleport ports has been been activated. If yes, the user is sent to the postion predetermined for that floor. By using this method, at any one time, only one floor is loaded in.
