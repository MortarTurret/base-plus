//----------------------------------------------------------------------------
ItemImageData CommandPackImage
{
  firstPerson = false;
  maxEnergy = 15;
  minEnergy = 5;
  mountPoint = 2;
  sfxFire = SoundUseAmmoStation;
  shapeFile = "mortarpack";
  weaponType = 2;
};

ItemData CommandPack
{
	className = "Backpack";
	description = "Command Pack";
	hiliteOnActive = true;
	hudIcon = "recon";
	imageType = CommandPackImage;
	price = 175;
	shadowDetailMask = 4;
	showWeaponBar = true;
  heading = "cBackpacks";
  shapeFile = "mortarpack";
};

function CommandPack::IsAvailable(%player) {
  return (Player::isTriggered(%player, $BackpackSlot));
}

function CommandPackImage::onActivate(%player, %imageSlot)
{
  %client = Player::getClient(%player);
  %energy = GameBase::getEnergy(%player);

  Player::trigger(%player, $BackpackSlot, true);
  GameBase::playSound(%player, SoundDeploySensor, 0);

  Client::sendMessage(%client, 0, "Remote Command Link Established");

  if(%energy <= 25) {
    Client::sendMessage(%client, 0, "Warning: Remote Command Link Unstable");
  }

  Client::setGuiMode(%client, 2);
}

function CommandPackImage::onDeactivate(%player, %imageSlot)
{
  %client = Player::getClient(%player);
  %controlClient = GameBase::getControlClient(%player);
  %energy = GameBase::getEnergy(%player);

  //- If the user runs out of energy, then present slightly different messaging
  %messageCondition = (%energy <= 5);
  %message = %messageCondition ? "Lost" : "Terminated";
  %messageSound = %messageCondition ? SoundPackFail : SoundPackUse;

  Player::trigger(%player, $BackpackSlot, false);
  GameBase::playSound(%player, %messageSound, 0);

  Client::sendMessage(%client, 0, "Remote Command Link " @ %message);
  Client::setGuiMode(%client, $GuiModePlay);

  Client::setControlObject(%client, %player);
}