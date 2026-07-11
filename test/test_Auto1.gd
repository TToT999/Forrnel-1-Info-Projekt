extends GutTest

var Auto1Script = load("res://Scripts/Controller-Scripts/Auto1.cs")
var auto

func before_each():
	auto = Auto1Script.new()


func test_turnfactor_stopped():
	auto.velocity = Vector2.ZERO
	auto.BerechnungTurn(auto.velocity, 0.1)
	assert_true(auto.turnfactor == 0.0, "Turnfactor ist nicht 0 im Stillstand")


func test_turnfactor_moving():
	auto.velocity = Vector2(0.5, 0.5) * 100.0
	auto.BerechnungTurn(auto.velocity, 0.1)
	assert_true(auto.turnfactor == 1.0, "Turnfactor ist nicht 1 in der Bewegung")


func test_braking():
	auto.velocity = Vector2(80.0, 0.0)
	
	if auto.velocity.length() > 0.0:
		auto.velocity = auto.velocity.normalized() * (auto.velocity.length() - 1.7)
		
	assert_almost_eq(auto.velocity.length(), 78.3, 0.01, "Bremse falsch")
