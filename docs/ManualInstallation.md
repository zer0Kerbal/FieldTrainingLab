---
permalink: /ManualInstallation.html
title: Manual Installation
description: the flat-pack Kiea instructions, written in Kerbalese, unusally present
tags: installation,directions,page,kerbal,ksp,zer0Kerbal,zedK
---
<!-- ManualInstallation.md v1.1.8.1
Field Training Lab (FTL)
created: 01 Oct 2019
updated: 29 Jul 2022 -->

<!-- based upon work by Lisias -->

# Field Training Lab (FTL)

[Home](./index.md)

This addon provides training for your kerbalnauts by adding a training center to all science laboratories. Training consumes Time and Electric Charge. For Kerbal Space Program.

## Installation Instructions

### Using CurseForge/OverWolf app or CKAN

You should be all good! (check for latest version on CurseForge)

### If Downloaded from CurseForge/OverWolf manual download

To install, place the `FieldTrainingLab` folder inside your Kerbal Space Program's GameData folder:

* **REMOVE ANY OLD VERSIONS OF THE PRODUCT BEFORE INSTALLING**
  * Delete `<KSP_ROOT>/GameData/FieldTrainingLab
* Extract the package's `FieldTrainingLab/` folder into your KSP's GameData folder as follows:
  * `<PACKAGE>/FieldTrainingLab` --> `<KSP_ROOT>/GameData/`
    * Overwrite any preexisting folder/file(s).
  * you should end up with `<KSP_ROOT>/GameData/FieldTrainingLab`

### If Downloaded from SpaceDock / GitHub / other

To install, place the `GameData` folder inside your Kerbal Space Program folder:

* **REMOVE ANY OLD VERSIONS OF THE PRODUCT BEFORE INSTALLING**, including any other fork:
  * Delete `<KSP_ROOT>/GameData/FieldTrainingLab`
* Extract the package's `GameData` folder into your KSP's root folder as follows:
  * `<PACKAGE>/GameData` --> `<KSP_ROOT>`
    * Overwrite any preexisting file.
  * you should end up with `<KSP_ROOT>/GameData/FieldTrainingLab`

## The following file layout must be present after installation

```markdown
<KSP_ROOT>
  + [GameData]
    + [FieldTrainingLab]
      + [Agencies]
        ...
      + [Compatibility]
        ...
      + [Contracts]
        ...
      + [Flags]
        ...
      + [Localization]
        ...
      + [Plugins]
        ...
      * #.#.#.#.htm
      * Attributions.htm
      * changelog.md
      * FieldTrainingLab.version
      * GPL-3.03.txt
      * ManualInstallation.htm
      * readme.htm
    ...
    * [Module Manager /L][mml] or [Module Manage][mm]
    * ModuleManager.ConfigCache
  * KSP.log
  ...
```

### Dependencies

* *either*
  * [Module Manager /L][mml]
  * [Module Manager][mm]

[mm]: https://forum.kerbalspaceprogram.com/index.php?/topic/50533-*/ "Module Manager"
[mml]: https://github.com/net-lisias-ksp/ModuleManager "Module Manager /L"
