🃏 Unity Multiplayer Turn-Based Card Game (Prototype)

A simple 1v1 online turn-based card game built in Unity focusing on multiplayer synchronization, turn flow, and reveal-based gameplay.

🚀 Features

Real-time multiplayer using Mirror Networking

Turn-based system with timers and End Turn sync

Card selection with cost limits

Folding system (hidden plays)

Alternating reveal phase

Live score updates

🌐 Networking

Host & Client multiplayer setup

JSON-based message communication

Event-driven game flow

🎮 Game Flow

Players select cards each turn

End Turn locks selections (folding)

When both players are ready → reveal phase starts

Cards reveal in alternating order

Scores update after each reveal

Game ends after 6 turns

🧠 Architecture
Networking → Game Logic → Card System → UI


Modular, clean, and event-driven.


⚠️ Notes

Card data currently hardcoded (JSON system prepared but skipped due to time)

UI kept minimal to focus on gameplay logic
