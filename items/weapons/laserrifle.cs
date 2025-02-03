$weapon = "LaserRifle";
$AutoUse[$weapon] = true;
$WeaponAmmo[$weapon] = "";
Item::AddWeaponToSwitchCycle( $weapon );
Item::AddDamageType( "Laser" );


//-------------------------------------- 
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------
LaserData sniperLaser
{
  baseDamageType    = $LaserDamageType;
  beamTime          = 0.5;
  damageConversion  = 0.007;
  detachFromShooter = true;
  hitName           = "enex.dts";
  hitSoundId        = SoundLaserHit;
  laserBitmapName   = "lightningNew.png";
  lightColor        = { 0.25, 0.50, 1.25 };
  lightRange        = 2.0;
};

TargetLaserData targetLaser
{
  baseDamageType    = 0;
  damageConversion  = 0.0;
  detachFromShooter = false;
  laserBitmapName   = "paintPulse.png";
  lightColor        = { 0.25, 1.0, 0.25 };
  lightRange        = 2.0;
};

//----------------------------------------------------------------------------

ItemImageData LaserRifleImage
{
  accuFire = true;
  fireTime = 0.5;
  lightColor = { 1, 0, 0 };
  lightRadius = 2;
  lightTime = 1;
  lightType = 3;  // Weapon Fire
  maxEnergy = 60;
  minEnergy = 10;
  mountPoint = 0;
  projectileType = SniperLaser;
  reloadTime = 0.1;
  sfxActivate = SoundPickUpWeapon;
  sfxFire = SoundFireLaser;
  shapeFile = "sniper";
  weaponType = 0; // Single Shot
};

ItemImageData LaserRifleTargetingImage
{
  accuFire = true;
  lightColor  = { 0.25, 1, 0.25 };
  lightRadius = 1;
  lightTime   = 1;
  lightType   = 3;  // Weapon Fire
  maxEnergy = 0;
  minEnergy = 0;
  mountPoint = 0;
  mountRotation = { 1.57, 0, 0 };
  projectileType = targetLaser;
  reloadTime = 1.0;
  shapeFile = "force";
  weaponType = 2; // Sustained
};

ItemData LaserRifle
{
  className = "Weapon";
  description = "Laser Rifle";
  heading = "bWeapons";
  hudIcon = "sniper";
  imageType = LaserRifleImage;
  price = 200;
  shadowDetailMask = 4;
  shapeFile = "sniper";
  showWeaponBar = true;
};

ItemData LaserRifleTargeting
{
  className     = "Weapon";
  description   = "Targeting Laser";
  heading       = "bWeapons";
  hudIcon       = "targetlaser";
  imageType     = LaserRifleTargetingImage;
  price         = 0;
  shadowDetailMask = 4;
  shapeFile     = "force";
  showInventory = false;
  showWeaponBar = false;
};

function LaserRifle::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) {
		Weapon::onUse(%player,%item);
  }

	else {
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Energy Pack to use Laser Rifle."); 
  }
}

function LaserRifle::onMount(%player, %slot) {
  Player::mountItem(%player, LaserRifleTargeting, 4);
}

function LaserRifle::onCrouch(%player) {
  Player::trigger(%player, 4, true);
}

function LaserRifle::onUncrouch(%player) {
  Player::trigger(%player, 4, false);
}

function LaserRifle::onUnmount(%player, %slot) {
  Player::unmountItem(%player, 4);
}