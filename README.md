Unity Multiplayer Turn-Based Card Game (Prototype)

A lightweight 1v1 online turn-based card game prototype built in Unity, focused on multiplayer synchronization, turn flow, and reveal-based resolution.

Project Goals

This project explores:

Multiplayer connectivity using Mirror Networking

Turn-based game flow with timers

Card selection & folding system

Alternating reveal resolution

Real-time score updates

Clean modular architecture

Networking

Solution Used: Mirror Networking

Features:

Host & Client multiplayer setup

JSON-based message passing between players

Turn synchronization across both clients

Event-driven message routing

Game Flow
Match Structure

2 players (1v1)

6 total turns

Each turn:

Players select multiple cards (within cost limit)

End Turn locks selections (folding)

When both players end → reveal phase starts

Turn System

30-second timer per turn

Manual End Turn button

Game waits until both players are ready

 Folding Phase

Selected cards become locked

Opponent only receives folded card count

Cards cannot be modified after folding

Reveal Phase

Reveal starts only when both players end turn

Initiative determined by current score

Cards revealed in alternating sequence

Each reveal immediately updates score

Scoring

Card power adds to player score

Score updates after each reveal

Final winner determined after 6 turns

Card System

Current prototype uses hardcoded card data for speed:

Example card attributes:

ID

Name

Cost

Power

(Architecture prepared for JSON-driven cards if extended)

Architecture Overview
Scripts/
  Networking/
    PlayerNetwork.cs
    GameMessageRouter.cs
    JsonMessage.cs

  Game/
    TurnManager.cs
    RevealManager.cs
    ScoreManager.cs

  Cards/
    Card.cs
    HandManager.cs


Design principles:

Event-driven messaging

Clear separation of gameplay & networking

Modular systems

Simple and readable code

 How to Run
PC Testing

Open project in Unity

Press Play → Click Host

Build project → Run executable → Click Client

Android Build

(Android build supported using Unity Build Settings)

Gameplay Demonstrates

Multiplayer connection

Card selection

Folding

Reveal order

Live score updates

Notes & Limitations

Card data currently hardcoded (JSON loader prepared but skipped due to time)

UI kept minimal to focus on core logic

Reconnection handling not fully implemented

Future Improvements

Full JSON-driven card system

Visual card animations

Ability effects system

Reconnection state recovery

Improved UI/UX

Tech Stack

Unity

C#

Mirror Networking

JSON messaging

Modular event-driven architecture
