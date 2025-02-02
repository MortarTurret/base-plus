//----------------------------------------------------------------------------
// Medium Female Armor
//----------------------------------------------------------------------------
$DamageScale[mfemale, $LandingDamageType] = $DamageScale[marmor, $LandingDamageType];
$DamageScale[mfemale, $ImpactDamageType] = $DamageScale[marmor, $ImpactDamageType];
$DamageScale[mfemale, $CrushDamageType] = $DamageScale[marmor, $CrushDamageType];
$DamageScale[mfemale, $ChaingunDamageType] = $DamageScale[marmor, $ChaingunDamageType];
$DamageScale[mfemale, $PlasmaDamageType] = $DamageScale[marmor, $PlasmaDamageType];
$DamageScale[mfemale, $TurretDamageType] = $DamageScale[marmor, $TurretDamageType];
$DamageScale[mfemale, $DiscDamageType] = $DamageScale[marmor, $DiscDamageType];
$DamageScale[mfemale, $RocketDamageType] = $DamageScale[marmor, $RocketDamageType];
$DamageScale[mfemale, $GrenadeDamageType] = $DamageScale[marmor, $GrenadeDamageType];
$DamageScale[mfemale, $DebrisDamageType] = $DamageScale[marmor, $DebrisDamageType];
$DamageScale[mfemale, $LaserDamageType] = $DamageScale[marmor, $LaserDamageType]; 
$DamageScale[mfemale, $MortarDamageType] = $DamageScale[marmor, $MortarDamageType];
$DamageScale[mfemale, $BlasterDamageType] = $DamageScale[marmor, $BlasterDamageType];
$DamageScale[mfemale, $ELFDamageType] = $DamageScale[marmor, $ELFDamageType];
$DamageScale[mfemale, $MineDamageType] = $DamageScale[marmor, $MineDamageType];

$ItemMax[mfemale, Blaster] = $ItemMax[marmor, Blaster];
$ItemMax[mfemale, Chaingun] = $ItemMax[marmor, Chaingun];
$ItemMax[mfemale, Disclauncher] = $ItemMax[marmor, Disclauncher];
$ItemMax[mfemale, GrenadeLauncher] = $ItemMax[marmor, GrenadeLauncher];
$ItemMax[mfemale, Mortar] = $ItemMax[marmor, Mortar];
$ItemMax[mfemale, PlasmaGun] = $ItemMax[marmor, PlasmaGun];
$ItemMax[mfemale, FlameThrower] = $ItemMax[marmor, FlameThrower];
$ItemMax[mfemale, LaserRifle] = $ItemMax[marmor, LaserRifle];
$ItemMax[mfemale, EnergyRifle] = $ItemMax[marmor, EnergyRifle];
$ItemMax[mfemale, MineAmmo] = $ItemMax[marmor, MineAmmo];
$ItemMax[mfemale, Grenade] = $ItemMax[marmor, Grenade];
$ItemMax[mfemale, Beacon] = $ItemMax[marmor, Beacon];

$ItemMax[mfemale, BulletAmmo] = $ItemMax[marmor, BulletAmmo];
$ItemMax[mfemale, PlasmaAmmo] = $ItemMax[marmor, PlasmaAmmo];
$ItemMax[mfemale, DiscAmmo] = $ItemMax[marmor, DiscAmmo];
$ItemMax[mfemale, GrenadeAmmo] = $ItemMax[marmor, GrenadeAmmo];
$ItemMax[mfemale, MortarAmmo] = $ItemMax[marmor, MortarAmmo];

$ItemMax[mfemale, EnergyPack] = $ItemMax[marmor, EnergyPack];
$ItemMax[mfemale, RepairPack] = $ItemMax[marmor, RepairPack];
$ItemMax[mfemale, ShieldPack] = $ItemMax[marmor, ShieldPack];
$ItemMax[mfemale, SensorJammerPack] = $ItemMax[marmor, SensorJammerPack];
$ItemMax[mfemale, MotionSensorPack] = $ItemMax[marmor, MotionSensorPack];
$ItemMax[mfemale, PulseSensorPack] = $ItemMax[marmor, PulseSensorPack];
$ItemMax[mfemale, DeployableSensorJammerPack] = $ItemMax[marmor, DeployableSensorJammerPack];
$ItemMax[mfemale, CameraPack] = $ItemMax[marmor, CameraPack];
$ItemMax[mfemale, TurretPack] = $ItemMax[marmor, TurretPack];
$ItemMax[mfemale, AmmoPack] = $ItemMax[marmor, AmmoPack];
$ItemMax[mfemale, RepairKit] = $ItemMax[marmor, RepairKit];
$ItemMax[mfemale, DeployableInvPack] = $ItemMax[marmor, DeployableInvPack];
$ItemMax[mfemale, DeployableAmmoPack] = $ItemMax[marmor, DeployableAmmoPack];

$MaxWeapons[mfemale] = $MaxWeapons[marmor];

//------------------------------------------------------------------
// Medium female data:
//------------------------------------------------------------------
PlayerData mfemale
{
  className = $Armor[_default, className]; 
  shapeFile = "mfemale";
  flameShapeName = "mflame";
  shieldShapeName = "shield";
  damageSkinData = "armorDamageSkins";
  debrisId = playerDebris;
  shadowDetailMask = 1;

  canCrouch = true;
  jetSound = SoundJetLight;
  mapFilter = 1;
  mapIcon = "M_player";
  visibleToSensor = True;

  maxJetSideForceFactor = $Armor[_default, handling, jetStrafe];
  maxJetForwardVelocity = $Armor[_default, handling, jetForward]; 
  minJetEnergy = $Armor[_default, energy, min];
  jetForce = $Armor[_default, handling, force];
  jetEnergyDrain = $Armor[_default, handling, drain];

  maxDamage = $Armor[_default, health];
  maxForwardSpeed = $Armor[_default, handling, forward];
  maxBackwardSpeed = $Armor[_default, handling, backward];
  maxSideSpeed = $Armor[_default, handling, strafe];
  groundForce = $Armor[_default, handling, ground];
  mass = $Armor[_default, handling, mass];
  groundTraction = $Armor[_default, handling, traction];

  maxEnergy = $Armor[_default, energy, max];
  drag = $Armor[_default, handling, drag];
  density = $Armor[_default, handling, density];

  minDamageSpeed = $Armor[_default, damageRatio, speed]; 
  damageScale = $Armor[_default, damageRatio, scale];

  jumpImpulse = $Armor[_default, handling, impulse];
  jumpSurfaceMinDot = $Armor[_default, handling, surface];

  // animation data:
  // animation name, one shot, exclude, direction,
  // firstPerson, chaseCam, thirdPerson, signalThread

  // movement animations:
  animData[0]  = { "root", none, 1, true, true, true, false, 0 };
  animData[1]  = { "run", none, 1, true, false, true, false, 3 };
  animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
  animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
  animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
  animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
  animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
  animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
  animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
  animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
  animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
  animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
  animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
  animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
  animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
  animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
  animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
  animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
  animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
  animData[19] = { "jet", none, 1, true, true, true, false, 3 };

  // misc. animations:
  animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
  animData[21] = { "throw", none, 1, true, false, false, false, 3 };
  animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
  animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
  animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
  // death animations:
  animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
  animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

  // signal moves:
  animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
  animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
  animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
  animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
  animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

  // celebraton animations:
  animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
  animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
  animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

  // taunt anmations:
  animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
  animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

  // poses:
  animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
  animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

  // Bonus wave
  animData[50] = { "wave", none, 1, true, false, false, true, 1 };

  rFootSounds = {
    SoundMFootRSoft,
    SoundMFootRHard,
    SoundMFootRSoft,
    SoundMFootRHard,
    SoundMFootRSoft,
    SoundMFootRSoft,
    SoundMFootRSoft,
    SoundMFootRHard,
    SoundMFootRSnow,
    SoundMFootRSoft,
    SoundMFootRSoft,
    SoundMFootRSoft,
    SoundMFootRSoft,
    SoundMFootRSoft,
    SoundMFootRSoft
  }; 

  lFootSounds = {
    SoundMFootLSoft,
    SoundMFootLHard,
    SoundMFootLSoft,
    SoundMFootLHard,
    SoundMFootLSoft,
    SoundMFootLSoft,
    SoundMFootLSoft,
    SoundMFootLHard,
    SoundMFootLSnow,
    SoundMFootLSoft,
    SoundMFootLSoft,
    SoundMFootLSoft,
    SoundMFootLSoft,
    SoundMFootLSoft,
    SoundMFootLSoft
  };

  footPrints = { 2, 3 };

  boxWidth = 0.7;
  boxDepth = 0.7;
  boxNormalHeight = 2.4;
  boxCrouchHeight = 1.7;

  boxNormalHeadPercentage  = 0.84;
  boxNormalTorsoPercentage = 0.55;

  boxHeadLeftPercentage  = 0;
  boxHeadRightPercentage = 1;
  boxHeadBackPercentage  = 0;
  boxHeadFrontPercentage = 1;
};