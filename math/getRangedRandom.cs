//------------------------------------------------------------------------------
//-  Generate a random float within a defined range
//------------------------------------------------------------------------------
function getRangedRandom(%minValue, %maxValue) {
  %randomValue = %minValue + (getRandom() * (%maxValue - %minValue));

  return %randomValue;
}