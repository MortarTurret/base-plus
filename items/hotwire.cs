$hotwireFadeTimer = 0.05;

//- New Methods
function GameBase::hotwired(%this, %state) {
  if(%state != "" && %this.hotwirable) {
    %this.hotwire = (!GameBase::isPowered(%this)) ? %state : false;

    return;
  }

  return %this.hotwire;
}

function GameBase::canHotwire(%this) {
  return %this.canhotwire;
}