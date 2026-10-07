# Code Architecture

The repository includes the custom C# scripts used to support interaction, map navigation and multimedia behavior in the prototype.

| Script | Responsibility |
|---|---|
| `MapPanZoomController.cs` | Mapbox map panning and zooming for mouse and mobile touch input |
| `POImanager.cs` | Per-AR-point audio playback when tracked content appears or is lost |
| `Controller.cs` | Trigger-based POI feedback and delayed collider activation |
| `PlayVideo.cs` | Starts playback through Unity's `VideoPlayer` component |

## Implementation notes

### Map interaction
`MapPanZoomController` switches automatically between desktop/editor mouse controls and mobile touch controls using Unity platform directives. It updates the active `AbstractMap` center and zoom level at runtime.

### Image-target / audio events
`POImanager` separates the three narrative points into individual event methods. This keeps audio feedback tied to the currently recognized AR point and stops playback when tracking is lost.

### Trigger feedback
`Controller` reacts to named POI clone objects through collider triggers and changes their renderer material color as proximity feedback.

### Video
`PlayVideo` exposes a public `PlayMyVideo()` method so video playback can be connected to UI buttons or Unity events.

## Potential refactoring
For a future production version, I would:
- Replace repeated POI name checks with reusable components, tags or data-driven POI definitions.
- Separate audio state from the manager into reusable AR-point components.
- Replace direct `GetComponent` calls during events with cached component references where appropriate.
- Add structured state management for visited / completed POIs.
- Add automated handling for narration replay and accessibility controls.
