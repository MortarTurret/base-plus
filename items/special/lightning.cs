$MaxEnergy[lightning] = 11;

function Lightning::hotwireFade(%target, %shooterId) {
  %delay = 0.05;
  %shooter = Client::getOwnedObject(%shooterId);

  if(%target.hotwirable && %target.hotwired) {
    if(GameBase::isPowered(%target)) {
      %target.hotwired = false;
    }

    else {
      if(%shooter.ELFState != "firing") {
        %target.hotwired = false;
      }

      if(!%target.hotwired) {
        %className = GameBase::getDataName(%target).className;

        schedule(%className @ "::onDisabled(" @ %target @ ");", 0);
      }
    }

    schedule("Lightning::hotwireFade(" @ %target @ ", " @ %shooterId @ ");", %delay);
  }
}

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
  //- Method Vars
  %damVal = %timeSlice * %damPerSec;
  %enVal  = %timeSlice * %enDrainPerSec;
  %targetEnergy = GameBase::getEnergy(%target);
  %shooter = Client::getOwnedObject(%shooterId);
  %shooterEnergy = GameBase::getEnergy(%shooter);
  %weapon = Player::getMountedItem(%shooter, $WeaponSlot);

  if($teamplay) {
    //- Scoped vars for team modes
    %shooterArmor = false;

    if(getObjectType(%shooter) == "player") {
      %shooterArmor = Player::getArmor(%shooter);
      %shooter.ELFTarget = %target;
    }

    //- Behavior for friendly targets
    if(GameBase::getTeam(%shooter) == GameBase::getTeam(%target)) {
      //- Recharge energy of friendly players
      if(getObjectType(%target) == "player") {
        %targetArmor = Player::getArmor(%target);
        %targetMaxEnergy = $MaxEnergy[%targetArmor];

        %enVal = %timeSlice * $MaxEnergy[lightning];
        %targetEnergy = %targetEnergy + %enVal;

        if(%targetEnergy < 0) %targetEnergy = 0;
        if(%targetEnergy > %targetMaxEnergy) %targetEnergy = %targetMaxEnergy;

        GameBase::setEnergy(%target, %targetEnergy);
      }

      //- Apply 0 damage to targets so that we can leverage Lightning as a 
      //- power source via new Gamebase methods
      else {
        if(%target.hotwirable) {
          if(!GameBase::isPowered(%target)) {
            %target.hotwired = true;
            %className = GameBase::getDataName(%target).className;

            schedule(%className @ "::onEnabled(" @ %target @ ");", 0.05);
          }

          Lightning::hotwireFade(%target, %shooterId);
        }

        GameBase::applyDamage(%target, $ELFDamageType, 0, %pos, %vec, %mom, %shooterId);
      }
    }

    //- Behavior for non-friendlies (same default behavior)
    else {
      GameBase::applyDamage(%target, $ELFDamageType, %damVal, %pos, %vec, %mom, %shooterId);

      %targetEnergy = GameBase::getEnergy(%target);
      %targetEnergy = %targetEnergy - %enVal;

      if(%targetEnergy < 0) {
        %targetEnergy = 0;
      }

      GameBase::setEnergy(%target, %targetEnergy);  
    }
  }

  //- Default ELF behavior for non-team modes
  else {
    GameBase::applyDamage(%target, $ELFDamageType, %damVal, %pos, %vec, %mom, %shooterId);

    %targetEnergy = GameBase::getEnergy(%target);
    %targetEnergy = %targetEnergy - %enVal;

    if(%targetEnergy < 0) {
      %targetEnergy = 0;
    }

    GameBase::setEnergy(%target, %targetEnergy);
  } 
}