CS-6457-O01 Milestone 0 "Plauche_J_m0"
Jeremiah Ashton Plauche
jplauch3@gatech.edu

Main scene is titled "Main Scene"


Project Instructions:
	For this assignment, you are to modify the “Roll-A-Ball” Unity Tutorial located at
	https://learn.unity.com/project/roll-a-ball

	Next modify your game as follows:
	• Add your name to the HUD (2D heads-up-display) of the game.
	• Modify your project to show hidden meta data files: Edit->Project Settings:Version Control:Mode==Visible Meta Files
	• Make one or more changes to the scripts. The changes should result in some visible change to the default tutorial game. 
		For instance, change the capabilities of the ball (new movement, fire projectiles, etc.).
	• Make one or more changes to the 3D graphics content of the game. The
		changes should result in some visible change to the game. For instance, add
		new objects to the level to make it look different.
	• Build executables for both OSX and Windows with the correct naming
		conventions (see below)

Changes I made:
	* Added functionality to make the ESC key automatically win the game
	* Added "Restart" & "Quit" buttons to the win screen with the appropriate functionality
	* Replaced the player ball with an egg model by pepnudl that I got from here https://free3d.com/3d-model/egg-370117.html
	* Made it so that the player grows with each powerup gained. This is reflected in the egg controller C# script
	* Changed the goal to reach 100% fullness
	* Made it so that the egg changes color according to what powerups were eaten
	* Created a fullness egg indicator that also indicators the egg color
	* Modified the pickups to look more interesting & to be affected by gravity without falling over
	* Modified rotator code to spin object randomly
	* Slightly increased the size of the bounding walls
	* Changed colors of the player, ground, walls, & pickups
	* Added two other pickup colors for variety, they don't do anything different
	* Made use of the DOTween plugin library to smoothly scale the size of my player game object
	* Made use of the ProBuilders plugin to create an uneven terrain to play on & replace the floor plain