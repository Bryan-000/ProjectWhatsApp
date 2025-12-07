# How to build the assets for the mod

## Project
* Step 1: Create a new Unity project in 2022.3.9f1 and 3D (Built-In Render Pipeline)
* Step 2: Create the folders "Editor", "Images", "Models", and "Sounds"
* Step 3: Open up the "Editor" folder and drag AssetsExporter.cs into it

## Images
* Step 1: Open up the "Images" folder in the project and drag the images from the repo into it
* Step 2: Right click the Assets window, Create -> Material 
* Step 3: Name it WhatsAppMaterial, WhatsAppInvincibleMaterial, and WhatsAppRemixMaterial
* Step 4: Repeat step 2 & 3 for each image
* Step 2: Add the images to the Asset Bundle through the bottom right AssetBundle dropdown, if you don't have an AssetBundle click "New..." and name it "assets.bundle"

## Models
* Step 1: Open the .blend file with blender (OFC)
* Step 2: Click 'File' in the top left
* Step 3: Export -> .FBX
* Step 4: Hit "Export FBX" and put it in your unity project
* Step 5: Open Unity and drag the imported FBX into the scene, then in the Hierarchy right click it's GameObject, Prefab -> Unpack Completely
* Step 6: In the Inspector, set the rotation to 0, 0, 0 then set the material of the object to the WhatsAppMaterial
* Step 7: Drag the GameObject from the Hierarchy into the Assets and name it "WhatsAppPrefab"
* Step 8: Add it to the Asset Bundle through the bottom right AssetBundle dropdown, if you don't have an AssetBundle click "New..." and name it "assets.bundle"

## Sounds
* Step 1: Drag them into the sounds folder
* Step 2: Add it to the Asset Bundle through the bottom right AssetBundle dropdown

## Building
* Step 1: Right click the Assets window and press "Export Assets"
* Step 2: Press "Select Export Folder" and navigate to your ProjectWhatsApp folder or type the path to it manually in "Export Folder Path"
* Step 3: Click "Export Assets" and wait for it to complete