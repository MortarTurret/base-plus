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

ExplosionData criticalBlasterExp {
   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   faceCamera = true;
   hasLight   = true;
   lightRange = 3.0;
   radFactors = { 1.0, 1.0, 1.0 };
   randomSpin = true;
   shapeName = "fusionex.dts";
   shiftPosition = True;
   soundId   = turretExplosion;
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

RocketData CriticalBlasterBolt {
  acceleration        = BlasterBolt.acceleration;
  bulletShapeName     = BlasterBolt.bulletShapeName;
  collisionRadius     = BlasterBolt.collisionRadius;
  damageClass         = 1;
  damageType          = $BlasterDamageType;
  damageValue         = BlasterBolt.damageValue * 3;
  explosionRadius     = BlasterBolt.explosionRadius * 10;
  explosionTag        = criticalBlasterExp;
  inheritedVelocityScale = BlasterBolt.inheritedVelocityScale;
  kickBackStrength    = BlasterBolt.kickBackStrength * 1.5;
  lightColor          = BlasterBolt.lightColor;
  lightRange          = BlasterBolt.lightRange * 3;
  liveTime            = BlasterBolt.liveTime;
  mass                = BlasterBolt.mass;
  muzzleVelocity      = BlasterBolt.muzzleVelocity;
  terminalVelocity    = BlasterBolt.terminalVelocity;
  totalTime           = BlasterBolt.totalTime;
  trailLength         = BlasterBolt.trailLength;
  trailType           = BlasterBolt.trailType;
  trailWidth          = BlasterBolt.trailWidth;
};

//--------------------------------------------------------------------------- //
//- Image defs                                                                //
//--------------------------------------------------------------------------- //
ItemImageData BlasterImage {
  shapeFile  = "energygun";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0;
  fireTime = 0.3;
  minEnergy = 5;
  maxEnergy = 6; // unused
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

//--------------------------------------------------------------------------- //
//- Callback event methods                                                    //
//--------------------------------------------------------------------------- //
function BlasterImage::onFire(%player, %slot) {
  %energy = GameBase::getEnergy(%player);
  %muzzle = GameBase::getMuzzleTransform(%player);
  %velocity = Item::getVelocity(%player);

  %criticalBound = 100;
  %criticalChance = getRangedRoundedRandom(0, %criticalBound + 1);

  error( %criticalBound @ " : " @ %criticalChance );

  if(%energy >= BlasterImage.minEnergy) {
    GameBase::setEnergy(%player, %energy - BlasterImage.minEnergy);
    Projectile::spawnProjectile((%criticalChance == %criticalBound) ? "CriticalBlasterBolt" : "BlasterBolt", %muzzle, %player, %velocity, $los::object);
  }

  else {
    Player::trigger(%player, $WeaponSlot, false);
  }
}