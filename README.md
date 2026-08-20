\# Zombie Asylum



Zombie Asylum is a 3D first-person zombie survival game developed in Unity and C#.



The player explores an abandoned asylum, fights four zombies located throughout the environment, manages health, and must eliminate all enemies to win.



\## Features



\- First-person player movement and mouse-look controls

\- Raycast-based shooting system

\- Visible FPS weapon with bullet visual effects

\- Zombie AI using Unity NavMesh

\- Zombies navigate between rooms and chase the player

\- Zombie attack and damage system

\- Player health system with real-time health UI

\- Start Game screen

\- Game Over and Restart system

\- Victory screen after eliminating all four zombies

\- Crosshair-based aiming

\- Multi-room 3D environment



\## Technologies



\- Unity 6

\- C#

\- Universal Render Pipeline (URP)

\- Unity NavMesh / AI Navigation

\- Unity Input System

\- TextMeshPro

\- Git \& GitHub



\## Controls



\- `WASD` - Move

\- `Mouse` - Look around

\- `Left Mouse Button` - Shoot



\## Gameplay



The game begins on the Start Game screen.



After starting, the player must explore the asylum while four zombies attempt to chase and attack them.



Each zombie has its own health and can be eliminated by shooting it.



If the player's health reaches zero, the Game Over screen is displayed.



If all four zombies are eliminated, the player wins and the Victory screen is displayed.



\## Main Systems



\### Player System

Handles player movement, camera rotation, shooting and health.



\### Zombie AI

Uses Unity NavMesh to allow zombies to navigate the environment and chase the player through rooms and doorways.



\### Combat System

The shooting system uses raycasting for accurate hit detection while a visual bullet effect is spawned from the weapon.



\### Game Manager

Controls the main game states:



\- Start Game

\- Active Gameplay

\- Game Over

\- Victory

\- Restart



\## Project Structure



```text

Assets/

├── Scripts/

│   ├── Player/

│   │   ├── PlayerMovement.cs

│   │   ├── PlayerLook.cs

│   │   ├── PlayerShooting.cs

│   │   └── PlayerHealth.cs

│   ├── Targets/

│   │   ├── ZombieAI.cs

│   │   ├── ZombieAttack.cs

│   │   └── ZombieHealth.cs

│   └── Systems/

│       └── ZombieGameManager.cs

├── Scenes/

│   └── ZombieGameScene.unity

└── Prefabs/

