$weapon = "Blaster";
$AutoUse[$weapon] = false;
$WeaponAmmo[$weapon] = "";
Item::AddWeaponToSwitchCycle( $weapon );
Item::AddDamageType( "Blaster" );

//--------------------------------------------------------------------------- //
//- Explosion defs                                                            //
//--------------------------------------------------------------------------- //
ExplosionData blasterExp {
  colors[0]  = { 0.25, 0.50, 100 };
  colors[1]  = { 0.25, 0.50, 100 };
  colors[2]  = { 0.25, 0.50, 100 };
  faceCamera = true;
  hasLight   = true;
  lightRange = 3.0;
  radFactors = { 0.5, 1.0, 1.0 };
  randomSpin = true;
  shapeName = "enex.dts";
  shiftPosition = True;
  soundId  = energyExplosion;
  timeOne  = 0.750;
  timeZero = 0.450;
};

//--------------------------------------------------------------------------- //
//- Projectile defs                                                           //
//--------------------------------------------------------------------------- //
RocketData BlasterBolt {
  acceleration        = 5.0;
  bulletShapeName     = "breath.dts";
  collisionRadius     = 0.0;
  damageClass         = 0;
  damageType          = $BlasterDamageType;
  damageValue         = 0.125;
  explosionRadius     = 0.5;
  explosionTag        = blasterExp;
  inheritedVelocityScale = 0.5;
  kickBackStrength    = 150.0;
  lightColor          = { 0.25, 0.50, 1.25 };
  lightRange          = 3.0;
  liveTime            = 1.125;
  mass                = 1.0;
  muzzleVelocity      = 200.0;
  terminalVelocity    = 200.0;
  totalTime           = 2.0;
  trailLength         = 15;
  trailType           = 1;
  trailWidth          = 0.3;
};

//--------------------------------------------------------------------------- //
//- Image defs                                                                //
//--------------------------------------------------------------------------- //
ItemImageData BlasterImage {
  shapeFile  = "energygun";
  mountPoint = 0;
  weaponType = 0; // Single Shot
  reloadTime = 0;
  fireTime = 0.3;
  minEnergy = 5;
  maxEnergy = 6;
  projectileType = BlasterBolt;
  accuFire = true;
  sfxFire = SoundFireBlaster;
  sfxActivate = SoundPickUpWeapon;
};

//--------------------------------------------------------------------------- //
//- Item defs                                                                 //
//--------------------------------------------------------------------------- //
ItemData Blaster {
  heading = "bWeapons";
  description = "Blaster";
  className = "Weapon";
  shapeFile  = "energygun";
  hudIcon = "blaster";
  shadowDetailMask = 4;
  imageType = BlasterImage;
  price = 85;
  showWeaponBar = true;
};
