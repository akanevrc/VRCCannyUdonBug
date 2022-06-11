# VRCCannyUdonBug

## Abstraction

Prefabs will be broken when UdonBehavior before VCC is imported in the environment after VCC

(a) The SDK before VCC :
VRCSDK3-WORLD-2022.06.03.00.03_Public

(b) The SDK after VCC :
VRChat SDK - Worlds 3.0.8

When prefabs is created in the project for (a) by the following procedure and imported into the project for (b), the public variables of the prefabs will be empty.

Procedure 1 : In case of UdonSharp
1. Create UdonSharpBehaviour and UdonSharpProgramAsset in the project for (a).
2. Define public variables in UdonSharpBehaviour and compile it.
3. Create a GameObject and set UdonSharpProgramAsset in UdonBehaviour.
4. In the inspector, set some values to the public variables of UdonBehaviour.
5. Save the GameObject as a Prefab.
6. When imported into the project for (b), UpdatePrefabs process of UdonSharp will be run automatically.
7. After the import is completed, check the values of the public variables of the UdonBehaviour, and will be lost the values set in step 4. (It is considered that this issue will occured when the value is specified type, such as int, UdonBehaviour. And will not occured such as UnityEngine.Object.)

Procedure 2: In case of UdonGraph
1. Create UdonGraphProgramAsset in the project for (a).
2. Define public variables on UdonGraphEditor and compile.
3. Create a GameObject and set UdonGraphProgramAsset in UdonBehaviour.
4. In the inspector, set some values to the public variables of UdonBehaviour.
5. Save the GameObject as a Prefab.
6. Import it into the project for (b).
7. After the import is completed, check the UdonBehaviour, and the ProgramSource value will be lost.

I was initially thinking that this problem was a bug in UdonSharp, but when UdonSharp referred to UdonBehaviour first, I confirmed that the public variables were already lost.
Also, I imported my asset that inherits UdonAssemblyProgramAsset into (b), the same problem as UdonGraphProgramAsset occured.

## Usage

Move Assets of UdonBeforeVCC project or import unitypackage into UdonAfterVCC project.
Assets are in `Assets/akanevrc/`.

## Abnormalities that occurred in this project

- `Assets/akanevrc/UdonSharp`
  - `GameObject` > `Sample Behaviour` > `Udon Behaviour` is `None`
  - `Child` > `Sample Behaviour` is replaced by `GameObject` > `Sample Behaviour`
  - `Parent` > `GameObject_Prefab` > `Sample Behaviour` is replaced by is replaced by `GameObject` > `Sample Behaviour`
    - This is normal specification of UdonSharp

- `Assets/akanevrc/UdonGraph`
  - `GameObject` > `Udon Behaviour` > `_udonBehaviour` is `Self`
  - `Parent` > `GameObject_Prefab` > `Udon Behaviour` > `_udonBehaviour` is `Self`
