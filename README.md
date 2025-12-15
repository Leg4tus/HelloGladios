# HelloGladios

Example project for creating Gladio Mori mods.

To get it working. Delete the assembly dependencies and add them from your own machine.

Right click Dependencies->Add Project Reference->Browse->Browse...->Select the required dlls one at a time
Following assemblies are found inside your Gladio Mori installation in "Gladio Mori_Data\Managed":
Assembly-CSharp
UnityEngine
UnityEngine.CoreModule
UnityEngine.UI

0harmony.dll you need to download separately from the harmony github or add the nuget package.

To test:
- Build your project
- Go to the root of your Gladio Mori installation.
- Create Folder "Mods"
- Inside it create a subfolder for your mod "my mod"
- Copy your dll and 0harmony.dll to "Mods\my mod" from bin
- Start Gladio Mori

If everything went right, your mod should be working.

# Uploading content to mod.io:
- Add your files to a zip with no subfolders
- Create the mod in mod.io
- Select relevant tags:
- Moveset:
  - Should contain one or more moveset files with ".json" extension
- Player skin:
  - Should contain one or more custom texture files with ".jpg", ".jpeg" or ".png" extension
- Local mod:
  - Should contain a dll mod that is not required by the clients in a multiplayer game. Server side mods even when altering multiplayer experience should be in this category
- Multiplayer mod:
  - Mods that are required by the clients and should be automatically downloaded.
- Arena:
  - Should contain a asset bundle called "maps". These are automatically loaded by clients when joining a server.
- Equipment:
  - Should contain a asset bundle called "equipment". These are automatically loaded by clients when joining a server.
 
# The mod load order is:
- Load modio subscribed maps
- Load modio subscribed equipment
- Load all mods from local mods folder in alphabetical order
- Load modio subscribed dll mods

## Dependencies:
- If you want to have dependencies to other mods, look at DependencyExample folder