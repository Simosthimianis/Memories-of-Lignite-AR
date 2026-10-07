# Technology & Interaction

## Unity
Unity is the main development environment used to compose scenes, connect AR content, integrate UI/audio/video and implement interaction logic.

## Vuforia / image-target workflow
The experience uses image targets to reveal one of three narrative AR points. The custom `POImanager.cs` script exposes separate **image appeared / image lost** methods for each point. These methods start or stop the appropriate voice/audio clip and are intended to be connected to the image-target tracking events in the Unity/Vuforia workflow.

## Mapbox
The project includes a custom `MapPanZoomController.cs` built around Mapbox's `AbstractMap`.

Implemented map interaction includes:
- Mouse-wheel zoom in Editor / standalone builds
- Click-and-drag map panning
- Two-finger touch / pinch zoom on mobile
- One-finger touch panning
- Minimum and maximum zoom limits
- Runtime map recentering through `UpdateMap`

## POI trigger feedback
`Controller.cs` handles trigger enter/exit events for spawned POI objects. Entering a POI trigger changes its renderer feedback state and the collider is enabled after a short startup delay.

## Multimedia playback
`PlayVideo.cs` provides a simple public method for starting a Unity `VideoPlayer`, allowing video content to be triggered from the interface or another event.

## Interface
The interface follows a restrained museum/documentary approach with semi-transparent panels designed to preserve visibility of the camera / physical environment.

Typical interface elements include:
- Section title
- Short contextual copy
- Voice-over area
- Audio / playback controls
- Progress cues
- Return / navigation controls

## Multimodality
The experience combines:
- Text
- Image
- Voice narration
- Environmental audio
- Video
- AR interface elements
- Map interaction

## AI-assisted production
AI tools were used as supporting production tools during ideation and mockup creation. ElevenLabs was used for text-to-speech narration. AI-generated visual material was treated as concept/mockup material and not as authentic historical documentation.
