$ammo = "PlasmaAmmo";
$weapon = "FlameThrower";
$WeaponAmmo[$weapon] = $ammo;

Item::AddWeaponToSwitchCycle( $weapon );

//--------------------------------------
ExplosionData FlameThrowerExp
{
   shapeName = "shotgunex.dts";
   soundId   = energyExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 1.0, 0.25, 0.25 };
   colors[1]  = { 1.0, 0.25, 0.25 };
   colors[2]  = { 1.0, 0.25, 0.25 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = True;
};

//----------------------------------------------------------------------------
GrenadeData FlameThrowerProjectile
{	
	collideWithOwner = True;
	collisionRadius = 0.2;
	damageClass = 1;
	damageType = $PlasmaDamageType;
	damageValue = 0.2;
	elasticity = 0.3;
	explosionRadius = 8;
	explosionTag = plasmaExp;
	inheritedVelocityScale = 0.5;
	kickBackStrength = 0;
	liveTime = 0.001;
	mass = 1.0;
	maxLevelFlightDist = 150;
	ownerGraceMS = 250;
	projSpecialTime = 0.05;
	smokeDist = 1.5;
	smokeName = "plasmatrail.dts";
	totalTime = 5.0;
  bulletShapeName = "plasmabolt.dts";
};

ItemImageData FlameThrowerImage
{
  accuFire = false;
  ammoType = PlasmaAmmo;
  fireTime = 0.1;
  lightColor = { 0.6, 1, 1.0 };
  lightRadius = 3;
  lightTime = 1;
  lightType = 3;
  mountOffset = { 0, 0.08, -0.22  };
  mountPoint = 0;
  mountRotation = { 0, 3.14, 0 };
  projectileType = FlameThrowerProjectile;
  reloadTime = 0;
  reloadTime = 0.1;
  sfxActivate = SoundPickUpWeapon;
  sfxFire = SoundJetHeavy;
  sfxReload = SoundDryFire;
  shapeFile = "grenadeL";
  weaponType = 0;
};

ItemData FlameThrower
{
	hudIcon = "plasma";
  className = "Weapon";
  description = "Flame Thrower";
  heading = "bWeapons";
  imageType = FlameThrowerImage;
  price = 85;
  shadowDetailMask = 4;
  shapeFile = "energygun";
  showWeaponBar = true;
};

//- EXTRAS 
//----------------------------------------------------------------------------
ItemImageData FlameThrowerExtraImage
{
	fireTime = 0.0;
	mountOffset = { 0, 0.65, -0.36 };
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
  shapeFile = "plasmabolt";
	weaponType = 0;
};

ItemImageData FlameThrowerExtraImage2
{
	fireTime = 0.0;
	mountOffset = { 0, 0.26, -0.45 };
	mountPoint = 0;
	mountRotation = { 1.57, 0, 0 };
  shapeFile = "plasammo";
	weaponType = 0;
};

ItemData FlameThrowerExtra
{
	className = "Weapon";
	hudIcon = "plasma";
	imageType = FlameThrowerExtraImage;
	price = 0;
	shadowDetailMask = 4;
	showInventory = false;
	showWeaponBar = false;
  heading = "bWeapons";
  shapeFile = "force";
};

ItemData FlameThrowerExtra2
{
	className = "Weapon";
	hudIcon = "plasma";
	imageType = FlameThrowerExtraImage2;
	price = 0;
	shadowDetailMask = 4;
	showInventory = false;
	showWeaponBar = false;
  heading = "bWeapons";
  shapeFile = "force";
};

function FlameThrower::onUse(%player, %item) 
{
  if(Player::getMountedItem(%player, $slot) != %item) 
	{	
		Player::mountItem(%player, %item, $slot);
    Player::mountItem(%player, FlameThrowerExtra, 4);
    Player::mountItem(%player, FlameThrowerExtra2, 6);
	}
}

function FlameThrower::onUnmount(%player,%item)
{	
  Player::unmountItem(%player, 4);
  Player::unmountItem(%player, 6);
}
