## About

"Your village has decided to deal with over population by sacrificing you to the great stone golem who lives nearby. Your goal is to sneak through the dungeon and escape undetected." The Village Sacrifice is a stealth game made in 72 hours for Ludem Dare 43. The theme was: sacrifices must be made. This repository contains the complete unity project (last tested on version 2018.2.18f1).

## Authors

* **Hayden Donnelly** - *Programmer*
* **Peter Prickarz** - *Artist*
* **Eric Goetz** - *Composer*

## Finite State Machine AI

The enemy AI has three main states: patrol, chase, and search. Beginning in the patrol state, it will walk around a number of pred-defined patrol routes.
If the AI detects the player during its patrol, it will enter the chase state. In this state, the AI will simply run towards wherever the player. 
If the AI loses line of sight on the player while chasing, will enter the search state. Upon first entering the search state, the AI will walk to the
player's last known location, and then begin to search the surrounding area in four directions. If the AI detects the player at any time during this search, it will automatically transition to the chase state. If the search completes and the player has not been detected, the AI will go back to the patrol state.

![IMG_0778](https://user-images.githubusercontent.com/30982485/172991846-ba52711d-c806-45ee-a4dc-78700701df00.jpg)

## Screenshots

![VS1_c](https://user-images.githubusercontent.com/30982485/102728697-39dde500-42fb-11eb-8b78-a6520002a540.png)
![VS2_c](https://user-images.githubusercontent.com/30982485/102728699-3d716c00-42fb-11eb-9700-841328660a2e.png)
![VS3_c](https://user-images.githubusercontent.com/30982485/102728701-3ea29900-42fb-11eb-90fe-b313b9a3c7a8.png)
