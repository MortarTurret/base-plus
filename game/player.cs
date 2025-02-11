$PlayerAnim::Crouching = 25;
$PlayerAnim::DieChest = 26;
$PlayerAnim::DieHead = 27;
$PlayerAnim::DieGrabBack = 28;
$PlayerAnim::DieRightSide = 29;
$PlayerAnim::DieLeftSide = 30;
$PlayerAnim::DieLegLeft = 31;
$PlayerAnim::DieLegRight = 32;
$PlayerAnim::DieBlownBack = 33;
$PlayerAnim::DieSpin = 34;
$PlayerAnim::DieForward = 35;
$PlayerAnim::DieForwardKneel = 36;
$PlayerAnim::DieBack = 37;

//----------------------------------------------------------------------------
$CorpseTimeoutValue = 22;
//----------------------------------------------------------------------------

// Player & Armor data block callbacks
function Player::onAdd(%this) {
	GameBase::setRechargeRate(%this, 8);

  //- -------------------------------- -//
  //- New properties for Player object -//
  //- -------------------------------- -//
  {
    //- Static Properties
    //- -----------------
    //- NOTE: These props DO NOT update within the `::__updateAttrs()` cycle
    {
      %client = Player::getClient(%this);

      %this.__name = Client::getName(%client);
      %this.__pronoun = Client::getPronoun(%client);
    }

    //- Live Properties
    //- ---------------
    //- NOTE: These props DO update within the `::__updateAttrs()` cycle
    {
      %this.__alive = false;          // Boolean: True if the player is currently alive
      %this.__ammo = 0;               // Integer: Player's current ammo for equipped weapon
      %this.__ammoType = "";          // String: Type of ammo used by Player's equipped weapon
      %this.__armor = "Spawn";        // String: Player's equipped armor
      %this.__crouched = false;       // Boolean: True if the player is crouching
      %this.__energy = 0;             // Integer: Player's current energy percentage
      %this.__firing = false;         // Boolean: True if the Player is actively firing
      %this.__firingFor = 0.0;        // Float: How the long player has been firing for
      %this.__health = 0;             // Integer: Player's current health percentage
      %this.__heat = 0.0;             // Float: Player's current heat factor for missiles
      %this.__hot = false;            // Boolean: True if hte Player's heat is > 0.5
      %this.__hotFor = 0.0;           // Float: How long the Player has been hot for
      %this.__jetting = false;        // Boolean: True if Player is currently jetting
      %this.__jettingFor = 0.0;       // Float: How long the Player has been jetting for
      %this.__lastDamaged = 0.0;      // Float: Seconds since the Player was last damaged 
      %this.__lastFire = 0.0;         // Float: Seconds since the Player last fired
      %this.__lastHot = 0.0;          // Float: Seconds since the Player was last hot
      %this.__lastJet = 0.0;          // Float: Seconds since the Player last jetted
      %this.__lastTarget = 0.0;       // Float: Seconds since the Player last targeted
      %this.__lastTrigger = 0.0;      // Float: Seconds since the Player last triggered
      %this.__pack = "";              // String: Player's equipped pack
      %this.__targeting = "";         // String: ID of entity Player is currently targeting via ELF, Repair or TargetLaser
      %this.__targetingFor = 0.0;     // Float: How long the Player has been targeting for
      %this.__triggering = false;     // Boolean: True if the player is holding trigger
      %this.__triggeringFor = 0.0;    // Float: How long the player has been holding trigger
      %this.__weapon = "";            // String: Player's equipped weapon
      %this.__weaponCanHeat = false;  // String: Firing heat factor (for scaling accuracy COF)
      %this.__weaponHeat = 0.0;       // Float: Firing heat factor (for scaling accuracy COF)
    }

    Player::__updateAttrs(%this);
  }
}

//----------------------------------------------------------------------------//
//- New method for tracking player metadata                                  -//
//----------------------------------------------------------------------------//
function Player::__updateAttrs(%this, %bypassCycle) {

  //- --------------------------------------------------------- -//
  //- If the match hasn't started yet, don't update player data -//
  //- --------------------------------------------------------- -//
  {
    //- NOTE: This helps eliminate unwanted behavior from certain built-in 
    //- methods due to how Dynamix decided to code them.  
    if(!$matchStarted) {
      schedule("Player::__updateAttrs(" @ %this @ ");", 0.1);

      return;
    }
  }

  //- ---------------------------------------------- -//
  //- Method scope: Setup shared vars for submethods -//
  //- ---------------------------------------------- -//
  %client = Player::getClient(%this);
  %time = getSimTime();

  //- ---------------------------------- -//
  //- Local scope: Update equipped armor -//
  //- ---------------------------------- -//
  {
    %this.__alive = (Player::isDead(%this)) ? false : true;
  }

  //- ---------------------------------- -//
  //- Local scope: Update equipped armor -//
  //- ---------------------------------- -//
  {
    %armor = Player::getArmor(%this);

    %this.__armor = (%armor == "larmor" || %armor == "lfemale") ? "Light" : 
      (%armor == "marmor" || %armor == "mfemale") ? "Medium" : "Heavy";
  }

  //- ------------------------------------- -//
  //- Local scope: Update health and energy -//
  //- ------------------------------------- -//
  {
    %diff = GameBase::getDataName(%this).maxDamage - GameBase::getDamageLevel(%this);
    %diff = round(%diff * 100);
    %this.__health = (%this.__alive) ? %diff : 0;

    %diff = GameBase::getEnergy(%this) / GameBase::getDataName(%this).maxEnergy;
    %diff = round(%diff * 100);
    %this.__energy = (%this.__alive) ? %diff : 0;
  }
  
  //- ----------------------------------- -//
  //- Local scope: Update equipped weapon -//
  //- ----------------------------------- -//
  {
    %this.__weapon = (%this.__alive) ? 
      Player::getMountedItem(%this, $WeaponSlot) : "";
  }
    
  //- -------------------------------------------- -//
  //- Local scope: Update current weapon ammo pool -//
  //- -------------------------------------------- -//
  {
    %weapon = Player::getMountedItem(%this, $WeaponSlot);
    %ammoCount = "Infinite";

    if(%this.__alive) {

      if(%weapon) {
        %this.__ammoType = %weapon.imageType.ammoType;

        if(%this.__ammoType) {
          %ammoCount = Player::getItemCount(%this, %this.__ammoType);
        }
      }

      else {
        %this.__ammoType = "";
      }
    }

    %this.__ammo = %ammoCount;
  }
  
  //- --------------------------------- -//
  //- Local scope: Update equipped pack -//
  //- --------------------------------- -//
  {
    %this.__pack = (%this.__alive) ? 
      Player::getMountedItem(%this, $BackpackSlot) : "";
  }

  //- ------------------------------------------------------ -//
  //- Local scope: Update trigger/fire/target (TFT) statuses -//
  //- ------------------------------------------------------ -//
  {
    %previousValue = %this.__triggering;

    if(Player::isTriggered(%this, $WeaponSlot)) {
      if(%this.__alive) { 
        %this.__triggering = true;

        if(%this.__ammo == "Infinite" || %this.__ammo > 0) {
          %this.__firing = true;
        }

        else {
          %this.__firing = false;
        }
      }

      else {
        %this.__firing = false;
        %this.__targeting = "";
        %this.__triggering = false;
      }
    }

    else {
      %this.__firing = false;
      %this.__targeting = "";
      %this.__triggering = false;
    }

    //- Run weapon synthetic activate/deactivate scripts
    //- ------------------------------------------------
    //- NOTE: This is in a weird place, but it's more performant to put this 
    //- here than it is to try and shoehorn it somewhere else in the loop
    if(%previousValue != %this.__triggering) {
      if(%this.__triggering) {
        error("triggering");

        if(isFunction(%this.__weapon @ "::onSynActivate")) {
          error("schedule syn activate");

          schedule(%this.__weapon @ "::onSynActivate(" @ %this @ ");", 0);
        }
      }

      else {
        if(isFunction(%this.__weapon @ "::onSynDectivate")) {
          schedule(%this.__weapon @ "::onSynDectivate(" @ %this @ ");", 0);
        }
      }
    }
  }

  //- -------------------------------------------------- -//
  //- Local scope: Update last TFT clocks and timestamps -//
  //- -------------------------------------------------- -//
  {
    %diff = 0;

    //- Triggering
    //- ----------
    //- NOTE: This is True whenever the player holds down the Fire button,
    //- regardless of whether or not their weapon is actually firing.
    {
      if(%this.__triggering) {
        %diff = %time - %this.__lastTrigger;

        if(%this.__lastTrigger == 0 || !%this.__triggering) {
          %diff = 0;
        }

        %this.__lastTrigger = %time;
        %this.__triggeringFor = %diff + %this.__triggeringFor;
        %this.__triggeringFor = toPrecision(%this.__triggeringFor, 2);
      }

      else {
        %this.__triggeringFor = 0;
      }
    }

    //- Firing
    //- ------
    //- NOTE: This is True whenever the player holds down the Fire button AND 
    //- their weapon is actually firing.
    {
      if(%this.__firing) {
        %diff = %time - %this.__lastFire;

        if(%this.__lastFire == 0 || !%this.__firing) {
          %diff = 0;
        }

        %this.__lastFire = %time;
        %this.__firingFor = %diff + %this.__firingFor;
        %this.__firingFor = toPrecision(%this.__firingFor, 2);
        %this.__weaponHeat = %this.__weaponHeat + 0.025 * sqrt(%this.__weaponHeat + 1);
      }

      else {
        %this.__firingFor = 0;
        %this.__weaponHeat = %this.__weaponHeat - 0.02 * sqrt(%this.__weaponHeat + 1);
      }
    
      //- Weapon Heat Clamp
      {
        %this.__weaponHeat = (%this.__weaponHeat >= 1) ? 1 : 
          (%this.__weaponHeat <= 0) ? 0 : %this.__weaponHeat;
      }
    }

    //- Targeting
    //- ---------
    //- NOTE: This works but... it's buggy because the Lightning built-in 
    //- doesn't seem to have a hookable method for ::determineTarget
    {
      if(%this.__targeting) {
        %diff = %time - %this.__lastTarget;

        if(%this.__lastTarget == 0 || !%this.__targeting) {
          %diff = 0;
        }

        %this.__lastTarget = %time;
        %this.__targetingFor = %diff + %this.__targetingFor;
        %this.__targetingFor = toPrecision(%this.__targetingFor, 2);
      }

      else {
        %this.__targetingFor = 0;
      }
    }
  }

  //- -------------------------------------- -//
  //- Local scope: Update current jet status -//
  //- -------------------------------------- -//
  {
    if(%this.__alive) {
      %diff = 0;

      %this.__jetting = Player::isJetting(%this);
      %this.__jetting = (GameBase::getEnergy(%this) > 0) ? %this.__jetting : false;
  
      if(%this.__jetting) {
        %diff = %time - %this.__lastJet;

        if(%this.__lastJet == 0 || !%this.__jetting) {
          %diff = 0;
        }

        %this.__lastJet = %time;
        %this.__jettingFor = %diff + %this.__jettingFor;
        %this.__jettingFor = toPrecision(%this.__jettingFor, 2);
      }

      else {
        %this.__jettingFor = 0;
      } 
    }

    else {
      %this.__jettingFor = 0;
    }
  }

  //- ------------------------------------------------------ -//
  //- Local scope: Update current heat factor (for missiles) -//
  //- ------------------------------------------------------ -//
  {
    //- HeatFactor 
    //- ----------
    {
      //- Adjustable heat ramps based on equipped armor! This means 
      //- that light armors will heat up faster, but also cool down 
      //- faster and heavies heat up slower, but also stay hot longer.
      //- ------------------------------------------------------------------
      //- NOTE: The heatRate, coolRate and headIndex values should probably 
      //- be moved into the armor scripts... but they're fine here, for now.

      %heatFactor = %this.__heat;

      %heatRate = (%this.__armor == "Light") ? 0.1 : 
                  (%this.__armor == "Heavy") ? 0.05 : 0.08;

      %coolRate = (%this.__armor == "Light") ? 0.08 : 
                  (%this.__armor == "Heavy") ? 0.05 : 0.06;

      %heatFactor = (%this.__jetting) ? %heatFactor + %heatRate : %heatFactor - %coolRate;
      %heatFactor = clamp(0, %heatFactor, 1);

      %this.__heat = %heatFactor;
    }

    //- Hot Checks
    //- ----------
    {
      //- Armor weight directly relates to heat retention; heavy armor triggers 
      //- turret and plasma heat checks earlier.
      %heatIndex = (%this.__armor == "Light") ? 0.80 : 
                  (%this.__armor == "Heavy") ? 0.55 : 0.067;

      %this.__hot = (%this.__heat > %heatIndex) ? true : false;

      %diff = 0;

      if(%this.__hot) {
        %diff = %time - %this.__lastHot;

        if(%this.__lastHot == 0 || !%this.__hot) {
          %diff = 0;
        }

        %this.__lastHot = %time;
        %this.__hotFor = %diff + %this.__hotFor;
      }

      else {
        %this.__hotFor = 0;
      }
    }
  }

  //- -------------------------------------------------------------- -//
  //- Local scope: Update current crouching check (for target laser) -//
  //- -------------------------------------------------------------- -//
  {
    %previousValue = %this.__crouching;
    %this.__crouching = Player::isCrouching(%this);

    if(%previousValue != %this.__crouching) {
      if(%this.__crouching) {
        if(isFunction(%this.__weapon @ "::onCrouch")) {
          schedule(%this.__weapon @ "::onCrouch(" @ %this @ ");", 0);
        }
      }

      else {
        if(isFunction(%this.__weapon @ "::onUncrouch")) {
          schedule(%this.__weapon @ "::onUncrouch(" @ %this @ ");", 0);
        }
      }
    }
  }

  //- ----------------------------------------- -//
  //- Method scope: Call method n times/second. -//
  //- ----------------------------------------- -//
  schedule("Player::__updateAttrs(" @ %this @ ");", 0.05);
}
//----------------------------------------------------------------------------//
//----------------------------------------------------------------------------//




function Player::onRemove(%this) {
	// Drop anything left at the players pos
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			// Note: Player::dropItem is not called here.
			%item = newObject("","Item",%type,1,false);
			schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);

			addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));
		}
	}
}

function Player::onNoAmmo( %player,%imageSlot,%itemType ) {
	//echo("No ammo for weapon ",%itemType.description," slot(",%imageSlot,")");
}

function Player::onKilled( %this ) {
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;
	
	if ( $AutoRespawn > 0 )
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	
	Player::setDamageFlash( %this, 0.75 );
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || ( getRandom() > "0.2" ) )
				Player::dropItem(%this,%type);
		}
	}

   if ( %cl != -1 ) {
		if(%this.vehicle != "")	{
			if(%this.driver != "") {
				%this.driver = "";
        	 	Client::setControlObject(Player::getClient(%this), %this);
        	 	Player::setMountObject(%this, -1, 0);
			} else {
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";		
		}
      schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
      Client::setOwnedObject(%cl, -1);
      Client::setControlObject(%cl, Client::getObserverCamera(%cl));
      Observer::setOrbitObject(%cl, %this, 5, 5, 5);
      schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
      %cl.observerMode = "dead";
      %cl.dieTime = getSimTime();
   }
}

function Player::onDamage( %this, %type, %value, %pos, %vec, %mom, %vertPos, %quadrant, %object ) {
	if ( !Player::isExposed(%this) )
		return;

  error(%vertPos);
  error(%quadrant);

	%damagedClient = Player::getClient(%this);
	%shooterClient = %object;
	%shooterName = Client::getName( %shooterClient );

	Player::applyImpulse(%this,%mom);

	if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) {
		if (%shooterClient != -1) {
			%curTime = getSimTime();

			if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) {
				if(%type != $MineDamageType) {
					Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
					Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
				} else {
					Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
					Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
				}

				%this.LastHarm = %shooterClient;
				%this.DamageStamp = %curTime;
			}
		}
		%friendFire = $Server::TeamDamageScale;
	}
  
  else if ( %type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient) ) {
		%friendFire = $Server::TeamDamageScale;
	}
  
  else {
		%friendFire = 1.0;	
	}

	if (!Player::isDead(%this)) {
		%armor = Player::getArmor(%this);

		//More damage applyed to head shots
		if(%vertPos == "head" && %type == $LaserDamageType) {
			if(%armor == "harmor") { 
				if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
					%value += (%value * 0.3);
				}
			} else {
				%value += (%value * 0.3);
			}
		}

		//If Shield Pack is on
		if (%type != -1 && %this.shieldStrength) {
			%energy = GameBase::getEnergy(%this);
			%strength = %this.shieldStrength;
			if (%type == $GrenadeDamageType || %type == $MortarDamageType)
				%strength *= 0.75;
			%absorb = %energy * %strength;
			if (%value < %absorb) {
				GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
				%thisPos = getBoxCenter(%this);
				%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
				GameBase::activateShield(%this,%vec,%offsetZ);
				%value = 0;
			} else {
				GameBase::setEnergy(%this,0);
				%value = %value - %absorb;
			}
		}

    else {
      if(%type == $PlasmaDamageType) {
        //- Plasma Damage now increases the heatFactor on players it hits.
        %this.__heat = clamp(0, %this.__heat + 0.1 * (%this.__heat + 1), 1);

        //- If the player is hot (__heat over 0.5), then apply extra damage 
        //- based on their heatFactor
        if(%this.__hot) {
          %damageLevel = GameBase::getDamageLevel(%this) + (%this.__heat * 0.1);

          GameBase::setDamageLevel(%this, %damageLevel);
        }
      } 
    }

		if (%value) {
			%value = $DamageScale[%armor, %type] * %value * %friendFire;
			%dlevel = GameBase::getDamageLevel(%this) + %value;
			%spillOver = %dlevel - %armor.maxDamage;
			%flash = Player::getDamageFlash(%this) + %value * 2;
			if (%flash > 0.75) 
				%flash = 0.75;
			Player::setDamageFlash(%this,%flash);
			
			if ( %shooterName != "" )
				Event::Trigger( eventServerClientDamaged, %damagedClient, %shooterClient, %type, ( %spillOver >= 0 ) ? %armor.maxDamage : %value );

			if ( %dlevel >= %armor.maxDamage )
				Client::onKilled( %damagedClient, %shooterClient, %type );
			
			// set the damage after omdamage / onkilled are called so the player object still exists
			GameBase::setDamageLevel(%this,%dlevel);

			//If player not dead then play a random hurt sound
			if(!Player::isDead(%this)) { 
				if(%damagedClient.lastDamage < getSimTime()) {
					%sound = randomItems(3,injure1,injure2,injure3);
					playVoice(%damagedClient,%sound);
					%damagedClient.lastdamage = getSimTime() + 1.5;
				}
			} else {
				if((%spillOver > 0.5 && (%type == $DiscDamageType || %type == $GrenadeDamageType || %type== $MortarDamageType|| %type == $RocketDamageType)) || (%this.__heat >= 1 && %type == $PlasmaDamageType)) {
					Player::trigger(%this, $WeaponSlot, false);
					%weaponType = Player::getMountedItem(%this,$WeaponSlot);

					if(%weaponType != -1) {
						Player::dropItem(%this,%weaponType);
          }

					Player::blowUp(%this);
				}
        
        else {
					if ((%value > 0.40 && (%type== $DiscDamageType || %type == $GrenadeDamageType || %type== $MortarDamageType || %type == $RocketDamageType )) || (Player::getLastContactCount(%this) > 6) ) {
						if(%quadrant == "front_left" || %quadrant == "front_right") 
							%curDie = $PlayerAnim::DieBlownBack;
						else
							%curDie = $PlayerAnim::DieForward;
					} else if( Player::isCrouching(%this) ) {
						%curDie = $PlayerAnim::Crouching;	
					} else if(%vertPos=="head") {
						if(%quadrant == "front_left" ||	%quadrant == "front_right"	) 
							%curDie = randomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
						else 
							%curDie = randomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
					} else if (%vertPos == "torso") {
						if(%quadrant == "front_left" ) 
							%curDie = randomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
						else if(%quadrant == "front_right") 
							%curDie = randomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
						else if(%quadrant == "back_left" ) 
							%curDie = randomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						else if(%quadrant == "back_right") 
							%curDie = randomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
					} else if (%vertPos == "legs") {
						if(%quadrant == "front_left" ||	%quadrant == "back_left") 
							%curDie = $PlayerAnim::DieLegLeft;
						if(%quadrant == "front_right" ||	%quadrant == "back_right") 
							%curDie = $PlayerAnim::DieLegRight;
					}
					Player::setAnimation(%this, %curDie);
				}

				if(%type == $ImpactDamageType && %object.clLastMount != "")  
					%shooterClient = %object.clLastMount;
			}
		}
	}
}

function randomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6) {
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Player::onCollision( %this, %object ) {
	if ( !Player::isDead(%this) || ( getObjectType(%object) != "Player" ) )
		return;

	// Transfer all our items to the player
	%sound = false;
	%max = getNumItems();
	for (%i = 0; %i < %max; %i = %i + 1) {
		%count = Player::getItemCount(%this,%i);
		if (%count) {
			%delta = Item::giveItem(%object,getItemData(%i),%count);
			if (%delta > 0) {
				Player::decItemCount(%this,%i,%delta);
				%sound = true;
			}
		}
	}
	if (%sound) {
		// Play pickup if we gave him anything
		playSound(SoundPickupItem,GameBase::getPosition(%this));
	}
}

function Player::getHeatFactor(%this) {
  return %this.__hot;
}

function Player::jump( %this,%mom ) {
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
      %vehicle = Player::getMountObject (%this);
		%this.lastMount = %vehicle;
		%this.newMountTime = getSimTime() + 3.0;
		Player::setMountObject(%this, %vehicle, 0);
		Player::setMountObject(%this, -1, 0);
		Player::applyImpulse(%pl,%mom);
		playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
   }
}


//----------------------------------------------------------------------------

function remoteKill(%client) {
   if(!$matchStarted)
      return;

   %player = Client::getOwnedObject(%client);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		Client::onKilled(%client,%client); // player::kill after this so we still exist for triggered events
		playNextAnim(%client);
		Player::kill(%client);
   }
}

$animNumber = 25;
function playNextAnim( %client ) {
	if($animNumber > 36) 
		$animNumber = 25;		
	Player::setAnimation( %client, $animNumber++ );
}

function Player::enterMissionArea(%this)
{
   %set = nameToID("MissionCleanup/ObjectivesSet");
	%this.outArea = "";
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "playerEnterMissionArea", %this);
}

function Player::leaveMissionArea(%this)
{
	%this.outArea=1;
	Client::sendMessage(Player::getClient(%this),1,"You have left the mission area.");
	alertPlayer(%this, 3);
}
   
function alertPlayer( %player, %count ) {
	if ( %player.outArea != 1 )
		return;

	%cl = Player::getClient( %player );
	if ( ( %cl != -1 ) && ( %count > 0 ) ) {
		Client::sendMessage( %cl, 0, "~wLeftMissionArea.wav" );
		schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",1.5,%player);
	} else {
		%set = nameToID("MissionCleanup/ObjectivesSet");
		for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
			GameBase::virtual(%obj, "playerLeaveMissionArea", %player);
	}
}
