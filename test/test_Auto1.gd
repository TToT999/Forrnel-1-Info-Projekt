extends GutTest

var Auto1Script = load("res://Scripts/Scripts-redo/Auto1/Auto_Modell.cs")
var auto
var InputScript = load("res://Scripts/Scripts-redo/Auto1/Auto1.cs")
var input
func before_each():
	auto = Auto1Script.new()
	input = InputScript.new()

func test_turnfactor_stopped():
	auto.BerechnungTurn(Vector2(0,0), 0.1, 0)
	assert_true(auto.turnFactor == 0.0, "Turnfactor ist nicht 0 im Stillstand")


func test_turnfactor_moving():
	auto.BerechnungTurn(Vector2(100,0), 0.1, 0)
	assert_true(auto.turnFactor == 1.0, "Turnfactor ist nicht 1 in der Bewegung")


func test_braking():
	input.velocity = Vector2(80.0, 0.0)
	
	if input.velocity.length() > 0.0:
		input.velocity = input.velocity.normalized() * (input.velocity.length() - 1.7)
		
	assert_almost_eq(input.velocity.length(), 78.3, 0.01, "Bremse falsch")
