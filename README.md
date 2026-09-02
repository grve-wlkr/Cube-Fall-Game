A 2D endless vertical platformer game.
The objective is to guide the player down a continuous descent while platforms constantly scroll upward. 
Survival depends on quick reflexes and landing on the right surfaces while avoiding hazards.

Key Mechanics:
Dynamic Platform Spawner (PlatformSpawner.cs): 
Generates randomized platforms at varying positions and intervals.

Platform Variety & Hazards (PlatformScript.cs): 
  Standard Platforms: Safe surfaces to land and regain footing.
  Moving / Speed Platforms: Push the player horizontally in either direction.
  Spike Platforms: Hazardous surfaces to avoid.
  Breakable Platforms: Platforms that crack and crumble upon contact.

Continuous Scrolling (BG_Scroll.cs): 
Smooth vertical background scrolling that creates a seamless sense of continuous motion and urgency.
