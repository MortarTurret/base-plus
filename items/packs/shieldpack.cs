//----------------------------------------------------------------------------
ItemImageData ShieldPackImage
{
  firstPerson = false;
  maxEnergy = 9;   // Energy/sec for sustained weapons
  minEnergy = 4;
  mountPoint = 2;
  sfxFire = SoundShieldOn;
  shapeFile = "shieldPack";
  weaponType = 2;  // Sustained
};

ItemData ShieldPack
{
	className = "Backpack";
	description = "Shield Pack";
	hiliteOnActive = true;
	hudIcon = "shieldpack";
	imageType = ShieldPackImage;
	price = 175;
	shadowDetailMask = 4;
	shapeFile = "shieldPack";
	showWeaponBar = true;
  heading = "cBackpacks";
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.012;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
}
