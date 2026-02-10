Unity Multiplayer Turn-Based Card Game (Prototype)

A 1v1 online turn-based card game built in Unity demonstrating multiplayer synchronization, folding mechanics, and alternating reveal resolution.

⚙️ Setup Instructions
Requirements

Unity (2021+ recommended)

Windows PC or Android device

Running the Game (Local Multiplayer Test)

Open project in Unity

Press Play and click Host

Build the project (File → Build Settings → Build)

Run the built executable or Android APK

Click Client to connect to the Host

Two players will now be connected.

🌐 Networking Solution

Mirror Networking

Used for:

Real-time multiplayer connection (Host + Client)

Player spawning and synchronization

JSON-based event messaging between clients

All gameplay actions are transmitted using structured JSON messages containing an action field.

🎴 Reveal Sequence & Initiative Logic
Turn Flow

Players select cards locally

Press End Turn to lock selections (folding)

Reveal phase starts only when both players are ready

Initiative

At the start of each reveal phase:

Player with the higher current score reveals first

If tied, initiative is chosen randomly

Initiative remains fixed for the entire reveal phase

Reveal Order

Cards are revealed:

In the order they were played

In an alternating sequence between players

Example:

Initiative player reveals card #1 → score updates

Opponent reveals card #1 → score updates

Initiative player reveals card #2 → score updates

Opponent reveals card #2 → score updates

This continues until all folded cards are resolved.

🧠 Notes

Card logic is currently hardcoded for prototyping speed

UI is minimal to focus on core gameplay correctness

Prototype prioritizes networking and turn-based logic over visuals

🛠 Tech Stack

Unity

C#

Mirror Networking
