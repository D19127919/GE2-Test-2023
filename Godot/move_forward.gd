extends KinematicBody

export var speed = 0.1
# Called when the node enters the scene tree for the first time.
func _ready():
	
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _physics_process(delta):
	move_and_slide(global_transform.basis.z * speed)
#	pass
