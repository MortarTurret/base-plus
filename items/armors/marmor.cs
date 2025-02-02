//----------------------------------------------------------------------------
// Medium Armor
//----------------------------------------------------------------------------
$DamageScale[marmor, $LandingDamageType] = $Armor[_default, damageRatio, $LandingDamageType];
$DamageScale[marmor, $ImpactDamageType] = $Armor[_default, damageRatio, $ImpactDamageType];
$DamageScale[marmor, $CrushDamageType] = $Armor[_default, damageRatio, $CrushDamageType];
$DamageScale[marmor, $ChaingunDamageType] = $Armor[_default, damageRatio, $ChaingunDamageType];
$DamageScale[marmor, $PlasmaDamageType] = $Armor[_default, damageRatio, $PlasmaDamageType];
$DamageScale[marmor, $TurretDamageType] = $Armor[_default, damageRatio, $TurretDamageType];
$DamageScale[marmor, $DiscDamageType] = $Armor[_default, damageRatio, $DiscDamageType];
$DamageScale[marmor, $RocketDamageType] = $Armor[_default, damageRatio, $RocketDamageType];
$DamageScale[marmor, $GrenadeDamageType] = $Armor[_default, damageRatio, $GrenadeDamageType];
$DamageScale[marmor, $DebrisDamageType] = $Armor[_default, damageRatio, $DebrisDamageType];
$DamageScale[marmor, $LaserDamageType] = $Armor[_default, damageRatio, $LaserDamageType]; 
$DamageScale[marmor, $MortarDamageType] = $Armor[_default, damageRatio, $MortarDamageType];
$DamageScale[marmor, $BlasterDamageType] = $Armor[_default, damageRatio, $BlasterDamageType];
$DamageScale[marmor, $ELFDamageType] = $Armor[_default, damageRatio, $ELFDamageType];
$DamageScale[marmor, $MineDamageType] = $Armor[_default, damageRatio, $MineDamageType];

$ItemMax[marmor, Blaster] = $Armor[_default, weapon, Blaster];
$ItemMax[marmor, Chaingun] = $Armor[_default, weapon, Chaingun];
$ItemMax[marmor, Disclauncher] = $Armor[_default, weapon, Disclauncher];
$ItemMax[marmor, GrenadeLauncher] = $Armor[_default, weapon, GrenadeLauncher];
$ItemMax[marmor, Mortar] = $Armor[_default, weapon, Mortar];
$ItemMax[marmor, PlasmaGun] = $Armor[_default, weapon, PlasmaGun];
$ItemMax[marmor, FlameThrower] = $Armor[_default, weapon, FlameThrower];
$ItemMax[marmor, LaserRifle] = $Armor[_default, weapon, LaserRifle];
$ItemMax[marmor, EnergyRifle] = $Armor[_default, weapon, EnergyRifle];
$ItemMax[marmor, MineAmmo] = $Armor[_default, misc, MineAmmo] + 3;
$ItemMax[marmor, Grenade] = $Armor[_default, misc, Grenade];
$ItemMax[marmor, Beacon] = $Armor[_default, misc, Beacon] - 1;

$ItemMax[marmor, BulletAmmo] = $Armor[_default, ammo, BulletAmmo];
$ItemMax[marmor, PlasmaAmmo] = $Armor[_default, ammo, PlasmaAmmo];
$ItemMax[marmor, DiscAmmo] = $Armor[_default, ammo, DiscAmmo];
$ItemMax[marmor, GrenadeAmmo] = $Armor[_default, ammo, GrenadeAmmo];
$ItemMax[marmor, MortarAmmo] = $Armor[_default, ammo, MortarAmmo];

$ItemMax[marmor, EnergyPack] = $Armor[_default, pack, EnergyPack];
$ItemMax[marmor, RepairPack] = $Armor[_default, pack, RepairPack];
$ItemMax[marmor, ShieldPack] = $Armor[_default, pack, ShieldPack];
$ItemMax[marmor, CommandPack] = $Armor[_default, pack, CommandPack];
$ItemMax[marmor, SensorJammerPack] = $Armor[_default, pack, SensorJammerPack];
$ItemMax[marmor, MotionSensorPack] = $Armor[_default, pack, MotionSensorPack];
$ItemMax[marmor, PulseSensorPack] = $Armor[_default, pack, PulseSensorPack];
$ItemMax[marmor, DeployableSensorJammerPack] = $Armor[_default, pack, DeployableSensorJammerPack];
$ItemMax[marmor, CameraPack] = $Armor[_default, pack, CameraPack];
$ItemMax[marmor, TurretPack] = $Armor[_default, pack, TurretPack];
$ItemMax[marmor, HeavyTurretPack] = $Armor[_default, pack, HeavyTurretPack];
$ItemMax[marmor, AmmoPack] = $Armor[_default, pack, AmmoPack];
$ItemMax[marmor, RepairKit] = $Armor[_default, pack, RepairKit];
$ItemMax[marmor, DeployableInvPack] = $Armor[_default, pack, DeployableInvPack];
$ItemMax[marmor, DeployableAmmoPack] = $Armor[_default, pack, DeployableAmmoPack];

$MaxWeapons[marmor] = $Armor[_default, weapon, All];

//------------------------------------------------------------------
// Medium Armor data:
//------------------------------------------------------------------
PlayerData marmor
{
  className = $Armor[_default, className]; 
  shapeFile = "marmor";
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
  // animation name, one shot, exclude, direction
  // firstPerson, chaseCam, thirdPerson, signalThread

  // movement animations:
  animData[0]  = { "root", none, 1, true, true, true, false, 0 };
  animData[1]  = { "run", none, 1, true, false, true, false, 3 };
  animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
  animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
  animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
  animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
  animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
  animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
  animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
  animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
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
  animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };

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

  boxNormalHeadPercentage  = 0.83;
  boxNormalTorsoPercentage = 0.49;

  boxHeadLeftPercentage  = 0;
  boxHeadRightPercentage = 1;
  boxHeadBackPercentage  = 0;
  boxHeadFrontPercentage = 1;
};