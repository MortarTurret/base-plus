$ammo = "PlasmaAmmo";
$weapon = "FlameThrower";
$WeaponAmmo[$weapon] = $ammo;
$AutoUse[$weapon] = true;

Item::AddWeaponToSwitchCycle( $weapon );

//----------------------------------------------------------------------------
GrenadeData FlameThrowerProjectile
{	
	collideWithOwner = True;
	collisionRadius = 0.2;
	damageClass = 1;
	damageType = $PlasmaDamageType;
	damageValue = 0.02;
	elasticity = 0.3;
	explosionRadius = 6;
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
	accuFire = true;
  ammoType = PlasmaAmmo;
  fireTime = 0.1;
  lightColor = { 1, 0.6, 0.2 };
  lightRadius = 3;
  lightTime = 1;
  lightType = 3;
  mountOffset = { 0, 0.08, -0.22  };
  mountPoint = 0;
  mountRotation = { 0, 3.14, 0 };
  reloadTime = 0.1;
  sfxActivate = SoundPickUpWeapon;
  sfxFire = SoundJetHeavy;
  sfxReload = SoundJetHeavy;
  shapeFile = "grenadeL";
  weaponType = 2;
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
	shapeFile = "grenadeL";
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

function FlameThrower::onMount(%player, %slot) {
  %player.__firingCycle = "even";
  %player.__weaponCanHeat = true;

  Player::mountItem(%player, FlameThrowerExtra, 4);
  Player::mountItem(%player, FlameThrowerExtra2, 6);
}

function FlameThrowerImage::spawnFire(%player, %slot) {
	%ammo = Player::getItemCount(%player, $WeaponAmmo["FlameThrower"]);
  
  if(%ammo > 0) {
    %muzzle = GameBase::getMuzzleTransform(%player);
    %velocity = Item::getVelocity(%player);
    %heat = %player.__weaponHeat;

    if(!Player::getMountedItem(%player, 4)) {
      Player::mountItem(%player, FlameThrowerExtra, 4);
    }

    if(%player.__weaponHeat >= 1) {
      Player::trigger(%player, $WeapontSlot, false);
		  playSound(SoundFireSeeking, GameBase::getPosition(%player));

      {
        %client = Player::getClient(%player);
        %playerName = Client::getName(%client);
        %damageLevel = GameBase::getDamageLevel(%player) + 0.1;
        %maxDamage = GameBase::getDataName(%player).maxDamage;

        Player::setDamageFlash(%player, %damageLevel);

        if(%damageLevel >= %maxDamage)
        {
        	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
          %message = sprintf( $deathMsg[-3, %ridx], %player.__name, %player.__pronoun );

					Player::setAnimation(%player, $PlayerAnim::DieForward);
          Player::kill(%client);
          message::all( 0, %msg, $DeathMessageMask );
        }

        else {
          GameBase::setDamageLevel(%player, %damageLevel);
        }
      }
    }

    else {
      Projectile::spawnProjectile("FlameThrowerProjectile", %muzzle, %player, %velocity, $los::object);

      if(%player.__firing) {
        %player.__weaponHeat = %player.__weaponHeat ;
        Player::decItemCount(%player, $WeaponAmmo["FlameThrower"], 1);

        schedule("FlameThrowerImage::spawnFire(" @ %player @ "," @ %slot @ ");", 0.1);
      }
    }
  }
}

function FlameThrowerImage::onActivate(%player, %slot) {
  schedule("FlameThrowerImage::spawnFire(" @ %player @ "," @ %slot @ ");", 0.35);
}

function CommandPackImage::onDeactivate(%player, %imageSlot)
{
  %ammo = Player::getItemCount(%player, $WeaponAmmo["FlameThrower"]);
  
	if(%ammo > 0) {
    if(!Player::getMountedItem(%player, 4)) {
      Player::mountItem(%player, FlameThrowerExtra, 4);
    }
  }

  else {
    %player.__firingCycle = "even";

    Player::unmountItem(%player, 4);
  }
  
  GameBase::playSound(%player, SoundDryFire, 0);
}

function FlameThrower::onUnmount(%player, %slot) {
  %player.__firingCycle = "even";
  %player.__weaponCanHeat = false;

  Player::unmountItem(%player, 4);
  Player::unmountItem(%player, 6);
}