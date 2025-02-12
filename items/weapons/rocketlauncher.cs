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
  shapeFile = "paintgun";
  spinUpTime = 0;
  weaponType = 0;
};

ItemImageData RocketLauncherGhostImage {
  accuFire = false;
  ammoType = RocketLauncherImage.ammoType;
  fireTime = 3.0;
  lightColor = { 0.6, 1, 1.0 };
  lightRadius = 3;
  lightTime = 1;
  lightType = 3;
  mountPoint = 0;
  mountRotation = { 0, 3.14, 0 };
  reloadTime = 1.25;
  sfxFire = SoundFireMortar;
  sfxReady = SoundMortarIdle;
  sfxReload = SoundMortarReload;
  shapeFile = "mortargun";
  weaponType = 0;
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

ItemData RocketLauncherGhost
{
  className = RocketLauncher.className;
  description = RocketLauncher.description;
  heading = RocketLauncher.heading;
  hudIcon = RocketLauncher.hudIcon;
  imageType = RocketLauncherGhostImage;
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
  Player::mountItem(%player, RocketLauncherGhost, 4);
}

function RocketLauncher::onSynActivate(%player) {
  %ammo = Player::getItemCount(%player, $WeaponAmmo[Mortar]);

  if(%ammo) {
    %lockDistance = getAVR();
		%transform = GameBase::getMuzzleTransform(%player);
		%velocity = Item::getVelocity(%player);

    if(GameBase::getLOSInfo(%player, %lockDistance)) {     
			%type = getObjectType($los::object);
			%targeted = GameBase::getOwnerClient($los::object);

      error(%type);

			if(%type == "Player" || %type == "Flier") {
        Player::trigger(%player, 4, true);
				Player::decItemCount(%player,$WeaponAmmo[Mortar], 1);

        playSound(mine_act, GameBase::getPosition(%player), 0);

        Projectile::spawnProjectile("PersonnelMissile", %transform, %player, %velocity, $los::object); 
        Player::trigger(%player, 4, false);
			}

			else {
        GameBase::playSound(%player, SoundPackFail, 0);
			}
		}

		else {
      GameBase::playSound(%player, SoundPackFail, 0);
		} 
  }
}

function RocketLauncher::onSynDectivate(%player) {
  Player::trigger(%player, 4, false);
}

function RocketLauncher::onUnmount(%player, %slot) {
  Player::trigger(%player, 4, false);

  Player::unmountItem(%player, $WeaponSlot);
  Player::unmountItem(%player, 4);
} 