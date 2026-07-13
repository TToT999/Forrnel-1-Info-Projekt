extends Node2D


func _on_zurück_2_pressed() -> void:
	get_tree().change_scene_to_file("res://start.tscn");


func _on_track_1_pressed() -> void:
	Global.SetTracknummer(1)


func _on_track_2_pressed() -> void:
	Global.SetTracknummer(2)
