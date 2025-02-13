$ammo = "MortarAmmo";
$weapon = "RocketLauncher";
$AutoUse[$weapon] = true;
$WeaponAmmo[$weapon] = $ammo;

Item::AddWeaponToSwitchCycle( $weapon );

//--------------------------------------------------------------------------- //
//- Projectile defs                                                           //
//--------------------------------------------------------------------------- //
SeekingMissileData PersonnelMissile
{
  bulletShapeName = "rocket.dts";
  collisionRadius = 0.25;
  damageClass      = 1;
  damageType       = $RocketDamageType;
  damageValue      = 0.5;
  explosionRadius  = 7.5;
  explosionTag    = rocketExp;
  inheritedVelocityScale = 0.75;
  kickBackStrength = 150.0;
  lightColor       = { 0.4, 0.4, 1.0 };
  lightRange       = 5.0;
  liveTime          = 6;
  mass            = 2.0;
  muzzleVelocity    = 85.0;
  nonSeekingTurningRadius = getAVR() / 2;
  proximityDist     = getAVR() / 25;
  seekingTurningRadius    = getAVR() / 10;
  smokeDist         = 3.00;
  soundId = SoundJetLight;
  totalTime         = 6;
};

//--------------------------------------------------------------------------- //
//- Image defs                                                                //
//--------------------------------------------------------------------------- //
ItemImageData RocketLauncherImage
{
  accuFire = false;
  ammoType = MortarAmmo;
  fireTime = 0;
  mountOffset = { 0, 0.05, -0.01 };
  mountPoint = 0;
  mountRotation= { 0, 3.14, 0 };
  reloadTime = 0;
  sfxActivate = SoundPickUpWeapon;
  shapeFile = "breath";
  spinUpTime = 0;
  weaponType = 0;
};

ItemImageData RocketLauncherChassisImage {
  accuFire = false;
  ammoType = RocketLauncherImage.ammoType;
  fireTime = 3.0;
  lightColor = { 0.6, 1, 1.0 };
  lightRadius = 3;
  lightTime = 1;
  lightType = 3;
  mountOffset = { 0, -0.5, 0 };
  mountPoint = 0;
  mountRotation = { 0, -1.57, -1.57 };
  reloadTime = 1.25;
  sfxFire = SoundFireMortar;
  sfxReady = SoundMortarIdle;
  sfxReload = SoundMortarReload;
  shapeFile = "invent_remote";
  weaponType = 0;
};

ItemImageData RocketLauncherExtraImage {
  accuFire = false;
  ammoType = RocketLauncherImage.ammoType;
  fireTime = 3.0;
  lightColor = { 0.6, 1, 1.0 };
  lightRadius = 3;
  lightTime = 1;
  lightType = 3;
  mountOffset = { 0.07, 0.05, 0.01 };
  mountPoint = 0;
  mountRotation = { 1.37, -1.57, 0 };
  reloadTime = 1.25;
  shapeFile = "discammo";
  weaponType = 0;
};

ItemImageData RocketLauncherGoLightImage {
	maxEnergy = 0;
	minEnergy = 0;
	reloadTime = 1.0;
	sfxFire = SoundUseAmmoStation;
  accuFire = false;
  ammoType = RocketLauncherImage.ammoType;
  fireTime = 3.0;
  lightColor = { 0.6, 1, 1.0 };
  lightRadius = 3;
  lightTime = 1;
  lightType = 3;
  mountOffset = { 0, -0.15, 0.1 };
  mountPoint = 0;
  mountRotation = { 1.14, 0, 3.14 };
  shapeFile = "paintgun";
  weaponType = 2;
};

//--------------------------------------------------------------------------- //
//- Item defs                                                                 //
//--------------------------------------------------------------------------- //
ItemData RocketLauncher
{
  className = "Weapon";
  description = "Rocket Launcher";
  heading = "bWeapons";
  hudIcon = "compass";
  imageType = RocketLauncherImage;
  price = 450;
  shadowDetailMask = 4;
  shapeFile = "mortargun";
  showWeaponBar = true;
};

ItemData RocketLauncherChassis
{
  className = RocketLauncher.className;
  description = RocketLauncher.description;
  heading = RocketLauncher.heading;
  hudIcon = RocketLauncher.hudIcon;
  imageType = RocketLauncherChassisImage;
  price = 0;
  shadowDetailMask = RocketLauncher.shadowDetailMask;
  shapeFile = RocketLauncher.shapeFile;
  showInventory = false;
  showWeaponBar = false;
};

ItemData RocketLauncherExtra
{
  className = RocketLauncher.className;
  description = RocketLauncher.description;
  heading = RocketLauncher.heading;
  hudIcon = RocketLauncher.hudIcon;
  imageType = RocketLauncherExtraImage;
  price = 0;
  shadowDetailMask = RocketLauncher.shadowDetailMask;
  shapeFile = RocketLauncher.shapeFile;
  showInventory = false;
  showWeaponBar = false;
};

ItemData RocketLauncherGoLight
{
  className = RocketLauncher.className;
  description = RocketLauncher.description;
  heading = RocketLauncher.heading;
  hudIcon = RocketLauncher.hudIcon;
  imageType = RocketLauncherGoLightImage;
  price = 0;
  shadowDetailMask = RocketLauncher.shadowDetailMask;
  shapeFile = RocketLauncher.shapeFile;
  showInventory = false;
  showWeaponBar = false;
};

//--------------------------------------------------------------------------- //
//- Callback event methods                                                    //
//--------------------------------------------------------------------------- //
function RocketLauncher::onMount(%player, %slot) {
  Player::mountItem(%player, RocketLauncher, $WeaponSlot);
  Player::mountItem(%player, RocketLauncherChassis, 4);
  Player::mountItem(%player, RocketLauncherGoLight, 5);
  Player::mountItem(%player, RocketLauncherExtra, 6);
}

function RocketLauncher::whileMounted(%player, %slot) {  
  %lockDistance = getAVR();
  
  if(GameBase::getLOSInfo(%player, %lockDistance)) {
    %type = getObjectType($los::object);

    if(%type == "Player" || %type == "Flier" || %type == "Turret") {
      if(!Player::isTriggered(%player, 5)) {
        error("LOCK " @ %type);

        Player::trigger(%player, 5, true);
      }
		}

    else {
      if(Player::isTriggered(%player, 5)) {
        error("FAIL " @ %type);

        Player::trigger(%player, 5, false);
      }
		}
  }
}

function RocketLauncher::onSynActivate(%player) {
  %ammo = Player::getItemCount(%player, $WeaponAmmo[Mortar]);  
  %client = Player::getClient(%player);

  if(%ammo) {
    %lockDistance = getAVR();
		%transform = GameBase::getMuzzleTransform(%player);
		%velocity = Item::getVelocity(%player);

    if(GameBase::getLOSInfo(%player, %lockDistance)) {
			%type = getObjectType($los::object);

			if(%type == "Player" || %type == "Flier") {
        Player::trigger(%player, 4, true);
        Player::trigger(%player, 6, true);
				Player::decItemCount(%player,$WeaponAmmo[Mortar], 1);

        Projectile::spawnProjectile("PersonnelMissile", %transform, %player, %velocity, $los::object); 
 
        Player::trigger(%player, 4, false);
        Player::trigger(%player, 5, false);
        Player::trigger(%player, 6, false);

        GameBase::playSound(mine_act, GameBase::getPosition(%player), 0);
        Client::sendMessage(%client, 0, "Invalid target.");
			}

			else {
        GameBase::playSound(%player, SoundPackFail, 0);
        Client::sendMessage(%client, 1, "Invalid target.");
			}
		}

		else {
      GameBase::playSound(%player, SoundPackFail, 0);
      Client::sendMessage(%client, 1, "No target.");
		} 
  }

  else {
    GameBase::playSound(%player, SoundPackFail, 0);
    Client::sendMessage(%client, 1, "Ammunition depleted.");
  } 
}

function RocketLauncher::onSynDectivate(%player) {
  Player::trigger(%player, 4, false);
  Player::trigger(%player, 5, false);
  Player::trigger(%player, 6, false);
}

function RocketLauncher::onUnmount(%player, %slot) {
  Player::trigger(%player, 4, false);
  Player::trigger(%player, 5, false);
  Player::trigger(%player, 6, false);

  Player::unmountItem(%player, $WeaponSlot);
  Player::unmountItem(%player, 4);
  Player::unmountItem(%player, 5);
  Player::unmountItem(%player, 6);
} 