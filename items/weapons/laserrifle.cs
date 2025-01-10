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
   laserBitmapName   = "laserPulse.png";
   hitName           = "laserhit.dts";

   damageConversion  = 0.007;
   baseDamageType    = $LaserDamageType;

   beamTime          = 1;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};


//----------------------------------------------------------------------------

ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 1;
	fireTime = 1;
	minEnergy = 15;
	maxEnergy = 75;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
  sfxReload = SoundPackFail;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
  description = "Laser Rifle";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "sniper";
  heading = "bWeapons";
  shadowDetailMask = 4;
  imageType = LaserRifleImage;
  price = 200;
  showWeaponBar = true;
};

function LaserRifle::onUse(%player,%item) {
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
		Weapon::onUse(%player,%item);

	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Energy Pack to use Laser Rifle."); 
}