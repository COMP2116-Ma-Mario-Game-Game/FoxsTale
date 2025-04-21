![Project Banner](./banner.png)

FOX'S TALE is a game with a similar playstyle to the classic "Mario" games. Players can control the character to move forward and backward. Furthermore, the character can single jump and double jump. In the game, players can collect gems to gain points and avoid obstacles in order to keep the character healthy. At the main page of the game there is a leaderboard of all players' scores.

## Table of content

- [Quick Started](#quick-started)
- [Purpose of Our Game](#purpose)
- [Team Members](#members)
- [Schedule](#schedule)
- [Development Process](#development-process)
- [Current Status](#current-status)
- [Future Plan](#future-plan)

<a id='quick-started'></a>

## Quick Started

### Demo Video

[![Demo Video](./demo_capture.png)](https://youtu.be/4HbANseA9HE)

Our game is available on the [web page](https://comp2116-ma-mario-game-game.github.io/), or if you prefer a desktop version you can download it from the [release build](https://github.com/COMP2116-Ma-Mario-Game-Game/FoxsTale/releases/tag/1.0). Give it a try!

### Minimum Requirements

- OS: Windows 10 64-bit or newer
- CPU: Intel Core i5-9700 / AMD Ryzen 5 5500
- Memory: 16GB RAM
- GPU: NVIDIA GeForce GTX 1060 / AMD Radeon RX 5600 / INTEL Arc A750
- DirectX: Version 12
- Storage: 128MB available space

<a id='purpose'></a>

## Purposes of Our Game

Our target audience is mainly primary and secondary school children who are looking for a simple and positive game to enjoy but it is also suitable for people of any age to play. For the development, we chose the Agile Development Process. The reason for this choice is because the game market is highly competitive, which prompt us to adopt the Time-To-Market strategy and the Agile Development Process is a good fit for this strategy. After much delibration, we have concluded that we're able to complete this goal under some deep analysis of condition such as possibility, difficulty, work time period etc..

<a id='members'></a>

## Team Members

Our team consists of the following members:

| Name | Student ID | Role | Responsiblities | Portion |
| --- | :---: | --- | --- | :---: |
| Michale Leong | P2304152 | Programmer, Docs Clerk  | Prototype, Main Game, Docs | 0.2 |
| Henry Chou | P2304111 | Docs Clerk | Docs | 0.2 |
| Bibie Chen | P2321060 | Game Designer, Programmer, Docs Clerk | Prototype, Main Game, Docs | 0.2 |
| Thomas Cheang | P2321902 | Docs Clerk, Video Editor | Docs, Demo | 0.2 |
| Todd Huang | P2304318 | Programmer, Docs Clerk | Prototype, Docs | 0.2 |

<a id='schedule'></a>

## Schedule

Below is the planned schedule of the game development up to the first release. It is divided into three phases:

- Exploration (Feb 20 - Mar 11, 2025 / 3 weeks)

    In this phrase, we brainstormed the theme and the potential features of our game. Additionally, we built a simple demo to showcase the feasiblity.

- Iterations (Mar 24 - Apr 13, 2025 / 3 weeks)

    In this phase, the development process formally started. We carried out our development with weekly iterations.

- Pre-release (Apr 14 - Apr 22, 2025 / ~1 week)

    In this phase, we had the game ready for its first release. Besdies, we finalized the front page of our repository.

<a id='development-process'></a>

## Development Process

### Meeting Minutes

- [#29 1st group meeting discussion](https://github.com/COMP2116-Ma-Mario-Game-Game/FoxsTale/issues/29)
- [#30 2nd group meeting discussion](https://github.com/COMP2116-Ma-Mario-Game-Game/FoxsTale/issues/30)
- [#31 3rd group meeting discussion](https://github.com/COMP2116-Ma-Mario-Game-Game/FoxsTale/issues/31)

### Tasks

We use GitHub Issues to manage our tasks for the aigle development process, and here are the [rules](https://github.com/COMP2116-Ma-Mario-Game-Game/FoxsTale/issues/3) we follow. For a complete list of tasks, please visit [here](https://github.com/COMP2116-Ma-Mario-Game-Game/FoxsTale/issues?q=is%3Aissue%20type%3ATask%20).

### Iterations & Pre-release

- Iteration 0 (Mar 4 - 10, 2025 / 1 week)

    Planned Tasks:
    1. Complete the basic framework of the game.
    2. Create a tile palette and draw a level with tilemaps.

    Completed Tasks:
    1. Complete the basic framework of the game.
    2. Create a tile palette and draw a level with tilemaps.

- Iteration 1 (Mar 24 - 30 / 1 week)

    Planned Tasks:
    1. Create the basic model and animation of the protagonist Fox.
    2. Create a health system and sut up health UI
    3. Create and integrate the first enemy
    4. Create the back-end of the ranking of the game

    Completed Tasks:
    1. Create the basic model and animation of the protagonist Fox.
    2. Create a health system and sut up health UI
    3. Create and integrate the first enemy
    4. Create the back-end of the ranking of the game

- Iteration 2 (Mar 31 - Apr 6 / 1 week)

    Planned Tasks:
    1. Create a collective system and sut up collective UI
    2. Create the basic model and animation of the Gems(collective things).
    3. Add pickup effect
    4. Add sound effect
    5. Create the front-end of the ranking of the game

    Completed Tasks:
    1. Create a collective system and sut up collective UI
    2. Create the basic model and animation of the Gems(collective things).
    3. Add pickup effect
    4. Create the front-end of the ranking of the game

- Iteration 3 (Apr 7 - Apr 13 / 1 week)

    Planned Tasks:
    1. Add sound effect
    2. Make the Menu work
    3. Create the score system and timing system
    4. implement the score system into the ranking system

    Completed Tasks:
    1. Add sound effect
    2. Make the Menu work
    3. Create the score system and timing system
    4. implement the score system into the ranking system

- Pre-release (Apr 14 - Apr 22 / ~1 week)

    Planned Tasks:
    1. Conduct final game testing and debugging and prepare for release.
    2. Integrate Ranking Board to the Main Menu.
    3. Fix known bugs.
    4. Polish the README.md.

    Completed Tasks:
    1. Conduct final game testing and debugging and prepare for release.
    2. Integrate Ranking Board to the Main Menu.
    3. Fix known bugs.
    4. Polish the README.md.

### Toolset

- Programming Language: C#, Python
- Frameworks: Django
- IDEs: Unity 6000.0, VS Code
- Version Control: Git, GitHub
- Hosting Platform: PythonAnywhere

### Algorithm

In this game, we have use the following algorithm:

- Collision Detection Algorithms: AABB（Axis-Aligned Bounding Box）
- Animation control algorithms: State Motorised Painting
- Graphics Rendering Algorithms: Z-buffering
- AI Enemy Behaviour Algorithm: State Machine

### Open Source Notice

In this game, we have used the following open source packages:

- [Newtonsoft Json Unity Package](https://docs.unity3d.com/Packages/com.unity.nuget.newtonsoft-json@3.2)
- [Material Files / Assets](https://pan.baidu.com/s/1BiMuJRmoXYkkGZcgxdlsmA)       (Extract code: d7cz)
- [Django 4.2](https://www.djangoproject.com/)

<a id='current-status'></a>

## Current status

Currently, our game only has one level. In addition to that, our game contains a timing system, score system and ranking system. The timing system contributes to the score system while the ranking system depends on the score system.

<a id='future-plan'></a>

## Future Plan

This section outlines the elements of our game we wish to develop in future:

- More levels: The difficulty will increase as the player enters later levels.
- Game tutorial: Insert a beginner tutorial at the very first stage to teach new players how to play.
- Multi-player system: Other than the single player mode, we could develope a multiplayer mode for a new game experience.
- Different characters: New characters could be developed which might come with different abilities.
- New skins: A character's skin system might be developed to attract more players and keep the game fresh.
- Shopping system: A shopping system could be developed for player to spend the gems they collected in game to buy new characters, skins or items.
- Item: Items may give character different effect.
- Buff and debuff system: During the game, there might be some obstacles or items that may affect character's status such as swiftness, blindness, slowness, jump boost, rushing, freezing, poison etc.
