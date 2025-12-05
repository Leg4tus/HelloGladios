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
- Inside i create a subfolder for your mod "my mod"
- Copy your dll and 0harmony.dll there from bin
- Start Gladio Mori

If everything went right, your mod should be working.

