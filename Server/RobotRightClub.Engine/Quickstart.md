#Quickstart Process

## Arena setup (fixed)

* Create the board
* Add obstacles
* Add activation pads to the boards
* Add robot start pads

Send list of valid robot start pads to First Player
Wait for response... (robot + start position)


On response:
* Add robot to start position
* Send update to Second Player: new robot position, list of valid robot start pads
Wait for response... (robot + start position)

Alternate between first and second player until all robots are placed.