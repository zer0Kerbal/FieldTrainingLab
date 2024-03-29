---
permalink: /Changelog.html
title: The Change Log
description: The Opening Credits, and the closing credits, plus the first of two (or is three) end credit scenes
tags: changes,changelog,change-log,page,kerbal,ksp,zer0Kerbal,zedK
---
<!-- 
hdr-changelog.md v1.0.0.0
Field Training Lab (FTL)
created: 13 May 2022
updated:
CC BY-ND 4.0 by zer0Kerbal
--># Changelog  
  
| modName    | Field Training Lab (FTL)                                          |
| ---------- | ----------------------------------------------------------------- |
| license    | GPL-3.0                                                           |
| author     | Efour and zer0Kerbal                                              |
| forum      | (https://forum.kerbalspaceprogram.com/index.php?/topic/188841-*/) |
| github     | (https://github.com/zer0Kerbal/zer0Kerbal/FieldTrainingLab)       |
| curseforge | (https://www.curseforge.com/kerbal/ksp-mods/FieldTrainingLab)     |
| spacedock  | (https://spacedock.info/mod/971)                                  |
| ckan       | FieldTrainingLab                                                  |

## Version 1.2.2.0-release `<Thank you Efour>` edition

* Released
  * 11 Jan 2023
  * Release for Kerbal Space Program 1.12.4
  * by [zer0Kerbal](https://github.com/zer0Kerbal)

### Summary 1.2.2.0

* Recompiled for 1.12.4 with .NET 4.7.2 using C# 7.0

### Changes 1.2.2.0

#### Code 1.2.2.0

* Recompile for
  * KSP 1.12.2
  * .Net 4.7.2
  * C# 7.0
  * <FieldTrainingLab.dll> v1.2.1.14 --> 1.2.2.22

#### Localization 1.2.2.0

* Code is localized.
  * <en-us.cfg> 1.0.2.0
  * <zh-cn.cfg> v1.0.1.0 (needs a serious update - many strings added)
  * add tags
* closes #14 - English <us-en.cfg>
* closes #31 - Code Localization
* updates #13 - Localization - Master

#### Compatability 1.2.2.0

* Add
  * <StationPartsExpansionRedux.cfg> v1.0.0.0
  * <TokamakIndustries.cfg> v1.0.0.0
  * <Bluedog.cfg> v1.0.0.0
* Update
  * <Kerbalism.cfg> v1.3.0.0
* courtesy of [Gordon Dry](https://forum.kerbalspaceprogram.com/index.php?/profile/163177*/)

#### Config 1.2.2.0

* move primary patch into Config
* lint and update patches
* add tags to parts

#### Status 1.2.2.0

* Issues
  * closes #39 - Field Training Lab (FTL) 1.2.2.0-release `<Thank you Efour>` edition
  * closes #40 - 1.2.2.0 Additional Tasks

---

## Version 1.2.1.0-release - `<Clean Blackboards>` edition

* 28 Jun 2022
* For Kerbal Space Program [1.12.x]

### License

* Update to GPLv3
  * was Expat/MIT
* closes #32 - Update License to GPLv3

### docs/

* Add
  * [Attribution.md] v1.0.6.0
  * [ManualInstallation.md] v1.1.7.0
  * [404-petunia.md]
  * [LegalMumboJumbo.md] v1.0.5.0
  * [Localizations.md] v1.1.3.1
  * [Notices.md] v1.0.0.0
  * [Why-not.md]
  * [_config.yml]
* closes #2 - Needs a wiki
* closes #35 - add docs/

### Convert Changelog

* Convert from .cfg to md
* Add missing information for earlier releases
* closes #33 - Convert Changelog

### Code

* Recompile for KSP 1.12.3
* Using .NET 4.6.1
  * remove
    * [InstallChecker.cs]
    * [AssemblyVersion.tt]
    * [Log.cs]
  * update [Version.tt]]

### Compatibility

* Rename
  * Patches to Compatibility
* Update
  * licenses
  * [Kerbalism.cfg] v1.0.1.0
    * fixes #34 - [Bug 🐞]: Kerbalism.cfg

### Add

* Agent
* Flag
  * 512x320
  * 64x40 truecolor_scaled

### Localization

* Add
  * [readme.md] v2.1.2.0
  * [quickstart.md] v1.0.1.1
* updates #14 - English <us-en.cfg>
* updates #13 - Localization - Master
* updates #31 - Code Localization
* updates #22 - Simplified Chinese (简体中文) <zh-cn.cfg>

### Status

* Issues
  * closes #9 - Field Training Lab (FTL) 1.2.1.0-release `<EDITION>`
  * closes #10 - 1.2.1.0 Verify Legal Mumbo Jumbo
  * closes #11 - 1.2.1.0 Update Documentation
  * closes #12 - 1.2.1.0 Update Social Media
* Closes Duplicate Issues
  * #1 - Localization
  * #4 - :sparkles: **Localization** :sparkles:
  * #5 - Localization - en-us.cfg (English)
  * #6 - Localization - pt-br.cfg Brazil
  * #7 - Localization - zh-cn.cfg - Simplified Chinese
  * #8 - Update Field Training Laboratory (FTL)

---

## Version 1.2.0.0 - `<New Carpets! Automation Motivation Modernization>`

* 05 Apr 2020
* KSP 1.9.1
* .NET 4.8

### Code 1.2.0.0

* update
  * Editor GetInfo() to be more informative
  * include assembly version in PAW
* Add
  * game settings page
  * ***disabled for now***
    * game settings page
    * global setting to enable/disable PAW color
    * option to globally enable/disable
    * option: use science and ratio
    * option: use reputation and ratio
    * option: use funds and ratio

---

## Version = 1.1.0.0 - `<Automation Motivation Modernization>`

* KSP 1.8.1 with .NET 4.8

* isn't that enough? :D
* started adding in JoyntMail :D

---

## Version = 1.0.3.5 - `<Automation Motivation Modernization.`

* KSP 1.7.3 with .NET 3.5

### Code and Code Related  

* updated / modernized .csproj
* this preps mod for much easier releases
  * added automation
  * [Version.tt]
  * [AssemblyVersion.tt]
* moved
  * into Properties/
  * [AssemblyVersion.tt]
* updated
  * to v2 of InstallChecker.cs
* moved Textures/
  * -> Plugins/Textures/

### Deployment and Backend

* Update
  * [Changelog.cfg]
    * to include new Kerbal Changelog features
    * [_deploy]
    * [_buildRelease]
  * [.gitattributes]
  * [].gitignore]
  * [*Readme.md]
    * automated Readme.md -> Readme.htm
    * Readme.htm now included in release
    * Releases.layout.md
* [CONTRIBUTING.md] now included in repository
* [FieldTrainingLab.version] to be avc compliant
* Added
  * avc github checker and badge
* Added
  * json's

---

## Verison 1.0.3.4.1 - `<stowaways be gone!>` edition

* released Oct 1, 2019
* for KSP 1.7.x
* removed SimpleLogistics.dll that stowed away.

---

## Version 1.0.3.4

### Adoption by zer0Kerbal

### Code 1.0.3.4

* Added
  * PAW grouping (really needed for these mods)
  * a blurb in the editor getInfo{}
  * [InstallChecker.cs]

### Compatibility 1.0.3.4

* Updated
  * [FieldTrainingLab.cfg]
    * now patches all parts with moduleScienceLab
    * changed the [TrainingLab] to be [FieldTrainingLab]
      * patches reflect this
* Removed
  * other patch

---

## Version  1.0.3.3

=--- original ---=

* for Kerbal Space Program 1.6.1
* Released on 2018-12-21

* Efour's last release
* Recompiled 1.6.0

---

## Version 1.0.3.2

* for Kerbal Space Program 1.5.1
* Released on 2018-10-30

* Recompiled for 1.5.1

---

## Version 1.0.3.1

* for Kerbal Space Program 1.3.1
* Released on 2017-11-27

* Recompiled KSP 1.3.1

---

## Version 1.0.3

* for Kerbal Space Program 1.2.2
* Released on 2016-11-03

* Recompiled to 1.2.1

---

## Version 1.0.2.1

* for Kerbal Space Program 1.2
* Released on 2016-10-22

* KPBS support

---

## Version 1.0.2

* for Kerbal Space Program 1.2
* Released on 2016-10-16

* Calculating Dead and respawned kerbalnaut

---

## Version 1.0.1.0

* for Kerbal Space Program 1.2
* Released on 2016-10-12

* Co-Work with Field Training Facility Mod

---

## Version 1.0.0.0

* for Kerbal Space Program 1.2
* Released on 2016-10-08

* No changelog provided

---

## Version 1.0.0.0

* for Kerbal Space Program 1.1.3
* Released on 2016-10-07

* No changelog provided

---
