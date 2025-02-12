//------------------------------------------------------------------------------
//-  Generate a random float within a defined range
//------------------------------------------------------------------------------
function getRangedRoundedRandom(%minValue, %maxValue, %leadingZero) {
  %randomValue = %minValue + (getRandom() * (%maxValue - %minValue));
  %randomValue = round(%randomValue);

  if(%leadingZero && String::len(%randomValue) < 2) {
    %randomValue = "0" @ %randomValue;
  }

  return %randomValue;
}